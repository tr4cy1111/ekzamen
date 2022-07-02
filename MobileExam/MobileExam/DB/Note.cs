using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileExam.DB
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Unique]
        public string Login { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public int ID_Type { get; set; }


    }
}
