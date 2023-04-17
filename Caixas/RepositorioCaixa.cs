using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Caixas
{
    public class RepositorioCaixa : Repositorio
    {
        public void InserirNovoItem(Caixa caixa1)
        {

            Caixa caixa = new Caixa();
            caixa.etiqueta = caixa1.etiqueta;
            caixa.cor = caixa1.cor;
            caixa.id = contadorDeId;

            IncrementarId();

            listaDeItens.Add(caixa);
        }
        public Caixa PegarCaixaPorId(int IdCaixa)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Caixa c in listaDeItens)
            {
                if (c.id == IdCaixa)
                {
                    return c;
                }
            }
            return null;
        }
        internal void ExcluirItem(int idASerExcluido)
        {
            listaDeItens.RemoveAt(PegarIndiceDoIdEscolhido(idASerExcluido));
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Caixa c in listaDeItens)
            {
                if (c.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void AtribuirCaixaNaLista(int idASerEditado, Caixa caixa)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = caixa;
        }
        public void CadastrarUmaCaixaAutomaticamente()
        {
            Caixa caixaex = new Caixa();
            caixaex.etiqueta = "Caixola";
            caixaex.cor = "preta";
            caixaex.id = 1;
            listaDeItens.Add(caixaex);
        }
    }
}
