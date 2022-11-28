namespace BlazorEcom.Client.Services
{
    public class ProductManager : IProductManager
    {
        private readonly HttpClient _httpClient;

        public ProductManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/product/");
            return result;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ProductModel>($"/api/product/{id}");
            return result;
        }

        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            var result = await _httpClient.PostAsJsonAsync<ProductModel>("/api/product/add/", product);
            if (result.IsSuccessStatusCode)
                return product;
            return null;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/product/delete/{id}");
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/product/edit/{id}", product);
            if (result.IsSuccessStatusCode)
                return product;
            return null;
        }
    }
    public interface IProductManager
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> AddProduct(ProductModel product);
        Task<bool> RemoveProduct(int id);
        Task<ProductModel> UpdateProduct(ProductModel product, int id);
    }
}


