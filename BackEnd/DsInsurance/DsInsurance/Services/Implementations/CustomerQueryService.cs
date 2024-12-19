using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly IRepository<CustomerQuery> _queryRepository;
        private readonly IMapper _mapper;

        public CustomerQueryService(IRepository<CustomerQuery> queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public List<CustomerQueryDto> GetAllQueries()
        {
            var queries = _queryRepository.GetAll()
                .Include(q => q.Customer)
                .Include(q => q.PolicyAccount)
                .Include(q => q.Employee)
                .ToList();

            if (!queries.Any())
                throw new NotFoundException("CustomerQueries");

            return _mapper.Map<List<CustomerQueryDto>>(queries);
        }

        public List<CustomerQueryDto> GetAllQueriesCustomerId(Guid customerId)
        {
            var queries = _queryRepository.GetAll()
                .Include(q => q.Customer)
                .Include(q => q.PolicyAccount)
                .Include(q => q.Employee)
                .Where(q=> q.CustomerId == customerId)
                .ToList();

            if (!queries.Any())
                throw new NotFoundException("CustomerQueries");

            return _mapper.Map<List<CustomerQueryDto>>(queries);
        }


        public CustomerQueryDto GetQueryById(Guid queryId)
        {
            var query = _queryRepository.GetAll()
                .Include(q => q.Customer)
                .Include(q => q.PolicyAccount).ThenInclude(pa=>pa.InsuranceScheme)
                .Include(q => q.Employee)
                .FirstOrDefault(q => q.QueryId == queryId);

            if (query == null)
                throw new NotFoundException("CustomerQuery");

            return _mapper.Map<CustomerQueryDto>(query);
        }

        public Guid AddCustomerQuery(CustomerQueryDto queryDto)
        {
            var query = _mapper.Map<CustomerQuery>(queryDto);
            _queryRepository.Add(query);
            return query.QueryId;
        }

        public void UpdateCustomerQuery(CustomerQueryDto queryDto)
        {
            var updatedQuery = _mapper.Map<CustomerQuery>(queryDto);
            var existingQuery = _queryRepository.GetAll().AsNoTracking().FirstOrDefault(q => updatedQuery.QueryId == q.QueryId);

            if (existingQuery == null)
                throw new NotFoundException("CustomerQuery");

            _queryRepository.Update(updatedQuery);
        }

        public void DeleteCustomerQuery(Guid queryId)
        {
            var query = _queryRepository.GetById(queryId);
            if (query == null)
                throw new NotFoundException("CustomerQuery");

            query.IsActive = false; 
            _queryRepository.Update(query);
        }
    }
}
