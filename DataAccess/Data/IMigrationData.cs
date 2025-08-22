
namespace DataAccess.Data;

public interface IMigrationData
{
    Task<int> CheckMigration(string scriptName);
    Task DeleteMigration(string scriptName);
    Task EnsureHistoryTable();
    Task InsertMigration(string scriptName);
    Task Migration_Down();
    Task Migration_Up();
}