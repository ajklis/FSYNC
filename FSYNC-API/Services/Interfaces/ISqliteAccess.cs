namespace FSYNC_API.Services.Interfaces
{
    internal interface ISqliteAccess
    {
        public Task<bool> AddRecord(string recordName, string path);
        public Task<bool> RemoveRecord(string recordName);
    }
}
