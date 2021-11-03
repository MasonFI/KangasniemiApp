using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KangasniemiApp.Model
{
    public class ChartModel
    {
        public string Title { get; set; }
        public string TitleY { get; set; }
        public string TitleX { get; set; }
        public List<string> Labels { get; set; }
        public List<List<decimal>> Values { get; set; }
    }
}
