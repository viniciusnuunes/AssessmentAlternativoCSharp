using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using System.Collections.Generic;

namespace ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Repository
{
    public interface IAcessoDados
    {
        List<Aluno> retornarTodosAlunos(string caminhoDoArquivo);

        void adicionarAluno(Aluno aluno);

        Aluno retornarAluno(string matricula);
    }
}