using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para agregar un libro a la base de datos
        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        // Método para obtener un libro específico por su ID
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // Método para obtener todos los libros o bien si se tiene un filtro como en titulo autor
        public async Task<IEnumerable<Book>> GetAllAsync(string searchTerm)
        {
            return await _context.Books.Where(c=>c.Titulo.Contains(searchTerm) || c.Autor.Contains(searchTerm) || searchTerm==null).ToListAsync();
        }

        // Método para actualizar un libro existente en la base de datos
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        // Método para eliminar un libro específico por su ID
        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }       
    }
}
