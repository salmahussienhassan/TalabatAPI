using Talabat.Core.Specifications;

namespace Talabat.Api.Helper
{
    public class Pagination<T>
    {
        public Pagination( int pageindex,int pagesize,int count,IReadOnlyList<T> data) 
        {
            this.PageIndex = pageindex;
            this.PageSize =pagesize;
            this.Count = count;
            this.Data = data;
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }

    }
}
