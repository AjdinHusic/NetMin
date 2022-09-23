using NetMin.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace NetMin.Extensions;

public static class ServiceCollectionExtensions
{

    public static void ConfigureSqlKata(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(_ =>
        {
            var cf = _.GetRequiredService<IDbConnectionFactory>();
            var connection = cf.GetDbConnection();
            var compiler = new MySqlCompiler();
            var factory = new QueryFactory(connection, compiler);

            return factory;
        });
    }
}
