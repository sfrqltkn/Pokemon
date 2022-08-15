using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Model;
namespace PokemonReviewApp.Controllers
{
    //Postmanı rota veriyor
    [Route("api/[controller]")]
    //ApiController olduğunu belirtiyoruz
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        //mapper veri tipini döüştürmemizi sağlar
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IReviewRepository _reviewRepository;

        public PokemonController(IPokemonRepository pokemonRepository , IMapper mapper, IReviewerRepository reviewerRepository,IReviewRepository reviewRepository)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;  
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            //Pokemonları ver
            //var=değişken tanımı yaparken tür belirtmeksizin tanım yapmamızı sağlamaktadır
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }
        
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }
        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            var rating = _mapper.Map<Pokemon>(_pokemonRepository.GetPokemonRating(pokeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);


            if (!_pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(int pokeId,
            [FromQuery] int ownerId, [FromQuery] int catId,
            [FromBody] PokemonDto updatedPokemon)
        {
            if (updatedPokemon == null)
                return BadRequest(ModelState);

            if (pokeId != updatedPokemon.Id)
                return BadRequest(ModelState);

            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);

            if (!_pokemonRepository.UpdatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfAPokemon(pokeId);
            var pokemonToDelete = _pokemonRepository.GetPokemon(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_pokemonRepository.DeletePokemon(pokemonToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}

