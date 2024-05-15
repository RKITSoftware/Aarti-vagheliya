using LogLevel_Demo.Enum;
using LogLevel_Demo.Interface;
using LogLevel_Demo.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogLevel_Demo.Controllers
{
    /// <summary>
    /// Controller class responsible for handling order-related HTTP requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLOrderServiceController : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Declare instance of IOrderService interface
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// instance of ILogger
        /// </summary>
        private readonly ILogger<CLOrderServiceController> _logger; // Inject ILogger

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to initialize the controller with required services.
        /// </summary>
        /// <param name="orderService">The order service.</param>
        /// <param name="logger">The logger.</param>
        public CLOrderServiceController(IOrderService orderService, ILogger<CLOrderServiceController> logger)
        {
            _orderService = orderService;
            _logger = logger; // Initialize ILogger
           
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all order details.
        /// </summary>
        [HttpGet("GetAllOrderDetails")]
        public IActionResult GetAllOrderDetails()
        {
            return Ok(_orderService.GetAllOrder());
        }

        /// <summary>
        /// Places an order asynchronously.
        /// </summary>
        /// <param name="order">The order to be placed.</param>
        [HttpPost("placeOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] ORD01 order)
        {
            try
            {
                var orderId = await _orderService.PlaceOrderAsync(order);
                return Ok($"Order placed successfully. Order ID: {orderId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while placing the order: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the status of an order asynchronously.
        /// </summary>
        /// <param name="orderId">The ID of the order to update.</param>
        /// <param name="status">The new status of the order.</param>
        [HttpPut("updateOrderStatus/{orderId}/{status}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, enmOrderStatus status)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(orderId, status);
                return Ok($"Order status updated successfully. Order ID: {orderId}, New Status: {status}");
            }
            catch (OrderNotFoundException ex)
            {
                _logger.LogWarning($"Order with ID {orderId} not found.");
                return NotFound($"Order with ID {orderId} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating order status. Order ID: {orderId}");
                return StatusCode(500, $"An error occurred while updating order status: {ex.Message}");
            }    
        }

        /// <summary>
        /// Checks the status of an order asynchronously.
        /// </summary>
        /// <param name="orderId">The ID of the order to check.</param>
        [HttpGet("checkOrderStatus/{orderId}")]
        public async Task<IActionResult> CheckOrderStatus(int orderId)
        {
            try
            {
                var orderStatus = await _orderService.CheckOrderStatusAsync(orderId);
                return Ok($"Order status for Order ID {orderId}: {orderStatus}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while checking order status: {ex.Message}");
            }
        }

        #endregion
    }
}
