using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shapesapp.Data;

namespace shapesapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShapesController : ControllerBase
    {
        private readonly ShapesTestContext _context;

        public ShapesController(ShapesTestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shape>>> GetShapes()
        {
            var shapes = await _context.Shapes.Include(s => s.FormsType).ToListAsync();

            var filteredShapes = shapes.Where(s =>
                s.PositionX >= 0 && s.PositionX <= 600 &&
                s.PositionY >= 0 && s.PositionY <= 800 &&
                (s.Width == null || s.PositionX + s.Width <= 600) &&
                (s.Height == null || s.PositionY + s.Height <= 800)
            ).ToList();

            return Ok(filteredShapes);
        }
    }
}
