
using System.Collections.Generic;

using BMES.Models.Orders;

namespace BMES.Repository
{
    public interface IOrderItemRepository
    {
        OrderItem FindOrderItemById(long id);
        IEnumerable<OrderItem> FindOrderItemByOrderId(long orderId);
        IEnumerable<OrderItem> GetAllOrderItems();
        void SaveOrderItem(OrderItem orderitem);
        void UpdateOrderItem(OrderItem orderitem);
        void DeleteOrderItem(OrderItem orderitem);
    }
}
