using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HastaneOtomasyonu.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoktorApiController : ControllerBase
	{
		private readonly HastaneCS hastaneCS; // Replace YourDbContext with your actual DbContext type

		public DoktorApiController(HastaneCS context)
		{
			hastaneCS = context;
		}

		// GET: api/<AircraftApiController>
		[HttpGet]
		public IActionResult Get()
		{
			var doktors = hastaneCS.Doktorlars.ToList();
			return Ok(doktors);
		}

		// GET api/<AircraftApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var doktor = hastaneCS.Doktorlars.Find(id);

			if (doktor == null)
			{
				return NotFound();
			}

			return Ok(doktor);
		}

		// POST api/<AircraftApiController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Doktorlar doktor)
		{
			if (ModelState.IsValid)
			{
				await hastaneCS.Doktorlars.AddAsync(doktor);
				await hastaneCS.SaveChangesAsync();

				return CreatedAtAction(nameof(Get), new { id = doktor.DoktorlarId }, doktor);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		// PUT api/<AircraftApiController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Doktorlar updatedDoktorlar)
		{
			if (id != updatedDoktorlar.DoktorlarId)
			{
				return BadRequest();
			}

			hastaneCS.Entry(updatedDoktorlar).State = EntityState.Modified;

			try
			{
				await hastaneCS.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DoktorVarmi(id))
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

		// DELETE api/<AircraftApiController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var doktor = await hastaneCS.Doktorlars.FindAsync(id);

			if (doktor == null)
			{
				return NotFound();
			}

			hastaneCS.Doktorlars.Remove(doktor);
			await hastaneCS.SaveChangesAsync();

			return NoContent();
		}

		private bool DoktorVarmi(int id)
		{
			return hastaneCS.Doktorlars.Any(e => e.DoktorlarId == id);
		}
	}
}
