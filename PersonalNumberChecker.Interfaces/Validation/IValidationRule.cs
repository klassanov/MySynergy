namespace PersonalNumberChecker.Interfaces.Validation
{
    public interface IValidationRule
    {
        bool IsRespected(string personalNumber);

        ValidationError ValidationError { get; }
    }
}
