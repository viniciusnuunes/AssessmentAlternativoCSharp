using ADS1T1M.TP3.Vinicius_Nunes.Domain.Entities;
using ADS1T1M.TP3.Vinicius_Nunes.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADS1T1M.TP3.Vinicius_Nunes.WPFApp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBuscarMatricula_Click(object sender, RoutedEventArgs e)
        {
            string matricula = txtMatriculaBusca.Text;
            AcessarDocumento dados = new AcessarDocumento();
            Aluno aluno = dados.retornarAluno(matricula);

            if (aluno == null)
            {
                txtStatus.Text = "Aluno não encontrado";
                alteraCorStatus("inexistente");
            }
            else
            {
                validarStatusAluno(aluno);
            }
        }

        private void exibirInfoAluno(Aluno aluno)
        {
            txtNome.Text = aluno.Nome;
            txtMatricula.Text = aluno.Matricula;
            txtDataDeNascimento.Text = aluno.dataDeNascimento.ToString("dd/MM/yyyy");
            txtCpf.Text = aluno.Cpf;
        }

        private void validarStatusAluno(Aluno aluno)
        {
            if (aluno.Ativo)
            {
                txtStatus.Text = "Aluno liberado";
                exibirInfoAluno(aluno);
                alteraCorStatus("liberado");
            }
            else
            {
                txtStatus.Text = "Aluno suspenso";
                exibirInfoAluno(aluno);
                alteraCorStatus("suspenso");
            }
        }

        private void alteraCorStatus(string status)
        {
            txtStatus.Visibility = Visibility.Visible;

            switch (status)
            {
                case "inexistente":
                    txtStatus.Background = Brushes.Blue;
                    break;
                case "liberado":
                    txtStatus.Background = Brushes.Green;
                    break;
                case "suspenso":
                    txtStatus.Background = Brushes.Red;
                    break;
                default:
                    break;
            }
        }

        private void matricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtNome.Text = "";
            txtMatricula.Text = "";
            txtCpf.Text = "";
            txtDataDeNascimento.Text = "";

            txtStatus.Visibility = Visibility.Hidden;
        }
    }
}
