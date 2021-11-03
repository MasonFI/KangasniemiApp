using System.Collections.Generic;

namespace KangasniemiApp.Model.PxNet
{
    public class Request
    {
        public List<QueryItem> Query { get; set; }
        public RequestResponse Response { get; set; }
    }
}
