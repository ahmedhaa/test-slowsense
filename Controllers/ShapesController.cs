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
        public IEnumerable<ShapeDTO> GetShapes()
        {
            var shapes = _context.Shapes
                .Include(s => s.FormsType) 
                .ToList();


            var filteredShapes = shapes.Where(s =>
                s.PositionX >= 0 && s.PositionX <= 600 &&
                s.PositionY >= 0 && s.PositionY <= 800 &&
                (s.Width == null || s.PositionX + s.Width <= 600) &&
                (s.Height == null || s.PositionY + s.Height <= 800)
            ).ToList();

           
            var shapeDTOs = filteredShapes.Select(s => new ShapeDTO
            {
                Id = s.Id,
                FormsTypeId = s.FormsTypeId,
                FormsTypeName = s.FormsType.Name, // Inclure le nom du type de forme
                PositionX = s.PositionX,
                PositionY = s.PositionY,
                Width = s.Width,
                Height = s.Height,
                Text = s.Text,
                Order = s.Order
            }).ToList();

            return shapeDTOs;
        }
    }
}
