﻿using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CatCore.Utils;
using CatCore.Client.TypeConverters;
using CatCore.Data;

namespace Client
{
	internal class CommandHandler
	{
		private readonly DiscordSocketClient _client;
		private readonly InteractionService _interactionService;
		private readonly IServiceProvider _services;
		private readonly Logger _logger;

		public event Func<LogMessage, Task> Log;

		public CommandHandler(DiscordSocketClient client, InteractionService interaction, IServiceProvider service)
		{
			_logger = new("Command Handler", LogSeverity.Debug);
			_logger.LogFired += x => Log.Invoke(x);
			_client = client;
			_interactionService = interaction;
			_services = service;
		}

		public async Task InitializeAsync()
		{
			try
			{
				await _logger.LogVerbose("Adding TypeConverters").ConfigureAwait(false);
				_interactionService.AddTypeConverter(typeof(int?), new DefaultNullableValueConverter<int>());
				_interactionService.AddGenericTypeConverter<Poll>(typeof(PollTypeConverter<>));
				await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

				_client.InteractionCreated += _handleInteraction;
				
				// TODO: post interaction cleanup and error logging.

				_interactionService.SlashCommandExecuted += _slashCommandExecuted;
			}
			catch (Exception ex)
			{
				await _logger.LogCritical("Failed to start interactions service.", ex);
			}
		}

		private async Task _slashCommandExecuted(SlashCommandInfo command, IInteractionContext context, IResult result)
		{
			if (result.IsSuccess)
			{
				await _logger.LogDebug($"Successfully executed the command {command.Name}");
			}
			else
			{
				await _interactionFailHandle(command.Name, result, context.Interaction as SocketInteraction);
			}
		}

		private async Task _interactionFailHandle(string name, IResult result, SocketInteraction interaction)
		{
			string error = $"The command {name} failed because of the {result.Error?.ToString() ?? "unknown"} error \n```\n{result?.ErrorReason}\n```";
			// interaction timed out.
			if (!interaction.IsValidToken) return;
			
			if (interaction.HasResponded)
			{
				await interaction.RespondAsync(error, ephemeral: true);
			}
			else
			{
				await interaction.FollowupAsync(error, ephemeral: true);
			}
		}

		private async Task _handleInteraction(SocketInteraction interaction)
		{
			var context = new SocketInteractionContext(_client, interaction);
			await _interactionService.ExecuteCommandAsync(context, _services);
		}
	}
}
