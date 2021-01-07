using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.LeadManagement.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Core.Helpers;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    /// <summary>
    ///  This class is used to implement CRUD for MultiDetail
    /// </summary>
    /// <seealso cref="RepositoryBase<Multidetail>" />
    /// <seealso cref="IMultiDetailRepository" />
    public class MultiDetailRepository : RepositoryBase<Multidetail>, IMultiDetailRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<MultiDetailResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<MultiDetailResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiDetailRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public MultiDetailRepository(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<MultiDetailResponse> sortHelper,
            IDataShaper<MultiDetailResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all multicodes.
        /// </summary>
        /// <param name="multiDetailParameters">The multidetail parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetMultiDetails(MultiDetailParameters multiDetailParameters)
        {
            var getMultiDetailParams = new object[] {
                new MySqlParameter("@p_Id", multiDetailParameters.Id),
                new MySqlParameter("@p_Code", string.Empty)
            };

            var multidetails = await FindAll("CALL SpSelectActiveMultiDetail(@p_Id, @p_Code)", getMultiDetailParams).ToListAsync();
            var mappedmultidetails = multidetails.AsQueryable().ProjectTo<MultiDetailResponse>(mapper.ConfigurationProvider);
            //var sortedmultidetails = sortHelper.ApplySort(mappedmultidetails, multiDetailParameters.OrderBy);
            //var shapedmultidetails = dataShaper.ShapeData(sortedmultidetails, multiDetailParameters.Fields);
            var shapedmultidetails = dataShaper.ShapeData(mappedmultidetails, string.Empty);

            return await PagedList<Entity>.ToPagedList(shapedmultidetails, 0, 0);
        }

        /// <summary>
        /// Gets the multicode by identifier.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public async Task<List<Multidetail>> GetMultiDetailsByCode(string code)
        {
            var getMultiDetailParams = new object[] {
                new MySqlParameter("@p_Id", 0),
                new MySqlParameter("@p_Code", code)
            };

            return await FindAll("CALL SpSelectActiveMultiDetail(@p_Id, @p_Code)", getMultiDetailParams).ToListAsync();
            //  var mappedmultidetails = multidetails.AsQueryable().ProjectTo<MultiDetailResponse>(mapper.ConfigurationProvider);
            //return multidetails.FirstOrDefault();
            //return multidetails;
        }

        /// <summary>
        /// Gets the multidetailId by identifier.
        /// </summary>
        /// <param name="multidetailId">The multidetailId identifier.</param>
        /// <returns></returns>
        public async Task<Multidetail> GetMultiDetailByMultiDetailId(int multidetailId)
        {
            var getMultiDetailParams = new object[] {
                new MySqlParameter("@p_Id", multidetailId),
                new MySqlParameter("@p_Code", string.Empty)
            };

            var multicodes = await FindAll("CALL SpSelectActiveMultiDetail(@p_Id, @p_Code)", getMultiDetailParams).ToListAsync();

            return multicodes.FirstOrDefault();
        }

        /// <summary>
        /// Creates the multiDetail.
        /// </summary>
        /// <param name="multiDetail">The multiDetail.</param>
        public void CreateMultiDetails(Multidetail multiDetail)
        {
            Create(multiDetail);
        }

        /// <summary>
        /// Updates the multidetail.
        /// </summary>
        /// <param name="multidetailId">The multidetail.</param>
        public void UpdateMultiDetails(Multidetail multiDetail)
        {
            Update(multiDetail);
        }

        /// <summary>
        /// Deletes the multidetail.
        /// </summary>
        /// <param name="multidetailId">The multidetail.</param>
        public void DeleteMultiDetails(Multidetail multiDetail)
        {
            Delete(multiDetail);
        }
    }
}
