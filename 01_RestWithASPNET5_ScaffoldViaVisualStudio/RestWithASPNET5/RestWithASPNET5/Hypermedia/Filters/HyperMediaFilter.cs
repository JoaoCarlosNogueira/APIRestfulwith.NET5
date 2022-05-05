using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Hypermedia.Filters
{
    public class HyperMediaFilter: ResultFilterAttribute
    {
        private readonly HyperMediaFilterOptions   _hypermediaFilterOptions;
        public HyperMediaFilter(HyperMediaFilterOptions hypermediaFilterOptions)
        {
            _hypermediaFilterOptions = hypermediaFilterOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            if(context.Result is  OkObjectResult  objectResult)
            {
                var enricher = _hypermediaFilterOptions.ContentResponseEnricherList.FirstOrDefault(x => x.CanEnrich(context));

                if (enricher != null) Task.FromResult(enricher.Enrich(context));

            };
        }
    }
}
