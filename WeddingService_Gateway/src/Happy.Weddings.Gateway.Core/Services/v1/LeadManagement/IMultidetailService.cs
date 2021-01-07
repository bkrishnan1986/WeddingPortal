﻿using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multidetail;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.LeadManagement
{
    public interface IMultidetailService
    {
        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multidetailParameter">The Multidetail parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllMultiDetails(MultidetailParameter multidetailParameter);

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetMultiDetailsByCode(string Code);

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateMultiDetails(CreateMultidetailLeadRequest request);

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateMultiDetails(MultidetailIdDetails details, UpdateMultidetailLeadRequest request);

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteMultiDetails(MultidetailIdDetails details);
    }
}
