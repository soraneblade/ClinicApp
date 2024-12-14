using Api.Clinic.Enterprise;
using Api.Clinic.Models;
using Api.Clinic.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Clinic.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly ILogger<TreatmentController> _logger;

        public TreatmentController(ILogger<TreatmentController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<TreatmentDTO> Get()
        {
            return new TreatmentEC().Treatments;
        }

        [HttpGet("{id}")]
        public TreatmentDTO? GetById(int id)
        {
            return new TreatmentEC().GetById(id);
        }

        [HttpDelete("{id}")]

        public TreatmentDTO? Delete(int id)
        {
            return new TreatmentEC().Delete(id);
        }

       /* [HttpPost]
        public TreatmentDTO? AddOrUpdate([FromBody] TreatmentDTO? treatment)
        {
            return new TreatmentEC().AddOrUpdate(treatment);
        } */

        /*[HttpPost("Search")]
        public List<TreatmentDTO> Search([FromBody] Query q)
        {
            return new TreatmentEC().Search(q?.Content ?? string.Empty)?.ToList() ?? new List<TreatmentDTO>();
        }*/
    }
}


 