using IU360.Sigma.Mvc.Models;
using IU360.Sigma.Mvc.Models.DBEntities;
using IU360.Sigma.Mvc.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                    TempData["errormessage"] = "Fill in all mandatory fields.";
                    return View();

                }
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();

            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var produto = _context.Produtos.SingleOrDefault(x => x.Id == Id);

                if (produto != null)
                {
                    var produtoView = new ProdutoViewModel()
                    {
                        Name = produto.Name,
                        Description = produto.Description,
                        Price = produto.Price,
                        Quantity = produto.Quantity,
                        CreatedDate = produto.CreatedDate,
                    };
                    return View(produtoView);
                }
                else
                {
                    TempData["errorMessage"] = "Product details not avaible with the id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult Edit(ProdutoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produto = new Produto()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        Quantity = model.Quantity,
                        CreatedDate = model.CreatedDate,
                    };
                    _context.Produtos.Update(produto);
                    _context.SaveChanges();
                    TempData["succesMessage"] = "Product edited successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model dat is invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var produto = _context.Produtos.SingleOrDefault(x => x.Id == Id);

                if (produto != null)
                {
                    var produtoView = new ProdutoViewModel()
                    {
                        Name = produto.Name,
                        Description = produto.Description,
                        Price = produto.Price,
                        Quantity = produto.Quantity,
                        CreatedDate = produto.CreatedDate,
                    };
                    return View(produtoView);
                }
                else
                {
                    TempData["errorMessage"] = "Product details not avaible with the id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult Delete(ProdutoViewModel model)
        {
            try
            {
                var produto = _context.Produtos.SingleOrDefault(x => x.Id == model.Id);

                if (produto != null)
                {
                    _context.Produtos.Remove(produto);
                    _context.SaveChanges();
                    TempData["succesMessage"] = "Product deleted successfuly!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Product details not avaible with the id: {model.Id}";
                    return RedirectToAction("Index");
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
