﻿// <auto-generated />
using System;
using Db.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Db.Storage.MS_SQL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240529090419_Test_New")]
    partial class Test_New
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientTutor", b =>
                {
                    b.Property<Guid>("ClientsIsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TutorsIsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClientsIsnNode", "TutorsIsnNode");

                    b.HasIndex("TutorsIsnNode");

                    b.ToTable("ClientTutor");
                });

            modelBuilder.Entity("Db.Storage.Models.Center", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IsnNode");

                    b.HasIndex("Name");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("Db.Storage.Models.Client", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("IsnCenter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IsnNode");

                    b.HasIndex("IsnCenter");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Db.Storage.Models.Tutor", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IsnCenter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IsnNode");

                    b.HasIndex("IsnCenter");

                    b.ToTable("Tutor");
                });

            modelBuilder.Entity("ClientTutor", b =>
                {
                    b.HasOne("Db.Storage.Models.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsIsnNode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Storage.Models.Tutor", null)
                        .WithMany()
                        .HasForeignKey("TutorsIsnNode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Db.Storage.Models.Client", b =>
                {
                    b.HasOne("Db.Storage.Models.Center", "Center")
                        .WithMany("Clients")
                        .HasForeignKey("IsnCenter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Center");
                });

            modelBuilder.Entity("Db.Storage.Models.Tutor", b =>
                {
                    b.HasOne("Db.Storage.Models.Center", "Center")
                        .WithMany("Tutors")
                        .HasForeignKey("IsnCenter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Center");
                });

            modelBuilder.Entity("Db.Storage.Models.Center", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Tutors");
                });
#pragma warning restore 612, 618
        }
    }
}
