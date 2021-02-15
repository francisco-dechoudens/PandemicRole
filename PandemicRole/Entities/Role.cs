using System;
using SQLite;

namespace PandemicRole.Entities
{
    public class Role
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string Credits { get; set; }
    }
}
