namespace Shared.ErrorModels
{
    public class ValidationError
    {
        public string FieldId {  get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}