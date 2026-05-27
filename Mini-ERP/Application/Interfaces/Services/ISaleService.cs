using Mini_ERP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniERP.Application.Interfaces.Services;

public interface ISaleService
{
    Task<IEnumerable<Sale>> GetAllSalesAsync();
    Task<Sale?> GetSaleByIdAsync(int id);
    Task<Sale> AddSaleAsync(Sale sale);
    Task<Sale> PutSaleAsync(int id, Sale sale);
    Task<Sale> DeleteSaleAsync(int id);
}
