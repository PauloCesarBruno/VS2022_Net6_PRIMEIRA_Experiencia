using System.ComponentModel.DataAnnotations;

namespace Brinquedos_NET6.Models
{
    public class Brinquedo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório."),
        MinLength(3, ErrorMessage ="Mínimo de 03 (três) caracteres."),
        MaxLength(100, ErrorMessage ="Máximo 100 (cem) caracteres."),
        Display(Name ="Nome do Brinquedo")]
        public String Nome { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório."),
        Display(Name ="Faixa Etária de Até"),
        MaxLength(80,ErrorMessage ="Máximo 80 (Cinquenta) caracteres Alfanumericos.")]
        public String IdadeDeAte { get; set; }
                                    
        [Display(Name ="Valor"),
        DataType(DataType.Currency)]
        public Decimal Valor { get; set; }
        
        [Display(Name ="Data de Fabricação"),
        DataType(DataType.Date)]
        public DateTime DataDeFabricacao { get; set; }

        public bool EmEstoque { get; set; }
    }
}
