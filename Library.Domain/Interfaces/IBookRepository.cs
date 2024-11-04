
using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        // Método para agregar un libro
        Task AddAsync(Book book);

        // Método para obtener un libro por su ID
        Task<Book> GetByIdAsync(int id);

        // Método para obtener todos los libros
        Task<IEnumerable<Book>> GetAllAsync(string searchTerm);

        // Método para actualizar un libro existente
        Task UpdateAsync(Book book);

        // Método para eliminar un libro por su ID
        Task DeleteAsync(int id);
      
    }
}