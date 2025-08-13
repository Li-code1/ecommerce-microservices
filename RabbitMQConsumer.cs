public class RabbitMQConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public RabbitMQConsumer(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare("order_created", false, false, false, null);
        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var data = JsonConvert.DeserializeObject<OrderMessage>(message);

            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
            var product = await db.Products.FindAsync(data.ProductId);
            if (product != null)
            {
                product.Quantity -= data.Quantity;
                await db.SaveChangesAsync();
            }
        };

        channel.BasicConsume("order_created", true, consumer);
        return Task.CompletedTask;
    }
}

public class OrderMessage
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}