using Microsoft.AspNetCore.Mvc;
using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Repositories;
using Sharks.Checkpoint02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Controllers
{
    public class EditoraController : Controller
    {
        private IEditoraRepository _editoraRepository;

        public EditoraController(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new EditoraViewModel()
            {
                Lista = _editoraRepository.Listar()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(Editora editora)
        {
            _editoraRepository.Cadastrar(editora);
            _editoraRepository.Salvar();
            TempData["msg"] = "Editora cadastrada!";
            return RedirectToAction("Index");
        }
    }
}
