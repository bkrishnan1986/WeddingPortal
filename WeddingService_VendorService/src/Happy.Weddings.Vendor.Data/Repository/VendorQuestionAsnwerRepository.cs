using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class VendorQuestionAsnwerRepository : RepositoryBase<Vendorquestionanswers>, IVendorQuestionAnswerRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<VendorQuestionAnswerResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<VendorQuestionAnswerResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorQuestionAsnwerRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public VendorQuestionAsnwerRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<VendorQuestionAnswerResponse> sortHelper,
            IDataShaper<VendorQuestionAnswerResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public void CreateVendorQuestionAnswer(List<Vendorquestionanswers> vendorquestionanswers)
        {
            CreateRange(vendorquestionanswers);
        }

        public async Task<List<VendorQuestionAnswerResponseDetails>> GetAllVendorQuestionAnswersById(string Id, bool IsForVendor)
        {
            var Result = await FindByCondition(vqa => vqa.VendorLeadId.Equals(Id) && vqa.IsForVendor.Equals(Convert.ToInt16(IsForVendor)))                      
                        .ProjectTo<VendorQuestionAnswerResponseDetails>(mapper.ConfigurationProvider)
                        .ToListAsync(); 
            return Result;   
        }

        public async Task<Vendorquestionanswers> GetVendorQuestionAnswer(string VendorleadId)
        {
            var getVendorQuestionAsnwerParameters = new object[] {
                new MySqlParameter("@VendorLeadId", VendorleadId),
                new MySqlParameter("@QuestionId",0),
                new MySqlParameter("@IsForVendor", true),
            };

            var servicequestions = await FindAll("CALL SpSelectActiveVendorQuestionAnswers(@VendorLeadId, @QuestionId, @IsForVendor)", getVendorQuestionAsnwerParameters).ToListAsync();

            return servicequestions.FirstOrDefault();
        }
        public async Task<List<Vendorquestionanswers>> GetVendorQuestionAnswers(string VendorleadId, int questionId)
        {
            var getVendorQuestionAsnwerParameters = new object[] {
                new MySqlParameter("@p_VendorLeadId", VendorleadId),
                new MySqlParameter("@p_QuestionId",questionId),
                new MySqlParameter("@p_IsForVendor", true),
            };

            return await FindAll("CALL SpSelectActiveVendorQuestionAnswers(@p_VendorLeadId, @p_QuestionId, @p_IsForVendor)", getVendorQuestionAsnwerParameters).ToListAsync();
        }
        public void UpdateVendorQuestionAnswer(List<Vendorquestionanswers> vendorquestionanswers)
        {
            if (vendorquestionanswers != null && vendorquestionanswers.Count > 0)
            {
                foreach (var item in vendorquestionanswers)
                {
                    Delete(item);
                }
            }
        }
    }
}
