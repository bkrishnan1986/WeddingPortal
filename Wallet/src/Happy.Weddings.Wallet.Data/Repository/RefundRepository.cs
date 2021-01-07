#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | RefundRepository --class
//----------------------------------------------------------------------------------------------

#endregion

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Wallet.Core.DTO.Requests.Refund;
using Happy.Weddings.Wallet.Core.DTO.Responses.Refund;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Helpers;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// RefundRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Refund}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IRefundRepository" />
    public class RefundRepository : RepositoryBase<Refund>, IRefundRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<RefundResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<RefundResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RefundRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public RefundRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<RefundResponse> sortHelper,
            IDataShaper<RefundResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Refund.
        /// </summary>
        /// <param name="refundParameter">The Refund parameters.</param>
        /// <returns></returns>
        //public async Task<List<Refund>> GetAllRefund(RefundParameter refundParameter)
        //{
        //    {
        //        var getRefundParameter = new object[]
        //        {
        //            new MySqlParameter("@p_Value", refundParameter.Value),
        //            new MySqlParameter("@p_IsforSingleRefund", refundParameter.IsforSingleRefund),
        //            new MySqlParameter("@p_IsforRaisedBy", refundParameter.IsforRaisedBy)
        //        };

        //        var refund = await FindAll("CALL SpSelectActiveRefund(@p_Value,@p_IsforSingleRefund,@p_IsforRaisedBy)", getRefundParameter).ToListAsync();

        //        return refund;
        //    }
        //}
        public async Task<List<RefundResponse>> GetAllRefund(RefundParameter refundParameter)
        {
            var refunds = FindByCondition(x => x.Id > 0).OrderBy(x => x.Id)
                                   .ProjectTo<RefundResponse>(mapper.ConfigurationProvider);
            SearchByRefundByParameters(ref refunds, refundParameter);
            var result = await refunds.ToListAsync();
            return result;
        }

        private void SearchByRefundByParameters(ref IQueryable<RefundResponse> refunds, RefundParameter refundParameter)
        {
            if (refundParameter.IsforSingleRefund == true)
            {
                refunds = refunds.Where(x => x.Id == refundParameter.Value).OrderBy(x => x.Id);
            }

            if (refundParameter.IsforRaisedBy == true)
            {
               refunds = refunds.Where(x => x.RaisedBy.Equals(refundParameter.Value)).OrderBy(x => x.Id);               
            }
        }

        /// <summary>
        /// Gets the Refund by identifier.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <returns></returns>
        public async Task<Refund> GetRefundById(int refundId)
        {
            var getRefundParameter = new object[]
               {
                    new MySqlParameter("@p_Value", refundId),
                    new MySqlParameter("@p_IsforSingleRefund", true),
                    new MySqlParameter("@p_IsforRaisedBy", false)
               };

            var refund = await FindAll("CALL SpSelectActiveRefund(@p_Value,@p_IsforSingleRefund,@p_IsforRaisedBy)", getRefundParameter).ToListAsync();

            return refund.FirstOrDefault();
        }

        public async Task<List<RefundResponse>> GetRefundsById(int refundId)
        {
            var result = await FindByCondition(wa => wa.Id.Equals(refundId)).OrderBy(x => x.Id)
                  .ProjectTo<RefundResponse>(mapper.ConfigurationProvider)
                  .ToListAsync();
            return result;
        }


        /// <summary>
        /// Creates the Refund.
        /// </summary>
        /// <param name="refund">The Refund.</param>
        public void CreateRefund(Refund refund)
        {
            Create(refund);
        }

        /// <summary>
        /// Updates the Refund.
        /// </summary>
        /// <param name="refund">The Refund.</param>
        public void UpdateRefund(Refund refund)
        {
            Update(refund);
        }
    }
}
