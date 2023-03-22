using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEMS.Application
{

    interface IValidationStrategy
    {
        bool IsValid(string input);
    }
    class InputValidator
    {
        private readonly IValidationStrategy _strategy;

        public InputValidator(IValidationStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool Validate(string input)
        {
            
            return _strategy.IsValid(input);
        }
    }
    class ZipcodeValidator : IValidationStrategy
    {
        public bool IsValid(string zipCode)
        {
            string pattern = @"^[0-9]{5}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(zipCode);
        }
    }

    class NameValidator : IValidationStrategy
    {
        public bool IsValid(string name)
        {
            string pattern = @"^[\p{L} -]+$";
            Regex regex = new(pattern);
            return regex.IsMatch(name);
        }
    }

    class StreetNumberValidator : IValidationStrategy
    {
        public bool IsValid(string streetnumber)
        {
            string pattern = @"^\d+[A-Za-z]?$";
            Regex regex = new(pattern);
            return regex.IsMatch(streetnumber);
        }
    }
    class ThreeUpperValidator : IValidationStrategy
    {
        public bool IsValid(string upper)
        {
            string pattern = @"^[A-Z]{3}$";
            Regex regex = new(pattern);
            return regex.IsMatch(upper);
        }
    }

    class SalaryValidator : IValidationStrategy
    {
        public bool IsValid(string salary)
        {
            return decimal.TryParse(salary, out _ );
        }
    }

}