using Microsoft.AspNetCore.Mvc;
using NetMin.Interfaces;
using NetMin.Models;
using NetMin.Repositories;

namespace NetMin.Controllers;

[ApiController]
[Route("databases")]
public class DatabaseController : ControllerBase
{
    private readonly ICoreDbRepository _repository;
    private readonly IDbConnectionFactory _connectionFactory;
    
    public DatabaseController(ICoreDbRepository repository, IDbConnectionFactory connectionFactory)
    {
        _repository = repository;
        _connectionFactory = connectionFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDatabases()
    {
        return Ok(await _repository.GetDatabases());
    }

    [HttpGet("{database}/tables")]
    public async Task<IActionResult> GetAllDbTables(string database)
    {
        var tables = await _repository.GetTables(database);
        return Ok(tables);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateDatabase([FromBody] DatabaseInfo database)
    {
        var cn = _connectionFactory.GetDbConnection(database.Database);
        return Ok(cn.Database);
    }

    
}