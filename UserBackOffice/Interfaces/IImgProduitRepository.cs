using UserBackOffice.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IImgProduitRepository
    {
        Task<ImgProduit> GetImgProduitById(int id);
        Task DeletePhoto(ImgProduit img_produit);
        Task AddImagesToProduit(int id, List<IFormFile> productImages);
    }
}
