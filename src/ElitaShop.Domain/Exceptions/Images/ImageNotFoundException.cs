namespace ElitaShop.Domain.Exceptions.Images
{
    public class ImageNotFoundException : NotFoundException
    {
        public ImageNotFoundException()
        {
            this.TitleMessage = "Category not found !";
        }
    }
}
