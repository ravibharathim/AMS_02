using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class PurchaseStatusRepository : BaseRepository<PurchaseStatus>, IPurchaseStatusRepository
    {
        public PurchaseStatus CreatePurchaseStatus(PurchaseStatus purchaseStatus)
        {
            return Insert(purchaseStatus);
        }

        public PurchaseStatus UpdatePurchaseStatus(PurchaseStatus purchaseStatus)
        {
            return Update(purchaseStatus);
        }

        public List<PurchaseStatus> GetPurchaseStatus()
        {
            return GetAll();
        }
        public PurchaseStatus GetPurchaseStatusByID(int purchaseStatusID)
        {
            return GetByID(purchaseStatusID);
        }
    }
}
