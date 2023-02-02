using OncuService.Api.WebApi.Models;

namespace OncuService.Api.WebApi.Services.LogoService;

public interface ICustomerService
{
    Task<CustomerData> GetById(String id);
}
