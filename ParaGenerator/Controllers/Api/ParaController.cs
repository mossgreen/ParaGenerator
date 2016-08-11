using ParaGenerator.Dtos;
using ParaGenerator.Models;
using System.Web.Http;

namespace ParaGenerator.Controllers.Api
{
    public class ParaController : ApiController
    {

        private ParaDBEntities db = new ParaDBEntities();



        [HttpPost]
        public IHttpActionResult Move(paraDto dto)
        {
            var paraId = dto.paraId;
            var direction = dto.direction;

            db.move(paraId, direction);

            return Ok();
        }
    }
}
