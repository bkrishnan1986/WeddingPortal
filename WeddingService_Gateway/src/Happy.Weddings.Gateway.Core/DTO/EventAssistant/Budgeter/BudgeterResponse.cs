﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                         | MultiDetailResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Newtonsoft.Json;
using System;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Budgeter
{
    /// <summary>
    ///   This class is used to map MultiDetail Response
    /// </summary>
    public class BudgeterResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the item cost.
        /// </summary>
        /// <value>
        /// The item cost.
        /// </value>
        public float? ItemCost { get; set; }

        /// <summary>
        /// Gets or sets the amount paid.
        /// </summary>
        /// <value>
        /// The amount paid.
        /// </value>
        public float? AmountPaid { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public int Category { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }
}
