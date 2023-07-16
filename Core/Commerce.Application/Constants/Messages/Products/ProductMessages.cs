namespace Commerce.Application.Constants.Messages.Products
{
    public static class ProductMessages
    {
        public static string AddedProductSuccessfully()
        {
            return "Product has been successfully added!";
        }
        public static string ProductNameCanNotBeNull()
        {
            return "Product name can not be null!";
        }
        public static string ProductNameMinLength()
        {
            return "Product name must be at least 3 character!";
        }

        public static string ProductPriceCanNotBeNull()
        {
            return "Product price can not be null!";
        }

        public static string ProductPriceMinValue()
        {
            return "Product price must be greater than 0 or equal!";
        }
        
        public static string ProductStockCanNotBeNull()
        {
            return "Product stock can not be null!";
        }

        public static string ProductStockMinValue()
        {
            return "Product stock must be greater than 0 or equal!";
        }
    }
}
