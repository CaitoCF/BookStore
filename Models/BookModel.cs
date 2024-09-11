namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? IdAuthor { get; set; } = null;

        public double? Price { get; set; } = null;
    }
}
