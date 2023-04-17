using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    public class Revista : Entidade
    {
        public string tipoColecao;
        public string numeroEdicao;
        public string ano;
        public Caixa caixa;
        public int id;


        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(tipoColecao))
                erros.Add("Insira o tipo de coleção");

            if (string.IsNullOrEmpty(numeroEdicao))
                erros.Add("Insira o numero da edição");

            if (string.IsNullOrEmpty(ano))
                erros.Add("Insira um ano");

            return erros;
        }
    }
}
