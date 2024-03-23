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
                _context.Countries.Add(new Country()
                {
                    Name = "Portugal",
                    States =
                    [
                        new State()
                        {
                            Name = "Lisboa",
                            Cities =
                            [
                                new City { Name = "Lisboa" },
                                new City { Name = "Sintra" },
                                new City { Name = "Cascais" },
                                new City { Name = "Oeiras" },
                            ]
                        },
                        new State()
                        {
                            Name = "Viseu",
                            Cities =
                            [
                                new City { Name = "Viseu" },
                                new City { Name = "São Pedro do Sul" },
                                new City { Name = "Vouzela" },
                                new City { Name = "Oliveira de Frades" },
                            ]
                        },
                    ],
                });

                _context.Countries.Add(new Country()
                {
                    Name = "Espanha",
                    States =
                    [
                        new State()
                        {
                            Name = "Madrid",
                            Cities =
                            [
                                new City { Name = "Madrid" },
                            ]
                        },
                    ],
                });

                _context.Countries.Add(new Country()
                {
                    Name = "França",
                    States =
                    [
                        new State()
                        {
                            Name = "Paris",
                            Cities =
                            [
                                new City { Name = "Paris" },
                            ]
                        },
                    ],
                });

                _context.Countries.Add(new Country()
                {
                    Name = "Itália",
                    States =
                    [
                        new State()
                        {
                            Name = "Roma",
                            Cities =
                            [
                                new City { Name = "Roma" },
                            ]
                        }
                    ],
                });

            }
            await _context.SaveChangesAsync();
        }
    }
}