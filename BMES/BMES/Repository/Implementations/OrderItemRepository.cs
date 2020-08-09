using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Database;
using BMES.Models.Orders;

namespace BMES.Repository.Implementations
{
    public class OrderItemRepository:IOrderItemRepository
    {
        private BmesDbContext _context;

        public OrderItemRepository(BmesDbContext context)
        {
            _context = context;
        }

        public OrderItem FindOrderItemById(long id)
        {
            var orderitem = _context.OrderItems.Find(id);
            return orderitem;
        }

        public IEnumerable<OrderItem> FindOrderItemByOrderId(long orderId)
        {
            var orderitems = _context.OrderItems.Where(o=>o.OrderId == orderId);
            return orderitems;
        }

        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            var orderitems = _context.OrderItems;
            return orderitems;
        }

        public void SaveOrderItem(OrderItem orderitem)
        {
            _context.OrderItems.Add(orderitem);
            _context.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderitem)
        {
            _context.OrderItems.Update(orderitem);
            _context.SaveChanges();
        }

        public void DeleteOrderItem(OrderItem orderitem)
        {
            _context.OrderItems.Remove(orderitem);
            _context.SaveChanges();
        }
    }
}
