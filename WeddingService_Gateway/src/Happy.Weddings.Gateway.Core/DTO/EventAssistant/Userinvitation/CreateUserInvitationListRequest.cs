using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Userinvitation
{
    public class CreateUserInvitationListRequest
    {

        public IEnumerable<CreateUserinvitationRequest> CreateUserInvitationRequest { get; set; }
    }
}
