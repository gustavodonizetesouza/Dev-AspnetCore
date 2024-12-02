using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class GeneroController : Controller
    {
        readonly private ApplicationDbContext _db;

        public GeneroController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Tela inicial do Generos, listando todos cadastrados
        public IActionResult Index()
        {
            IEnumerable<GeneroModel> genero = _db.genero;
            return View(genero);
        }
        //Carrega o formulario de cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        //Cadastra os generos no banco de dados
        [HttpPost]
        public IActionResult Cadastrar(GeneroModel genero)
        {
            if (ModelState.IsValid)
            {
                _db.genero.Add(genero);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View();
        }
        //Carrega o formulário editar com os dados para edição
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            GeneroModel genero = _db.genero.First(x => x.id == id);

            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }
        //Salva edição no banco de dados
        [HttpPost]
        public IActionResult Editar(GeneroModel genero)
        {
            if (ModelState.IsValid)
            {
                _db.genero.Update(genero);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(genero);
        }
        //Carregar formulario com o dados para exclusão
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            GeneroModel genero = _db.genero.FirstOrDefault(x => x.id == id);

            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }
        //Realizar a exclusão dos dados
        [HttpPost]
        public IActionResult Excluir(GeneroModel genero)
        {

            if (genero == null)
            {

                return NotFound();
            }
            _db.genero.Remove(genero);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
