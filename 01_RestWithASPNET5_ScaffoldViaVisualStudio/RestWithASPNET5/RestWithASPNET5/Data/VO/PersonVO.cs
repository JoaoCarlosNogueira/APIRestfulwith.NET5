using RestWithASPNET5.Hypermedia;
using RestWithASPNET5.Hypermedia.Abstract;
using RestWithASPNET5.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Data.VO
{
   
    public class PersonVO: ISupportHyperMedia
    {  
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set;} = new List<HyperMediaLink>();
    }
}
