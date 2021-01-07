#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | BenefitRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.Benefits;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Benefits
    /// </summary>
    public class BenefitRepository : RepositoryBase<Benefits>, IBenefitsRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<BenefitsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<BenefitsResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OffersRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public BenefitRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<BenefitsResponse> sortHelper,
            IDataShaper<BenefitsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Benefits.
        /// </summary>
        /// <param name="BenefitsParameter">The story parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllBenefits(BenefitsParameter benefitParameter)
        {
            {

                {
                    var getBenefitsParams = new object[] {
                new MySqlParameter("@p_Limit", benefitParameter.PageSize),
                new MySqlParameter("@p_Offset", (benefitParameter.PageNumber - 1) * benefitParameter.PageSize),
                new MySqlParameter("@p_SearchKeyword", benefitParameter.SearchKeyword),
              //  new MySqlParameter("@benefit", benefitParameter.Benefit),
                new MySqlParameter("@p_Value", benefitParameter.Value),
                new MySqlParameter("@p_FromDate", benefitParameter.FromDate),
                new MySqlParameter("@p_ToDate", benefitParameter.ToDate)
            };
                    var Benefits = await FindAll("CALL SpSelectActiveBenefit(@p_Limit, @p_Offset, @p_SearchKeyword, @p_Value, @p_FromDate,@p_ToDate)", getBenefitsParams).ToListAsync();
                    var mappedBenefits = Benefits.AsQueryable().ProjectTo<BenefitsResponse>(mapper.ConfigurationProvider);
                    var sortedBenefits = sortHelper.ApplySort(mappedBenefits, benefitParameter.OrderBy);
                    var shapedBenefits = dataShaper.ShapeData(sortedBenefits, benefitParameter.Fields);

                    return await PagedList<Entity>.ToPagedList(shapedBenefits, benefitParameter.PageNumber, benefitParameter.PageSize);

                }


            }
        }
        /// <summary>
        /// Gets the Benefits by identifier.
        /// </summary>
        /// <param name="BenefitId">The Benefits identifier.</param>
        /// <returns></returns>
        public async Task<Benefits> GetBenefitById(int benefitId)
        {
            var getBenefitParams = new object[] {

                new MySqlParameter("@p_SearchKeyword", "Id"),
                new MySqlParameter("@p_Value", benefitId),
                new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
                };

            var Benefit = await FindAll("CALL SpSelectActiveBenefit(@p_Limit, @p_Offset, @p_SearchKeyword,@p_Value, @p_FromDate, @p_ToDate)", getBenefitParams).ToListAsync();
            return Benefit.FirstOrDefault();
        }

        /// <summary>
        /// Creates the Benefits.
        /// </summary>
        /// <param name="benefits">The Benefits.</param>
        public void CreateBenefit(Benefits benefits)
        {

            Create(benefits);
        }

        /// <summary>
        /// Updates the Benefit.
        /// </summary>
        /// <param name="Benefit">The Benefit.</param>
        public void UpdateBenefit(Benefits benefits)
        {

            Update(benefits);
        }

    }
}

