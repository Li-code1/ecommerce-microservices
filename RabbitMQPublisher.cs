[10:33, 13/08/2025] Liliane: public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
}
[10:34, 13/08/2025] Liliane: public interface IRabbitMQPublisher
{
    void Publish(string queue, object message);
}

public class RabbitMQPublisher : IRabbitMQPublisher
{
    public void Publish(string queue, object message)
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue, false, false, false, null);
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        channel.BasicPublish("", queue, null, body);
    }
}