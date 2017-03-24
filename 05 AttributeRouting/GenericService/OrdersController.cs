using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GenericService
{
    public class OrdersController : ApiController
    {
        [Route("customers/{customerId:int}/orders")]
        [HttpGet]
        public IQueryable<string> FindOrdersByCustomer(int customerId)
        {
            var orders = new string[] {"order1", "order2"};
            return orders.AsQueryable();
        }
    }
}