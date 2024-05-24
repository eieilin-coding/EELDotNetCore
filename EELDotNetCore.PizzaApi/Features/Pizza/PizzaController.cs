using EELDotNetCore.PizzaApi.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EELDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PizzaController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }
        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        //[HttpPost("Order")]
        //public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        //{
        //    var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
        //    var total = itemPizza.Price;
        //    if (orderRequest.Extras.Length > 0)
        //    {
        //        //select * from Tbl_PizzaExtras where PizzaExtraId in (1,2,3,4)
        //        //foreach (var item in orderRequest.Extras)
        //        //{
        //        //}
        //        var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
        //        total += lstExtra.Sum(x => x.Price);
        //    }
        //    PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
        //    {
        //        PizzaId = orderRequest.PizzaId,
        //        PizzaOrderInvoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
        //        TotalAmount = 0
        //    };

        //}
        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if (orderRequest.Extras.Length > 0)
            {
                // select * from Tbl_PizzaExtras where PizzaExtraId in (1,2,3,4)
                // foreach (var item in orderRequest.Extras)
                // {
                // }

                var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");

            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            return Ok();
        }
    }

}
