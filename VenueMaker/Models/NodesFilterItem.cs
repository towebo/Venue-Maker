using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueMaker.Models
{
    public enum NodesFilter
    {
        All,
        Active,
        Inactive
    } // enum


    public class NodesFilterItem
    {
        public NodesFilter Filter { get; set; }
        public string Name { get; set; }


    public static NodesFilterItem[] GetAll()
        {
            List<NodesFilterItem> result = new List<NodesFilterItem>();

            result.Add(new NodesFilterItem()
            {
                Filter = NodesFilter.All,
                Name = "Alla"
            });
            result.Add(new NodesFilterItem()
            {
                Filter = NodesFilter.Active,
                Name = "Aktiva"
            });
            result.Add(new NodesFilterItem()
            {
                Filter = NodesFilter.Inactive,
                Name = "Inaktiva"
            });

            return result.ToArray();
        }

    }
}
