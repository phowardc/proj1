namespace zelis.Shared.Dtos
{
    public class CommunicationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TypeCode { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public DateTime LastUpdatedUtc { get; set; }
    }
}
