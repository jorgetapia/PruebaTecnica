
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Método para agregar un nuevo libro
        public async Task AddBookAsync(Book book)
        {
            
            await _bookRepository.AddAsync(book);
        }

        // Método para obtener un libro por ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        // Método para obtener todos los libros
        public async Task<IEnumerable<Book>> GetAllBooksAsync(string searchTerm)
        {
            return await _bookRepository.GetAllAsync(searchTerm);
        }

        // Método para actualizar un libro existente
        public async Task UpdateBookAsync(Book book)
        {
            
            await _bookRepository.UpdateAsync(book);
        }

        // Método para eliminar un libro por ID
        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

      
       
    }
}