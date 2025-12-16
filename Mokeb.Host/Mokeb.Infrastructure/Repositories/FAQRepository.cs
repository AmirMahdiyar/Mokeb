using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Domain.Model.Entities;
using Mokeb.Infrastructure.Context;

namespace Mokeb.Infrastructure.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private readonly DbSet<FAQ> _faqs;

        public FAQRepository(MokebDbContext faqs)
        {
            _faqs = faqs.Set<FAQ>();
        }

        public void AddFaq(FAQ fAQ)
        {
            _faqs.Add(fAQ);
        }
    }
}
