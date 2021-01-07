using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class CategoryDetailsRepository : RepositoryBase<Categorydetails>, ICategoryDetailsRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<CategoryDetailsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<CategoryDetailsResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDetailsRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public CategoryDetailsRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<CategoryDetailsResponse> sortHelper,
            IDataShaper<CategoryDetailsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

       /* public async Task<IEnumerable<CategoryResponse>> GetCategoryDetailsById(int categoryId)
        {
            /*  var getProfilePictureParameters = new object[] {
                  new MySqlParameter("@limit", null),
                  new MySqlParameter("@offset", null),
                  new MySqlParameter("@value", categoryId),
                  new MySqlParameter("@IsForVendor", true)
              };

              var categorydetails = await FindAll("CALL SpSelectActiveCategoryDetails(@limit, @offset, @value, @IsForVendor)", getProfilePictureParameters).ToListAsync();
              return categorydetails.FirstOrDefault();   */
           /* return await FindByCondition(category => category.CategoryId.Equals(categoryId))
               .ProjectTo<CategoryResponse>(mapper.ConfigurationProvider)
               .ToListAsync();
        }   */

        public async Task<Categorydetails> GetCategoryDetailsById(int categoryId)
        {
            return await FindByCondition(category => category.CategoryId.Equals(categoryId))
                .Include(pp => pp.Profilepictures)
               .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<CategoryResponse>> GetCategoryDetailsVendorId(string vendorId)
        {
            return await FindByCondition(category => category.VendorId.Equals(vendorId) || category.VendorName.Equals(vendorId))
                /*.Include(pp => pp.Profilepictures)
                .Include(sc => sc.Subcategory)   */
                .ProjectTo<CategoryResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Creates the CategoryDetails.
        /// </summary>
        /// <param name="event">The event.</param>
        public void CreateCategoryDetails(Categorydetails categorydetails)
        {
            Create(categorydetails);
        }

        /// <summary>
        /// Creates the CategoryDetails.
        /// </summary>
        /// <param name="event">The event.</param>
        public void UpdateCategoryDetailsData(Categorydetails categorydetails)
        {
            Update(categorydetails);
        }
    }
}
