using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public class PolicyRepository : CosmosDbRepository<Policy>, IPolicyRepository
    {
        private readonly ILogger<PolicyRepository> _logger;

        public PolicyRepository(IOptions<AzureCosmosDbOptions> azureCosmosDbOptions, ILogger<PolicyRepository> logger) : base(azureCosmosDbOptions, "Policy")
        {
            _logger = logger;
        }

        public async Task<Policy> AddAsync(Policy policy)
        {
            return await CreateItemAsync(policy, policy.ProductCategory);
        }

        public async Task<bool> DeleteAsync(Guid id, Policy policy)
        {
            if (policy != null)
            {
                return await DeleteItemAsync(id.ToString(), policy.ProductType.ToString());
            }

            return false;
        }

        public async Task<Policy> FetchByParameterAsync(string policyNumber, ProductType productType)
        {
            var query =
             $"SELECT * FROM c where c.policyNumber = @policyNumber AND c.productCategory = @productCategory ";

            var queryDefinition = new QueryDefinition(query).WithParameter("@policyNumber", policyNumber)
                                                            .WithParameter("@productCategory", productType.ToString());

            var response = await FetchItemsAsync(queryDefinition);

            return response.SingleOrDefault();
        }

        public async Task<IEnumerable<Policy>> FetchListAsync()
        {
            var query =
              $"SELECT * FROM c";
            var queryDefinition = new QueryDefinition(query);

            for (int i= 0; i < 10000; i++)
                {

                var response = await FetchItemsAsync(queryDefinition);
            }

            return new List<Policy>();
        }

        public async Task<Policy> UpdateAsync(Guid id, Policy policy)
        {
            if (policy != null)
            {
                return await UpdateItemAsync(policy, policy.ProductType.ToString());
            }

            return null;
        }

        public async Task<Policy> FetchByPolicyNumberAsync(string policyNumber)
        {
            var query =
             $"SELECT * FROM c where c.policyNumber = @policyNumber";

            var queryDefinition = new QueryDefinition(query).WithParameter("@policyNumber", policyNumber);

            var response = await FetchItemsAsync(queryDefinition);

            return response.SingleOrDefault();
        }

        public async Task<Policy> FetchAsync(Guid id, ProductType productType)
        {
            return await FetchItemAsync(id.ToString(), productType.ToString());
        }
    }
}
