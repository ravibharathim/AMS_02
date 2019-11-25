using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class QuotationRepository : BaseRepository<Quotation>, IQuotationRepository
    {
        public Quotation CreateQuotation(Quotation quotation)
        {
            return Insert(quotation);
        }

        public Quotation UpdateQuotation(Quotation quotation)
        {
            return Update(quotation);
        }

        public List<Quotation> GetQuotations()
        {
            return GetAll();
        }
        public Quotation GetQuotationByID(int quotationID)
        {
            return GetByID(quotationID);
        }
    }
}
