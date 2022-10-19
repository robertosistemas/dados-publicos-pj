﻿using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class NaturezaJuridicaModelo : Entity<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
