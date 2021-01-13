using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace CMS_HERA_MVC.Repository
{
    public class ImgProduitRepository : IImgProduitRepository
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public ImgProduitRepository(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public Task<ImgProduit> GetImgProduitById(int id)
        {
            return  _context.ImgProduits
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddImagesToProduit(int id, List<IFormFile> productImages)
        {
            string uniqueFileName = null;
            int count = 1;

            foreach (IFormFile photo in productImages)
            {
                uniqueFileName = UploadedFile(photo);
                ImgProduit imgProduit = new ImgProduit { NbrImgProduit = count, Url = uniqueFileName, ProduitId = id };
                count++;
                _context.Add(imgProduit);
            }

            await _context.SaveChangesAsync();
        }

        private string UploadedFile(IFormFile model)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.CopyTo(fileStream);
                fileStream.Flush();
            }

            return uniqueFileName;
        }

        public async Task DeletePhoto(ImgProduit img_produit)
        {
            _context.ImgProduits.Remove(img_produit);
            
            await _context.SaveChangesAsync();

            //Deleted from the Images Folder
            DeletePhotoFromFolder(img_produit);
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
