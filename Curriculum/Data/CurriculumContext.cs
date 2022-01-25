using curriculum.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace curriculum.Data
{
    public class CurriculumContext : DbContext
    {
        public CurriculumContext(DbContextOptions<CurriculumContext> options) : base(options)
        {
        }

        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<UserNumber> UserNumbers { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<SubContent> SubContents { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Models.OtherData> OtherDatas { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<EmailConfig> EmailConfigs { get;set; }
        public DbSet<RecoverLog> RecoverLogs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocialMediaType> SocialMediaType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailConfig>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<EmailConfig>().ToTable("EmailConfig");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.id);
                entity.Property(user => user.id).ValueGeneratedNever();
                entity.HasMany(user => user.curriculums)
                .WithOne(sm => sm.user)
                .HasForeignKey(sm => sm.userId)
                .OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(user => user.emailList)
                .WithOne(em => em.user)
                .HasForeignKey(em => em.userId);
                entity.HasOne(user => user.credentials)
                .WithOne(ex => ex.user);
                entity.HasMany(user => user.phoneNumber)
                .WithOne(un => un.user)
                .HasForeignKey(un => un.userId);
            });
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Credentials>(entity =>
            {
                entity.HasKey(cred => cred.id);
                entity.Property(cred => cred.id).ValueGeneratedNever();
                entity.HasOne(cred => cred.user)
                .WithOne(sm => sm.credentials);
            });
            modelBuilder.Entity<Credentials>().ToTable("Credentials");
            modelBuilder.Entity<UserNumber>(entity =>
            {
                entity.HasKey(un => un.id);
                entity.Property(un => un.id).ValueGeneratedNever();
                entity.HasOne(un => un.phone);
            });
            modelBuilder.Entity<UserNumber>().ToTable("UserNumber");
            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasKey(pn => pn.id);
                entity.Property(pn => pn.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber");
            modelBuilder.Entity<Curriculum>(entity =>
            {
                entity.HasKey(cur => cur.id);
                entity.Property(cur => cur.id).ValueGeneratedNever();
                entity.HasOne(cur => cur.email);
                entity.HasOne(cur => cur.phoneNumber);
                entity.HasMany(cur => cur.socialMedia)
                .WithOne(sm => sm.curriculum)
                .HasForeignKey(sm => sm.curriculumId);
                entity.HasMany(cur => cur.experience)
                .WithOne(ex => ex.curriculum)
                .HasForeignKey(ex => ex.curriculumId);
                entity.HasMany(cur => cur.training)
                .WithOne(tr => tr.curriculum)
                .HasForeignKey(tr => tr.curriculumId);
                entity.HasMany(cur => cur.userLanguageList)
                .WithOne(ul => ul.curriculum)
                .HasForeignKey(ul => ul.curriculumId);
                entity.HasMany(cur => cur.otherData)
                .WithOne(ul => ul.curriculum)
                .HasForeignKey(ul => ul.curriculumId);
            });
            modelBuilder.Entity<Curriculum>().ToTable("Curriculum");
            modelBuilder.Entity<Models.OtherData>(entity =>
            {
                entity.HasKey(cur => cur.id);
                entity.Property(cur => cur.id).ValueGeneratedNever();
                entity.HasMany(cur => cur.values)
                .WithOne(sm => sm.other)
                .HasForeignKey(sm => sm.OtherDataId);
            });
            modelBuilder.Entity<Models.OtherData>().ToTable("OtherData");
            modelBuilder.Entity<Value>(entity =>
            {
                entity.HasKey(cur => cur.id);
                entity.Property(cur => cur.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<Value>().ToTable("Value");
            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasOne(ul => ul.language);
                entity.HasOne(ul => ul.level);
            });
            modelBuilder.Entity<UserLanguage>().ToTable("UserLanguage");
            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<LanguageLevel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<LanguageLevel>().ToTable("LanguageLevel");
            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasMany(exp => exp.contracts)
                .WithOne(con => con.experience)
                .HasForeignKey(con => con.experienceId);
                entity.Property(e => e.finishDate)
                .HasDefaultValue(null);
            });
            modelBuilder.Entity<Experience>().ToTable("Experience");
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasMany(con => con.proyects)
                .WithOne(pr => pr.contract)
                .HasForeignKey(pr => pr.contractId);
            });
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasMany(pr => pr.descriptionList)
                .WithOne(desc => desc.project)
                .HasForeignKey(desc => desc.proyectId);
            });
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Description>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<Description>().ToTable("Description");
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasMany(tr => tr.contents)
                .WithOne(con => con.training);
            });
            modelBuilder.Entity<Training>().ToTable("Training");
            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasMany(con => con.subContents)
                .WithOne(sub => sub.Content)
                .HasForeignKey(sub => sub.contentId);
            });
            modelBuilder.Entity<Content>().ToTable("Content");
            modelBuilder.Entity<SubContent>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<SubContent>().ToTable("SubContent");
            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<Email>().ToTable("Email");
            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasOne(e => e.type);
            });
            modelBuilder.Entity<SocialMedia>().ToTable("SocialMedia");
            modelBuilder.Entity<SocialMediaType>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
            });
            modelBuilder.Entity<SocialMediaType>().ToTable("SocialMediaType");
            modelBuilder.Entity<RecoverLog>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedNever();
                entity.HasOne(rl => rl.user);
                entity.Property(log => log.active)
                    .HasDefaultValue(true);
            });
            modelBuilder.Entity<RecoverLog>().ToTable("RecoverLog");
        }
    }
}
