using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "O campo {0} não pode ter mais de {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; } = null!;
    }
}