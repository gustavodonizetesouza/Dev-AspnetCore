namespace Biblioteca.Models
{
    public class ViewModelBiblioteca
    {        
        public BibliotecaModel Biblioteca { get; set; }
        public List<AutorModel> Autores { get; set; }
        public List<EditoraModel> Editoras { get; set; }
        public List<GeneroModel> Generos { get; set; }
    }
}
