using TechDirect.Data;

namespace TechDirect.Services
{
    public class OrderEmailService
    {
        private readonly MailKitEmailSender _emailSender;

        public OrderEmailService(MailKitEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendOrderConfirmationAsync(string toEmail, Order order)
        {
            var subject = "Order confirmation";

            var body = $@"
                <h2>Order confirmation</h2>
                <p>Thank you for your order.</p>
                <p><strong>Order ID:</strong> {order.Id}</p>
                <p><strong>Total:</strong> {order.Total:C}</p>
                <p><strong>Status:</strong> {order.Status}</p>
            ";

            await _emailSender.SendEmailAsync(toEmail, subject, body);
        }

        public async Task SendStatusUpdateAsync(string toEmail, Order order)
        {
            var subject = $"Your order status is now {order.Status}";

            var body = $@"
                <h2>Order status updated</h2>
                <p>Your order status has changed.</p>
                <p><strong>Order ID:</strong> {order.Id}</p>
                <p><strong>New status:</strong> {order.Status}</p>
                <p><strong>Total:</strong> {order.Total:C}</p>
            ";

            await _emailSender.SendEmailAsync(toEmail, subject, body);
        }
    }
}
