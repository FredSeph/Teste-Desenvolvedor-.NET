using Microsoft.AspNetCore.Mvc;
using Vestibular.Business.Interfaces;
using Vestibular.Objects.Inscricao;

namespace Vestibular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        #region Propriedades

        public readonly IVestibularBusiness _vestibularBusiness;

        #endregion

        #region Construtores

        public InscricaoController(IVestibularBusiness vestibularBusiness)
        {
            _vestibularBusiness = vestibularBusiness;
        }

        #endregion

        #region Endpoints

        [HttpGet]
        public ActionResult<Inscricoes> GetAll()
        {
            var content = _vestibularBusiness.GetInscricoes();

            return Ok(content);
        }

        [HttpGet("{id}")]
        public ActionResult<Inscricao> Get(int id)
        {
            var content = _vestibularBusiness.GetInscricao(id);

            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        [HttpGet("pesquisa")]
        public ActionResult<Inscricoes> Pesquisa(string cpf = null, int? idCurso = null)
        {
            var content = _vestibularBusiness.Pesquisa(cpf, idCurso);

            return Ok(content);
        }

        [HttpPost]
        public ActionResult Post(BodyInscricao body)
        {
            var id = _vestibularBusiness.AddInscricao(body);

            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, BodyInscricao body)
        {
            if (!_vestibularBusiness.ExistsInscricao(id))
            {
                return NotFound();
            }

            _vestibularBusiness.UpdateInscricao(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_vestibularBusiness.ExistsInscricao(id))
            {
                return NotFound();
            }

            _vestibularBusiness.DeleteInscricao(id);

            return NoContent();
        }

        #endregion
    }
}