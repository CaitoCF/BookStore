namespace BookStore.Dtos.Book
{
    public class CreateBookRequestDto
    {
        public string? Name { get; set; }

        public int? AuthorId { get; set; }

        public double? Price { get; set; }
    }
}
