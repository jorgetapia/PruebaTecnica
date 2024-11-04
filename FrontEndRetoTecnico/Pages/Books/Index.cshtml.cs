using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Application.Services;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEndRetoTecnico.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookService _bookService;

        public IndexModel(BookService bookService)
        {
            _bookService = bookService;
        }

        // Lista de libros para mostrar
        public IList<Book> Books { get; private set; }

        // Parámetros para búsqueda, filtrado y ordenamiento
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        

        public async Task OnGetAsync()
        {
            // Obtener la lista de libros aplicando búsqueda, filtrado y ordenamiento
            Books =(IList<Book>) await _bookService.GetAllBooksAsync(SearchTerm);
        }
    }
}