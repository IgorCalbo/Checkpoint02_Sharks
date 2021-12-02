using Microsoft.AspNetCore.Mvc;
using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Controllers
{
    public class EscritorController : Controller
    {
        private IEscritorRepository _escritorRepository;

        public EscritorController(IEscritorRepository escritorRepository)
        {
            _escritorRepository = escritorRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Escritor escritor)
        {
            _escritorRepository.Cadastrar(escritor);
            _escritorRepository.Salvar();
            TempData["msg"] = "Escritor cadastrado!";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var lista = _escritorRepository.Listar();
            return View(lista);
        }
    }
}
