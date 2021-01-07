using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceAnswer;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class ServiceAnswerRepository : RepositoryBase<Serviceanswer>, IServiceAnswerRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ServiceAnswerResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ServiceAnswerResponse> dataShaper;

        public ServiceAnswerRepository(VendorContext repositoryContext, IMapper mapper, ISortHelper<ServiceAnswerResponse> sortHelper,
                                      IDataShaper<ServiceAnswerResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }


        public void CreateServiceAnswer(List<Serviceanswer> serviceanswer)
        {
            CreateRange(serviceanswer);
        }
        public async Task<List<Serviceanswer>> GetServiceAnswerByQuestionId(int serviceQuestionId)
        {
            var getServicesAnswerParams = new object[] {
                new MySqlParameter("@p_Limit", 0),
                new MySqlParameter("@p_Offset", 0),
                new MySqlParameter("@p_Value", serviceQuestionId),
                new MySqlParameter("@p_IsForSingleData", false),
                new MySqlParameter("@p_IsForQuestion", true),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var serviceanswers = await FindAll("CALL SpSelectActiveServiceAnswer(@p_Limit, @p_Offset, @p_Value,@p_IsForSingleData, @p_IsForQuestion, @p_FromDate, @p_ToDate)", getServicesAnswerParams).ToListAsync();

            return serviceanswers;
        }
        public async Task<Serviceanswer> GetServiceAnswerById(int Id)
        {
            var getServicesAnswerParams = new object[] {
                new MySqlParameter("@p_Limit", 0),
                new MySqlParameter("@p_Offset", 0),
                new MySqlParameter("@p_Value", Id),
                new MySqlParameter("@p_IsForSingleData", true),
                new MySqlParameter("@p_IsForQuestion", false),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var serviceanswers = await FindAll("CALL SpSelectActiveServiceAnswer(@p_Limit, @p_Offset, @p_Value,@p_IsForSingleData, @p_IsForQuestion, @p_FromDate, @p_ToDate)", getServicesAnswerParams).ToListAsync();

            return serviceanswers.FirstOrDefault();
        }
        public void UpdateServiceAnswerRange(List<Serviceanswer> serviceanswer)
        {
            UpdateRange(serviceanswer);
        }
        public void UpdateServiceAnswer(Serviceanswer serviceanswer)
        {
            Update(serviceanswer);
        }
        public async Task<List<ServiceAnswerResponse>> GetServiceAnswersById(int serviceAnswerId)
        {
            var result =  await FindByCondition(sa => sa.Id.Equals(serviceAnswerId))
                 .ProjectTo<ServiceAnswerResponse>(mapper.ConfigurationProvider)
                 .ToListAsync();
            return result;
        }
    }
}
