using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vestibular.Objects.Candidato;
using Vestibular.Objects.Curso;
using Vestibular.Objects.Inscricao;
using Vestibular.Objects.ProcessoSeletivo;

namespace Vestibular.Business.Interfaces
{
    public interface IVestibularBusiness
    {
        ProcessosSeletivos GetProcessosSeletivos();
        ProcessoSeletivo GetProcessoSeletivo(int id);
        int AddProcessoSeletivo(BodyProcessoSeletivo processo);
        void UpdateProcessoSeletivo(int id, BodyProcessoSeletivo processo);
        void DeleteProcessoSeletivo(int id);
        bool ExistsProcessoSeletivo(int id);

        Candidatos GetCandidatos();
        Candidato GetCandidato(int id);
        int AddCandidato(BodyCandidato candidato);
        void UpdateCandidato(int id, BodyCandidato candidato);
        void DeleteCandidato(int id);
        bool ExistsCandidato(int id);

        Cursos GetCursos();
        Curso GetCurso(int id);
        int AddCurso(BodyCurso curso);
        void UpdateCurso(int id, BodyCurso curso);
        void DeleteCurso(int id);
        bool ExistsCurso(int id);

        Inscricoes GetInscricoes();
        Inscricao GetInscricao(int id);
        Inscricoes Pesquisa(string cpf = null, int? idCurso = null);
        int AddInscricao(BodyInscricao inscricao);
        void UpdateInscricao(int id, BodyInscricao inscricao);
        void DeleteInscricao(int id);
        bool ExistsInscricao(int id);
    }
}