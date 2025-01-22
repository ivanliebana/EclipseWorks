﻿// <auto-generated />
using System;
using EclipseWorks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20250121225400_table_taskcomment_update_oldvalue")]
    partial class table_taskcomment_update_oldvalue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Hash = "XRkjHJYxNd/WAqJUjPqRVDnRbpMsUA0WKUBSipZSMC8=",
                            IsManager = true,
                            Name = "Ivan Liebana",
                            Password = "/l09zHexixBPkhAoklwYZRr9otgGwWlYx6IarUdKM6w=",
                            RegistrationDate = new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9739)
                        },
                        new
                        {
                            Id = 2L,
                            Active = true,
                            Email = "aline@mail.com",
                            Hash = "OArMnzGPtVue/R8ov+/dfYenOspZjVvHGNatY65Ankg=",
                            IsManager = false,
                            Name = "Aline Paula",
                            Password = "rg7vK96gvxDbZojUSgsn9pFB5tgScpZXuYK/1FfM6KU=",
                            RegistrationDate = new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9840)
                        },
                        new
                        {
                            Id = 3L,
                            Active = true,
                            Email = "marialaura@mail.com",
                            Hash = "qxfJJI/2g7RPORgNwdSHumytP/Roxbw7Q8kOeOPXkjg=",
                            IsManager = false,
                            Name = "Maria Laura",
                            Password = "ERK5fFyFeMB8Zmqfg718aKhfXixEjs2nwaG+72f7yYU=",
                            RegistrationDate = new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9907)
                        },
                        new
                        {
                            Id = 4L,
                            Active = true,
                            Email = "henry@mail.com",
                            Hash = "Fk6t3GHzChsXPgfnvMwuM075pIpQDNvONI1o4+E6x8U=",
                            IsManager = false,
                            Name = "Henry",
                            Password = "LtqYyLeuqGo35nNAWpoaUm2Zf6pTf5Y8DH9gOOYYLeE=",
                            RegistrationDate = new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9956)
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
