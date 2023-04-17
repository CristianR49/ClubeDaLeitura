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
    internal class TelaPrincipal : Tela
    {
        public string MostrarMenuPrincipal()
        {
            string opcaoMenuPrincipal;
            Console.Clear();
            ApresentarCabecalho("Clube da leitura", "Menu Principal");
            Console.WriteLine("(1) Menu cadastros de Revistas");
            Console.WriteLine("(2) Menu cadastros de Caixas");
            Console.WriteLine("(3) Menu cadastros de Amigos");
            Console.WriteLine("(4) Menu cadastros de Empréstimos");
            Console.WriteLine("(5) Verificar os empréstimos realizados nos ultimos 30 dias");
            Console.WriteLine("(6) Verificar os empréstimos em aberto");
            Console.WriteLine("(7) Sair");
            opcaoMenuPrincipal = Console.ReadLine();
            return opcaoMenuPrincipal;
        }
    }
}
