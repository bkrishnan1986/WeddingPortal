using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branches;
using Happy.Weddings.Vendor.Core.DTO.Responses.Branch;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class BranchRepository : RepositoryBase<Branches>, IBranchRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<BranchResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<BranchResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public BranchRepository(VendorContext repositoryContext, IMapper mapper, 
            ISortHelper<BranchResponse> sortHelper,
            IDataShaper<BranchResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public async Task<List<BranchDetailsResponse>> GetAllBranches(BranchParameters branchParameters)
        {
            /* var getBranchParameters = new object[] {
                new MySqlParameter("@p_limit", branchParameters.PageSize),
                 new MySqlParameter("@p_offset", (branchParameters.PageNumber - 1) * branchParameters.PageSize),
                 new MySqlParameter("@p_District", branchParameters.Value)
             };

             var branches = await FindAll("CALL SpSearchActiveBranch(@p_limit, @p_offset,@p_District)", getBranchParameters).ToListAsync();
             var mappedbranches = branches.AsQueryable().ProjectTo<BranchResponse>(mapper.ConfigurationProvider);
             var sortedbranches = sortHelper.ApplySort(mappedbranches, branchParameters.OrderBy);
             var shapedbranches = dataShaper.ShapeData(sortedbranches, branchParameters.Fields);

             return await PagedList<Entity>.ToPagedList(shapedbranches, branchParameters.PageNumber, branchParameters.PageSize);  */

            var result = await FindByCondition(branch => branch.DistrictId.Equals(branchParameters.Value))
                       .Include(bo => bo.Branchserviceoffered)
                       .ProjectTo<BranchDetailsResponse>(mapper.ConfigurationProvider)
                       .ToListAsync();
            return result;
        }
        public async Task<Branches> GetBranchByBranchId(int branchId)
        {
            return await FindByCondition(branch => branch.Id.Equals(branchId))
              .Include(bo => bo.Branchserviceoffered)
              .FirstOrDefaultAsync();
        }    

        public async Task<List<BranchResponse>> GetBranchesByBranchId(int branchId)
        {
            var result = await FindByCondition(branch => branch.Id.Equals(branchId))
                        .ProjectTo<BranchResponse>(mapper.ConfigurationProvider)
                        .ToListAsync();
            return result;
        }

        public void CreateBranch(List<Branches> branches)
        {
            CreateRange(branches);
        }  

        public void UpdateBranch(Branches branches)
        {
            Update(branches);
        }

        public void DeleteBranch(Branches branches)
        {
            Delete(branches);
        }
    }
}
