using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSUtilities.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum AlertMessageTypes
    {
        Success =0,
        Info = 1,
        Warning = 2,
        Danger = 3
    }

    /// <summary>
    /// Referring the values from AssetStatus table.
    /// </summary>
    public enum AssetTrackingStatus
    {
        New = 1,
        Assign = 2,
        Unassign = 3,
        Reassign = 4,
        Expire = 5,
        Renew = 6,
        Damage = 7,
        Scraped = 8,
        Retire = 9
    }
    /// <summary>
    /// Refering the values from Componenet table
    /// </summary>
    public enum ComponentTrackingStatus
    {
        New = 1,
        Assign = 2,
        Unassign = 3,
        Reassign = 4,
        Expire = 5,
        Renew = 6,
        Damage = 7,
        Scraped = 8,
        Retire = 9
    }
    public enum AssetCategories
    {
        Hardware = 1,
        Software = 2
    }

    public enum AssetTypes
    {
        Laptop = 1,
        CPU = 2
    }

    public enum ComponentStatus
    {
        Assign = 1,
        Unassign = 2
    }

    public enum QuotationStatus
    {

        InProgress = 1,
        ApprovalPending = 2,
        Approved = 3,
        Rejected = 4,
        Cancelled = 5,
        Completed = 6,
        Closed =7

    }
}
