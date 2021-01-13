using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CMS_HERA_MVC.Repository
{
    public class ProduitRepository : Interfaces.IProduitRepository
    {
        private readonly DataContext _context;

        private readonly IWebHostEnvironment _env;

        public ProduitRepository (DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task AddProduit(Produit p)
        {
            _context.Add(p);

            await _context.SaveChangesAsync();
        }

        public async  Task DeleteProduit(Produit p)
        {
            _context.Produits.Remove(p);
            foreach(ImgProduit img in p.CataloguePhotos)
            {
                DeletePhotoFromFolder(img);
            }
            await _context.SaveChangesAsync();
        }

        public Task<Produit> GetProduitById(int id)
        {
            return _context.Produits.Include(ss => ss.CataloguePhotos)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<Produit> GetProduitByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produit> GetProduitByStatus(int status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produit> GetProduits(string searchString)
        {
            var produits = from s in _context.Produits
                             select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                produits = produits.Where(
                   s => s.Reference.Contains(searchString) ||
                      s.Prix.ToString().Contains(searchString) ||
                      s.Statut_Produit.ToString().Contains(searchString) ||
                      s.Description.Contains(searchString)

               );
            }

            return produits
                .Include(photos=> photos.CataloguePhotos)
                .Include(categorie=>categorie.Categorie)
                .Include(marque=>marque.Marque);
        }


        public async Task UpdateProduit(Produit p)
        {
            _context.Update(p);
            await _context.SaveChangesAsync();
        }

        public bool ProduitExists(int id)
        {
            return _context.Produits.Any(e => e.Id == id);
        }

        private void DeletePhotoFromFolder(ImgProduit img_produit)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, img_produit.Url);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
