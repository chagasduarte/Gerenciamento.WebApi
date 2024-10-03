﻿namespace Gerenciamento.Domain.Models
{
    public class Graficos
    {
        public List<Mes> Meses { get; set; }
        public  List<TipoDespesaAgrupada> TipoDespesaAgrupada {get;set;}
        public Graficos() 
        { 
            Meses = new List<Mes>();
            TipoDespesaAgrupada = new List<TipoDespesaAgrupada>();
        }
    }
}
