using ElitaShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.Services.Services.Products
{
    public class ProductReviewNotFoundException : NotFoundException
    {
        public ProductReviewNotFoundException() 
        {
            this.TitleMessage = "ProductReview not found !";
        }

    }
}
