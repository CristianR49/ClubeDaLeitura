using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Amigos
{
    public class RepositorioAmigo : Repositorio
    {
        public void InserirNovoItem(Amigo amigo1)
        {


            Amigo amigo = new Amigo();
            amigo.nome = amigo1.nome;
            amigo.nomeResponsavel = amigo1.nomeResponsavel;
            amigo.telefone = amigo1.telefone;
            amigo.endereco = amigo1.endereco;
            amigo.id = contadorDeId;
            amigo.JaPegou = false;

            IncrementarId();

            listaDeItens.Add(amigo);
        }
        public Amigo PegarAmigoPorId(int IdAmigo)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Amigo c in listaDeItens)
            {
                if (c.id == IdAmigo)
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
            foreach (Amigo c in listaDeItens)
            {
                if (c.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void AtribuirAmigoNaLista(int idASerEditado, Amigo amigo)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = amigo;
        }
        public void CadastrarUmAmigoAutomaticamente()
        {
            Amigo amigoex = new Amigo();
            amigoex.nome = "João";
            amigoex.nomeResponsavel = "Fabrício";
            amigoex.telefone = "8833 5009";
            amigoex.endereco = "Rua Santo Amaro 500";
            amigoex.id = 1;
            listaDeItens.Add(amigoex);
        }
    }
}
