namespace zelis.Shared.Dtos
{
    public class StatusOptionDto
    {
        public string StatusCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //IsSelected is only for UI
        public bool IsSelected { get; set; } = false;

    }
}
