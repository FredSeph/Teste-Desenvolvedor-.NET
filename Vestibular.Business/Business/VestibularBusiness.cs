using Vestibular.Business.Interfaces;
using Vestibular.Objects.Candidato;
using Vestibular.Objects.Curso;
using Vestibular.Objects.Inscricao;
using Vestibular.Objects.ProcessoSeletivo;
using Vestibular.Repository.Interfaces;

namespace Vestibular.Business.Business
{
    public class VestibularBusiness : IVestibularBusiness
    {
        #region Propriedades

        private readonly IProcessoSeletivoRepository _processoSeletivoRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IInscricaoRepository _inscricaoRepository;

        #endregion

        #region Construtores

        public VestibularBusiness(IProcessoSeletivoRepository processoSeletivoRepository,
                                  ICandidatoRepository candidatoRepository,
                                  ICursoRepository cursoRepository,
                                  IInscricaoRepository inscricaoRepository)
        {
            _processoSeletivoRepository = processoSeletivoRepository;
            _candidatoRepository = candidatoRepository;
            _cursoRepository = cursoRepository;
            _inscricaoRepository = inscricaoRepository;
        }

        #endregion

        #region Métodos Públicos

        // Processo Seletivo

        public ProcessosSeletivos GetProcessosSeletivos()
        {
            var items = new List<ProcessoSeletivo>();

            var entities = _processoSeletivoRepository.GetAll(false).ToList();

            entities.ForEach(e =>
            {
                var processo = new ProcessoSeletivo { Id = e.Id, Nome = e.Nome, DataInicio = e.DataInicio, DataTermino = e.DataTermino };

                items.Add(processo);
            });

            return new ProcessosSeletivos { Items = items };
        }

        public ProcessoSeletivo GetProcessoSeletivo(int id)
        {
            try
            {
                var entity = _processoSeletivoRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                return new ProcessoSeletivo { Id = entity.Id, Nome = entity.Nome, DataInicio = entity.DataInicio, DataTermino = entity.DataTermino };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddProcessoSeletivo(BodyProcessoSeletivo processo)
        {
            try
            {
                var entity = new Repository.Entities.ProcessoSeletivo
                {
                    Nome = processo.Nome,
                    DataInicio = processo.DataInicio,
                    DataTermino = processo.DataTermino
                };

                _processoSeletivoRepository.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProcessoSeletivo(int id, BodyProcessoSeletivo processo)
        {
            try
            {
                var entity = _processoSeletivoRepository.GetById(id);

                if (entity == null)
                {
                    return;
                }

                entity.Nome = processo.Nome;
                entity.DataInicio = processo.DataInicio;
                entity.DataTermino = processo.DataTermino;

                _processoSeletivoRepository.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProcessoSeletivo(int id)
        {
            _processoSeletivoRepository.RemoveById(id);
        }

        public bool ExistsProcessoSeletivo(int id)
        {
            return _processoSeletivoRepository.Any(e => e.Id == id);
        }

        // Candidato

        public Candidatos GetCandidatos()
        {
            var items = new List<Candidato>();

            var entities = _candidatoRepository.GetAll(false).ToList();

            entities.ForEach(e =>
            {
                var candidato = new Candidato { Id = e.Id, Nome = e.Nome, Email = e.Email, Telefone = e.Telefone, CPF = e.CPF };

                items.Add(candidato);
            });

            return new Candidatos { Items = items };
        }

        public Candidato GetCandidato(int id)
        {
            try
            {
                var entity = _candidatoRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                return new Candidato { Id = entity.Id, Nome = entity.Nome, Email = entity.Email, Telefone = entity.Telefone, CPF = entity.CPF };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddCandidato(BodyCandidato candidato)
        {
            try
            {
                var entity = new Repository.Entities.Candidato
                {
                    Nome = candidato.Nome,
                    Email = candidato.Email,
                    Telefone = candidato.Telefone,
                    CPF = candidato.CPF
                };

                _candidatoRepository.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCandidato(int id, BodyCandidato candidato)
        {
            try
            {
                var entity = _candidatoRepository.GetById(id);

                if (entity == null)
                {
                    return;
                }

                entity.Nome = candidato.Nome;
                entity.Email = candidato.Email;
                entity.Telefone = candidato.Telefone;
                entity.CPF = candidato.CPF;

                _candidatoRepository.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCandidato(int id)
        {
            _candidatoRepository.RemoveById(id);
        }

        public bool ExistsCandidato(int id)
        {
            return _candidatoRepository.Any(e => e.Id == id);
        }

        public bool ExistsCandidatoCpf(string cpf)
        {
            return _candidatoRepository.Any(e => e.CPF == cpf);
        }

        // Curso

        public Cursos GetCursos()
        {
            var items = new List<Curso>();

            var entities = _cursoRepository.GetAll(false).ToList();

            entities.ForEach(e =>
            {
                var curso = new Curso { Id = e.Id, Nome = e.Nome, Descricao = e.Descricao, VagasDisponiveis = e.VagasDisponiveis };

                items.Add(curso);
            });

            return new Cursos { Items = items };
        }

        public Curso GetCurso(int id)
        {
            try
            {
                var entity = _cursoRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                return new Curso { Id = entity.Id, Nome = entity.Nome, Descricao = entity.Descricao, VagasDisponiveis = entity.VagasDisponiveis };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddCurso(BodyCurso curso)
        {
            try
            {
                var entity = new Repository.Entities.Curso
                {
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                    VagasDisponiveis = curso.VagasDisponiveis
                };

                _cursoRepository.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCurso(int id, BodyCurso curso)
        {
            try
            {
                var entity = _cursoRepository.GetById(id);

                if (entity == null)
                {
                    return;
                }

                entity.Nome = curso.Nome;
                entity.Descricao = curso.Descricao;
                entity.VagasDisponiveis = curso.VagasDisponiveis;

                _cursoRepository.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCurso(int id)
        {
            _cursoRepository.RemoveById(id);
        }

        public bool ExistsCurso(int id)
        {
            return _cursoRepository.Any(e => e.Id == id);
        }

        // Inscrições

        public Inscricoes GetInscricoes()
        {
            var items = new List<Inscricao>();

            var entities = _inscricaoRepository.GetAll(false).ToList();

            entities.ForEach(e =>
            {
                var inscricao = new Inscricao { Id = e.Id, Numero = e.Numero, Data = e.Data, Status = e.Status, ProcessoSeletivo = GetProcessoSeletivo(e.IdProcessoSeletivo), Candidato = GetCandidato(e.IdCandidato), Curso = GetCurso(e.IdCurso) };

                items.Add(inscricao);
            });

            return new Inscricoes { Items = items };
        }

        public Inscricao GetInscricao(int id)
        {
            try
            {
                var entity = _inscricaoRepository.GetById(id);

                if (entity == null)
                {
                    return null;
                }

                return new Inscricao { Id = entity.Id, Numero = entity.Numero, Data = entity.Data, Status = entity.Status, ProcessoSeletivo = GetProcessoSeletivo(entity.IdProcessoSeletivo), Candidato = GetCandidato(entity.IdCandidato), Curso = GetCurso(entity.IdCurso) };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Inscricoes Pesquisa(string cpf = null, int? idCurso = null)
        {
            try
            {
                var items = new List<Inscricao>();

                Repository.Entities.Candidato candidato = null;

                if (!String.IsNullOrWhiteSpace(cpf))
                {
                    candidato = _candidatoRepository.GetByFields(c => c.CPF == cpf, false).FirstOrDefault();
                }

                var entities = _inscricaoRepository.GetByFields(i => (candidato == null || i.IdCandidato == candidato.Id) && (!idCurso.HasValue || i.IdCurso == idCurso.Value), false).ToList();

                entities.ForEach(e =>
                {
                    var inscricao = new Inscricao { Id = e.Id, Numero = e.Numero, Data = e.Data, Status = e.Status, ProcessoSeletivo = GetProcessoSeletivo(e.IdProcessoSeletivo), Candidato = GetCandidato(e.IdCandidato), Curso = GetCurso(e.IdCurso) };

                    items.Add(inscricao);
                });

                return new Inscricoes { Items = items };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddInscricao(BodyInscricao inscricao)
        {
            try
            {
                var entity = new Repository.Entities.Inscricao
                {
                    Numero = inscricao.Numero,
                    Data = DateTime.Now,
                    Status = inscricao.Status ?? true,
                    IdProcessoSeletivo = inscricao.IdProcessoSeletivo,
                    IdCandidato = inscricao.IdCandidato,
                    IdCurso = inscricao.IdCurso
                };

                _inscricaoRepository.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateInscricao(int id, BodyInscricao inscricao)
        {
            try
            {
                var entity = _inscricaoRepository.GetById(id);

                if (entity == null)
                {
                    return;
                }

                entity.Numero = inscricao.Numero;
                entity.Status = inscricao.Status ?? entity.Status;
                entity.IdProcessoSeletivo = inscricao.IdProcessoSeletivo;
                entity.IdCandidato = inscricao.IdCandidato;
                entity.IdCurso = inscricao.IdCurso;

                _inscricaoRepository.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteInscricao(int id)
        {
            _inscricaoRepository.RemoveById(id);
        }

        public bool ExistsInscricao(int id)
        {
            return _inscricaoRepository.Any(e => e.Id == id);
        }

        public bool ExistsInscricaoProcessoSeletivo(int idProcessoSeletivo)
        {
            return _inscricaoRepository.Any(e => e.IdProcessoSeletivo == idProcessoSeletivo);
        }

        public bool ExistsInscricaoCandidato(int idCandidato)
        {
            return _inscricaoRepository.Any(e => e.IdCandidato == idCandidato);
        }

        public bool ExistsInscricaoCurso(int idCurso)
        {
            return _inscricaoRepository.Any(e => e.IdCurso == idCurso);
        }

        #endregion
    }
}
