using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.CommentReply
{
    public class CommentReplyIdDetailsValidator : AbstractValidator<CommentReplyIdDetails>
    {
        public CommentReplyIdDetailsValidator()
        {
            RuleFor(x => x.CommentReplyId).NotEmpty();
        }
    }
}
