using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrder CreatePurchaseOrder(PurchaseOrder purchaseOrder);
        PurchaseOrder GetPurchaseOrderByID(int purchaseOrderID);
        List<PurchaseOrder> GetPurchaseOrders();
        PurchaseOrder UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
    }
}