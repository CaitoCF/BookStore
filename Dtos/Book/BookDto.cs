namespace BookStore.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? AuthorId { get; set; }

        public double? Price { get; set; }
    }
}
