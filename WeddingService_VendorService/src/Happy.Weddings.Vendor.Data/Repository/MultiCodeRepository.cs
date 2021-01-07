#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                         | MultiCodeRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Vendor.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    ///  This class is used to implement CRUD for  MultiCode
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Multicode}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IMultiCodeRepository" />
    public class MultiCodeRepository : RepositoryBase<Multicode>, IMultiCodeRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<MultiCodeResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<MultiCodeResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodeRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public MultiCodeRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<MultiCodeResponse> sortHelper,
            IDataShaper<MultiCodeResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }


        /// <summary>
        /// Gets all multicodes.
        /// </summary>
        /// <param name="multiCodeParameters">The multicode parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllMultiCodes(MultiCodeParameters multiCodeParameters)
        {
            var getMultiCodesParams = new object[] {
                new MySqlParameter("@p_Id", 0),
                new MySqlParameter("@p_Code", multiCodeParameters.Code)
            };

            var multicodes = await FindAll("CALL SpSelectActiveMultiCode(@p_Id, @p_Code)", getMultiCodesParams).ToListAsync();
            var mappedmulticodes = multicodes.AsQueryable().ProjectTo<MultiCodeResponse>(mapper.ConfigurationProvider);
            /*var sortedmulticodes = sortHelper.ApplySort(mappedmulticodes, multiCodeParameters.OrderBy);
            var shapedmulticodes = dataShaper.ShapeData(sortedmulticodes, multiCodeParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedmulticodes, multiCodeParameters.PageNumber, multiCodeParameters.PageSize);   */
            var shapedmulticodes = dataShaper.ShapeData(mappedmulticodes, string.Empty);

            return await PagedList<Entity>.ToPagedList(shapedmulticodes, 0, 0);
        }

        /// <summary>
        /// Gets the multicode by identifier.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public async Task<Multicode> GetMultiCodeById(string code)
        {
            var getMultiCodesParams = new object[] {
                 new MySqlParameter("@p_Id", 0),
                new MySqlParameter("@p_Code", code)
            };

            var multicodes = await FindAll("CALL SpSelectActiveMultiCode(@p_Id, @p_Code)", getMultiCodesParams).ToListAsync();
            return multicodes.FirstOrDefault();
        }

        /// <summary>
        /// Creates the multiCode.
        /// </summary>
        /// <param name="multiCode">The multiCode.</param>
        public void CreateMultiCode(Multicode multiCode)
        {
            Create(multiCode);
        }

        /// <summary>
        /// Updates the multiCode.
        /// </summary>
        /// <param name="multiCode">The multiCode.</param>
        public void UpdateMultiCode(Multicode multiCode)
        {
            Update(multiCode);
        }

        /// <summary>
        /// Deletes the multiCode.
        /// </summary>
        /// <param name="multiCode">The multiCode.</param>
        public void DeleteMultiCode(Multicode multiCode)
        {
            Delete(multiCode);
        }
    }
}
