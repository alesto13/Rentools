using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentools.Controllers
{
    public class AnnonceController : Controller
    {
        private readonly RentoolsContext _context;

        public AnnonceController(RentoolsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", new AnnonceSearchViewModel());
        }

        [HttpPost]
        public IActionResult Rechercher(AnnonceSearchViewModel recherche)
        {
            var annonces = _context.Annonce
            .Join(_context.CategorieAnnonce,
                  annonce => annonce.IdAnnonce,
                  categorieAnnonce => categorieAnnonce.AnnonceidAnnonce,
                  (annonce, categorieAnnonce) => new { Annonce = annonce, CategorieAnnonce = categorieAnnonce })
            .Join(_context.Categorie,
                  joinedTables => joinedTables.CategorieAnnonce.CategorieidCategorie,
                  categorie => categorie.IdCategorie,
                  (joinedTables, categorie) => new { Annonce = joinedTables.Annonce, Categorie = categorie })
            .Where(joinedTables =>
                (string.IsNullOrEmpty(recherche.NomAnnonce) || joinedTables.Annonce.NomAnnonce.Contains(recherche.NomAnnonce)) &&
                (string.IsNullOrEmpty(recherche.Categorie) || joinedTables.Categorie.Nom.Contains(recherche.Categorie)) &&
                (string.IsNullOrEmpty(recherche.Emplacement) || joinedTables.Annonce.Emplacement.Contains(recherche.Emplacement)))
            .Select(joinedTables => joinedTables.Annonce)
            .ToList();

            return View(annonces);
        }
    }