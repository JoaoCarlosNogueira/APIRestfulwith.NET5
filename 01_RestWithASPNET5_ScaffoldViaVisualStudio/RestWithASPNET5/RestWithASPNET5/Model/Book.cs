using RestWithASPNET5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Model
{
    [Table("books")] 
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime Launch_date { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("price")]
        public double Price { get; set; }

    }
}
