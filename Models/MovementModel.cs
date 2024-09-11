namespace BookStore.Models
{
    public class MovementModel
    {
        public int Id { get; set; }

        public int? IdBook { get; set; } = null;

        public int? IdUser { get; set; } = null;

        public int? Quantity { get; set; } = null;

        public double? TotalPrice { get; set; } = null;

        public DateTime? Date { get; set; } = null;
    }
}
