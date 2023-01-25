using BusinessLogic.DTO_s;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAppBooks.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        /// <summary>
        /// Initializes a new instance of <see cref="BooksController"/>
        /// </summary>
        /// <param name="bookService">The book service</param>
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] BookDto book, CancellationToken cancellation)
        {
            return Ok(await _bookService.AddAsync(book, cancellation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellation)
        {
            return Ok(await _bookService.DeleteAsync(id, cancellation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] BookDto book, CancellationToken cancellation)
        {
            return Ok(await _bookService.UpdateAsync(book, cancellation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="numberOfPage"></param>
        /// <returns></returns>
        [HttpGet("getbooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBooks([FromHeader] int size, [FromHeader] int numberOfPage, CancellationToken cancellation)
        {
            return Ok(await _bookService.GetBooksByPageAsync(size, numberOfPage, cancellation));
        }
    }
}
