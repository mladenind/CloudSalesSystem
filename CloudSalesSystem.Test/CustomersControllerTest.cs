using CloudSalesSystem.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace CloudSalesSystem.Test
{
    public class CustomersControllerTest
    {
        private readonly CustomersController _controller;
        private readonly IMediator _mediator;

        public CustomersControllerTest()
        {
            _mediator = new Mock<IMediator>().Object;
            _controller = new CustomersController(_mediator);
        }

        [Fact]
        public void GetAccountsForCustomerTest()
        {
            var result = _controller.GetAccountsForCustomer();
            Assert.Equal(200, ((IStatusCodeActionResult)result.Result).StatusCode);
        }
    }
}