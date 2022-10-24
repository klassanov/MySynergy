using Microsoft.Extensions.DependencyInjection;
using PersonalNumberChecker.Interfaces.Parsing;
using PersonalNumberChecker.Interfaces.Presentation;
using PersonalNumberChecker.Interfaces.Service;
using PersonalNumberChecker.Interfaces.Validation;
using PersonalNumberChecker.Parsing;
using PersonalNumberChecker.Presentation;
using PersonalNumberChecker.Service;
using PersonalNumberChecker.Validation.Rules;
using PersonalNumberChecker.Validation.Validators;
using System;
using System.Collections.Generic;

namespace PersonalNumberChecker
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            StartConsoleChecker();
        }

        private static void StartConsoleChecker()
        {
            while (true)
            {
                Console.WriteLine("Please insert a personal number to check or type 'quit' to exit:");
                string userInput = Console.ReadLine();
                if (userInput.Equals("quit"))
                {
                    break;
                }
                else
                {
                    var service = serviceProvider.GetService<IPersonalNumberService>();
                    service.CheckPersonalNumber(userInput);
                    Console.WriteLine();
                }
            }
        }

        private static void RegisterServices()
        {
            serviceProvider = new ServiceCollection()
                .AddTransient<IPersonalNumberParser, PersonalNumberParser>()
                .AddTransient<IPersonalNumberPresenter, ConsolePresenter>()
                .AddTransient<IPersonalNumberService, PersonalNumberService>()
                .AddTransient<IPersonalNumberValidator, PersonalNumberValidator>(x => {
                    return new PersonalNumberValidator(new List<IValidationRule>() {
                        new LengthRule(),
                        new OnlyDigitsRule(),
                        new LastDigitRule(),
                        new BirthDateRule()
                    });
                 })                 
                .BuildServiceProvider();
        }
    }
}
