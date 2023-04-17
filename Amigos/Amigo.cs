using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Amigos
{
    public class Amigo : Entidade
    {
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public bool JaPegou;

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Insira o nome");

            if (string.IsNullOrEmpty(nomeResponsavel))
                erros.Add("Insira o nome do responsável");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("Insira o telefone");

            if (string.IsNullOrEmpty(endereco))
                erros.Add("Insira o endereço");

            return erros;
        }
    }
}
