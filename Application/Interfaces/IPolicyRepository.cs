using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPolicyRepository : IDbRepository
    {
        Task<Policy> AddAsync(
            Policy policy);

        Task<bool> DeleteAsync(
            Guid id, Policy policy);

        Task<Policy> FetchByParameterAsync(
            string policyNumber, ProductType productType);

        Task<Policy> FetchByPolicyNumberAsync(
          string policyNumber);

        Task<Policy> FetchAsync(
         Guid id, ProductType productType);

        Task<IEnumerable<Policy>> FetchListAsync();

        Task<Policy> UpdateAsync(
            Guid id, Policy policy);
    }
}
