using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ICurrencyRepository
    {
         Task<IReadOnlyList<Currency>> GetAllCurrencies();
         Task FetchAllCurrencies(string[] currenciesString);
         Task FetchCurrency(string currencyCode);
    }
}