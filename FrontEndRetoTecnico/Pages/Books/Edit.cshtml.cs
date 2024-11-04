using System.Threading.Tasks;
using Library.Application.Services;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEndRetoTecnico.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly BookService _bookService;

        public EditModel(BookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _bookService.GetBookByIdAsync(id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bookService.UpdateBookAsync(Book);
            return RedirectToPage("./Index");
        }
    }
}
