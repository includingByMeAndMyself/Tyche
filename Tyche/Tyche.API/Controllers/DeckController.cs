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
        public IActionResult Create(string suitRequest)
        {
            if (Enum.TryParse<Suit>(suitRequest, out var suit))
            {
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

            return BadRequest($"Suit can be only \"Spades\", \"Clubs\", \"Hearts\", \"Diamonds\"; But you try enter suit - \"{suitRequest}\"");
        }

        [HttpGet("{suitRequest}")]
        public ActionResult<Deck> Get(string suitRequest)
        {
            if (Enum.TryParse<Suit>(suitRequest, out var suit))
            {
                var response = _deckService.GetDeckBySuit(suit);
                return Ok(response);
            }
            return BadRequest($"Suit can be only \"Spades\", \"Clubs\", \"Hearts\", \"Diamonds\"; But you try enter suit - \"{suitRequest}\"");
        }
    }
}
