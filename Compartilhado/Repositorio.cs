using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    public class Repositorio
    {
        public ArrayList listaDeItens = new ArrayList();
        public int contadorDeId = 2;

        public void IncrementarId()
        {
            contadorDeId++;
        }

        public ArrayList SelecionarTodos()
        {
            return listaDeItens;
        }
        public void ResetarIdSeAListaForApagada()
        {
            if (listaDeItens.Count == 0)
            {
                contadorDeId = 1;
            }
        }

    }
}
