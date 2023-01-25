using Library.BusinessLogic.DTO_s;
using Library.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Api.Models;

public class BorrowModelView
{
    public List<BorrowBookDto> Books { get; set; }

    public SelectList Genres = new SelectList(new List<Genre>(), "Id", "Name");
    
    public string? Name { get; set; }
}