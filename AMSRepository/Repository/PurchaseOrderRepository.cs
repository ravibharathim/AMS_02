using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrder CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            return Insert(purchaseOrder);
        }

        public PurchaseOrder UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            return Update(purchaseOrder);
        }

        public List<PurchaseOrder> GetPurchaseOrders()
        {
            return GetAll();
        }
        public PurchaseOrder GetPurchaseOrderByID(int purchaseOrderID)
        {
            return GetByID(purchaseOrderID);
        }
    }
}
