namespace SCGPS.Domain.Dto
{
    public class BaseDto 
    {
        public bool? IsSucceded { get; set; }
        public DateTime? Time { get; set; }
        public string? ErrorDescription { get; set; }
        public string? ErrorCode { get; set; }
    }
}
