using RestWithASPNET5.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Data.VO
{
   
    public class PersonVO
    {  
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
    }
}
