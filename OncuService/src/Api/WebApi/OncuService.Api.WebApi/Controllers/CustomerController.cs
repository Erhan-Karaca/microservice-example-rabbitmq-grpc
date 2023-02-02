using MediatR;
using Microsoft.AspNetCore.Mvc;
using OncuService.Api.WebApi.Models;
using OncuService.Api.WebApi.Services.LogoService;
using OncuService.Common.Models.RequestModels;

namespace OncuService.Api.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger _logger;

    public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    [HttpGet]
    public Task<CustomerData> Get()
    {
        _logger.LogDebug("grpc customerService start");

        return _customerService.GetById("1");
    }
}
