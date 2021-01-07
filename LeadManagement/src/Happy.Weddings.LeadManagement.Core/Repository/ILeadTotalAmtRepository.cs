#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | ILeadAssignRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface ILeadTotalAmtRepository : IRepositoryBase<Core.Entity.Leadassign>
    {
        Task<List<Core.Entity.Leadassign>> GetLeadTotalAmount(LeadCountTotAmtParameter leadCountTotAmt, string vendorId);
    }
}
