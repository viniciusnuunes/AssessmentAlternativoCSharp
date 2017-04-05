using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Repository
{
    public class AcessarDocumento : IAcessoDados
    {
        public string enderecoXmlOriginal = @"..\..\..\XML-Original\exporte-alunos-01.xml";
        private string enderecoXmlNovo = @"..\..\..\Data\exporte-alunos.xml";

        public string XmlOriginal { get { return enderecoXmlOriginal; } }
        public string xmlNovo { get { return enderecoXmlNovo; } }

        public List<Aluno> retornarTodosAlunos(string caminhoDoArquivo)
        {
            Aluno aluno = null;
            var alunos = new List<Aluno>();

            XmlDocument doc = new XmlDocument();
            doc.Load(caminhoDoArquivo);

            XmlNodeList elemList = doc.GetElementsByTagName("aluno");
            foreach (XmlNode no in elemList)
            {
                aluno = new Aluno();

                aluno.Matricula = no["matricula"].InnerText;
                aluno.Nome = no["nome"].InnerText;
                string sNascimento = no["datadenascimento"].InnerText;
                aluno.dataDeNascimento = Convert.ToDateTime(sNascimento);
                aluno.Cpf = no["cpf"].InnerText;
                string sAtivo = no["ativo"].InnerText;
                aluno.Ativo = (sAtivo == "1") ? true : false;

                alunos.Add(aluno);
            }
            return (alunos);
        }

        public void adicionarAluno(Aluno aluno)
        {
            XElement elementoXml = new XElement("aluno");

            elementoXml.Add(new XElement("matricula", aluno.Matricula));
            elementoXml.Add(new XElement("nome", aluno.Nome));
            elementoXml.Add(new XElement("datadenascimento", aluno.dataDeNascimento.ToString("dd/MM/yyyy")));
            elementoXml.Add(new XElement("cpf", aluno.Cpf));
            elementoXml.Add(new XElement("ativo", (aluno.Ativo) ? "1" : "0"));

            XElement xml = XElement.Load(enderecoXmlOriginal);
            xml.Add(elementoXml);
            xml.Save(enderecoXmlOriginal);
        }

        public Aluno retornarAluno(string matricula)
        {
            List<Aluno> todosAlunos = retornarTodosAlunos(enderecoXmlOriginal);

            foreach (Aluno aluno in todosAlunos)
            {
                if (aluno.Matricula == matricula)
                {
                    return aluno;
                }
            }
            return null;
        }

        public void alterarNomeXml(string dataLog)
        {
            string novoNomeXml = @"..\..\..\Data\exporte-alunos" + "-" + dataLog + ".xml";
            File.Move(enderecoXmlNovo, novoNomeXml);
        }
    }
}
