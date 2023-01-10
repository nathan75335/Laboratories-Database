using Lab3.DataAccessLayer.Models;
using Lab3.DataAccessLayer.Repositories;
using System.Threading.Tasks;

namespace Lab3Database
{
    public  class CachService
    {
        public static void HandleGenre(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var _genreRepository = context.RequestServices.GetRequiredService<IRepository<Genre>>();

                var genres = _genreRepository.GetAll("Genre20");

                string HtmlString = "<HTML><HEAD>" +
                    "<TITLE>Library</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8 />'" +
                    "<BODY><H1>List of Genres</H1>" +
                    "<TABLE BORDER=1>";
                HtmlString += "<TH>";
                HtmlString += "<TD>Id</TD>";
                HtmlString += "<TD>Name</TD>";
                HtmlString += "<TD>Description</TD>";
                HtmlString += "</TH>";
                
                foreach (var tank in genres)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + "</TD>";
                    HtmlString += "<TD>" + tank.Id + "</TD>";
                    HtmlString += "<TD>" + tank.Name + "</TD>";
                    HtmlString += "<TD>" + tank.Description + "</TD>";
                    HtmlString += "</TR>";
                }
                
                HtmlString += "</TABLE></BODY></HTML>";

                await context.Response.WriteAsync(HtmlString);
            });
        }

        public static void HandleEditionHouse(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var _genreRepository = context.RequestServices.GetRequiredService<IRepository<EditionHouse>>();

                var genres = _genreRepository.GetAll("EditionHouse20");

                string HtmlString = "<HTML><HEAD>" +
                    "<TITLE>Library</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8 />'" +
                    "<BODY><H1>List of Edition House</H1>" +
                    "<TABLE BORDER=1>";
                HtmlString += "<TH>";
                HtmlString += "<TD>Id</TD>";
                HtmlString += "<TD>Name</TD>";
                HtmlString += "<TD>Year</TD>";
                HtmlString += "<TD>Adress</TD>";
                HtmlString += "</TH>";
                
                foreach (var tank in genres)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + tank.Id + "</TD>";
                    HtmlString += "<TD>" + tank.Name + "</TD>";
                    HtmlString += "<TD>" + tank.EditionYear + "</TD>";
                    HtmlString += "<TD>" + tank.Adress + "</TD>";
                    HtmlString += "</TR>";
                }
                
                HtmlString += "</TABLE></BODY></HTML>";

                await context.Response.WriteAsync(HtmlString);
            });
        }
        
        public static void HandleBook(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var _bookRepository = context.RequestServices.GetRequiredService<IRepository<Book>>();
                
                var genres =  _bookRepository.GetAll("books20");

                string HtmlString = "<HTML><HEAD>" +
                                    "<TITLE>Library</TITLE></HEAD>" +
                                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8 />'" +
                                    "<BODY><H1>List of Books</H1>" +
                                    "<TABLE BORDER=1>";
                HtmlString += "<TH>";
                HtmlString += "<TD>Id</TD>";
                HtmlString += "<TD>Name</TD>";
                HtmlString += "<TD>Description</TD>";
                HtmlString += "<TD>EditionHouse</TD>";
                HtmlString += "</TH>";
                
                foreach (var tank in genres)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + tank.Id + "</TD>";
                    HtmlString += "<TD>" + tank.Name + "</TD>";
                    HtmlString += "<TD>" + tank.Genre.Name + "</TD>";
                    HtmlString += "<TD>" + tank.EditionHouse.Name + "</TD>";
                    HtmlString += "</TR>";
                }
                
                HtmlString += "</TABLE></BODY></HTML>";

                await context.Response.WriteAsync(HtmlString);
            });
        }
    }
}
