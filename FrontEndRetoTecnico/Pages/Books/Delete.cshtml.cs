using System.Threading.Tasks;
using Library.Application.Services;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEndRetoTecnico.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly BookService _bookService;

        public DeleteModel(BookService bookService)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
