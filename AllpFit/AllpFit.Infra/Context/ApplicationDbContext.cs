using AllpFit.Infra.Repositories;
using AllpFit.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AllpFit.Infra.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {

        #region Schemas

        public enum Schemas
        {
            Users,
            ContractsHistory,
            Payments,
            PaymenbtsHistory,
            Log,
            Sales,
            SalesExported
        }

        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }


        #region UnitOfWork Methods

        public void Clear()
        {
            var undetachedEntriesCopy = ChangeTracker.Entries()
                                                     .Where(e => e.State != EntityState.Detached)
                                                     .ToList();

            foreach (var entry in undetachedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public void Reset()
        {
            var entries = ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToArray();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void ResetEntity<TEntity>(TEntity entity) where TEntity : class
        {
                var entityName = Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name);
                var keyValues = entityName.Select(n => entity.GetType().GetProperty(n).GetValue(entity)).ToArray();
                var entityEntry = Entry(Set<TEntity>().Find(keyValues));

                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        entityEntry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entityEntry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entityEntry.Reload();
                        break;
                }
            }

        public async Task SaveChangesAsync(bool dispatchEvents = true)
        {
            await base.SaveChangesAsync();
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Entity Properties

            #region User

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.IdUser);
                user.Property(u => u.Name).IsRequired().HasMaxLength(150);
                user.Property(u => u.Surname).IsRequired().HasMaxLength(150);
                user.Property(u => u.Email).IsRequired().HasMaxLength(200);
                user.Property(u => u.IsAdmin).IsRequired();
                user.Property(u => u.Password).IsRequired().HasMaxLength(400);
                user.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
                user.Property(u => u.IdStatus).IsRequired();
                user.Property(u => u.InsertDate).IsRequired();
                user.Property(u => u.UpdatedDate);
                user.ToTable("users", nameof(Schemas.Users).ToLower());
            });

            #endregion

            #region Contract

            modelBuilder.Entity<Contract>(contract =>
            {
                contract.HasKey(c => c.IdContract);
                contract.Property(c => c.IdContractType).IsRequired();
                contract.Property(c => c.Price).IsRequired();
                contract.Property(c => c.StartDate).IsRequired();
                contract.Property(c => c.EndDate).IsRequired();
                contract.Property(c => c.IdStatus).IsRequired();
                contract.Property(c => c.InsertDate).IsRequired();
                contract.Property(c => c.UpdatedDate);
                contract.ToTable("contracts", nameof(Schemas.Users).ToLower());
            });

            #endregion

            #endregion

            #region Entity Relations

            modelBuilder.Entity<User>()
                .HasOne(u => u.Contract)
                .WithOne(c => c.User)
                .HasForeignKey<Contract>(c => c.IdContract)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.User)
                .WithOne(u => u.Contract)
                .HasForeignKey<Contract>(c => c.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            OverrideForeignKeyNames(modelBuilder);
        }

        protected void OverrideForeignKeyNames(ModelBuilder modelBuilder) =>
            modelBuilder.Model.GetEntityTypes()
                      .ToList()
                      .ForEach(entity =>
                      {
                          if (entity.BaseType == default)
                              entity.GetForeignKeys().ToList().ForEach(fk => fk.SetAnnotation(RelationalAnnotationNames.Name, fk.GetDefaultName()));
                      });
    }
}
