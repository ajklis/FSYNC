using FSYNC.Models;
using FSYNC.SqliteQueries;
using FSYNC_API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace FSYNC.Services.Implementation
{
    public class SqliteAccessService : ISqliteAccess
    {
        private readonly IConfiguration _config;
        private string _connectionString = "Data Source=#path;Version=3;";
        public SqliteAccessService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task ConfigureAsync()
        {
            // create .db file if doesnt exist
            string path = _config["FsyncPath"];
            if (_connectionString.Contains("#path"))
                _connectionString = _connectionString.Replace("#path", path + "fsync_state");
            var tempSplit = _connectionString.Split(['=', ';']);
            path = tempSplit[1];
            await Console.Out.WriteLineAsync($"sqltie path: {path}");
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            await Console.Out.WriteLineAsync($"sqltie path: {path}");
            // initialize db

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = Queries.GetCreateTableQuery();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }


        }

        /// <summary>
        /// Add record to sqlite file
        /// </summary>
        /// <param name="record">Record name to be saved in .db file. If doesn't exist, create entry</param>
        /// <returns>New name for record file, null if error while adding file</returns>
        public async Task AddRecord(Record record)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = Queries.GetRecordInsertQuery(record.RecordName, record.OriginalName);
                await Console.Out.WriteLineAsync(query);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public Task RemoveRecord(string recordName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Record>> GetRecords()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM RECORDS";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows) 
                {
                    List<Record> records = new List<Record>();
                    while (reader.Read())
                    {
                        records.Add(new Record()
                        {
                            ID = (int)(long)reader["ID"], // idc why but its long in sqlite, dont rly wanna fix it
                            RecordName = (string)reader["RecordName"],
                            OriginalName = (string)reader["OriginalName"]
                        });
                    }
                    connection.Close();
                    return records;
                }
            }
            return null;
        }

        public Task<Record> GetRecord(int id)
        {
            throw new NotImplementedException();
        }
    }
}
