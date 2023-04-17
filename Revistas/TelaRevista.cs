using ClubeDaLeitura.Caixas;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.Revistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Revistas
{
    public class TelaRevista : Tela
    {
       public RepositorioRevista repositorioRevista = null;
       public TelaCaixa telaCaixa = null;
       public RepositorioCaixa repositorioCaixa = null;

        public void CadastrarRevista()
        {
            bool infoInvalida;
            Revista revista;
            do
            {
                infoInvalida = false;
                Console.Clear();
                ApresentarCabecalho("Cadastro de Revistas", "Cadastrar uma nova Revista");

                if (telaCaixa.VerificarSeHaCadastroDeCaixa(true))
                {
                    return;
                }

                revista = InformarNovaRevista();

                ArrayList erros = revista.Validar();

                infoInvalida = ApresentarErros(infoInvalida, erros);

            } while (infoInvalida);
            repositorioRevista.InserirNovoItem(revista);
            ApresentarMensagem("Revista cadastrada com sucesso!", ConsoleColor.Green, true);
        }



        private Revista InformarNovaRevista()
        {
            Revista revista = new Revista();
            Console.WriteLine("Digite o tipo de coleção");
            revista.tipoColecao = (Console.ReadLine());
            Console.WriteLine("Digite o número da edição");
            revista.numeroEdicao = (Console.ReadLine());
            Console.WriteLine("Digite o ano");
            revista.ano = (Console.ReadLine());
            telaCaixa.VisualizarCaixasCadastradas();
            int idSelecionado = telaCaixa.InputarId();
            revista.caixa = repositorioCaixa.PegarCaixaPorId(idSelecionado);

            return revista;
        }

        public void VisualizarRevistasCadastradas()
        {
            ApresentarCabecalhoSimples("Revistas cadastradas:");
            if (VerificarSeHaCadastroDeRevista(false))
            {
                return;
            }

            MostrarRevistas();
        }

        private void MostrarRevistas()
        {
            ArrayList listaDeItens = repositorioRevista.SelecionarTodos();

            Console.WriteLine($"{"Id",-2}{"| Tipo da coleção",-32}{"| Número da edição", -19}{"| Ano",-17}{"| Caixa"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Revista r in listaDeItens)
            {
                Console.WriteLine($"{r.id,-2}| {r.tipoColecao,-30}| {r.numeroEdicao,-17}| {r.ano,-15}| {r.caixa.etiqueta}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarCadastroDeRevista()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Revistas", "Editar uma Revista");

            if (VerificarSeHaCadastroDeRevista(true))
            {
                return;
            }

            if (telaCaixa.VerificarSeHaCadastroDeCaixa(true))
            {
                return;
            }

            VisualizarRevistasCadastradas();

            int idASerEditado = InputarId();

            Revista revista = InformarNovaRevista();
            revista.id = idASerEditado;

            repositorioRevista.AtribuirRevistaNaLista(idASerEditado, revista);
            ApresentarMensagem("Revista editada com sucesso!", ConsoleColor.Green, true);
        }

        public void ExcluirCadastroDeRevista()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Revistas", "Excluir uma Revista");

            if (VerificarSeHaCadastroDeRevista(true))
            {
                return;
            }

            VisualizarRevistasCadastradas();

            int idASerExcluido = InputarId();

            repositorioRevista.ExcluirItem(idASerExcluido);

            ApresentarMensagem("Revista apagada com sucesso!", ConsoleColor.Green, true);

            repositorioRevista.ResetarIdSeAListaForApagada();
        }

        public bool VerificarSeHaCadastroDeRevista(bool apertarEnter)
        {
            bool naoTemRevistaCadastrada = false;
            ArrayList listaDeItens = repositorioRevista.SelecionarTodos();
            if (listaDeItens.Count == 0)
            {
                ApresentarMensagem("Não há Revistas cadastradas", ConsoleColor.Red, apertarEnter);
                naoTemRevistaCadastrada = true;
            }
            return naoTemRevistaCadastrada;
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
                    Console.Write("Digite o Id da Revista");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioRevista.PegarRevistaPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }

        public string MostrarMenuRevista()
        {
            string opcaoMenuRevista;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Revistas", "Menu");
            Console.WriteLine("(1) Cadastrar uma nova revista");
            Console.WriteLine("(2) Visualizar Revistas cadastradas");
            Console.WriteLine("(3) Editar um cadastro de Revista");
            Console.WriteLine("(4) Apagar um cadastro de revista");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuRevista = Console.ReadLine();
            return opcaoMenuRevista;
        }
    }
}
