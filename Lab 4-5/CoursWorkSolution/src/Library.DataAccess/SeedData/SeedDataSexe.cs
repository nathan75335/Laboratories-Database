using IdentityServer4.Extensions;
using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.SeedData;

public class SeedDataSexe
{
    // private readonly BookContext _bookContext;
    // private readonly DbSet<Sexe> _sexes;
    //
    // public SeedDataSexe(BookContext bookContext)
    // {
    //     _bookContext = bookContext;
    //     _sexes = _bookContext.Set<Sexe>();
    // }
    //
    // public List<Sexe> sexes = new List<Sexe>()
    // {
    //     new Sexe()
    //     {
    //         Name = "M"
    //     },
    //     new Sexe()
    //     {
    //         Name = "F"
    //     }
    // };
    //
    // public void SeedSexes()
    // {
    //     if (_sexes.IsNullOrEmpty())
    //     {
    //         _sexes.AddRange(sexes);
    //         _bookContext.SaveChanges();
    //     }
    // }
}
