using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento.Domain.Models
{
    public class Graficos
    {
        public List<Mes> Meses { get; set; }
        public Graficos() 
        { 
          Meses = new List<Mes>();
        }
    }
}
