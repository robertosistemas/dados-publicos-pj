using Microsoft.EntityFrameworkCore;
using NidaTech.DadosPublicos.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace NidaTech.DadosPublicos.EntityFrameworkCore.Seed.Host
{
    public class DefaultDominiosCreator
    {
        public static List<LogicoModelo> InitialLogicos => GetInitialLogicos();

        private readonly DadosPublicosDbContext _context;

        private static List<LogicoModelo> GetInitialLogicos()
        {
            return new List<LogicoModelo>
            {
                new LogicoModelo{ Codigo="N", Descricao="Não" },
                new LogicoModelo{ Codigo="S", Descricao="Sim" }
            };
        }

        public DefaultDominiosCreator(DadosPublicosDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLogicos();
        }

        private void CreateLogicos()
        {
            foreach (var logico in InitialLogicos)
            {
                AddLanguageIfNotExists(logico);
            }
        }

        private void AddLanguageIfNotExists(LogicoModelo logico)
        {
            if (_context.Logicos.IgnoreQueryFilters().Any(l => l.Codigo == logico.Codigo))
            {
                return;
            }

            _context.Logicos.Add(logico);
            _context.SaveChanges();
        }
    }
}
