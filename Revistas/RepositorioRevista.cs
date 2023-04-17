using ClubeDaLeitura.Caixas;
using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    public class RepositorioRevista : Repositorio
    {
       public RepositorioCaixa repositorioCaixa = null;
        public void InserirNovoItem(Revista revista1)
        {

            Revista revista = new Revista();
            revista.numeroEdicao = revista1.numeroEdicao;
            revista.tipoColecao = revista1.tipoColecao;
            revista.ano = revista1.ano;
            revista.caixa = revista1.caixa;
            revista.id = contadorDeId;

            IncrementarId();

            listaDeItens.Add(revista);
        }

        public Revista PegarRevistaPorId(int IdRevista)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Revista r in listaDeItens)
            {
                if (r.id == IdRevista)
                {
                    return r;
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
            foreach (Revista r in listaDeItens)
            {
                if (r.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void AtribuirRevistaNaLista(int idASerEditado, Revista revista)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = revista;
        }
        public void CadastrarUmaRevistaAutomaticamente()
        {

            Revista revistaex = new Revista();
            revistaex.tipoColecao = "As aventuras de batman";
            revistaex.numeroEdicao = "5";
            revistaex.ano = "1950";
            revistaex.caixa = repositorioCaixa.PegarCaixaPorId(1);
            revistaex.id = 1;
            listaDeItens.Add(revistaex);
        }
    }
}

