using BookStore.Dtos.Book;
using BookStore.Models;

namespace BookStore.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this BookModel bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Name = bookModel.Name,
                AuthorId = bookModel.AuthorId,
                Price = bookModel.Price,
            };
        }

        public static BookModel ToBookFromCreateDto(this CreateBookRequestDto bookDto)
        {
            return new BookModel
            {
                Name = bookDto.Name,
                AuthorId = bookDto.AuthorId,
                Price = bookDto.Price,
            };
        }
    }
}
