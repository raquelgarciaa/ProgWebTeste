﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoCategorias.Models;

namespace ProjetoCategorias.Controllers
{
    public class CategoriaController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
        new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
        new Categoria() { CategoriaId = 2, Nome = "Monitores"},
        new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
        new Categoria() { CategoriaId = 4, Nome = "Mouses"},
        new Categoria() { CategoriaId = 5, Nome = "Desktops"},
        new Categoria() { CategoriaId = 6, Nome = "Gabinetes"}
        };
        // GET: Categoria
        public ActionResult Index()
        {
            return View(categorias);
        }

        // GET: Categoria Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Categoria Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        // GET: Categoria Edit
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Categoria Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(
            categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        // GET: Categoria Details
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // GET: Categoria Delete
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Categoria Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(
            categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }
    }
}