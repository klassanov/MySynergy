using PersonalNumberChecker.Interfaces.Presentation;

namespace PersonalNumberChecker.Interfaces.Parsing
{
    public interface IPersonalNumberParser
    {
        IPersonalNumberModel ParsePersonalNumber(string personalNumber);
    }
}
