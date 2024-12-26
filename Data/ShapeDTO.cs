namespace shapesapp.Data
{
    public class ShapeDTO
    {
        public Guid Id { get; set; }
        public int FormsTypeId { get; set; }
        public string FormsTypeName { get; set; } // Le nom du type de forme
        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? Text { get; set; }
        public int Order { get; set; }
    }
}
