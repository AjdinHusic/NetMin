using NetMin.Models;

namespace NetMin.Interfaces;

public interface ICoreDbRepository
{
    public Task<IEnumerable<DatabaseInfo>> GetDatabases();
    public Task<IEnumerable<TableInfo>> GetTables(string database);
}