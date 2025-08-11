namespace zelis.Shared.Dtos
{
    public class CommunicationTypeDto
    {
        public string TypeCode { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public List<CommunicationTypeStatusDto> AllowedStatuses { get; set; } = new();
    }
}
