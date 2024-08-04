namespace Bosch.eCommerce.MVC.UI.DTOs.CartItemDtos
{
    public class InsertCartItemDto
    {
        public int productId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; } = 1;
        public int size { get; set; } = 7;
    }
}
