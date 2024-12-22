using System;
using System.Collections.Generic;

namespace shapesapp.Data
{
    public partial class ShapeType
    {
        public ShapeType()
        {
            Shapes = new HashSet<Shape>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Shape> Shapes { get; set; }
    }
}
