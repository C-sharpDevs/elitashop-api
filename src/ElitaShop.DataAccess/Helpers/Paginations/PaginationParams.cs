namespace ElitaShop.DataAccess.Paginations
{
    public class PaginationParams
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PaginationParams(int pageNumber, int pageSize)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int GetSkipCount()
        {
            return (PageNumber - 1) * PageSize;
        }
    }
}
