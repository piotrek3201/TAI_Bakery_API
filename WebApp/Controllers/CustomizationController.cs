using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/customization")]
    [ApiController]
    [Tags("Customization")]
    public class CustomizationController : ControllerBase
    {
        private readonly ICustomizationRepository customizationRepository;

        public CustomizationController(ICustomizationRepository customizationRepository)
        {
            this.customizationRepository = customizationRepository;
        }

        //GET: api/customization/additions/all
        [HttpGet("additions/all")]
        public async Task<ActionResult<IEnumerable<Addition>>> GetAllAdditions()
        {
            return await customizationRepository.GetAllAdditionsAsync();
        }

        //GET: api/customization/cakes/all
        [HttpGet("cakes/all")]
        public async Task<ActionResult<IEnumerable<Cake>>> GetAllCakes()
        {
            return await customizationRepository.GetAllCakesAsync();
        }

        //GET: api/customization/fillings/all
        [HttpGet("fillings/all")]
        public async Task<ActionResult<IEnumerable<Filling>>> GetAllFillings()
        {
            return await customizationRepository.GetAllFillingsAsync();
        }

        //GET: api/customization/glazes/all
        [HttpGet("glazes/all")]
        public async Task<ActionResult<IEnumerable<Glaze>>> GetAllGlazes ()
        {
            return await customizationRepository.GetAllGlazesAsync();
        }

        //GET: api/customization/sizes/all
        [HttpGet("sizes/all")]
        public async Task<ActionResult<IEnumerable<Size>>> GetAllSizes()
        {
            return await customizationRepository.GetAllSizesAsync();
        }

        //POST: api/customization/additions/add
        [HttpPost("additions/add")]
        public async Task<ActionResult> AddAddition(Addition addition)
        {
            bool createSuccesful = await customizationRepository.AddAdditionAsync(addition);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //POST: api/customization/cakes/add
        [HttpPost("cakes/add")]
        public async Task<ActionResult> AddCake(Cake cake)
        {
            bool createSuccesful = await customizationRepository.AddCakeAsync(cake);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //POST: api/customization/fillings/add
        [HttpPost("fillings/add")]
        public async Task<ActionResult> AddFilling(Filling filling)
        {
            bool createSuccesful = await customizationRepository.AddFillingAsync(filling);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //POST: api/customization/glazes/add
        [HttpPost("glazes/add")]
        public async Task<ActionResult> AddGlaze(Glaze glaze)
        {
            bool createSuccesful = await customizationRepository.AddGlazeAsync(glaze);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //POST: api/customization/sizes/add
        [HttpPost("sizes/add")]
        public async Task<ActionResult> AddSize(Size size)
        {
            bool createSuccesful = await customizationRepository.AddSizeAsync(size);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/customization/additions/update
        [HttpPut("additions/update")]
        public async Task<ActionResult> UpdateAddition(Addition addition)
        {
            bool updateSuccesful = await customizationRepository.UpdateAdditionAsync(addition);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/customization/cakes/update
        [HttpPut("cakes/update")]
        public async Task<ActionResult> UpdateCake(Cake cake)
        {
            bool updateSuccesful = await customizationRepository.UpdateCakeAsync(cake);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/customization/fillings/update
        [HttpPut("fillings/update")]
        public async Task<ActionResult> UpdateFilling(Filling filling)
        {
            bool updateSuccesful = await customizationRepository.UpdateFillingAsync(filling);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/customization/glazes/update
        [HttpPut("glazes/update")]
        public async Task<ActionResult> UpdateGlaze(Glaze glaze)
        {
            bool updateSuccesful = await customizationRepository.UpdateGlazeAsync(glaze);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/customization/sizes/update
        [HttpPut("sizes/update")]
        public async Task<ActionResult> UpdateSize(Size size)
        {
            bool updateSuccesful = await customizationRepository.UpdateSizeAsync(size);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/customization/additions/delete/{id}
        [HttpDelete("additions/delete/{id}")]
        public async Task<ActionResult> DeleteAddition(long id)
        {
            bool deleteSuccesful = await customizationRepository.DeleteAdditionAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/customization/cakes/delete/{id}
        [HttpDelete("cakes/delete/{id}")]
        public async Task<ActionResult> DeleteCake(long id)
        {
            bool deleteSuccesful = await customizationRepository.DeleteCakeAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/customization/fillings/delete/{id}
        [HttpDelete("fillings/delete/{id}")]
        public async Task<ActionResult> DeleteFilling(long id)
        {
            bool deleteSuccesful = await customizationRepository.DeleteFillingAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/customization/glazes/delete/{id}
        [HttpDelete("glazes/delete/{id}")]
        public async Task<ActionResult> DeleteGlaze(long id)
        {
            bool deleteSuccesful = await customizationRepository.DeleteGlazeAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/customization/sizes/delete/{id}
        [HttpDelete("sizes/delete/{id}")]
        public async Task<ActionResult> DeleteSize(long id)
        {
            bool deleteSuccesful = await customizationRepository.DeleteSizeAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
