using IU360.Sigma.Mvc.Models;
using IU360.Sigma.Mvc.Models.DBEntities;
using IU360.Sigma.Mvc.repositories;
using Microsoft.AspNetCore.Mvc;

namespace IU360.Sigma.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly CadastroDeProdutoDbContext _context;

        public ProdutoController(CadastroDeProdutoDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            List<ProdutoViewModel> produtoList = new List<ProdutoViewModel>();

            if (produtos != null)
            {
                
                foreach (var produto in produtos)
                {
                    var ProdutoViewModel = new ProdutoViewModel()
                    {
                        Id = produto.Id,
                        Name = produto.Name,
                        Description = produto.Description,
                        Price = produto.Price,
                        Quantity = produto.Quantity,
                        CreatedDate = produto.CreatedDate,
                    };
                    produtoList.Add(ProdutoViewModel);
                }
                return View(produtoList);
            }
            return View(produtoList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProdutoViewModel produtoData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produto = new Produto()
                    {
                        Name = produtoData.Name,
                        Description = produtoData.Description,
                        Price = produtoData.Price,
                        Quantity = produtoData.Quantity,
                        CreatedDate = produtoData.CreatedDate

                    };

                    _context.Produtos.Add(produto);
                    _context.SaveChanges();
                    TempData["succesMessage"] = "Product created sucessfuly.";
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["errormessage"] = "Model data is not valid.";
                    return View();

                }
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();
                
            }
        }
    }
}
