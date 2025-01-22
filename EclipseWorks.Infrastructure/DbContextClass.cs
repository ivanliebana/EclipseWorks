using EclipseWorks.Core.Models;
using EclipseWorks.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EclipseWorks.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ChangeTracker.Entries().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added).ToList().ForEach(entry =>
            {
                Audit(entry);
            });

            return base.SaveChangesAsync(cancellationToken);
        }

        private void Audit(EntityEntry entry)
        {
            foreach (var property in entry.Properties)
            {
                var table = entry.Entity.GetType().Name.ToLower().Replace("model", "");

                var authorId = entry.Entity.GetType().GetProperty("AuthorId")?.GetValue(entry.Entity, null).ToNInt64();

                if (authorId.HasValue &&
                    authorId > 0)
                {
                    if (entry.State == EntityState.Modified && table == "task")
                    {
                        if (!property.IsModified)
                            continue;

                        var oldValue = property.OriginalValue.ToString();
                        var newValue = property.CurrentValue.ToString();

                        if (newValue != oldValue)
                        {
                            var auditEntry = new OperationLogModel
                            {
                                Table = table,
                                Column = property.Metadata.Name,
                                OldValue = oldValue,
                                NewValue = newValue,
                                Date = DateTime.Now,
                                UserId = authorId.Value
                            };

                            this.OperationLog.Add(auditEntry);
                        }
                    }
                    else if (entry.State == EntityState.Added && table == "taskcomment")
                    {
                        var newValue = property.CurrentValue.ToString();
                        var column = property.Metadata.Name.ToLower();

                        if (column != "id")
                        {
                            var auditEntry = new OperationLogModel
                            {
                                Table = table,
                                Column = column,
                                NewValue = newValue,
                                Date = DateTime.Now,
                                UserId = authorId.Value
                            };

                            this.OperationLog.Add(auditEntry);
                        }
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region USER

            var password1 = PasswordHasher.GenerateSalt();
            var hashPassword1 = PasswordHasher.HashPassword("12345678", password1);

            builder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 1,
                    Name = "Ivan Liebana",
                    Email = "ivan@mail.com",
                    Password = password1,
                    Hash = hashPassword1,
                    RegistrationDate = DateTime.Now,
                    IsManager = true,
                    Active = true
                }
            );

            var password2 = PasswordHasher.GenerateSalt();
            var hashPassword2 = PasswordHasher.HashPassword("54678123", password2);

            builder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 2,
                    Name = "Aline Paula",
                    Email = "aline@mail.com",
                    Password = password2,
                    Hash = hashPassword2,
                    RegistrationDate = DateTime.Now,
                    IsManager = false,
                    Active = true
                }
            );

            var password3 = PasswordHasher.GenerateSalt();
            var hashPassword3 = PasswordHasher.HashPassword("98765432", password3);

            builder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 3,
                    Name = "Maria Laura",
                    Email = "marialaura@mail.com",
                    Password = password3,
                    Hash = hashPassword3,
                    RegistrationDate = DateTime.Now,
                    IsManager = false,
                    Active = true
                }
            );

            var password4 = PasswordHasher.GenerateSalt();
            var hashPassword4 = PasswordHasher.HashPassword("1235478", password4);

            builder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 4,
                    Name = "Henry",
                    Email = "henry@mail.com",
                    Password = password4,
                    Hash = hashPassword4,
                    RegistrationDate = DateTime.Now,
                    IsManager = false,
                    Active = true
                }
            );

            #endregion

            base.OnModelCreating(builder);
        }

        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<OperationLogModel> OperationLog { get; set; }
        public DbSet<TaskModel> Task { get; set; }
        public DbSet<TaskCommentModel> TaskComment { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}