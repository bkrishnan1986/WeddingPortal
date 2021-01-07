using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.CommentReply
{
    public class UpdateCommentReplyRequestValidator : AbstractValidator<UpdateCommentReplyBlogRequest>
    {
        public UpdateCommentReplyRequestValidator()
        {
            RuleFor(x => x.ReviewId).NotEmpty();
            RuleFor(x => x.CommentReply).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.ApprovalStatus).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
