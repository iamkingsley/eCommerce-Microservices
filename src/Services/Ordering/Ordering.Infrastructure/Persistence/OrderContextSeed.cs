using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {            
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                    UserName = "bernard",
                    FirstName = "Bernard",
                    LastName = "Codjoe",
                    EmailAddress = "cudjoebernard2@gmail.com",
                    AddressLine = "Accra",
                    Country = "Ghana",
                    State = "Greater Accra",
                    ZipCode = "233",
                    TotalPrice = 350,

                    CardName = "Bernard Codjoe",
                    CardNumber = "133101006546",
                    Expiration = "12/30/2026",
                    CVV = "444",
                    LastModifiedBy = "admin"
                }
            };
        }
    }
}
