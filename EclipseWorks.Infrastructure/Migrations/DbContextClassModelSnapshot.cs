﻿// <auto-generated />
using System;
using EclipseWorks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    [DbContext(typeof(DbContextClass))]
    partial class DbContextClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EclipseWorks.Core.Models.OperationLogModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Column")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("column");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp(6)")
                        .HasColumnName("date");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("newvalue");

                    b.Property<string>("OldValue")
                        .HasColumnType("text")
                        .HasColumnName("oldvalue");

                    b.Property<string>("Table")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("table");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("operationlog");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.ProjectModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("title");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("project");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.TaskCommentModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("authorid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)")
                        .HasColumnName("comment");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("taskid");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("taskcomment");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.TaskModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp(6)")
                        .HasColumnName("completiondate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)")
                        .HasColumnName("description");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp(6)")
                        .HasColumnName("duedate");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint")
                        .HasColumnName("projectid");

                    b.Property<short>("TaskPriorityId")
                        .HasColumnType("smallint")
                        .HasColumnName("taskpriorityid");

                    b.Property<short>("TaskStatusId")
                        .HasColumnType("smallint")
                        .HasColumnName("taskstatusid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("task");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.UserModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("hash");

                    b.Property<bool>("IsManager")
                        .HasColumnType("boolean")
                        .HasColumnName("ismanager");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("password");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp(6)")
                        .HasColumnName("registrationdate");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = true,
                            Email = "ivan@mail.com",
                            Hash = "JDMA+T2T1Bu4OfghY39Kw0vRoo273GvamX5YaM9g1LE=",
                            IsManager = true,
                            Name = "Ivan Liebana",
                            Password = "2Zhr60DG6xQdUKN+415GC5bDN3XJdUNo3RCUT2o5HpA=",
                            RegistrationDate = new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7178)
                        },
                        new
                        {
                            Id = 2L,
                            Active = true,
                            Email = "aline@mail.com",
                            Hash = "TIsFVUj+jJ4LSnjOxtwboe76jQkgIYInYXxCcEXz2Pc=",
                            IsManager = false,
                            Name = "Aline Paula",
                            Password = "KXHCEFfLxDKQXcmxmsYCQokoWUDgz7NKZQmKActufeo=",
                            RegistrationDate = new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7272)
                        },
                        new
                        {
                            Id = 3L,
                            Active = true,
                            Email = "marialaura@mail.com",
                            Hash = "M1I1SgZKaEAvQwDB90bqPaA1+JJG9rW2DWAbi64YjTw=",
                            IsManager = false,
                            Name = "Maria Laura",
                            Password = "Ff91rp9jEMCHUgtj6p5fNng5OOBguonrH4Wvtv9RA98=",
                            RegistrationDate = new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7337)
                        },
                        new
                        {
                            Id = 4L,
                            Active = true,
                            Email = "henry@mail.com",
                            Hash = "le7gU6vQPfKUPPOeqr8tg9gdG5gbW6BLR+sSwvGXiz8=",
                            IsManager = false,
                            Name = "Henry",
                            Password = "cdDGEKm5WiecCgBwn9A6DxqF1Mn5q1ghTQbt9IWe4Us=",
                            RegistrationDate = new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7385)
                        });
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.OperationLogModel", b =>
                {
                    b.HasOne("EclipseWorks.Core.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.ProjectModel", b =>
                {
                    b.HasOne("EclipseWorks.Core.Models.UserModel", "User")
                        .WithMany("Project")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.TaskCommentModel", b =>
                {
                    b.HasOne("EclipseWorks.Core.Models.TaskModel", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.TaskModel", b =>
                {
                    b.HasOne("EclipseWorks.Core.Models.ProjectModel", "Project")
                        .WithMany("Task")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.ProjectModel", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("EclipseWorks.Core.Models.UserModel", b =>
                {
                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
