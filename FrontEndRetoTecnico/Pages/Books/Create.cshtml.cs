using System.Threading.Tasks;
using Library.Application.Services;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEndRetoTecnico.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookService _bookService;

        public CreateModel(BookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bookService.AddBookAsync(Book);
            return RedirectToPage("./Index");
        }
    }
}
