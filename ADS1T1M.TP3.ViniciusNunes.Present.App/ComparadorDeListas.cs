using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Log;
using ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS1T1M.TP3.ViniciusNunes.Present.App
{
    class ComparadorDeListas
    {
        public void compararListaDeAlunos()
        {
            AcessarDocumento baseDeDados = new AcessarDocumento();

            List<Aluno> alunosOriginais = baseDeDados.retornarTodosAlunos(baseDeDados.XmlOriginal);
            List<Aluno> alunosNovos = baseDeDados.retornarTodosAlunos(baseDeDados.xmlNovo);

            string dataLog = DateTime.Now.ToString("yyyyMMddHHmm");

            foreach (Aluno aluno in alunosNovos)
            {
                if (alunosOriginais.Any(a => a.Matricula == aluno.Matricula && a.Ativo == aluno.Ativo))
                {
                    Console.WriteLine("O Aluno " + aluno.Nome + " permanece " + ((aluno.Ativo) ? "ativo\n" : "inativo\n"));
                    LogAplicacao.alunoSemAlteracao(aluno, dataLog);
                }
                else if (alunosOriginais.Any(a => a.Matricula == aluno.Matricula && a.Ativo != aluno.Ativo))
                {
                    Console.WriteLine("O aluno " + aluno.Nome + " mudou o seu estado. Agora ele se encontra " + ((aluno.Ativo) ? "ativo\n" : "inativo\n"));

                    LogAplicacao.alunoComAlteracao(aluno, dataLog);
                }
                else
                {
                    baseDeDados.adicionarAluno(aluno);

                    Console.WriteLine(aluno.Nome + " adicionado na lista.\n");

                    LogAplicacao.adicionarNovoAluno(aluno, dataLog);
                }
            }

            baseDeDados.alterarNomeXml(dataLog);

            Console.ReadKey();
        }        
    }
}
