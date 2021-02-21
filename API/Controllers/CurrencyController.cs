using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository _repo;
        private static readonly string[] _currenciesString = new[]
        {
            "USD/ILS", "GBP/EUR", "EUR/JPY", "EUR/USD"
        };
        public CurrencyController(ICurrencyRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("fetch")]
        public async Task<string> FetchAllCurrencies()
        {

            await _repo.FetchAllCurrencies(_currenciesString);
            return "fetching all currencies";

        }

        [HttpGet]
        public async Task<ActionResult<List<Currency>>> GetAllCurrencies()
        {
            var currenciesExchanges = await _repo.GetAllCurrencies();

            return Ok(currenciesExchanges);

        }


        [HttpGet("{currencyCode}")]
        public async Task FetchCurrency(string currencyCode)
        {

            await _repo.FetchCurrency(currencyCode);

        }

    }
}