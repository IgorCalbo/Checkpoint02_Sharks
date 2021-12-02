using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sharks.Checkpoint02.Models;
using Sharks.Checkpoint02.Repositories;
using Sharks.Checkpoint02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;
        private IEscritorRepository _escritorRepository;
        private IEditoraRepository _editoraRepository;
        private ILivroEscritorRepository _livroEscritorRepository;

        // Construtor que recebe por injeção de dependência o Context
        public LivroController(ILivroRepository livroRepository, IEscritorRepository escritorRepository,
            IEditoraRepository editoraRepository, ILivroEscritorRepository livroEscritorRepository)
        {
            _livroRepository = livroRepository;
            _escritorRepository = escritorRepository;
            _editoraRepository = editoraRepository;
            _livroEscritorRepository = livroEscritorRepository;
        }

        [HttpPost]
        public IActionResult Adicionar(LivroEscritor livroEscritor)
        {
            _livroEscritorRepository.Cadastrar(livroEscritor);
            _livroEscritorRepository.Salvar();
            TempData["msg"] = "Escritor adicionado!";
            return RedirectToAction("Detalhar", new { id = livroEscritor.LivroId });
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            // Pesquisa livro pelo Id, incluindo o relacionamento com a editora
            var livro = _livroRepository.BuscarPorId(id);

            // Listar todos os Escritores
            var lista = _escritorRepository.Listar();

            // Listar todos os escritores relacionados com o livro
            var escritoresLivro = _escritorRepository.BuscarPorLivroId(id);

            // Filtrar a lista, removendo os escritores associados com o livro
            var listaFiltrada = lista.Where(m => !escritoresLivro.Any(m1 => m.EscritorId == m1.EscritorId));

            var viewModel = new LivroViewModel()
            {
                Livro = livro,
                Escritores = escritoresLivro,
                OpcoesEscritores = new SelectList(listaFiltrada, "EscritorId", "Nome")
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _livroRepository.Remover(id);
            _livroRepository.Salvar();
            TempData["msg"] = "Livro removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarEditoras();
            var livro = _livroRepository.BuscarPorId(id);
            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(Livro livro)
        {
            _livroRepository.Atualizar(livro);
            _livroRepository.Salvar();
            TempData["msg"] = "Livro atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarEditoras();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            _livroRepository.Cadastrar(livro);
            _livroRepository.Salvar();
            TempData["msg"] = "Livro cadastrado!";
            return RedirectToAction("Detalhar", new { id = livro.LivroId });
        }

        // Enviar a lista de opções para o select
        private void CarregarEditoras()
        {
            var lista = _editoraRepository.Listar();
            ViewBag.editoras = new SelectList(lista, "EditoraId", "Nome");
        }

        public IActionResult Index(string nomeBusca, Genero? generoBusca)
        {
            // Pesquisar por parte do nome
            var lista = _livroRepository.BuscarPor(m =>
                (m.Nome.Contains(nomeBusca) || nomeBusca == null) &&
                (m.Genero == generoBusca || generoBusca == null));
            // Envia a lista de livros para a view 
            return View(lista);
        }
    }
}
