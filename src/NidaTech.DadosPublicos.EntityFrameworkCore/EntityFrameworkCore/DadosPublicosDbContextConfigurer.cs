using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NidaTech.DadosPublicos.EntityFrameworkCore
{
    public static class DadosPublicosDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DadosPublicosDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DadosPublicosDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
