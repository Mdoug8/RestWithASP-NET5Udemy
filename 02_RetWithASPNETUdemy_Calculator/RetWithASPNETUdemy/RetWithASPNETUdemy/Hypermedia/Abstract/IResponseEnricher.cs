using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace RetWithASPNETUdemy.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
