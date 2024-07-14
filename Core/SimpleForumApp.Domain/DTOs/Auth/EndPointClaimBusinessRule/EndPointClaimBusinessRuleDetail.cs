namespace SimpleForumApp.Domain.DTOs.Auth.EndPointClaimBusinessRule
{
    public class EndPointClaimBusinessRuleDetail
    {
        public long EndPointId { get; set; }
        public long ClaimBusinessRuleId { get; set; }
        public long ExecutionOrderId { get; set; }
        public string Code { get; set; }
        public int Priority { get; set; }
    }
}
