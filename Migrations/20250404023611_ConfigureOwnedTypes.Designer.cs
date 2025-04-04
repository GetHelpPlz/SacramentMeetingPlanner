﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250404023611_ConfigureOwnedTypes")]
    partial class ConfigureOwnedTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("MeetingDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Meeting", b =>
                {
                    b.OwnsMany("SacramentMeetingPlanner.Models.HymnSelection", "Hymns", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int>("MeetingId")
                                .HasColumnType("int");

                            b1.Property<string>("Purpose")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SelectedHymn")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("MeetingId");

                            b1.ToTable("HymnSelection");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");
                        });

                    b.OwnsMany("SacramentMeetingPlanner.Models.SpeakerSelection", "Speakers", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int>("MeetingId")
                                .HasColumnType("int");

                            b1.Property<string>("SelectedSpeaker")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Topic")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("MeetingId");

                            b1.ToTable("SpeakerSelection");

                            b1.WithOwner()
                                .HasForeignKey("MeetingId");
                        });

                    b.Navigation("Hymns");

                    b.Navigation("Speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
