namespace NidaTech.DadosPublicos.EntityFrameworkCore.Seed.Host
{
    public class InitialDominiosDbBuilder
    {
        private readonly DadosPublicosDbContext _context;

        public InitialDominiosDbBuilder(DadosPublicosDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultDominiosCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
