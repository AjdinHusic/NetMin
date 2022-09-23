using System.Data;

namespace NetMin.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection GetDbConnection(string? database = null);
}