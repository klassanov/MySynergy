using PersonalNumberChecker.Interfaces.Parsing;
using PersonalNumberChecker.Interfaces.Presentation;
using PersonalNumberChecker.Interfaces.Service;

namespace PersonalNumberChecker.Service
{
    public class PersonalNumberService: IPersonalNumberService
    {
        private readonly IPersonalNumberParser parser;
        private readonly IPersonalNumberPresenter presenter;

        public PersonalNumberService(IPersonalNumberParser parser, IPersonalNumberPresenter presenter)
        {
            this.parser = parser;
            this.presenter = presenter;
        }

        public void CheckPersonalNumber(string personalNumber)
        {
            var personalNumberViewModel = this.parser.ParsePersonalNumber(personalNumber);                                         
            this.presenter.Present(personalNumberViewModel);
        } 
    }
}
