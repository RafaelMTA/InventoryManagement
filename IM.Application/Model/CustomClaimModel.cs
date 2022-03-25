namespace IM.Application.Model
{
    public record CustomClaimModel
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public CustomClaimModel(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
