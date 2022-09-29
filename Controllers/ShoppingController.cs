using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avaliacao3Bim_Lp3.Models;
using MvcRazorViews.ViewModels;

namespace Avaliacao3Bim_Lp3.Controllers;

public class ShoppingController : Controller
{
    private static List<LojaViewModel> lojas = 
        new List<LojaViewModel>{
            new LojaViewModel(20, "piso 3", "Jóias Brasil", "Aqui você encontra as Jóias", "Loja", "joia@email.com"),
            new LojaViewModel(21, "piso 3", "Voce encontra aqui", "Vem comprar objetos para sua casa", "Kiosque", "obj@email.com"),
            new LojaViewModel(22, "piso 1", "Delicia Gelada", "Delicia Gelada", "Kiosque", "sorvet@email.com")
        };

    public IActionResult Index()
    {
        return View(lojas);
    }

    public IActionResult Show(int id)
    {
        int idLoja = 0;

        for (int i = 0; i < lojas.Count; i++)
        {
            if (lojas[i].Id.Equals(id))
            {
                idLoja = i;
            }
        }
        return View(lojas[idLoja]);
    }

    public IActionResult Cadastro()
    {
        return View();
    }    

    public IActionResult Admin()
    {
        return View(lojas);
    } 

    public IActionResult Excluir(int id)
    {
        var lojaExcluida = new LojaViewModel();

        foreach (var loja in lojas)
        {
            if (loja.Id.Equals(id))
            {
                lojaExcluida = loja;
            }
        }

        lojas.Remove(lojaExcluida);
        return View(lojaExcluida);
    }

    public IActionResult CadastroResposta(int id, string name, string piso, string desc, string email, string tipo)
    {
        ViewBag.Name = name;
        bool cadastrado = true;

        foreach (var loja in lojas)
        {
            if (loja.Id.Equals(id) || loja.Nome.Equals(name))
            {
                cadastrado = false;
            }
        }

        if (cadastrado)
        {
            lojas.Add(new LojaViewModel(id, piso, name, desc, tipo, email));
        }

        ViewBag.Cadastrado = cadastrado;

        return View();
    }
   }

   