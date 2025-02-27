using Microsoft.AspNetCore.Mvc;
using Vestibular.Business.Interfaces;
using Vestibular.Objects.ProcessoSeletivo;

namespace Vestibular.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessoSeletivoController : ControllerBase
{
    #region Propriedades

    public readonly IVestibularBusiness _vestibularBusiness;

    #endregion

    #region Construtores

    public ProcessoSeletivoController(IVestibularBusiness vestibularBusiness)
    {
        _vestibularBusiness = vestibularBusiness;
    }

    #endregion

    #region Endpoints

    [HttpGet]
    public ActionResult<ProcessosSeletivos> GetAll()
    {
        var content = _vestibularBusiness.GetProcessosSeletivos();

        return Ok(content);
    }

    [HttpGet("{id}")]
    public ActionResult<ProcessoSeletivo> Get(int id)
    {
        var content = _vestibularBusiness.GetProcessoSeletivo(id);

        if (content == null)
        {
            return NotFound();
        }

        return Ok(content);
    }

    [HttpPost]
    public ActionResult Post(BodyProcessoSeletivo body)
    {
        var id = _vestibularBusiness.AddProcessoSeletivo(body);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BodyProcessoSeletivo body)
    {
        if (!_vestibularBusiness.ExistsProcessoSeletivo(id))
        {
            return NotFound();
        }

        _vestibularBusiness.UpdateProcessoSeletivo(id, body);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (!_vestibularBusiness.ExistsProcessoSeletivo(id))
        {
            return NotFound();
        }

        _vestibularBusiness.DeleteProcessoSeletivo(id);

        return NoContent();
    }

    #endregion
}
