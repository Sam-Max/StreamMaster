﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreamMaster.Infrastructure.EF;

#nullable disable

namespace StreamMaster.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("NOCASE_UTF8")
                .HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FriendlyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Xml")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.ChannelGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegexMatch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("idx_Name");

                    b.HasIndex("Name", "IsHidden")
                        .HasDatabaseName("idx_Name_IsHidden");

                    b.ToTable("ChannelGroups");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.EPGFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoUpdate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChannelCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DownloadErrors")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EPGNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FileExists")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HoursToUpdate")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastDownloadAttempt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastDownloaded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("MinimumMinutesBetweenDownloads")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProgrammeCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SMFileType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("TimeShift")
                        .HasColumnType("REAL");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EPGFiles");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.M3UFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoUpdate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DownloadErrors")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FileExists")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HoursToUpdate")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastDownloadAttempt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastDownloaded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxStreamCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimumMinutesBetweenDownloads")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SMFileType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StartingChannelNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StationCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("M3UFiles");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.StreamGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoSetChannelNumbers")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StreamGroups");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.StreamGroupChannelGroup", b =>
                {
                    b.Property<int>("ChannelGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StreamGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChannelGroupId", "StreamGroupId");

                    b.HasIndex("StreamGroupId");

                    b.ToTable("StreamGroupChannelGroups");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.StreamGroupVideoStream", b =>
                {
                    b.Property<string>("ChildVideoStreamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StreamGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChildVideoStreamId", "StreamGroupId");

                    b.HasIndex("StreamGroupId");

                    b.ToTable("StreamGroupVideoStreams");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.SystemKeyValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SystemKeyValues");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.VideoStream", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("FilePosition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUserCreated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("M3UFileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("M3UFileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StreamProxyType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StreamingProxyType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TimeShift")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tvg_ID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tvg_chno")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tvg_group")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tvg_logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tvg_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Tvg_ID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("User_Tvg_chno")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User_Tvg_group")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Tvg_logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Tvg_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VideoStreamHandler")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("User_Tvg_chno")
                        .HasDatabaseName("IX_VideoStream_User_Tvg_chno");

                    b.HasIndex("User_Tvg_group")
                        .HasDatabaseName("idx_User_Tvg_group");

                    b.HasIndex("User_Tvg_name")
                        .HasDatabaseName("IX_VideoStream_User_Tvg_name");

                    b.HasIndex("User_Tvg_group", "IsHidden")
                        .HasDatabaseName("idx_User_Tvg_group_IsHidden");

                    b.ToTable("VideoStreams");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.VideoStreamLink", b =>
                {
                    b.Property<string>("ParentVideoStreamId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChildVideoStreamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParentVideoStreamId", "ChildVideoStreamId");

                    b.HasIndex("ChildVideoStreamId");

                    b.ToTable("VideoStreamLinks");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.StreamGroupChannelGroup", b =>
                {
                    b.HasOne("StreamMaster.Domain.Models.ChannelGroup", "ChannelGroup")
                        .WithMany()
                        .HasForeignKey("ChannelGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StreamMaster.Domain.Models.StreamGroup", "StreamGroup")
                        .WithMany("ChannelGroups")
                        .HasForeignKey("StreamGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChannelGroup");

                    b.Navigation("StreamGroup");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.StreamGroupVideoStream", b =>
                {
                    b.HasOne("StreamMaster.Domain.Models.VideoStream", "ChildVideoStream")
                        .WithMany("StreamGroups")
                        .HasForeignKey("ChildVideoStreamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StreamMaster.Domain.Models.StreamGroup", null)
                        .WithMany("ChildVideoStreams")
                        .HasForeignKey("StreamGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChildVideoStream");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.VideoStreamLink", b =>
                {
                    b.HasOne("StreamMaster.Domain.Models.VideoStream", "ChildVideoStream")
                        .WithMany()
                        .HasForeignKey("ChildVideoStreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StreamMaster.Domain.Models.VideoStream", "ParentVideoStream")
                        .WithMany("ChildVideoStreams")
                        .HasForeignKey("ParentVideoStreamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildVideoStream");

                    b.Navigation("ParentVideoStream");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.StreamGroup", b =>
                {
                    b.Navigation("ChannelGroups");

                    b.Navigation("ChildVideoStreams");
                });

            modelBuilder.Entity("StreamMaster.Domain.Models.VideoStream", b =>
                {
                    b.Navigation("ChildVideoStreams");

                    b.Navigation("StreamGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
