using System.Collections.Generic;

namespace KangasniemiApp.Model.PxNet
{
    public class Response
    {
        public string Class { get; set; }
        public string Label { get; set; }
        public string Source { get; set; }
        public string Updated { get; set; }

        public List<string> Id { get; set; }
        public List<int> Size { get; set; }

        public Dictionary<string, DimensionData> Dimension { get; set; }
        public List<decimal> Value { get; set; }
        public string Role { get; set; } // ??
        public string Version { get; set; }
        public Dictionary<string, Dictionary<string, string>> Extension { get; set; }
    }
}
