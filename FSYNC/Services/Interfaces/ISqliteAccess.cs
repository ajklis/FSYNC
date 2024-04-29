using FSYNC.Models;

namespace FSYNC_API.Services.Interfaces
{
    internal interface ISqliteAccess
    {
        public Task ConfigureAsync();
        public Task AddRecord(Record record);
        public Task RemoveRecord(string recordName);
        public Task<List<Record>> GetRecords();
        public Task<Record> GetRecord(int id);
    }
}
