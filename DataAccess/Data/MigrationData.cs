using DataAccess.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class MigrationData : IMigrationData
{
    private readonly ISqlDataAccess _db;

    public MigrationData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<int> CheckMigration(string scriptName)
    {
        var result = await _db.LoadData<int, dynamic>("spMigration_Check", new { name = scriptName });
        return result.FirstOrDefault();
    }

    public Task DeleteMigration(string scriptName) =>
        _db.SaveData("spMigration_Delete", new { name = scriptName });

    public Task EnsureHistoryTable() =>
        _db.SaveData("spMigration_EnsureHistoryTable", new { });

    public Task InsertMigration(string scriptName) =>
        _db.SaveData("spMigration_Insert", new { name = scriptName });

    public Task Migration_Up() =>
        _db.SaveData("spMigration_Up", new { });

    public Task Migration_Down() =>
        _db.SaveData("spMigration_Down", new { });
}
