[Authorize]
[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly SalesDbContext _context;
    private readonly IRabbitMQPublisher _publisher;

    public OrdersController(SalesDbContext context, IRabbitMQPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        var client = new HttpClient();
        var response = await client.GetAsync("http://inventoryservice/api/products");
        var products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
        var product = products.FirstOrDefault(p => p.Id == order.ProductId);

        if (product == null || product.Quantity < order.Quantity)
            return BadRequest("Produto indisponível");

        order.Status = "Confirmado";
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        _publisher.Publish("order_created", new { order.ProductId, order.Quantity });

        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders() =>
        Ok(await _context.Orders.ToListAsync());
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}