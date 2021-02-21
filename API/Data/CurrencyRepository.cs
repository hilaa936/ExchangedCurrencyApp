using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.services;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DBContext _context;
        private readonly CurrencyExchangesService _service;
    
        public CurrencyRepository(DBContext context)
        {
            _context = context;
            _service = new CurrencyExchangesService();
        }

        public async Task FetchAllCurrencies(string[] currenciesString)
        {
            foreach (string str in currenciesString)
            {
                string code = str.Replace("/", "_");
                await FetchCurrency(code);
            }
        }


        public async Task FetchCurrency(string currencyCode)
        {
            decimal value = await _service.FetchCurrencyRateAsync(currencyCode);

            // checked that the name isnt already exist

            var CurrencyExist = await _context.CurrencyExchange.FirstOrDefaultAsync(c => c.Name == currencyCode); //AddAsync(currency);
            
            if (CurrencyExist == null)
            {
                await _context.CurrencyExchange.AddAsync(new Currency() { Name = currencyCode, Value = value, UpdatedOn = DateTime.Now });
            }
            else if (CurrencyExist.Value != value)
            {
                CurrencyExist.Value = value;
                CurrencyExist.UpdatedOn = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Currency>> GetAllCurrencies()
        {
            return await _context.CurrencyExchange.ToListAsync();//.lis
        }
    }
}
