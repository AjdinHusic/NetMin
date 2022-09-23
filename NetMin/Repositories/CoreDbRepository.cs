using NetMin.Interfaces;
using NetMin.Models;
using SqlKata.Execution;

namespace NetMin.Repositories;

public class CoreDbRepository : ICoreDbRepository
{
    private readonly QueryFactory _db;

    public CoreDbRepository(QueryFactory db)
    {
        _db = db;
    }

    public async Task<IEnumerable<DatabaseInfo>> GetDatabases()
    {
        var result = await _db.SelectAsync<DatabaseInfo>("show databases;");
        return result;
    }

    public async Task<IEnumerable<TableInfo>> GetTables(string database)
    {
        var result = await _db
            .Query("information_schema.tables")
            .Select("table_name as Table", "table_rows as RowCount")
            .Where("table_schema", database ?? _db.Connection.Database)
            .GetAsync<TableInfo>();
        return result;
    }

    public async Task<IEnumerable<dynamic>> GetRecords(string database, string table)
    {
        throw new NotImplementedException();
    }
}