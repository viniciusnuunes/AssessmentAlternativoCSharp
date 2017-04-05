using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS1T1M.TP3.ViniciusNunes.Present.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ComparadorDeListas iniciarPrograma = new ComparadorDeListas();

            iniciarPrograma.compararListaDeAlunos();

            //AcessarDocumento iniciar = new AcessarDocumento();
            //List<Aluno> alunos = new List<Aluno>();
            //alunos = AcessarDocumento.retornarTodosAlunos(iniciar.enderecoXmlOriginal);


            //foreach (Aluno aluno in alunos)
            //{
            //    Console.WriteLine(aluno.Nome);
            //}
            //Console.ReadKey();

        }
    }
}
