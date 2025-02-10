using DesingPatternsV2.Models;
using DesingPatternsV2.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesingPatternsV2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _veiculoRepository.GetAll();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);

            if(veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post(Veiculo veiculo)
        {
            _veiculoRepository.Add(veiculo);

            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid? id, Veiculo veiculo)
        {
            if (id == null)
            {
                return BadRequest();
            }

            _veiculoRepository.Update(veiculo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            _veiculoRepository.Delete(veiculo);

            return NoContent();
        }
    }
}
