using Orders.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Shared.Entities
{
    public class State : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Distrito")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode ter mais de {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }
        public Country? Country { get; set; }

        [Display(Name = "Cidades")]
        public ICollection<City>? Cities { get; set; }
        public int CitiesNumber => (Cities == null || Cities!.Count == 0) ? 0 : Cities.Count;
    }
}
