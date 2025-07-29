using AYShop.BLL.Services.Interface;
using AYShop.DAL.DTO.Requests;
using AYShop.DAL.DTO.Responses;
using AYShop.DAL.Models;
using AYShop.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYShop.BLL.Services.Classes
{
    public class BrandService:GenericService<BrandRequest,BrandResponse,Brand>,IBrandService
    {
        public BrandService(IBrandRepository repository) : base(repository) { }

    }
}
