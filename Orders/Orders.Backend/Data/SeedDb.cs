
using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CkeckCountriesAsync();
            await CkeckCategoriesAsync();

        }

        private async Task CkeckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnologia" });
                _context.Categories.Add(new Category { Name = "Mascotes" });
                _context.Categories.Add(new Category { Name = "Bebidas" });
                _context.Categories.Add(new Category { Name = "Comida" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CkeckCountriesAsync()
        {
            if (!_context.Countries.Any()) 
            {
                _context.Countries.Add(new Country { Name = "Portugal" });
                _context.Countries.Add(new Country { Name = "Espanha" });
                _context.Countries.Add(new Country { Name = "França" });
                _context.Countries.Add(new Country { Name = "Itália" });
            }
            await _context.SaveChangesAsync();
        }
    }
}
