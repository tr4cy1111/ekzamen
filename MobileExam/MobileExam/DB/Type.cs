using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileExam.DB
{
    [Table("Types")]
    public class Type
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }  
    }
}
