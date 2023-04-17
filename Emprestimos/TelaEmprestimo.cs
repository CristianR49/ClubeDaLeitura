using ClubeDaLeitura.Revistas;
using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Amigos;

namespace ClubeDaLeitura.Emprestimos
{
    internal class TelaEmprestimo : Tela
    {
        public RepositorioEmprestimo repositorioEmprestimo;
        public TelaRevista telaRevista = null;
        public RepositorioRevista repositorioRevista = null;
        public TelaAmigo telaAmigo = null;
        public RepositorioAmigo repositorioAmigo = null;
        public void CadastrarEmprestimo()
        {
            bool infoInvalida;
            Emprestimo emprestimo;
            do
            {
                infoInvalida = false;
                Console.Clear();
                ApresentarCabecalho("Cadastro de Emprestimos", "Cadastrar um novo Emprestimo");

                if (telaRevista.VerificarSeHaCadastroDeRevista(true))
                {
                    return;
                }
                if (telaAmigo.VerificarSeHaCadastroDeAmigo(true))
                {
                    return;
                }

                emprestimo = InformarNovoEmprestimo();

                ArrayList erros = emprestimo.Validar();

                infoInvalida = ApresentarErros(infoInvalida, erros);
                if(erros.Count > 0)
                {
                    return;
                }
                emprestimo.amigo.JaPegou = true;

            } while (infoInvalida);
            repositorioEmprestimo.InserirNovoItem(emprestimo);
            ApresentarMensagem("Emprestimo cadastrado com sucesso!", ConsoleColor.Green, true);
        }



        private Emprestimo InformarNovoEmprestimo()
        {
            Emprestimo emprestimo = new Emprestimo();
            telaRevista.VisualizarRevistasCadastradas();
            int idSelecionado = telaRevista.InputarId();
            emprestimo.revista = repositorioRevista.PegarRevistaPorId(idSelecionado);
            telaAmigo.VisualizarAmigosCadastrados();
            idSelecionado = telaAmigo.InputarId();
            emprestimo.amigo = repositorioAmigo.PegarAmigoPorId(idSelecionado);
            Console.WriteLine("Digite a data do empréstimo");
            emprestimo.dataEmprestimo = (Console.ReadLine());
            Console.WriteLine("Digite a data da devolução");
            emprestimo.dataDevolucao = (Console.ReadLine());

            return emprestimo;
        }

        public void VisualizarEmprestimosCadastrados()
        {
            ApresentarCabecalhoSimples("Emprestimos cadastrados:");
            if (VerificarSeHaCadastroDeEmprestimo(false))
            {
                return;
            }

            MostrarEmprestimos();
            Console.ReadLine();
        }

        private void MostrarEmprestimos()
        {
            ArrayList listaDeItens = repositorioEmprestimo.SelecionarTodos();

            Console.WriteLine($"{"Id",-2}{"| Revista",-32}{"| Amigo",-19}{"| Data do empréstimo",-22}{"| Data de devolução"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Emprestimo e in listaDeItens)
            {
                Console.WriteLine($"{e.id,-2}| {e.revista.tipoColecao,-30}| {e.amigo.nome,-17}| {e.dataEmprestimo,-20}| {e.dataDevolucao}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void MostrarEmprestimosDosUltimos30Dias()
        {
            ArrayList listaDeItens = repositorioEmprestimo.SelecionarTodos();
            Console.WriteLine("Cadastros desde 17/03/2023:");
            Console.WriteLine($"{"Id",-2}{"| Revista",-32}{"| Amigo",-19}{"| Data do empréstimo",-22}{"| Data de devolução"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Emprestimo e in listaDeItens)
            {
                string[] infosData = new string[10];
                infosData = e.dataDevolucao.Split("/");
                if (Convert.ToInt32(infosData[0]) > Convert.ToInt32("18") && infosData[1] == "03" && infosData[2] == "23" || Convert.ToInt32(infosData[0]) < Convert.ToInt32("18") && infosData[1] == "04" && infosData[2] == "23")
                Console.WriteLine($"{e.id,-2}| {e.revista.tipoColecao,-30}| {e.amigo.nome,-17}| {e.dataEmprestimo,-20}| {e.dataDevolucao}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.ReadLine();
        }

        public void EditarCadastroDeEmprestimo()
        {
            bool infoInvalida = false;
            Emprestimo emprestimo;
            int idASerEditado;
            do
            {
                Console.Clear();

                ApresentarCabecalho("Cadastro de Emprestimos", "Editar um Emprestimo");

                if (VerificarSeHaCadastroDeEmprestimo(true))
                {
                    return;
                }

                if (telaRevista.VerificarSeHaCadastroDeRevista(true))
                {
                    return;
                }

                if (telaAmigo.VerificarSeHaCadastroDeAmigo(true))
                {
                    return;
                }

                VisualizarEmprestimosCadastrados();

                idASerEditado = InputarId();

                emprestimo = InformarNovoEmprestimo();
                emprestimo.id = idASerEditado;

                ArrayList erros = emprestimo.Validar();

                infoInvalida = ApresentarErros(infoInvalida, erros);

            } while (infoInvalida);
            repositorioEmprestimo.AtribuirEmprestimoNaLista(idASerEditado, emprestimo);

            ApresentarMensagem("Emprestimo editado com sucesso!", ConsoleColor.Green, true);

        }

        public void ExcluirCadastroDeEmprestimo()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Emprestimos", "Excluir um Emprestimo");

            if (VerificarSeHaCadastroDeEmprestimo(true))
            {
                return;
            }

            VisualizarEmprestimosCadastrados();

            int idASerExcluido = InputarId();

            repositorioEmprestimo.ExcluirItem(idASerExcluido);

            ApresentarMensagem("Emprestimo apagado com sucesso!", ConsoleColor.Green, true);

            repositorioEmprestimo.ResetarIdSeAListaForApagada();
        }

        private bool VerificarSeHaCadastroDeEmprestimo(bool apertarEnter)
        {
            bool naoTemEmprestimoCadastrado = false;
            ArrayList listaDeItens = repositorioEmprestimo.SelecionarTodos();
            if (listaDeItens.Count == 0)
            {
                ApresentarMensagem("Não há Emprestimos cadastrados", ConsoleColor.Red, apertarEnter);
                naoTemEmprestimoCadastrado = true;
            }
            return naoTemEmprestimoCadastrado;
        }
        private int InputarId()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                string idDigitado;
                bool letraNoMeio;
                do
                {
                    Console.Write("Digite o Id do Emprestimo");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioEmprestimo.PegarEmprestimoPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }

        public string MostrarMenuEmprestimo()
        {
            string opcaoMenuEmprestimo;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Emprestimos", "Menu");
            Console.WriteLine("(1) Cadastrar um novo emprestimo");
            Console.WriteLine("(2) Visualizar Emprestimos cadastrados");
            Console.WriteLine("(3) Editar um cadastro de Emprestimo");
            Console.WriteLine("(4) Apagar um cadastro de emprestimo");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuEmprestimo = Console.ReadLine();
            return opcaoMenuEmprestimo;
        }
    }
}
