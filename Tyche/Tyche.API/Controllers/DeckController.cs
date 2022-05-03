using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tyche.API.Infrastructure;
using Tyche.API.Models;
using Tyche.Domain.Interfaces;


namespace Tyche.API.Controllers
{
    /// <summary>
    /// Controller for creating, receiving, working with a deck of cards
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;
        private readonly Automapper _automapper = new Automapper();

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        /// <summary>
        /// Create a named deck of cards
        /// </summary>
        /// <param Name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(DeckRequest request)
        {
            try
            {
                var response = await _deckService.CreateNamedDeckAsync(request.Name, request.DeckType);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Getting a deck of cards by name
        /// </summary>
        /// <param Name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<DeckResponse>>  GetDeckByName(string name)
        {

            var deck = await _deckService.GetDeckByNameAsync(name);
            if (deck != null)
            {
                var response = _automapper.MappingToDeckResponse(deck);
                return Ok(response);
            }
            else
            {
                return Ok($"Have no decks of cards {name}");
            }
        }

        /// <summary>
        /// Get a list of deck names
        /// </summary>
        /// <returns></returns>
        [HttpGet("Names/")]
        public async Task<IActionResult> GetNames()
        {
            var names = await _deckService.GetCreatedDecksNamesAsync();
            if (names.Length != 0)
                return Ok(names);
            else
                return Ok("No decks of cards");
        }

        /// <summary>
        /// Getting a all decks of cards
        /// </summary>
        /// <returns></returns>
        [HttpGet("Decks/")]
        public async Task<ActionResult<DeckResponse[]>> GetDecks()
        {
            var decks = await _deckService.GetDecksAsync();
            if (decks != null)
            {
                var response = new List<DeckResponse>();

                foreach (var deck in decks)
                {
                    response.Add(_automapper.MappingToDeckResponse(deck));
                }
                return Ok(response.ToArray());
            }
            else
                return Ok("No decks of cards");
        }

        /// <summary>
        /// Deleting a deck of cards by name
        /// </summary>
        /// <returns></returns>
        [HttpDelete("ByNames/")]
        public async Task<IActionResult> Delete(string name)
        {
            var response = await _deckService.DeleteDeckByNameAsync(name);
            return Ok(response);
        }

        /// <summary>
        /// Deleting all deck of cards
        /// </summary>
        /// <param Suit="request"></param>
        /// <returns></returns>
        [HttpDelete("Decks/")]
        public async Task<IActionResult> Delete()
        {
            var response = await _deckService.DeleteDecksAsync();
            return Ok(response);
        }

        /// <summary>
        /// Shuffle dekcs of cards in the selected way
        /// </summary>
        /// <param SortOption="request"></param>
        /// <returns></returns>
        [HttpPut("Shuffle/")]
        public async Task<IActionResult> Update(ShuffleRequest request)
        {
            var response = await _deckService.ShuffleDeckByNameAsync(request.SortOption, request.Name);
            return Ok(response);
        }
    }
}
