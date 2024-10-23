#pragma warning disable
namespace CarStore.DataAccess.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
    }
}
