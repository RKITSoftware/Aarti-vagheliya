using LogLevel_Demo.Enum;
using LogLevel_Demo.Interface;
using LogLevel_Demo.Model;
using NLog;
using NLog.Config;
using NLog.Targets;
using LogLevel = NLog.LogLevel;

namespace LogLevel_Demo.BusinessLogic
{
    /// <summary>
    /// Service responsible for handling orders.
    /// </summary>
    public class BLOrderService : IOrderService
    {
        #region private member

        /// <summary>
        /// Declare instance of Logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// static list to strore data.
        /// </summary>
        private static List<ORD01> _lstOrders = new List<ORD01>();

        /// <summary>
        /// object of random
        /// </summary>
        private static Random _random = new Random();

        //private FileTarget _fileTarget = new FileTarget();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for initializing the BLOrderService.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public BLOrderService()
        {
            // Configure NLog to use a dynamic FileTarget
            ConfigureDynamicFileTarget();

            // Log a trace message indicating that the BLOrderService has been initialized
            _logger.Trace("BLOrderService initialized.");

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>List of ORD01 objects representing the orders.</returns>
        public List<ORD01> GetAllOrder()
        {
            // Trace logging when fetching all orders
            _logger.Trace("Fetching all orders.");

            return _lstOrders;
        
        }

        /// <summary>
        /// Places an order asynchronously.
        /// </summary>
        /// <param name="order">The order to be placed.</param>
        /// <returns>The ID of the placed order.</returns>
        public async Task<int> PlaceOrderAsync(ORD01 order)
        {
            // Generate a random order ID
            int orderId = GenerateRandomOrderId();

            // Perform order processing logic here
            _logger.Info($"New order placed. Order ID: {orderId}, Customer: {order.D01F02}, Pizza Type: {order.D01F03}");

            // Set the generated order ID and add the order to the list
            order.D01F01 = orderId;
            _lstOrders.Add(order);

            // Simulate order placement by returning the generated order ID
            return await Task.FromResult(orderId);
        }

        /// <summary>
        /// Updates the status of an order asynchronously.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="status">The new status of the order.</param>
        public async Task UpdateOrderStatusAsync(int orderId, enmOrderStatus status)
        {
            // Check if the order with the specified ID exists in the list
            var order = _lstOrders.FirstOrDefault(o => o.D01F01 == orderId);
           
            if (order == null)
            {
                _logger.Error($"Failed to update order status. Order with ID {orderId} not found.");
                throw new OrderNotFoundException($"Order with ID {orderId} not found.");
            }

            // Perform order status update logic here
            _logger.Debug($"Updating status of order ID {orderId} to {status}");

            // Simulate order status update
            await Task.Delay(1000); // Simulate some processing time

            _logger.Info($"Order status updated. Order ID: {orderId}, New Status: {status}");
        }

        /// <summary>
        /// Checks the status of an order asynchronously.
        /// </summary>
        /// <param name="orderId">The ID of the order to check.</param>
        /// <returns>The current status of the order.</returns>
        public async Task<enmOrderStatus> CheckOrderStatusAsync(int orderId)
        {
            // Check if the order with the specified ID exists in the list
            var order = _lstOrders.FirstOrDefault(o => o.D01F01 == orderId);
            if (order == null)
            {
                _logger.Warn($"Order with ID {orderId} not found.");
                return enmOrderStatus.None; // Return None status if the order is not found
            }

            // Perform order status check logic here
            var status = GetRandomOrderStatus();
            _logger.Trace($"Checking status of order ID {orderId}. Current Status: {status}");

            // Simulate order status retrieval
            await Task.Delay(500); // Simulate some processing time

            _logger.Info($"Order status checked. Order ID: {orderId}, Current Status: {status}");
            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// get a random order status
        /// </summary>
        /// <returns>random status from enum.</returns>
        private enmOrderStatus GetRandomOrderStatus()
        {
            // Simulate getting a random order status
            var values = System.Enum.GetValues(typeof(enmOrderStatus));
            var randomIndex = new Random().Next(values.Length);
            return (enmOrderStatus)values.GetValue(randomIndex);

        }

        /// <summary>
        ///  generate a random order ID
        /// </summary>
        /// <returns>random order ID</returns>
        private int GenerateRandomOrderId()
        {
            // Generate a random order ID
            return _random.Next(1000, 9999);
        }

        /// <summary>
        /// Configures a dynamic FileTarget for NLog.
        /// </summary>
        private void ConfigureDynamicFileTarget()
        {
            // Create a new FileTarget
            var fileTarget = new FileTarget("dynamicFileTarget")
            {
                FileName = "${basedir}/logs/Trace/dynamic-log-${shortdate}.txt", // Log file path with date-based naming
                Layout = "${longdate} | ${level:uppercase=true} | ${logger} | ${message} ${exception:format=tostring}", // Log message layout
                ArchiveFileName = "${basedir}/logs/archives/dynamic-log-{#}.txt", // Archived log file naming
                ArchiveEvery = FileArchivePeriod.Day, // Archive daily
                ArchiveNumbering = ArchiveNumberingMode.Rolling, // Rolling numbering for archived files
                MaxArchiveFiles = 7, // Keep up to 7 archived files
                EnableFileDelete = true, // Allow file deletion
            };

            // Get the current NLog configuration or create a new one if not present
            var config = LogManager.Configuration;

            // Add the FileTarget to the configuration
            config.AddTarget(fileTarget);

            // Define a rule to write logs to the FileTarget for all levels from Trace to Fatal
            var rule = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.ReconfigExistingLoggers();

            // Apply the configuration
           // LogManager.Configuration = config;
        }

        #endregion
    }
}
