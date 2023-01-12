namespace Domain
{
    public class DBInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}