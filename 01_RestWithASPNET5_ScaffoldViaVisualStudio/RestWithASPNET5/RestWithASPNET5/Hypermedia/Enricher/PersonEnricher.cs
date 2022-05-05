using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Data.VO;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNET5.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _lock = new object();

        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/people/v1";
            string link = GetLink(content.Id, urlHelper, path);
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.get,
                Href = link,
                Rel = RelationType.Self,
                Type = ResponseTypeFormat.DefaultGet
            });
            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        { 
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultAPI", url)).Replace("%2F", "/").ToString();
            };
            
        }
    }
}
