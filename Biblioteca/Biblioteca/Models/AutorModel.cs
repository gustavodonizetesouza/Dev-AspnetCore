using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class AutorModel
    {
        [Key] // Define a propriedade como chave primária
        public int id { get; set; }

        [Required(ErrorMessage ="Campo nome é obrigatório")]
        public string nome { get; set; }

       
    }
}
