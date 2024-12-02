using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class BibliotecaModel
    {
        [Key] // Define a propriedade como chave primária
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string titulo { get; set; }
        
        public string subtitulo { get; set; }

        

        


      
    }

   
}
