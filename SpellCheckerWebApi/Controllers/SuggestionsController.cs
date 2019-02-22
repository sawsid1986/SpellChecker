using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpellChecker.Repositories;

namespace SpellCheckerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISpellCheckerRepository _spellCheckerRepository;

        public SuggestionsController(ISpellCheckerRepository spellCheckerRepository)
        {
            _spellCheckerRepository = spellCheckerRepository;
        }

        [HttpGet("{word}")]
        public ActionResult FindSuggestions(string word)
        {
            return Ok(_spellCheckerRepository.FindWordSuggestions(word));
        }
    }
}