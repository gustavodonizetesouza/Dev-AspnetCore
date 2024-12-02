using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class EmprestimosModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Destino!")]
        public string Destino{ get; set;}

        [Required(ErrorMessage = "Digite o nome do Proprietario!")]
        public string Proprietario { get; set;}

        [Required(ErrorMessage = "Digite o nome do Livro!")]
        public string Livro { get; set;}

        public DateTime data_emprestimo { get; set; }


    }
}
