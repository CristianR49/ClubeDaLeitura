using ClubeDaLeitura.Amigos;
using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Amigos
{
    public class TelaAmigo : Tela
    {
        public RepositorioAmigo repositorioAmigo;

        public void CadastrarAmigo()
        {
            bool infoInvalida;
            Amigo amigo;
            do
            {
                infoInvalida = false;
                Console.Clear();
                ApresentarCabecalho("Cadastro de Amigos", "Cadastrar um novo Amigo");

                amigo = InformarNovoAmigo();

                ArrayList erros = amigo.Validar();

                infoInvalida = ApresentarErros(infoInvalida, erros);

            } while (infoInvalida);
            repositorioAmigo.InserirNovoItem(amigo);
            ApresentarMensagem("Amigo cadastrado com sucesso!", ConsoleColor.Green, true);
        }



        private Amigo InformarNovoAmigo()
        {
            Amigo amigo = new Amigo();
            Console.WriteLine("Digite o nome");
            amigo.nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do responsável");
            amigo.nomeResponsavel = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            amigo.telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço");
            amigo.endereco = Console.ReadLine();
            return amigo;
        }

        public void VisualizarAmigosCadastrados()
        {
            ApresentarCabecalhoSimples("Amigos cadastrados:");
            if (VerificarSeHaCadastroDeAmigo(false))
            {
                return;
            }

            MostrarAmigos();
        }

        private void MostrarAmigos()
        {
            ArrayList listaDeItens = repositorioAmigo.SelecionarTodos();

            Console.WriteLine($"{"Id",-2}{"| Nome",-27}{"| Nome do responsável",-27}{"| Telefone",-27}{"| Endereço"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Amigo a in listaDeItens)
            {
                Console.WriteLine($"{a.id,-2}| {a.nome,-25}| {a.nomeResponsavel, -25}| {a.telefone,-25}| {a.endereco}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarCadastroDeAmigo()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Amigos", "Editar um Amigo");

            if (VerificarSeHaCadastroDeAmigo(true))
            {
                return;
            }

            VisualizarAmigosCadastrados();

            int idASerEditado = InputarId();

            Amigo amigo = InformarNovoAmigo();
            amigo.id = idASerEditado;

            repositorioAmigo.AtribuirAmigoNaLista(idASerEditado, amigo);
            ApresentarMensagem("Amigo editado com sucesso!", ConsoleColor.Green, true);
        }

        public void ExcluirCadastroDeAmigo()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Amigos", "Excluir um Amigo");

            if (VerificarSeHaCadastroDeAmigo(true))
            {
                return;
            }

            VisualizarAmigosCadastrados();

            int idASerExcluido = InputarId();

            repositorioAmigo.ExcluirItem(idASerExcluido);

            ApresentarMensagem("Amigo apagado com sucesso!", ConsoleColor.Green, true);

            repositorioAmigo.ResetarIdSeAListaForApagada();
        }

        public bool VerificarSeHaCadastroDeAmigo(bool apertarEnter)
        {
            bool naoTemAmigoCadastrado = false;
            ArrayList listaDeItens = repositorioAmigo.SelecionarTodos();
            if (listaDeItens.Count == 0)
            {
                ApresentarMensagem("Não há Amigos cadastrados", ConsoleColor.Red, apertarEnter);
                naoTemAmigoCadastrado = true;
            }
            return naoTemAmigoCadastrado;
        }


        public int InputarId()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                string idDigitado;
                bool letraNoMeio;
                do
                {
                    Console.Write("Digite o Id da Amigo");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = VerificarSeTemLetraNoMeio(idDigitado);

                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioAmigo.PegarAmigoPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);
            return idSelecionado;
        }

        public string MostrarMenuAmigo()
        {
            string opcaoMenuAmigo;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Amigos", "Menu");
            Console.WriteLine("(1) Cadastrar um novo Amigo");
            Console.WriteLine("(2) Visualizar Amigos cadastrados");
            Console.WriteLine("(3) Editar um cadastro de Amigo");
            Console.WriteLine("(4) Apagar um cadastro de Amigo");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuAmigo = Console.ReadLine();
            return opcaoMenuAmigo;
        }
    }
}
