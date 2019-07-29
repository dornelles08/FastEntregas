﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Model;

namespace FastEntregasWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IGerenciadorUsuario gerenciadorUsuario;

        public UsuarioController(IGerenciadorUsuario _gerenciadorUsuario)
        {
            gerenciadorUsuario = _gerenciadorUsuario;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(gerenciadorUsuario.ObterTodos());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int codigo)
        {
            Usuario usuario = gerenciadorUsuario.Obter(codigo);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                gerenciadorUsuario.Inserir(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = gerenciadorUsuario.Obter(id);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                gerenciadorUsuario.Editar(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuarioModel = gerenciadorUsuario.Obter(id);
            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario usuario)
        {
            gerenciadorUsuario.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}