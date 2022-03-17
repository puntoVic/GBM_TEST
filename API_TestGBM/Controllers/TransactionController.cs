using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.Responses;
using Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_TestGBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
       

        // POST api/<TransactionController>
        [HttpPost]
        public Response Transaction([FromBody] Transaction transaction)
        {
            if(transaction.Operation == "BUY")
                return B_Transaction.ExecutePurchase(transaction);
            else
                return B_Transaction.ExecuteSale(transaction);
        }
        
        
    }
}
