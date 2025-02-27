using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vestibular.Business.Interfaces;
using Vestibular.Objects.Curso;

namespace Vestibular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        #region Propriedades

        public readonly IVestibularBusiness _vestibularBusiness;

        #endregion

        #region Construtores

        public CursoController(IVestibularBusiness vestibularBusiness)
        {
            _vestibularBusiness = vestibularBusiness;
        }

        #endregion

        #region Endpoints

        [HttpGet]
        public ActionResult<Cursos> GetAll()
        {
            var content = _vestibularBusiness.GetCursos();

            return Ok(content);
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> Get(int id)
        {
            var content = _vestibularBusiness.GetCurso(id);

            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        [HttpPost]
        public ActionResult Post(BodyCurso body)
        {
            var id = _vestibularBusiness.AddCurso(body);

            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, BodyCurso body)
        {
            if (!_vestibularBusiness.ExistsCurso(id))
            {
                return NotFound();
            }

            _vestibularBusiness.UpdateCurso(id, body);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_vestibularBusiness.ExistsCurso(id))
            {
                return NotFound();
            }

            _vestibularBusiness.DeleteCurso(id);

            return NoContent();
        }

        #endregion
    }
}