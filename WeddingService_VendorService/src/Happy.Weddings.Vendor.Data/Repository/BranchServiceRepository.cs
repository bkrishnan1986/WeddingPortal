using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class BranchServiceRepository : RepositoryBase<Branchserviceoffered>, IBranchServiceRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<BranchServiceResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<BranchServiceResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public BranchServiceRepository(VendorContext repositoryContext, IMapper mapper,
            ISortHelper<BranchServiceResponse> sortHelper,
            IDataShaper<BranchServiceResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }
        public async Task<PagedList<Entity>> GetBranchServiceOfferedById(BranchServiceParameters branchServiceParameters)
        {
            var getBranchServiceParameters = new object[] {
               new MySqlParameter("@p_limit", branchServiceParameters.PageSize),
                new MySqlParameter("@p_offset", (branchServiceParameters.PageNumber - 1) * branchServiceParameters.PageSize),
                new MySqlParameter("@p_Service", branchServiceParameters.ServiceId),
                new MySqlParameter("@p_Branch", branchServiceParameters.BranchId),
                new MySqlParameter("@p_IsForService", branchServiceParameters.IsForService),
                new MySqlParameter("@p_IsForBranch", branchServiceParameters.IsForBranch)
            };

            var branches = await FindAll("CALL SpSelectActiveBranchServices(@p_limit, @p_offset,@p_Service,@p_Branch," +
                "@p_IsForService,@p_IsForBranch)", getBranchServiceParameters).ToListAsync();
            var mappedbranches = branches.AsQueryable().ProjectTo<BranchServiceResponse>(mapper.ConfigurationProvider);
            var sortedbranches = sortHelper.ApplySort(mappedbranches, branchServiceParameters.OrderBy);
            var shapedbranches = dataShaper.ShapeData(sortedbranches, branchServiceParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedbranches, branchServiceParameters.PageNumber, branchServiceParameters.PageSize);
        }  

        public async Task<List<BranchServiceResponse>> GetBranchServiceOfferedByServiceId(int serviceId)
        {
            var result = await FindByCondition(bs => bs.Id.Equals(serviceId))
                         .ProjectTo<BranchServiceResponse>(mapper.ConfigurationProvider)
                         .ToListAsync();
            return result;
        }

        public void CreateBranchServices(Branchserviceoffered branchserviceoffered)
        {
            Create(branchserviceoffered);
        }      

        public void UpdateBranchServices(Branchserviceoffered branchserviceoffered)
        {
            Update(branchserviceoffered);
        }
    }
}
