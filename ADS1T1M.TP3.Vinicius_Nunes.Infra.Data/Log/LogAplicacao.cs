using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Log
{
    public static class LogAplicacao
    {
        private static string enderecoArquivoLog = "..\\..\\..\\Data\\exporte-alunos-log-de-carga-";

        public static string ArquivoLog
        {
            get { return enderecoArquivoLog; }
        }

        public static void alunoSemAlteracao(Aluno aluno, string dataLog)
        {
            File.AppendAllText(enderecoArquivoLog + dataLog + ".txt", "matricula > " + aluno.Matricula + ";" + " nome > " + aluno.Nome + "; ativo > " + ((aluno.Ativo) ? "1" : "0") + "; OK" + Environment.NewLine);
        }

        public static void alunoComAlteracao(Aluno aluno, string dataLog)
        {
            File.AppendAllText(enderecoArquivoLog + dataLog + ".txt", "matricula > " + aluno.Matricula + ";" + " nome > " + aluno.Nome + "; alterado : ativo > " + ((aluno.Ativo) ? "1" : "0") + Environment.NewLine);
        }

        public static void adicionarNovoAluno(Aluno aluno, string dataLog)
        {
            File.AppendAllText(enderecoArquivoLog + dataLog + ".txt", "matricula > " + aluno.Matricula + ";" + " nome > " + aluno.Nome + "; ativo > " + ((aluno.Ativo) ? "1" : "0") + " Adicionado" + Environment.NewLine);
        }
    }
}
