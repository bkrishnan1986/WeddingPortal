#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | RepositoryWrapper class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Core.Helpers;
using Happy.Weddings.LeadManagement.Core.Repository;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Data.Repository;
using Happy.Weddings.LeadManagement.Core.DTO.Responses.MultiCode;
using Happy.Weddings.LeadManagement.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Lead.Data.Repository;

#endregion

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        private LeadContext repositoryContext { get; set; }


        /// <summary>
        /// Gets the MultiCode.
        /// </summary>
        private IMultiCodeRepository multiCode { get; set; }
        /// <summary>
        /// Gets the MultiDetail.
        /// </summary>
        private IMultiDetailRepository multidetail { get; set; }
        /// <summary>
        /// Gets the lead.
        /// </summary>
        private ILeadDataCollectionRepository LeadData { get; set; }
        /// <summary>
        /// Gets the lead.
        /// </summary>
        /// <value>
        /// The lead.
        /// </value>
        private ILeadRepository Leads { get; set; }
        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        /// <value>
        /// The quote.
        /// </value>
        private ILeadQuoteRepository LeadQuote { get; set; }
        /// <summary>
        /// Gets or sets the Validation.
        /// </summary>
        /// <value>
        /// The Validation.
        /// </value>
        private ILeadValidationRepository LeadValidation { get; set; }
        /// <summary>
        /// Gets or sets the Assign.
        /// </summary>
        /// <value>
        /// The Assign.
        /// </value>
        private ILeadAssignRepository LeadAssign { get; set; }

        /// <summary>
        /// Gets or sets the lead status.
        /// </summary>
        /// <value>
        /// The lead status.
        /// </value>
        private ILeadStatusRepository LeadStatus { get; set; }

        private ILeadCountRepository LeadCount { get; set; }

        private ILeadTotalAmtRepository LeadTotalAmt { get; set; }


        /// <summary>
        /// The multicode sort helper
        /// </summary>
        private ISortHelper<MultiCodeResponse> multicodeSortHelper;
        /// <summary>
        /// The multidetail sort helper
        /// </summary>
        private ISortHelper<MultiDetailResponse> multidetailSortHelper;
        /// <summary>
        /// The lead data collection sort helper
        /// </summary>
        private ISortHelper<LeadDataCollectionResponse> leadDataCollectionSortHelper;
        /// <summary>
        /// The lead Quote sort helper
        /// </summary>
        private ISortHelper<LeadQuoteResponse> leadQuoteSortHelper;
        /// <summary>
        /// The lead Validation sort helper
        /// </summary>
        private ISortHelper<LeadValidationResponse> leadValidationSortHelper;
        /// <summary>
        /// The lead Assign sort helper
        /// </summary>
        private ISortHelper<LeadAssignResponse> leadAssignSortHelper;

        /// <summary>
        /// The lead Status sort helper
        /// </summary>
        private ISortHelper<LeadStatusResponse> leadStatusSortHelper;

        /// <summary>
        /// The multidetail data shaper
        /// </summary>
        private IDataShaper<MultiDetailResponse> multidetailDataShaper;
        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<MultiCodeResponse> multicodeDataShaper;
        /// <summary>
        /// The lead data collection data shaper
        /// </summary>
        private IDataShaper<LeadDataCollectionResponse> leadDataCollectionDataShaper;
        /// <summary>
        /// The lead Quote data shaper
        /// </summary>
        private IDataShaper<LeadQuoteResponse> leadQuoteDataShaper;
        /// <summary>
        /// The lead Validation data shaper
        /// </summary>
        private IDataShaper<LeadValidationResponse> leadValidationDataShaper;
        /// <summary>
        /// The lead Assign data shaper
        /// </summary>
        private IDataShaper<LeadAssignResponse> leadAssignDataShaper;
        /// <summary>
        /// The lead Status data shaper
        /// </summary>
        private IDataShaper<LeadStatusResponse> leadStatusDataShaper;

        /// <summary>
        /// Gets the multicode.
        /// </summary>
        public IMultiCodeRepository MultiCodes
        {
            get
            {
                if (multiCode == null)
                {
                    multiCode = new MultiCodeRepository(repositoryContext, mapper, multicodeSortHelper, multicodeDataShaper);
                }
                return multiCode;
            }
        }
        /// <summary>
        /// Gets the multidetail.
        /// </summary>
        public IMultiDetailRepository MultiDetails
        {
            get
            {
                if (multidetail == null)
                {
                    multidetail = new MultiDetailRepository(repositoryContext, mapper, multidetailSortHelper, multidetailDataShaper);
                }
                return multidetail;
            }
        }
        /// <summary>
        /// Gets the lead Data.
        /// </summary>
        /// <value>
        /// The lead Data.
        /// </value>
        public ILeadDataCollectionRepository LeadDataRepository
        {
            get
            {
                if (LeadData == null)
                {
                    LeadData = new LeadDataCollectionRepository(repositoryContext, mapper, leadDataCollectionSortHelper, leadDataCollectionDataShaper);
                }
                return LeadData;
            }
        }
        /// <summary>
        /// Gets the lead.
        /// </summary>
        /// <value>
        /// The lead.
        /// </value>
        public ILeadRepository LeadRepository
        {
            get
            {
                if (Leads == null)
                {
                    Leads = new LeadRepository(repositoryContext, mapper);
                }
                return Leads;
            }
        }
        /// <summary>
        /// Gets the lead Quote.
        /// </summary>
        /// <value>
        /// The lead Quote.
        /// </value>
        public ILeadQuoteRepository LeadQuoteRepository
        {
            get
            {
                if (LeadQuote == null)
                {
                    LeadQuote = new LeadQuoteRepository(repositoryContext, mapper, leadQuoteSortHelper, leadQuoteDataShaper);
                }
                return LeadQuote;
            }
        }
        /// <summary>
        /// Gets the lead Validation.
        /// </summary>
        /// <value>
        /// The lead Validation.
        /// </value>
        public ILeadValidationRepository LeadValidationRepository
        {
            get
            {
                if (LeadValidation == null)
                {
                    LeadValidation = new LeadValidationRepository(repositoryContext, mapper, leadValidationSortHelper, leadValidationDataShaper);
                }
                return LeadValidation;
            }
        }
        /// <summary>
        /// Gets the lead Assign.
        /// </summary>
        /// <value>
        /// The lead Assign.
        /// </value>
        public ILeadAssignRepository LeadAssignRepository
        {
            get
            {
                if (LeadAssign == null)
                {
                    LeadAssign = new LeadAssignRepository(repositoryContext, mapper, leadAssignSortHelper, leadAssignDataShaper);
                }
                return LeadAssign;
            }
        }
        public ILeadStatusRepository LeadStatusRepository
        {
            get
            {
                if (LeadStatus == null)
                {
                    LeadStatus = new LeadStatusRepository(repositoryContext, mapper, leadStatusSortHelper, leadStatusDataShaper);
                }
                return LeadStatus;
            }
        }
        public ILeadCountRepository LeadCountRepository
        {
            get
            {
                if (LeadCount == null)
                {
                    LeadCount = new LeadCountRepository(repositoryContext, mapper);
                }
                return LeadCount;
            }
        }
        public ILeadTotalAmtRepository LeadTotalAmtRepository
        {
            get
            {
                if (LeadTotalAmt == null)
                {
                    LeadTotalAmt = new LeadTotalAmountRepository(repositoryContext, mapper);
                }
                return LeadTotalAmt;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryWrapper"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="multicodeSortHelper">The multi code sort helper.</param>
        /// <param name="multicodeDataShaper">The multi code data shaper.</param>
        /// <param name="multidetailSortHelper">The multi detail sort helper.</param>
        /// <param name="multidetailDataShaper">The multi detail data shaper.</param>
        /// <param name="leadDataCollectionSortHelper">The lead Data Collection sort helper.</param>
        /// <param name="leadDataCollectionDataShaper">The lead Data Collection data shaper.</param>
        /// <param name="leadQuoteSortHelper">The lead quote sort helper.</param>
        /// <param name="leadQuoteDataShaper">The lead quote data shaper.</param>
        /// <param name="leadValidationSortHelper">The lead Validation sort helper.</param>
        /// <param name="leadValidationDataShaper">The lead Validation data shaper.</param>
        /// <param name="leadAssignSortHelper">The lead Assign sort helper.</param>
        /// <param name="leadAssignDataShaper">The lead Assign data shaper.</param>

        public RepositoryWrapper(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<MultiCodeResponse> multicodeSortHelper,
            IDataShaper<MultiCodeResponse> multicodeDataShaper,
            ISortHelper<MultiDetailResponse> multidetailSortHelper,
            IDataShaper<MultiDetailResponse> multidetailDataShaper,
            ISortHelper<LeadDataCollectionResponse> leadDataCollectionSortHelper,
            IDataShaper<LeadDataCollectionResponse> leadDataCollectionDataShaper,
            ISortHelper<LeadQuoteResponse> leadQuoteSortHelper,
            IDataShaper<LeadQuoteResponse> leadQuoteDataShaper,
            ISortHelper<LeadValidationResponse> leadValidationSortHelper,
            IDataShaper<LeadValidationResponse> leadValidationDataShaper,
            ISortHelper<LeadAssignResponse> leadAssignSortHelper,
            IDataShaper<LeadAssignResponse> leadAssignDataShaper,
            ISortHelper<LeadStatusResponse> leadStatusSortHelper,
            IDataShaper<LeadStatusResponse> leadStatusDataShaper
            )
        {
            this.repositoryContext = repositoryContext;
            this.mapper = mapper;
            this.multicodeSortHelper = multicodeSortHelper;
            this.multicodeDataShaper = multicodeDataShaper;
            this.multidetailSortHelper = multidetailSortHelper;
            this.multidetailDataShaper = multidetailDataShaper;
            this.leadDataCollectionSortHelper = leadDataCollectionSortHelper;
            this.leadDataCollectionDataShaper = leadDataCollectionDataShaper;
            this.leadQuoteSortHelper = leadQuoteSortHelper;
            this.leadQuoteDataShaper = leadQuoteDataShaper;
            this.leadValidationSortHelper = leadValidationSortHelper;
            this.leadValidationDataShaper = leadValidationDataShaper;
            this.leadAssignSortHelper = leadAssignSortHelper;
            this.leadAssignDataShaper = leadAssignDataShaper;
            this.leadStatusSortHelper = leadStatusSortHelper;
            this.leadStatusDataShaper = leadStatusDataShaper;
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await repositoryContext.SaveChangesAsync() >= 0;
        }
    }
}
