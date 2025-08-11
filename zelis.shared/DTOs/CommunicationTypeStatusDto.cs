namespace zelis.Shared.Dtos
{
    public class CommunicationTypeStatusDto
    {
        public int Id { get; set; }                     // DB PK for this mapping
        public int CommunicationTypeId { get; set; }    // FK to CommunicationType
        public string TypeCode { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
