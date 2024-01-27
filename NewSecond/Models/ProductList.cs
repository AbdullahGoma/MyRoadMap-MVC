namespace NewFirst.Models
{
    public static class ProductList
    {
        public static List<Product> Products { get; set; }
        static ProductList()
        {
            Products = new List<Product>();
            Products.Add(new Product { ID = 1, Name = "Phone1", Price = 1000, Img = "1.jpj" });
            Products.Add(new Product { ID = 2, Name = "Phone2", Price = 1500, Img = "2.jpj" });
            Products.Add(new Product { ID = 3, Name = "Phone3", Price = 2000, Img = "3.jpj" });
        }
    }
}
