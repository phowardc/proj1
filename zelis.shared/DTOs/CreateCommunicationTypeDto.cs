namespace zelis.Shared.Dtos
{
    public class CreateCommunicationTypeDto
    {
        public string TypeCode { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public List<string> AllowedStatusCodes { get; set; } = new();
    }
}
