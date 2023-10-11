namespace ElitaShop.Domain.Exceptions.Images
{
    public class ImageNotFoundException : NotFoundException
    {
        public ImageNotFoundException()
        {
            this.TitleMessage = "Image not found !";
        }
    }
}
