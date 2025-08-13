[Authorize]
[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly InventoryDbContext _context;

    public ProductsController(InventoryDbContext context) => _context = context;

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts() =>
        Ok(await _context.Products.ToListAsync());

    [HttpPut("{id}/decrease")]
    public async Task<IActionResult> DecreaseStock(int id, [FromBody] int quantity)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null || product.Quantity < quantity)
            return BadRequest("Estoque insuficiente");

        product.Quantity -= quantity;
        await _context.SaveChangesAsync();
        return Ok(product);
    }
}