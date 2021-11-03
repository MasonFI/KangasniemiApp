using System.Collections.Generic;

namespace KangasniemiApp.Model.PxNet
{
    public class DimensionData
    {
        public string Label { get; set; }
        public Dictionary<string,Dictionary<string,string>> Category { get; set; }
    }
}
