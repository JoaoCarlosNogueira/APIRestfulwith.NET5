using RestWithASPNET5.Hypermedia;
using RestWithASPNET5.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNET5.Data.VO
{
    public class BookVO: ISupportHyperMedia{
     public long Id { get; set; }
        public string Author { get; set; }
        
        public DateTime Launch_date { get; set; }
       
        public string Title { get; set; }
        
        public double Price { get; set; }
        public List<HyperMediaLink> Links { get; set;} = new List<HyperMediaLink>();
    }
}
