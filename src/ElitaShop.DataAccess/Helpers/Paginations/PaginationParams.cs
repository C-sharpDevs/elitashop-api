namespace ElitaShop.DataAccess.Paginations
{
    public class PaginationParams
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PaginationParams(int pageSize, int pageNumber)
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
