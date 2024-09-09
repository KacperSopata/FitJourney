using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.ViewModels.ProductVm;
using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public int AddProduct(NewProductVm product)
        {
            var prod = _mapper.Map<Product>(product);
            var id = _productRepo.AddProduct(prod);
            return id;
        }

        public bool CanUserEditProduct(int productId, string userId, bool isAdmin)
        {
            var product = _productRepo.GetProductById(productId);
            if (product == null) return false;
            return isAdmin || product.UserId == userId;
        }

        public void DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
        }

        public ListProductForListVM GetAllProductForList(int pageSize, int pageNO, string searchString)
        {
            // Zapewnienie, że searchString nie jest null
            searchString = searchString ?? string.Empty;

            // Pobieranie produktów i mapowanie do ViewModel
            var products = _productRepo.GetAllProduct()
                .Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<ProductForListVM>(_mapper.ConfigurationProvider)
                .ToList();

            // Paginacja
            var productToShow = products.Skip(pageSize * (pageNO - 1)).Take(pageSize).ToList();

            // Przygotowanie wyniku
            var productsList = new ListProductForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNO,
                SearchString = searchString,
                Products = productToShow,
                Count = products.Count
            };

            return productsList;
        }

        public ProductDetailVm GetDetails(int productId)
        {
            var product = _productRepo.GetDetails(productId);
            var productVm = _mapper.Map<ProductDetailVm>(product);
            return productVm;
        }

        public NewProductVm GetproductForEdit(int id)
        {
            var product = _productRepo.GetProductById(id);
            var productVm = _mapper.Map<NewProductVm>(product);
            return productVm;
        }

        public void UpdateProduct(NewProductVm model)
        {
            var product = _mapper.Map<Product>(model);
            _productRepo.UpdateProduct(product);
        }
    }
}