using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Tyche.Domain.Interfaces;
using Tyche.Domain.Models;

namespace Tyche.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Create(Suit suit)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            try
            {
                var response = _deckService.CreateNamedDeck(suit);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{DeckSuit:int}")]
        public IActionResult Get(int suit)
        {
            var response = _deckService.GetNamedDeck(suit);
            return Ok(response);
        }
    }
}
