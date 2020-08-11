using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Repository;
using BMES.ViewModels.CheckOut;
using BMES.Models.Shared;
using BMES.Models.Address;
using BMES.Models.Customer;
using BMES.Models.Orders;
using BMES.Models.Cart;

namespace BMES.Services.Implementations
{
    public class CheckOutService:ICheckOutService
    {
        private ICustomerRepository _customerRepository;
        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;

        private ICartService _cartService;

        public CheckOutService(ICustomerRepository customerRepository,
                               IPersonRepository personRepository,
                               IAddressRepository addressRepository,
                               IOrderRepository orderRepository,
                               IOrderItemRepository orderItemRepository,
                               ICartRepository cartRepository,
                               ICartItemRepository cartItemRepository,
                               ICartService cartService)
        {
            _customerRepository = customerRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
        }

        public void ProcessCheckout(CheckoutViewModel checkoutViewModel)
        {
            var person = new Person
            {
                FirstName = checkoutViewModel.FirstName,
                MiddleName = checkoutViewModel.MiddleName,
                LastName = checkoutViewModel.LastName,
                EmailAddress = checkoutViewModel.EmailAddress,
                ModifiedDate = DateTimeOffset.Now,
                CreateDate = DateTimeOffset.Now,
                isDeleted = false
            };

            _personRepository.SavePerson(person);

            var address = new AddressModel
            {
                AddressLine1 = checkoutViewModel.AddressLine1,
                AddressLine2 = checkoutViewModel.AddressLine2,
                City = checkoutViewModel.City,
                State = checkoutViewModel.State,
                Country = checkoutViewModel.Country,
                ModifiedDate = DateTimeOffset.Now,
                CreateDate = DateTimeOffset.Now,
                ZipCode = checkoutViewModel.ZipCode
            };

            _addressRepository.SaveAddress(address);

            var customer = new CustomerModel
            {
                PersonId = person.Id,
                Person = person,
                ModifiedDate = DateTimeOffset.Now,
                CreateDate = DateTimeOffset.Now,
                isDeleted = false
            };

            _customerRepository.SaveCustomer(customer);

            var cart = _cartService.GetCart();

            if (cart != null)
            {
                var cartItems = _cartItemRepository.FindCartItemByCartId(cart.Id);
                IList<CartItem> cartItemsList = cartItems.ToArray();
                var cartTotal = _cartService.GetCartTotal();
                decimal shippingCharge = 0;
                var orderTotal = cartTotal + shippingCharge;

                var order = new Order
                {
                    OrderTotal = orderTotal,
                    OrderItemTotal = cartTotal,
                    ShippingCharge = shippingCharge,
                    AddressId = address.Id,
                    DeliveryAddress = address,
                    CustomerId = customer.Id,
                    Customer = customer,
                    ModifiedDate = DateTimeOffset.Now,
                    CreateDate = DateTimeOffset.Now,
                    OrderStatus = OrderStatus.Submitted
                };

                _orderRepository.SaveOrder(order);

                foreach (var cartItem in cartItemsList)
                {
                    var orderItem = new OrderItem
                    {
                        Quantity = cartItem.Quantity,
                        Order = order,
                        OrderId = order.Id,
                        Product = cartItem.Product,
                        ModifiedDate = DateTimeOffset.Now,
                        CreateDate = DateTimeOffset.Now,
                        ProductId = cartItem.ProductId
                    };
                   
                    _orderItemRepository.SaveOrderItem(orderItem);
                }
                order.ModifiedDate = DateTimeOffset.Now;
                _orderRepository.UpdateOrder(order);
                _cartRepository.DeleteCart(cart);
            }
        }
    }
}
