using ElitaShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.Domain.Exceptions.Products
{
    public class ProductReviewNotFoundException : NotFoundException
    {
        public ProductReviewNotFoundException()
        {
            TitleMessage = "ProductReview not found !";
        }

    }
}
