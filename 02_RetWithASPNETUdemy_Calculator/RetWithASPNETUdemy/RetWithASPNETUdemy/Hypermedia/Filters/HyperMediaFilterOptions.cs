using RetWithASPNETUdemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RetWithASPNETUdemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
