using System.Data;
using Dapper;
using Learn.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Services;

public class TestStreamRepository: ITestStreamService
{
    public string ConnectionString = null;
    
    public TestStreamRepository(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public void GetTestStream(string fileName, string fileSavePath)
    {
        TestStream testStream;

        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            testStream = dbConnection.QueryFirstOrDefault<TestStream>("SELECT * FROM TestStream WHERE FilePath = @fileName", new { fileName });
        }

        if (testStream != null && testStream.FileContent != null)
        {
            File.WriteAllBytes(fileSavePath, testStream.FileContent);
        }
    }

    public async Task AddTestStreamAsync(string filePath)
    {
        byte[] fileContent;
        
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var ms = new MemoryStream())
            {
                await fs.CopyToAsync(ms);
                fileContent = ms.ToArray();
            }
        }
        
        var testStream = new TestStream
        {
            FilePath = filePath,
            FileContent = fileContent
        };
        
        using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO TestStream (FilePath, FileContent) VALUES (@FilePath, @FileContent)";
            await dbConnection.ExecuteAsync(sql, testStream);
        }
    }
}