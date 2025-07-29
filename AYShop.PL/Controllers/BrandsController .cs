using AYShop.BLL.Services.Interface;
using AYShop.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AYShop.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

       public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var brand = _brandService.GetById(id);
            if (brand is null) return NotFound();
            return Ok(brand);
        }
        [HttpPost]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = _brandService.Create(request);
            return CreatedAtAction(nameof(Get), new { id }, new {message=request});
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var updated = _brandService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = _brandService.ToggleStatus(id);
            return updated
                ? Ok(new { message = "status toggled" })
                : NotFound(new { message = "category not found" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _brandService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }

    }
}
