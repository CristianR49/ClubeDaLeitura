using ClubeDaLeitura.Amigos;
using ClubeDaLeitura.Caixas;
using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Emprestimos
{
    internal class RepositorioEmprestimo : Repositorio
    {
        public RepositorioRevista repositorioRevista = null;
        public RepositorioAmigo repositorioAmigo = null;
        public void InserirNovoItem(Emprestimo emprestimo1)
        {

            Emprestimo emprestimo = new Emprestimo();
            emprestimo.revista = emprestimo1.revista;
            emprestimo.amigo = emprestimo1.amigo;
            emprestimo.dataEmprestimo = emprestimo1.dataEmprestimo;
            emprestimo.dataDevolucao = emprestimo1.dataDevolucao;
            emprestimo.id = contadorDeId;

            IncrementarId();

            listaDeItens.Add(emprestimo);
        }

        public Emprestimo PegarEmprestimoPorId(int IdEmprestimo)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Emprestimo e in listaDeItens)
            {
                if (e.id == IdEmprestimo)
                {
                    return e;
                }
            }
            return null;
        }
        public void ExcluirItem(int idASerExcluido)
        {
            listaDeItens.RemoveAt(PegarIndiceDoIdEscolhido(idASerExcluido));
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Emprestimo e in listaDeItens)
            {
                if (e.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void AtribuirEmprestimoNaLista(int idASerEditado, Emprestimo emprestimo)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = emprestimo;
        }
        public void CadastrarUmEmprestimoAutomaticamente()
        {

            Emprestimo emprestimoex = new Emprestimo();
            emprestimoex.revista = repositorioRevista.PegarRevistaPorId(1);
            emprestimoex.amigo = repositorioAmigo.PegarAmigoPorId(1);
            emprestimoex.amigo.JaPegou = true;
            emprestimoex.dataEmprestimo = "10/10/22";
            emprestimoex.dataDevolucao = "30/1/23";
            emprestimoex.id = 1;
            listaDeItens.Add(emprestimoex);
        }
    }
}
