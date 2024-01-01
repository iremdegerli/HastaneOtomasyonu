using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace HastaneOtomasyonu.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoktorApiController : ControllerBase
	{
		private readonly HastaneCS hastaneCS; 

		public DoktorApiController(HastaneCS context)
		{
			hastaneCS = context;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var doktors = hastaneCS.Doktorlars.ToList();
			return Ok(doktors);
		}

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
