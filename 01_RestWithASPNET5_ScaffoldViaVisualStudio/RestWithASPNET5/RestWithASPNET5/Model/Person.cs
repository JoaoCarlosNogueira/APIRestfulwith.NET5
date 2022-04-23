using RestWithASPNET5.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {  
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Adress { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
