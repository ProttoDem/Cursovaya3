namespace Domain
{
    public class DB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Type { get; set; }
        public bool isDeleted { get; set; }
    }
}