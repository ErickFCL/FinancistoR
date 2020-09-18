using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancistoR.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancistoR.Controllers
{
    public class AccountController : Controller
    {
        private FinancistoContext _context;
        public AccountController(FinancistoContext context)
        {
            _context = context;

        }
       // [HttpGet]
       public ActionResult Index()
        {

           // var context = new FinancistoContext();
            //ViewBag.Accounts = _context.Accounts.ToList();
            //otra forma//
             var accounts = _context.Accounts.ToList();
            // ViewBag.Accounts = GetDatos();
            return View("Index",accounts);
            //return RedirecToAction("Edit",new{id=1,nomre="erick"}); //account/edit?id=1&nombre=erick

        }
        //[HttpGet]
        public ActionResult Create()
        {
          
            return View("Create",new Account());
        }
        [HttpPost]
        public ActionResult Create(Account account)
        {
            //if (account.Name == null || account.Name == "")
                //ModelState.AddModelError("Name1", "El campo Nombre es requerido");
            //var account = new Account { Name = Name, Type = Type, Currency = Currency, Amount = Amount };
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();

                // ViewBag.Accounts = _context.Accounts.ToList();
                return RedirectToAction("Index");
                //return account.Type + " " + account.Name + " " + account.Currency + " " + account.Amount;
            }
            return View("Create",account);
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Types = new List<string> { "Efectivo", "Debito", "Credito" };
            var account = _context.Accounts.Where(o => o.Id == id).FirstOrDefault();
            
            return View("Edit", account);
        }
        [HttpPost]
        public ActionResult Edit(Account account)
        {
            // var dbAccount = _context.Accounts.Where(o => o.Id == account.Id).FirstOrDefault();
            //dbAccount.Name = account.Name;
            //_context.SaveChanges();

            if (ModelState.IsValid)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account = account;
            return View("edit");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = _context.Accounts.Where(o => o.Id == id).FirstOrDefault();
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /* public ViewResult Create2()
         {
          ViewBag.Hello = "Hola mundo";
             return View("Create");
         }*/


        /*YA ESTA EN SQL
        private List<Account> GetDatos()
        {
            //List<bool> data = new List<bool>();
            var data = new List<Account>();
            data.Add(new Account{
                Type = "Efectivo",
                Name = "Billetera",
                Currency = "Soles",
                Amount = 0
             });
            data.Add(new Account
            {
                Type = "Debito",
                Name = "BCP Sueldo bit2bit",
                Currency = "Soles",
                Amount = 1000
            });
            data.Add(new Account
            {
                Type = "Efectivo",
                Name = "BCP Tarjeta de Credito",
                Currency = "Soles",
                Amount = 1000
            });
            return data;
        }
        */
    }
}
