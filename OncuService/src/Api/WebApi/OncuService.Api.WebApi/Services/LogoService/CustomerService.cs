using GrpcLogoServiceCustomer;
using OncuService.Api.WebApi.Models;

namespace OncuService.Api.WebApi.Services.LogoService;

public class CustomerService : ICustomerService
{
    private readonly Customer.CustomerClient _customerClient;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(Customer.CustomerClient customerClient, ILogger<CustomerService> logger)
    {
        _customerClient = customerClient;
        _logger = logger;
    }

    public async Task<CustomerData> GetById(string id)
    {
        _logger.LogDebug("Grpc customerService client created, request = {@id}", id);
        var response = await _customerClient.GetCustomerByIdAsync(new CustomerRequest { Id = id });
        _logger.LogDebug("Grpc customerService response {@response}", response);
        return MapToBasketData(response);
    }

    private CustomerData MapToBasketData(CustomerResponse customerResponse)
    {
        if (customerResponse == null)
        {
            return null;
        }

        var map = new CustomerData
        {
            Id = customerResponse.Id,
            Name = customerResponse.Name
        };

        return map;
    }
}
