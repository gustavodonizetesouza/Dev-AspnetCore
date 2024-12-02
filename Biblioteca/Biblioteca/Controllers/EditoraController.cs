using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class EditoraController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EditoraController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Tela inicial do Editora, listando todos cadastrados
        public IActionResult Index()
        {
            IEnumerable<EditoraModel> editora = _db.editora;
            return View(editora);
        }
        //Carrega o formulario de cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        //Cadastra as editoras no banco de dados
        [HttpPost]
        public IActionResult Cadastrar(EditoraModel editora)
        {
            if (ModelState.IsValid)
            {
                _db.editora.Add(editora);
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
            EditoraModel editora = _db.editora.First(x => x.id == id);

            if (editora == null)
            {
                return NotFound();
            }
            return View(editora);
        }
        //Salva edição no banco de dados
        [HttpPost]
        public IActionResult Editar(EditoraModel editora)
        {
            if (ModelState.IsValid)
            {
                _db.editora.Update(editora);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editora);
        }
        //Carregar formulario com o dados para exclusão
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EditoraModel editora = _db.editora.FirstOrDefault(x => x.id == id);

            if (editora == null)
            {
                return NotFound();
            }
            return View(editora);
        }
        //Realizar a exclusão dos dados
        [HttpPost]
        public IActionResult Excluir(EditoraModel editora)
        {

            if (editora == null)
            {

                return NotFound();
            }
            _db.editora.Remove(editora);
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
            EditoraModel editora = _db.editora.First(x => x.id == id);

            if (editora == null)
            {
                return NotFound();
            }
            return View(editora);
        }
    }
}
