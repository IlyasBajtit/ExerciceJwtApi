using AutoMapper;
using ExerciceJwtApiPizza.Dtos;
using ExerciceJwtApiPizza.Helpers;
using ExerciceJwtApiPizza.Models;
using ExerciceJwtApiPizza.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciceJwtApiPizza.Controllers
{

    [Route("pizzas")]
    [ApiController]
    [Authorize]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository<Pizza> _repository;
        private readonly IMapper _mapper;

        public PizzaController(IRepository<Pizza> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Pizza> pizzas = await _repository.GetAll();

            IEnumerable<PizzaDTO> pizzaDTOs = _mapper.Map<IEnumerable<PizzaDTO>>(pizzas)!;



            return Ok(pizzaDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pizza = await _repository.Get(id);

            if (pizza == null)
                return NotFound(new
                {
                    Message = "There is no Pizza with this Id."
                });

            PizzaDTO pizzaDTO = _mapper.Map<PizzaDTO>(pizza)!;

            return Ok(new
            {
                Message = "Pizza found.",
                Contact = pizzaDTO
            });
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Post([FromBody] PizzaDTO pizzaDTO)
        {
            var pizza = _mapper.Map<Pizza>(pizzaDTO)!;

            var pizzaAdded = await _repository.Add(pizza);

            var pizzaAddedDTO = _mapper.Map<PizzaDTO>(pizzaAdded)!;

            if (pizzaAdded != null)
                return CreatedAtAction(nameof(GetById),
                                       new { id = pizzaAddedDTO.Id },
                                       new
                                       {
                                           Message = "Pizza Added.",
                                           Contact = pizzaAddedDTO
                                       });

            return BadRequest("Something went wrong...");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PizzaDTO pizzaDTO)
        {
            var pizzaFromDb = await _repository.Get(id);

            if (pizzaFromDb == null)
                return NotFound("There is no Pizza with this Id.");

            pizzaDTO.Id = id;

            var pizza = _mapper.Map<Pizza>(pizzaDTO)!;

            var pizzaUpdated = await _repository.Update(pizza);

            var pizzaUpdatedDTO = _mapper.Map<PizzaDTO>(pizzaUpdated);

            if (pizzaUpdated != null)
                return Ok(new
                {
                    Message = "Pizza Updated.",
                    Contact = pizzaUpdatedDTO
                });

            return BadRequest("Something went wrong...");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repository.Delete(id))
                return Ok("Pizza Deleted");

            return BadRequest("Something went wrong...");
        }

    }
}