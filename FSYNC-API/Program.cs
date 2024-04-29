using FSYNC.Services.Implementation;
using FSYNC.Models;
using Microsoft.Extensions.Configuration;

namespace FSYNC_API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            SqliteAccessService sqlite = new SqliteAccessService(config);
            await sqlite.ConfigureAsync();
            //Console.ReadKey();
            await sqlite.AddRecord(new Record("rec1", "origrec1"));
            await sqlite.AddRecord(new Record("rec2", "origrec2"));
            await sqlite.AddRecord(new Record("rec3", "origrec3"));
            var list = await sqlite.GetRecords();
            foreach(var r in list)
                await Console.Out.WriteLineAsync(r.RecordName);
        }
    }
}
