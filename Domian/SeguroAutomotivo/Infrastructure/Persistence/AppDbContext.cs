using SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence;

internal sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        var applyConfigMethod = typeof(ModelBuilder)
            .GetMethods()
            .First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration) && m.GetParameters().Length == 1);

        var configTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }));

        foreach (var config in configTypes)
        {
            var configurationInstance = Activator.CreateInstance(config.ConfigType);
            var genericMethod = applyConfigMethod.MakeGenericMethod(config.EntityType);
            genericMethod.Invoke(modelBuilder, new[] { configurationInstance });
        }

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if ((item.State == EntityState.Modified || item.State == EntityState.Added)
                    && item.Properties.Any(c => c.Metadata.Name == "LasUpdatedAt"))
                    item.Property("LasUpdatedAt").CurrentValue = DateTime.UtcNow;

                if (item.State == EntityState.Added)
                    if (item.Properties.Any(c => c.Metadata.Name == "CreatedAt") && item.Property("CreatedAt").CurrentValue.GetType() != typeof(DateTime))
                        item.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            }
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
        catch (DbUpdateException)
        {
            throw new Exception();
        }
        catch (Exception)
        {
            throw;
        }
    }
}