using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class BibliotecaController : Controller
    {
        readonly private ApplicationDbContext _db;
       

        public BibliotecaController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Tela inicial do Biblioteca, listando todos cadastrados
        public IActionResult Index()
        {
            IEnumerable<BibliotecaModel> biblioteca = _db.biblioteca;
            return View(biblioteca);        
            
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var generos = _db.genero.ToList(); //Lista de genero do banco
            var editoras = _db.editora.ToList(); //Lista de editora do banco
            var autores = _db.autor.ToList(); // Lista de autores do banco
            var viewModel = new ViewModelBiblioteca
            {
                Biblioteca = new BibliotecaModel(),
                Generos = generos,
                Editoras = editoras,
                Autores = autores
            };
            return View(viewModel);
           
        }
        [HttpPost]
        public IActionResult Cadastrar(BibliotecaModel biblioteca)
        {
            if (ModelState.IsValid)
            {
                _db.biblioteca.Add(biblioteca);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View();

        }
    }
}
