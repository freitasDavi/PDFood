using Food.API.DTO.Products;
using System.Text.Json;

namespace Food.API.Infra
{
    public static class FakeStoreClient
    {
        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://fakestoreapi.com/")
        };

        public static async Task<int> AddNewProductToFakeStore (FakesStoreProductDTO dto)
        {
            using StringContent jsonContent = new StringContent(
                JsonSerializer.Serialize(
                    new
                    {
                        dto
                    }));

            using HttpResponseMessage response = await httpClient.PostAsync("products", jsonContent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadFromJsonAsync<FakeStoreProductResponseDTO>();

            return jsonResponse.Id;
        }


        public static async Task UpdateProductInTheFakeStore (FakesStoreProductDTO dto)
        {
            using StringContent jsonContent = new StringContent(
                JsonSerializer.Serialize(
                    new
                    {
                        dto
                    }));

            using HttpResponseMessage response = await httpClient.PutAsync($"products/{dto.Id}", jsonContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
