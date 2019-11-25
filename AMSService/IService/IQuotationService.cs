using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSService.Service
{
    public interface IQuotationService
    {
        int CreateQuotation(AMSUtilities.Models.QuotationModel quotationModel);
        AMSUtilities.Models.QuotationModel GetQuotationModel(int? Id = null);
        List<AMSUtilities.Models.QuotationModel> GetQuotations();
        int UpdateQuotation(AMSUtilities.Models.QuotationModel quotationModel);
    }
}
