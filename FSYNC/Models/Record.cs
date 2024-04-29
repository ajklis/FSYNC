namespace FSYNC.Models
{
    public class Record
    {
        public Record() { }
        public Record(string recordName, string originalName)
        {
            RecordName = recordName;
            OriginalName = originalName;
        }

        public int ID { get; set; }
        public string RecordName { get; set; }
        public string OriginalName { get; set; }
    }
}
