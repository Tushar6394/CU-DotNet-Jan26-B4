using AutoMapper;
using MyWebAPI.Data;
using MyWebAPI.DTOs;
using MyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LaptopsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Laptops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaptopReadDto>>> GetLaptop()
        {
            var laptops = await _context.Laptops
                .Select(l => new LaptopReadDto
                {
                    Id = l.Id,
                    Brand = l.Brand,
                    Model = l.Model,
                    Price = l.Price
                })
                .ToListAsync();

            return laptops;
        }

        // GET: api/Laptops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaptopReadDto>> GetLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);

            if (laptop == null)
            {
                return NotFound();
            }

            return new LaptopReadDto
            {
                Id = laptop.Id,
                Brand = laptop.Brand,
                Model = laptop.Model,
                Price = laptop.Price
            };
        }

        // PUT: api/Laptops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaptop(int id, LaptopUpdateDto laptopDto)
        {
            var laptop = await _context.Laptops.FindAsync(id);

            if (laptop == null)
            {
                return NotFound();
            }

            laptop.Brand = laptopDto.Brand;
            laptop.Model = laptopDto.Model;
            laptop.Price = laptopDto.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Laptops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LaptopReadDto>> PostLaptop(LaptopCreateDto laptopDto)
        {
            var laptop = _mapper.Map<Laptop>(laptopDto);

            _context.Laptops.Add(laptop);
            await _context.SaveChangesAsync();

            var readDto = new LaptopReadDto
            {
                Id = laptop.Id,
                Brand = laptop.Brand,
                Model = laptop.Model,
                Price = laptop.Price
            };

            return CreatedAtAction("GetLaptop", new { id = laptop.Id }, readDto);
        }

        // DELETE: api/Laptops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }

            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.Id == id);
        }
    }
}