using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer
{
    public class ServiceAnswerParameters :  QueryStringParameters
    {
        public int QuestionId { get; set; }
        public int Id { get; set; }
        public int AnswerId { get; set; }
    }
}
