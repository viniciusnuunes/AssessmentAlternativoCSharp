using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }        
        public DateTime dataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
