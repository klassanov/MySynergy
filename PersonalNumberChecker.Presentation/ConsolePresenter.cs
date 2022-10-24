using PersonalNumberChecker.Interfaces.Presentation;
using System;

namespace PersonalNumberChecker.Presentation
{
    public class ConsolePresenter : IPersonalNumberPresenter
    {
        public void Present(IPersonalNumberModel personalNumber)
        {
            Console.WriteLine(personalNumber.IsValid.ToString().ToUpper());
            if (personalNumber.IsValid)
            {
                Console.WriteLine(personalNumber.BirthDate.ToString("yyyy-MM-dd"));
                Console.WriteLine(personalNumber.Gender.ToString().Substring(0,1));
            }
        }
    }
}
