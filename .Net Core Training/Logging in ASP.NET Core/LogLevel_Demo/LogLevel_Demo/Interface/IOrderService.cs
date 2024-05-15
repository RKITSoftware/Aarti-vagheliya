using LogLevel_Demo.Enum;
using LogLevel_Demo.Model;

namespace LogLevel_Demo.Interface
{
    /// <summary>
    /// Exception thrown when an order is not found.
    /// </summary>
    public class OrderNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public OrderNotFoundException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Interface for managing order-related operations.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Places a new order.
        /// </summary>
        /// <param name="order">The order details.</param>
        /// <returns>The ID of the newly placed order.</returns>
        Task<int> PlaceOrderAsync(ORD01 order);

        /// <summary>
        /// Updates the status of an existing order.
        /// </summary>
        /// <param name="orderId">The ID of the order to update.</param>
        /// <param name="status">The new status of the order.</param>
        Task UpdateOrderStatusAsync(int orderId, enmOrderStatus status);

        /// <summary>
        /// Checks the status of an existing order.
        /// </summary>
        /// <param name="orderId">The ID of the order to check.</param>
        /// <returns>The current status of the order.</returns>
        Task<enmOrderStatus> CheckOrderStatusAsync(int orderId);

        /// <summary>
        /// retrive list of alll Orders.
        /// </summary>
        /// <returns>return list of order</returns>
        List<ORD01> GetAllOrder();
    }
}
