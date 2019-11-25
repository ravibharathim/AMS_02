using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSService.Service
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly IVendorService _vendorService;
        public QuotationService(IQuotationRepository quotationRepository,IVendorService vendorService)
        {
            _quotationRepository = quotationRepository;
            _vendorService = vendorService;
        }

        public QuotationModel GetQuotationModel(int? Id = null)
        {
            if (Id.HasValue)
            {
                Quotation quotation = _quotationRepository.GetQuotationByID(Id.Value);
                if (quotation != null)
                {
                    return new QuotationModel
                    {
                        ID = quotation.ID,
                        VendorID = quotation.VendorID,
                        AssetRequestID = quotation.AssetRequestID,
                        QuotationFilePath = quotation.QuotationFilePath,
                        QuotationStatusID = quotation.QuotationStatusID,
                        QuotationReceivedDate = quotation.QuotationReceivedDate,
                        Vendorddl = _vendorService.GetDropdownVendors()
                    };
                }
                else
                {
                    throw new EntryPointNotFoundException();
                }
            }
            else
            {
                return new QuotationModel {

                    Vendorddl = _vendorService.GetDropdownVendors()
                };
            }
        }
        public List<QuotationModel> GetQuotations()
        {
            var quotations = _quotationRepository.GetQuotations();
            if(quotations != null && quotations.Count > 0)
            {
                return quotations.Select(q => new QuotationModel
                {
                    ID = q.ID,
                    VendorID = q.VendorID,
                    VendorName = q.Vendor.Name,
                    AssetRequestID = q.AssetRequestID,
                    QuotationFilePath = q.QuotationFilePath,
                    QuotationStatusID = q.QuotationStatusID,
                    QuotationStatus = q.QuotationStatus.Description,
                    QuotationReceivedDate = q.QuotationReceivedDate
                }).ToList();
            }
            else
            {
                return new List<QuotationModel> { };
            }
        }

        public int CreateQuotation(QuotationModel quotationModel)
        {
            Quotation quotation = null;
            quotation = this._quotationRepository.CreateQuotation(new Quotation()
            {
                VendorID = quotationModel.VendorID,
                AssetRequestID = quotationModel.AssetRequestID,
                QuotationFilePath = quotationModel.QuotationFilePath,
                QuotationStatusID = (int)AMSUtilities.Enums.QuotationStatus.ApprovalPending,
                QuotationReceivedDate = quotationModel.QuotationReceivedDate
            });

            return quotation.ID;
        }

        public int UpdateQuotation(QuotationModel quotationModel)
        {
            Quotation quotation = _quotationRepository.GetQuotationByID(quotationModel.ID);
            if (quotation != null)
            {
                quotation.VendorID = quotationModel.VendorID;
                quotation.AssetRequestID = quotationModel.AssetRequestID;
                quotation.QuotationFilePath = quotationModel.QuotationFilePath;
                quotation.QuotationStatusID = quotationModel.QuotationStatusID;
                quotation.QuotationReceivedDate = quotationModel.QuotationReceivedDate;
            }

            _quotationRepository.UpdateQuotation(quotation);

            return quotation.ID;
        }


    }
}
