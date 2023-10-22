namespace ElitaShop.Services.Interfaces.Common
{
    public interface IPaginator
    {
        public void Paginate(long itemsCount, PaginationParams @params);
    }
}
