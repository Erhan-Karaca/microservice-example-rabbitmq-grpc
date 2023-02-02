using Grpc.Core;

namespace GrpcLogoServiceCustomer;

public class CustomerService : Customer.CustomerBase
{
    public CustomerService()
    {

    }

    public override Task<CustomerResponse> GetCustomerById(CustomerRequest request, ServerCallContext context)
    {
        CustomerResponse result = new CustomerResponse()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Customer Name"
        };
        return Task.FromResult(result);
    }
}
