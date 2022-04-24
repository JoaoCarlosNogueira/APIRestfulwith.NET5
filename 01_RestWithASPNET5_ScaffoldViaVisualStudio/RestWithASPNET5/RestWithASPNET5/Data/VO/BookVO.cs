using System;

namespace RestWithASPNET5.Data.VO
{
    public class BookVO{
     public long Id { get; set; }
        public string Author { get; set; }
        
        public DateTime Launch_date { get; set; }
       
        public string Title { get; set; }
        
        public double Price { get; set; }


    }
}
