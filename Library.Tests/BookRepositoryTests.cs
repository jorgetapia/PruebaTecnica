using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Library.Tests
{
    public class BookRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly BookRepository _repository;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Filename=:memory:") // Base de datos en memoria
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.OpenConnection(); 
            _context.Database.EnsureCreated(); 

            _repository = new BookRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldAddBookToDatabase()
        {
            // Arrange
            var newBook = new Book { Titulo = "Libro de Prueba", Autor = "Autor Prueba", Genero = "Ficción", Sinopsis="Prueba de sinopsis" };

            // Act
            await _repository.AddAsync(newBook);

            // Assert
            var result = await _context.Books.FirstOrDefaultAsync(b => b.Titulo == "Libro de Prueba");
            Assert.NotNull(result);
            Assert.Equal("Autor Prueba", result.Autor);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            // Arrange
            _context.Books.Add(new Book { Titulo = "Libro 1", Autor = "Autor 1", Genero = "Ficción",Sinopsis= "Prueba de sinopsis 1" });
            _context.Books.Add(new Book { Titulo = "Libro 2", Autor = "Autor 2", Genero = "No Ficción",Sinopsis = "Prueba de sinopsis 2" });
            await _context.SaveChangesAsync();

            // Act
            var books = await _repository.GetAllAsync("Libro");

            // Assert
            Assert.Equal(2, books.Count());
        }

        [Fact]
        public async Task SearchAsync_ShouldReturnBooksMatchingSearchTerm()
        {
            // Arrange
            _context.Books.Add(new Book { Titulo = "La Sombra del Viento", Autor = "Carlos Ruiz Zafón", Genero = "Ficción",Sinopsis="Prueba sinopsis "});
            _context.Books.Add(new Book { Titulo = "El Alquimista", Autor = "Paulo Coelho", Genero = "Ficción", Sinopsis = "Prueba sinopsis " });
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync("El Alquimista");

            // Assert
            Assert.Single(result);
            Assert.Equal("El Alquimista", result.FirstOrDefault().Titulo);
        }
    }
}
