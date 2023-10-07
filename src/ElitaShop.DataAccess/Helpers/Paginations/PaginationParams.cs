namespace ElitaShop.DataAccess.Paginations
{
    public class PaginationParams
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PaginationParams(int pageSiza, int pageNumber)
        {
            PageSiza = pageSiza;
            PageNumber = pageNumber;
        }

        public int GetSkipCount()
        {
            return (PageNumber - 1) * PageSize;
        }
    }
}
