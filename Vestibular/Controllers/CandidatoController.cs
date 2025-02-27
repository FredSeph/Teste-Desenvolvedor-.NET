using Microsoft.AspNetCore.Mvc;
using Vestibular.Business.Interfaces;
using Vestibular.Objects.Candidato;

namespace Vestibular.Controllers
{
    /// <summary>
    /// CRUD de Candidato
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        #region Propriedades

        public readonly IVestibularBusiness _vestibularBusiness;

        #endregion

        #region Construtores

        public CandidatoController(IVestibularBusiness vestibularBusiness)
        {
            _vestibularBusiness = vestibularBusiness;
        }

        #endregion

        #region Endpoints

        /// <summary>
        /// Lista candidatos.
        /// </summary>
        /// <returns>Objeto contendo lista e contador.</returns>
        [HttpGet]
        public ActionResult<Candidatos> GetAll()
        {
            var content = _vestibularBusiness.GetCandidatos();

            return Ok(content);
        }

        /// <summary>
        /// Retorna um candidato.
        /// </summary>
        /// <param name="id">Id do candidato.</param>
        /// <returns>Objeto Candidato.</returns>
        [HttpGet("{id}")]
        public ActionResult<Candidato> Get(int id)
        {
            var content = _vestibularBusiness.GetCandidato(id);

            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        /// <summary>
        /// Adiciona um candidato.
        /// </summary>
        /// <param name="body">Dados do candidato.</param>
        /// <returns>Id do candidato criado.</returns>
        /// <remarks>Header location.</remarks>
        [HttpPost]
        public ActionResult Post(BodyCandidato body)
        {
            if (_vestibularBusiness.ExistsCandidatoCpf(body.CPF))
            {
                return Forbid("CPF já cadastrado.");
            }

            var id = _vestibularBusiness.AddCandidato(body);

            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        /// <summary>
        /// Edita um candidato.
        /// </summary>
        /// <param name="id">Id do candidato.</param>
        /// <param name="body">Dados do candidato.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Update(int id, BodyCandidato body)
        {
            if (!_vestibularBusiness.ExistsCandidato(id))
            {
                return NotFound();
            }

            _vestibularBusiness.UpdateCandidato(id, body);

            return NoContent();
        }

        /// <summary>
        /// Deleta um candidato.
        /// </summary>
        /// <param name="id">Id do candidato.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_vestibularBusiness.ExistsCandidato(id))
            {
                return NotFound();
            }

            if (_vestibularBusiness.ExistsInscricaoCandidato(id))
            {
                return StatusCode(403, "Candidato possui uma ou mais inscrições.");
            }

            _vestibularBusiness.DeleteCandidato(id);

            return NoContent();
        }

        #endregion
    }
}
