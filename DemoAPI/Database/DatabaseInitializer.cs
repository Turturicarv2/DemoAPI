using DbUp;

namespace DemoAPI.Database;

public class DatabaseInitializer
{
    private readonly IConfiguration _config;

    public DatabaseInitializer(IConfiguration config)
    {
        _config = config;
    }

    public async Task InitializeAsync(string connectionStringId = "Default")
    {
        EnsureDatabase.For.SqlDatabase(_config.GetConnectionString(connectionStringId));

        var upgrader = DeployChanges.To.SqlDatabase(_config.GetConnectionString(connectionStringId))
            .WithScriptsEmbeddedInAssembly(typeof(DatabaseInitializer).Assembly)
            .LogToConsole()
            .Build();

        if (upgrader.IsUpgradeRequired())
        {
            var result = upgrader.PerformUpgrade();
        }
    }
}
