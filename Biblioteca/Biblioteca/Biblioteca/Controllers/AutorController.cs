using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class AutorController : Controller
    {
        readonly private ApplicationDbContext _db;

        public AutorController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Tela inicial do Autor, listando todos cadastrados
        public IActionResult Index()
        {
            IEnumerable<AutorModel> autor = _db.autor;
            return View(autor);
        }
        //Carrega o formulario de cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        //Cadastra os autores no banco de dados
        [HttpPost]
        public IActionResult Cadastrar(AutorModel autor)
        {
            if (ModelState.IsValid)
            {
                _db.autor.Add(autor);
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
            AutorModel autor = _db.autor.First(x => x.id == id);

            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }
        //Salva edição no banco de dados
        [HttpPost]
        public IActionResult Editar(AutorModel autor)
        {
            if (ModelState.IsValid)
            {
                _db.autor.Update(autor);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(autor);
        }
        //Carregar formulario com o dados para exclusão
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AutorModel autor = _db.autor.FirstOrDefault(x => x.id == id);

            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }
        //Realizar a exclusão dos dados
        [HttpPost]
        public IActionResult Excluir(AutorModel autor)
        {

            if (autor == null)
            {

                return NotFound();
            }
            _db.autor.Remove(autor);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        //Carrega o formulário apenas para visualizar o cadastro
        [HttpGet]
        public IActionResult Visualizar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AutorModel autor = _db.autor.First(x => x.id == id);

            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }
    }


}
