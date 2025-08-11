namespace zelis.Api.Models;


    public class CommunicationStatusHistory
    {
        public int Id { get; set; }

        public Guid CommunicationId { get; set; }
        public Communication? Communication { get; set; }  // nullable nav

        public string StatusCode { get; set; } = string.Empty;
        public DateTime OccurredUtc { get; set; }
    }