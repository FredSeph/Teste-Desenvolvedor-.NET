using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Repository.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public DateTime Data { get; set; }

        public bool Status { get; set; }

        public int IdProcessoSeletivo { get; set; }

        public int IdCandidato { get; set; }

        public int IdCurso { get; set; }
    }
}