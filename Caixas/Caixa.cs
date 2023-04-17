using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    public class Caixa : Entidade
    { 
        public string cor;
        public string etiqueta;

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(cor))
                erros.Add("Insira a cor");

            if (string.IsNullOrEmpty(etiqueta))
                erros.Add("Insira a etiqueta");

            return erros;
        }
    }
}
