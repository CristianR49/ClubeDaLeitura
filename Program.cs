using ClubeDaLeitura.Amigos;
using ClubeDaLeitura.Caixas;
using ClubeDaLeitura.Emprestimos;
using ClubeDaLeitura.Revistas;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace ClubeDaLeitura
{

    public class Program
    {
        static void Main(string[] args)
        {
            #region especificações
            #region revista
            /*Para cada Revista, deverá ser cadastrado:
    • o tipo de coleção
    • o número da edição
    • o ano da revista
    • a caixa onde está guardada
    Cada caixa tem uma cor, uma etiqueta e um número.
            */
            #endregion
            #region empréstimo
            /*
    Para cada Empréstimo cadastram-se:
    • o amigo que pegou a revista
    • qual foi a revista emprestada
    • a data do empréstimo
    • a data de 
    Cada criança só pode pegar uma revista por empréstimo.
        */
            #endregion
            #region amigo
            /*
    O cadastro do Amigo consiste de:
    • nome
    • nome do responsável
    • telefone
    • endereço
            */
            #endregion
            #endregion

            string opcaoMenuPrincipal;
            string opcaoMenuCaixa;
            string opcaoMenuRevista;
            string opcaoMenuAmigo;
            string opcaoMenuEmprestimo;

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            TelaCaixa telaCaixa = new TelaCaixa();
            TelaRevista telaRevista = new TelaRevista();
            TelaAmigo telaAmigo = new TelaAmigo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();

            telaCaixa.repositorioCaixa = repositorioCaixa;
            telaRevista.repositorioRevista = repositorioRevista;
            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.telaCaixa = telaCaixa;
            telaAmigo.repositorioAmigo = repositorioAmigo;
            repositorioRevista.repositorioCaixa = repositorioCaixa;
            telaEmprestimo.repositorioEmprestimo = repositorioEmprestimo;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.telaRevista = telaRevista;
            repositorioEmprestimo.repositorioRevista = repositorioRevista;
            repositorioEmprestimo.repositorioAmigo = repositorioAmigo;
            


            TelaPrincipal telaPrincipal = new TelaPrincipal();

            #region itens de exemplo
            repositorioCaixa.CadastrarUmaCaixaAutomaticamente();
            repositorioRevista.CadastrarUmaRevistaAutomaticamente();
            repositorioAmigo.CadastrarUmAmigoAutomaticamente();
            repositorioEmprestimo.CadastrarUmEmprestimoAutomaticamente();
            #endregion


            //testar a função de verifirar a vari no meio de um índece,.,?? show

            while (true)
            {
                opcaoMenuPrincipal = telaPrincipal.MostrarMenuPrincipal();
                while (opcaoMenuPrincipal == "1")
                {
                    opcaoMenuRevista = telaRevista.MostrarMenuRevista();
                    if (opcaoMenuRevista == "1")
                    {
                        telaRevista.CadastrarRevista();
                    }
                    if (opcaoMenuRevista == "2")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Cadastro de Revistas");
                        telaRevista.VisualizarRevistasCadastradas();
                        Console.ReadLine();
                    }
                    if (opcaoMenuRevista == "3")
                    {
                        telaRevista.EditarCadastroDeRevista();
                    }
                    if (opcaoMenuRevista == "4")
                    {
                        telaRevista.ExcluirCadastroDeRevista();
                    }
                    if (opcaoMenuRevista == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "2")
                {
                    opcaoMenuCaixa = telaCaixa.MostrarMenuCaixa();
                    if (opcaoMenuCaixa == "1")
                    {
                        telaCaixa.CadastrarCaixa();
                    }
                    if (opcaoMenuCaixa == "2")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Cadastro de Caixas");
                        telaCaixa.VisualizarCaixasCadastradas();
                        Console.ReadLine();
                    }
                    if (opcaoMenuCaixa == "3")
                    {
                        telaCaixa.EditarCadastroDeCaixa();
                    }
                    if (opcaoMenuCaixa == "4")
                    {
                        telaCaixa.ExcluirCadastroDeCaixa();
                    }
                    if (opcaoMenuCaixa == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "3")
                {
                    opcaoMenuAmigo = telaAmigo.MostrarMenuAmigo();
                    if (opcaoMenuAmigo == "1")
                    {
                        telaAmigo.CadastrarAmigo();
                    }
                    if (opcaoMenuAmigo == "2")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Cadastro de Amigos");
                        telaAmigo.VisualizarAmigosCadastrados();
                        Console.ReadLine();
                    }
                    if (opcaoMenuAmigo == "3")
                    {
                        telaAmigo.EditarCadastroDeAmigo();
                    }
                    if (opcaoMenuAmigo == "4")
                    {
                        telaAmigo.ExcluirCadastroDeAmigo();
                    }
                    if (opcaoMenuAmigo == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "4")
                {
                    opcaoMenuEmprestimo = telaEmprestimo.MostrarMenuEmprestimo();
                    if (opcaoMenuEmprestimo == "1")
                    {
                        telaEmprestimo.CadastrarEmprestimo();
                    }
                    if (opcaoMenuEmprestimo == "2")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Cadastro de Emprestimos");
                        telaEmprestimo.VisualizarEmprestimosCadastrados();
                        Console.ReadLine();
                    }
                    if (opcaoMenuEmprestimo == "3")
                    {
                        telaEmprestimo.EditarCadastroDeEmprestimo();
                    }
                    if (opcaoMenuEmprestimo == "4")
                    {
                        telaEmprestimo.ExcluirCadastroDeEmprestimo();
                    }
                    if (opcaoMenuEmprestimo == "5")
                    {
                        break;
                    }
                }
                if(opcaoMenuPrincipal == "5")
                {
                    telaEmprestimo.MostrarEmprestimosDosUltimos30Dias();
                }
                if (opcaoMenuPrincipal == "6")
                {
                    telaEmprestimo.VisualizarEmprestimosCadastrados();
                }
                if (opcaoMenuPrincipal == "7")
                {
                    break;
                }
            }
        }
    }
}