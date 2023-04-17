using ClubeDaLeitura.Caixas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura
{
    public class TelaCaixa : Tela
    {
        public RepositorioCaixa repositorioCaixa;

        public void CadastrarCaixa()
        {
            bool infoInvalida;
            Caixa caixa;
            do
            {
                infoInvalida = false;
                Console.Clear();
                ApresentarCabecalho("Cadastro de Caixas", "Cadastrar uma nova Caixa");

                caixa = InformarNovaCaixa();

                ArrayList erros = caixa.Validar();

                infoInvalida = ApresentarErros(infoInvalida, erros);

            } while (infoInvalida);
            repositorioCaixa.InserirNovoItem(caixa);
            ApresentarMensagem("Caixa cadastrada com sucesso!", ConsoleColor.Green, true);
        }

        

        private Caixa InformarNovaCaixa()
        {
            Caixa caixa = new Caixa();
            Console.WriteLine("Digite a etiqueta (nome)");
            caixa.etiqueta = (Console.ReadLine());
            Console.WriteLine("Digite a cor");
            caixa.cor = (Console.ReadLine());

            return caixa;
        }

        public void VisualizarCaixasCadastradas()
        {

            ApresentarCabecalhoSimples("Caixas cadastradas:");
            if (VerificarSeHaCadastroDeCaixa(false))
            {
                return;
            }

            MostrarCaixas();
        }

        private void MostrarCaixas()
        {
            ArrayList listaDeItens = repositorioCaixa.SelecionarTodos();

            Console.WriteLine($"{"Id",-2}{"| Etiqueta",-27}{"| Cor"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Caixa c in listaDeItens)
            {
                Console.WriteLine($"{c.id, -2}| {c.etiqueta, -25}| {c.cor}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarCadastroDeCaixa()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Caixas", "Editar uma Caixa");

            if (VerificarSeHaCadastroDeCaixa(true))
            {
                return;
            }

            VisualizarCaixasCadastradas();

            int idASerEditado = InputarId();

            Caixa caixa = InformarNovaCaixa();
            caixa.id = idASerEditado;

            repositorioCaixa.AtribuirCaixaNaLista(idASerEditado, caixa);
            ApresentarMensagem("Caixa editada com sucesso!", ConsoleColor.Green, true);
        }

        public void ExcluirCadastroDeCaixa()
        {
            Console.Clear();

            ApresentarCabecalho("Cadastro de Caixas", "Excluir uma Caixa");

            if (VerificarSeHaCadastroDeCaixa(true))
            {
                return;
            }

            VisualizarCaixasCadastradas();

            int idASerExcluido = InputarId();

            repositorioCaixa.ExcluirItem(idASerExcluido);

            ApresentarMensagem("Caixa apagada com sucesso!", ConsoleColor.Green, true);

            repositorioCaixa.ResetarIdSeAListaForApagada();
        }

        public bool VerificarSeHaCadastroDeCaixa(bool apertarEnter)
        {
            bool naoTemCaixaCadastrada = false;
            ArrayList listaDeItens = repositorioCaixa.SelecionarTodos();
            if (listaDeItens.Count == 0)
            {
                ApresentarMensagem("Não há Caixas cadastradas", ConsoleColor.Red, apertarEnter);
                naoTemCaixaCadastrada = true;
            }
            return naoTemCaixaCadastrada;
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
                    Console.Write("Digite o Id da Caixa");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = VerificarSeTemLetraNoMeio(idDigitado);

                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioCaixa.PegarCaixaPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }

        public string MostrarMenuCaixa()
        {
            string opcaoMenuCaixa;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Caixas", "Menu");
            Console.WriteLine("(1) Cadastrar uma nova caixa");
            Console.WriteLine("(2) Visualizar Caixas cadastradas");
            Console.WriteLine("(3) Editar um cadastro de Caixa");
            Console.WriteLine("(4) Apagar um cadastro de caixa");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuCaixa = Console.ReadLine();
            return opcaoMenuCaixa;
        }
    }
}
