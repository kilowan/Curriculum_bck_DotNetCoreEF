﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using curriculum.Data;

namespace curriculum.Migrations
{
    [DbContext(typeof(CurriculumContext))]
    partial class CurriculumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("curriculum.Data.Models.Content", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("trainingId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("trainingId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("curriculum.Data.Models.Contract", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("experienceId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("experienceId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("curriculum.Data.Models.Credentials", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("curriculum.Data.Models.Curriculum", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("emailId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("emailId");

                    b.HasIndex("phoneId");

                    b.HasIndex("userId");

                    b.ToTable("Curriculum");
                });

            modelBuilder.Entity("curriculum.Data.Models.Description", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("proyectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("proyectId");

                    b.ToTable("Description");
                });

            modelBuilder.Entity("curriculum.Data.Models.Email", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("curriculum.Data.Models.Experience", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("curriculumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("initDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("curriculumId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("curriculum.Data.Models.Language", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("levelId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("levelId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("curriculum.Data.Models.LanguageLevel", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("LanguageLevel");
                });

            modelBuilder.Entity("curriculum.Data.Models.OtherData", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("curriculumId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("curriculumId");

                    b.ToTable("OtherData");
                });

            modelBuilder.Entity("curriculum.Data.Models.PhoneNumber", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<string>("prefix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("curriculum.Data.Models.Project", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("contractId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("contractId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("curriculum.Data.Models.SocialMedia", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("curriculumId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("curriculumId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("curriculum.Data.Models.SubContent", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("contentId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("contentId");

                    b.ToTable("SubContent");
                });

            modelBuilder.Entity("curriculum.Data.Models.Training", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("curriculumId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("finishDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("graduationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("initDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("curriculumId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("curriculum.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("curriculum.Data.Models.UserLanguage", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("curriculumId")
                        .HasColumnType("int");

                    b.Property<int>("languageId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("curriculumId");

                    b.HasIndex("languageId");

                    b.ToTable("UserLanguage");
                });

            modelBuilder.Entity("curriculum.Data.Models.UserNumber", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("phoneId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("phoneId");

                    b.HasIndex("userId");

                    b.ToTable("UserNumber");
                });

            modelBuilder.Entity("curriculum.Data.Models.Value", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("OtherDataId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("OtherDataId");

                    b.ToTable("Value");
                });

            modelBuilder.Entity("curriculum.Data.Models.Content", b =>
                {
                    b.HasOne("curriculum.Data.Models.Training", "training")
                        .WithMany("contents")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("training");
                });

            modelBuilder.Entity("curriculum.Data.Models.Contract", b =>
                {
                    b.HasOne("curriculum.Data.Models.Experience", "experience")
                        .WithMany("contracts")
                        .HasForeignKey("experienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("experience");
                });

            modelBuilder.Entity("curriculum.Data.Models.Credentials", b =>
                {
                    b.HasOne("curriculum.Data.Models.User", "user")
                        .WithOne("credentials")
                        .HasForeignKey("curriculum.Data.Models.Credentials", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("curriculum.Data.Models.Curriculum", b =>
                {
                    b.HasOne("curriculum.Data.Models.Email", "email")
                        .WithMany()
                        .HasForeignKey("emailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("curriculum.Data.Models.PhoneNumber", "phoneNumber")
                        .WithMany()
                        .HasForeignKey("phoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("curriculum.Data.Models.User", "user")
                        .WithMany("curriculums")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("email");

                    b.Navigation("phoneNumber");

                    b.Navigation("user");
                });

            modelBuilder.Entity("curriculum.Data.Models.Description", b =>
                {
                    b.HasOne("curriculum.Data.Models.Project", "project")
                        .WithMany("descriptionList")
                        .HasForeignKey("proyectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");
                });

            modelBuilder.Entity("curriculum.Data.Models.Email", b =>
                {
                    b.HasOne("curriculum.Data.Models.User", "user")
                        .WithMany("emailList")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("curriculum.Data.Models.Experience", b =>
                {
                    b.HasOne("curriculum.Data.Models.Curriculum", "curriculum")
                        .WithMany("experience")
                        .HasForeignKey("curriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curriculum");
                });

            modelBuilder.Entity("curriculum.Data.Models.Language", b =>
                {
                    b.HasOne("curriculum.Data.Models.LanguageLevel", "level")
                        .WithMany()
                        .HasForeignKey("levelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("level");
                });

            modelBuilder.Entity("curriculum.Data.Models.OtherData", b =>
                {
                    b.HasOne("curriculum.Data.Models.Curriculum", "curriculum")
                        .WithMany("otherData")
                        .HasForeignKey("curriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curriculum");
                });

            modelBuilder.Entity("curriculum.Data.Models.Project", b =>
                {
                    b.HasOne("curriculum.Data.Models.Contract", "contract")
                        .WithMany("proyects")
                        .HasForeignKey("contractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contract");
                });

            modelBuilder.Entity("curriculum.Data.Models.SocialMedia", b =>
                {
                    b.HasOne("curriculum.Data.Models.Curriculum", "curriculum")
                        .WithMany("socialMedia")
                        .HasForeignKey("curriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curriculum");
                });

            modelBuilder.Entity("curriculum.Data.Models.SubContent", b =>
                {
                    b.HasOne("curriculum.Data.Models.Content", "Content")
                        .WithMany("subContents")
                        .HasForeignKey("contentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");
                });

            modelBuilder.Entity("curriculum.Data.Models.Training", b =>
                {
                    b.HasOne("curriculum.Data.Models.Curriculum", "curriculum")
                        .WithMany("training")
                        .HasForeignKey("curriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curriculum");
                });

            modelBuilder.Entity("curriculum.Data.Models.UserLanguage", b =>
                {
                    b.HasOne("curriculum.Data.Models.Curriculum", "curriculum")
                        .WithMany("userLanguageList")
                        .HasForeignKey("curriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("curriculum.Data.Models.Language", "language")
                        .WithMany()
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curriculum");

                    b.Navigation("language");
                });

            modelBuilder.Entity("curriculum.Data.Models.UserNumber", b =>
                {
                    b.HasOne("curriculum.Data.Models.PhoneNumber", "phone")
                        .WithMany()
                        .HasForeignKey("phoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("curriculum.Data.Models.User", "user")
                        .WithMany("phoneNumber")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("phone");

                    b.Navigation("user");
                });

            modelBuilder.Entity("curriculum.Data.Models.Value", b =>
                {
                    b.HasOne("curriculum.Data.Models.OtherData", "other")
                        .WithMany("values")
                        .HasForeignKey("OtherDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("other");
                });

            modelBuilder.Entity("curriculum.Data.Models.Content", b =>
                {
                    b.Navigation("subContents");
                });

            modelBuilder.Entity("curriculum.Data.Models.Contract", b =>
                {
                    b.Navigation("proyects");
                });

            modelBuilder.Entity("curriculum.Data.Models.Curriculum", b =>
                {
                    b.Navigation("experience");

                    b.Navigation("otherData");

                    b.Navigation("socialMedia");

                    b.Navigation("training");

                    b.Navigation("userLanguageList");
                });

            modelBuilder.Entity("curriculum.Data.Models.Experience", b =>
                {
                    b.Navigation("contracts");
                });

            modelBuilder.Entity("curriculum.Data.Models.OtherData", b =>
                {
                    b.Navigation("values");
                });

            modelBuilder.Entity("curriculum.Data.Models.Project", b =>
                {
                    b.Navigation("descriptionList");
                });

            modelBuilder.Entity("curriculum.Data.Models.Training", b =>
                {
                    b.Navigation("contents");
                });

            modelBuilder.Entity("curriculum.Data.Models.User", b =>
                {
                    b.Navigation("credentials");

                    b.Navigation("curriculums");

                    b.Navigation("emailList");

                    b.Navigation("phoneNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
