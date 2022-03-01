﻿// <auto-generated />
using System;
using CatCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatCore.Client.Migrations
{
	[DbContext(typeof(CatCoreDbContext))]
	[Migration("20220224044919_PollRoleEmotes")]
	partial class PollRoleEmotes
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

			modelBuilder.Entity("CatCore.Data.Guild", b =>
				{
					b.Property<int>("GuildId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<ulong>("DiscordId")
						.HasColumnType("INTEGER");

					b.Property<ulong>("MessageFlagChannelId")
						.HasColumnType("INTEGER");

					b.HasKey("GuildId");

					b.ToTable("Guilds");
				});

			modelBuilder.Entity("CatCore.Data.Message", b =>
				{
					b.Property<int>("MessageId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<string>("AdminMessage")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<int>("Color")
						.HasColumnType("INTEGER");

					b.Property<string>("Description")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("Footer")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("ImageUrl")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<int?>("MessageGroupId")
						.HasColumnType("INTEGER");

					b.Property<string>("Title")
						.IsRequired()
						.HasColumnType("TEXT");

					b.HasKey("MessageId");

					b.HasIndex("MessageGroupId");

					b.ToTable("Messages");
				});

			modelBuilder.Entity("CatCore.Data.MessageGroup", b =>
				{
					b.Property<int>("MessageGroupId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<bool>("IsPublic")
						.HasColumnType("INTEGER");

					b.Property<string>("Name")
						.IsRequired()
						.HasColumnType("TEXT");

					b.HasKey("MessageGroupId");

					b.ToTable("MessageGroups");
				});

			modelBuilder.Entity("CatCore.Data.Poll", b =>
				{
					b.Property<int>("PollId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<int>("Color")
						.HasColumnType("INTEGER");

					b.Property<string>("Description")
						.HasColumnType("TEXT");

					b.Property<string>("Footer")
						.HasColumnType("TEXT");

					b.Property<int>("GuildId")
						.HasColumnType("INTEGER");

					b.Property<string>("ImageUrl")
						.HasColumnType("TEXT");

					b.Property<int>("Max")
						.HasColumnType("INTEGER");

					b.Property<int>("Min")
						.HasColumnType("INTEGER");

					b.Property<string>("Title")
						.HasColumnType("TEXT");

					b.HasKey("PollId");

					b.HasIndex("GuildId");

					b.ToTable("Polls");
				});

			modelBuilder.Entity("CatCore.Data.PollRole", b =>
				{
					b.Property<int>("PollRoleId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<string>("Description")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("Emote")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<int>("PollId")
						.HasColumnType("INTEGER");

					b.Property<ulong>("RoleId")
						.HasColumnType("INTEGER");

					b.HasKey("PollRoleId");

					b.HasIndex("PollId");

					b.ToTable("PollRoles");
				});

			modelBuilder.Entity("CatCore.Data.Pronoun", b =>
				{
					b.Property<int>("PronounId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<string>("Object")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("PossessiveAdjective")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("PossessivePronoun")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("Reflexive")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<string>("Subject")
						.IsRequired()
						.HasColumnType("TEXT");

					b.Property<int?>("UserID")
						.HasColumnType("INTEGER");

					b.HasKey("PronounId");

					b.HasIndex("UserID");

					b.ToTable("Pronouns");
				});

			modelBuilder.Entity("CatCore.Data.RegexAction", b =>
				{
					b.Property<int>("RegexActionId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<string>("ActionName")
						.HasColumnType("TEXT");

					b.Property<bool>("CleanMessage")
						.HasColumnType("INTEGER");

					b.Property<int>("GuildId")
						.HasColumnType("INTEGER");

					b.Property<string>("RegexString")
						.HasColumnType("TEXT");

					b.Property<bool>("RemoveWhitespace")
						.HasColumnType("INTEGER");

					b.Property<int>("Type")
						.HasColumnType("INTEGER");

					b.Property<bool>("Valid")
						.HasColumnType("INTEGER");

					b.HasKey("RegexActionId");

					b.HasIndex("GuildId");

					b.ToTable("RegexActions");
				});

			modelBuilder.Entity("CatCore.Data.User", b =>
				{
					b.Property<int>("UserID")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<ulong>("DiscordID")
						.HasColumnType("INTEGER");

					b.Property<bool>("IsDev")
						.HasColumnType("INTEGER");

					b.HasKey("UserID");

					b.ToTable("Users");
				});

			modelBuilder.Entity("CatCore.Data.UserMessage", b =>
				{
					b.Property<int>("UserMessageId")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<bool>("IsRead")
						.HasColumnType("INTEGER");

					b.Property<bool>("IsSuppressed")
						.HasColumnType("INTEGER");

					b.Property<int>("MessageId")
						.HasColumnType("INTEGER");

					b.Property<int>("UserId")
						.HasColumnType("INTEGER");

					b.HasKey("UserMessageId");

					b.HasIndex("MessageId");

					b.HasIndex("UserId");

					b.ToTable("UserMessages");
				});

			modelBuilder.Entity("MessageGroupUser", b =>
				{
					b.Property<int>("MessageGroupsMessageGroupId")
						.HasColumnType("INTEGER");

					b.Property<int>("VisiableToUserID")
						.HasColumnType("INTEGER");

					b.HasKey("MessageGroupsMessageGroupId", "VisiableToUserID");

					b.HasIndex("VisiableToUserID");

					b.ToTable("MessageGroupUser");
				});

			modelBuilder.Entity("CatCore.Data.Message", b =>
				{
					b.HasOne("CatCore.Data.MessageGroup", "MessageGroup")
						.WithMany("Messages")
						.HasForeignKey("MessageGroupId");

					b.Navigation("MessageGroup");
				});

			modelBuilder.Entity("CatCore.Data.Poll", b =>
				{
					b.HasOne("CatCore.Data.Guild", "Guild")
						.WithMany("Polls")
						.HasForeignKey("GuildId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Guild");
				});

			modelBuilder.Entity("CatCore.Data.PollRole", b =>
				{
					b.HasOne("CatCore.Data.Poll", "Poll")
						.WithMany("Roles")
						.HasForeignKey("PollId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Poll");
				});

			modelBuilder.Entity("CatCore.Data.Pronoun", b =>
				{
					b.HasOne("CatCore.Data.User", null)
						.WithMany("Pronouns")
						.HasForeignKey("UserID");
				});

			modelBuilder.Entity("CatCore.Data.RegexAction", b =>
				{
					b.HasOne("CatCore.Data.Guild", "Guild")
						.WithMany("RegexActions")
						.HasForeignKey("GuildId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Guild");
				});

			modelBuilder.Entity("CatCore.Data.UserMessage", b =>
				{
					b.HasOne("CatCore.Data.Message", "Message")
						.WithMany()
						.HasForeignKey("MessageId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("CatCore.Data.User", "User")
						.WithMany("Messages")
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Message");

					b.Navigation("User");
				});

			modelBuilder.Entity("MessageGroupUser", b =>
				{
					b.HasOne("CatCore.Data.MessageGroup", null)
						.WithMany()
						.HasForeignKey("MessageGroupsMessageGroupId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.HasOne("CatCore.Data.User", null)
						.WithMany()
						.HasForeignKey("VisiableToUserID")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("CatCore.Data.Guild", b =>
				{
					b.Navigation("Polls");

					b.Navigation("RegexActions");
				});

			modelBuilder.Entity("CatCore.Data.MessageGroup", b =>
				{
					b.Navigation("Messages");
				});

			modelBuilder.Entity("CatCore.Data.Poll", b =>
				{
					b.Navigation("Roles");
				});

			modelBuilder.Entity("CatCore.Data.User", b =>
				{
					b.Navigation("Messages");

					b.Navigation("Pronouns");
				});
#pragma warning restore 612, 618
		}
	}
}
