using ClubeDaLeitura.Amigos;
using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Emprestimos
{
    internal class Emprestimo : Entidade
    {

        public Amigo amigo;
        public Revista revista;
        public string dataEmprestimo;
        public string dataDevolucao;
        public int id;


        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (amigo.JaPegou == true)
                erros.Add("O amigo já pegou uma revista");

            if (string.IsNullOrEmpty(dataEmprestimo))
                erros.Add("Insira a data do empréstimo");

            if (string.IsNullOrEmpty(dataDevolucao))
                erros.Add("Insira data de devolução");

            return erros;

        }
    }
}
