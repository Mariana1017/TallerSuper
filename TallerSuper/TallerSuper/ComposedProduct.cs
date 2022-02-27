using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSuper
{
    public class ComposedProduct : Product
    {
        public ComposedProduct(List<Product> products)
        {
            Products = products;
        }

        public ComposedProduct()
        {
        }

        public float Discount { get; set; }
        public List<Product> Products { get; set; }
       

        public override decimal ValueToPay()
        {
            decimal AccumulatorProducts = 0;
            decimal DiscountProduct;

            foreach (Product product in Products)
            {
                AccumulatorProducts += product.ValueToPay();
            }
            DiscountProduct = AccumulatorProducts * (decimal)Discount;

            return AccumulatorProducts - DiscountProduct;
        }
        public override string ToString()
        {
            List<String> products1 = new List<String>();

            foreach (Product product in Products)
            {
                products1.Add(product.Description);
            }
            return $" {Id}   {Description}" +
            $"\n\tProducts...: {$"{String.Join(",", products1)}",17}" +
            $"\n\tDiscount...: {$"{Discount:P2}",17}" +
            $"\n\tValue......: {$"{ValueToPay():C2}",17}";
        }
    }
}
