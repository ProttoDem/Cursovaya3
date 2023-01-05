﻿namespace Domain
{
    public class DB
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool isDeleted { get; set; }
    }
}