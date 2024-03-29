﻿using System.Text.RegularExpressions;

namespace SEMS.Application
{

    public interface IValidationStrategy
    {
        bool IsValid(string input);
    }
    public class InputValidator
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
    public class ZipcodeValidator
    {
        public static bool IsValid(string zipCode)
        {
            string pattern = @"^[0-9]{5}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(zipCode);
        }
    }

    public class NameValidator
    {
        public static bool IsValid(string name)
        {
            string pattern = @"^[\p{L} -]+$";
            Regex regex = new(pattern);
            return regex.IsMatch(name);
        }
    }

    public class StreetNumberValidator
    {
        public static bool IsValid(string streetnumber)
        {
            string pattern = @"^\d+[A-Za-z]?$";
            Regex regex = new(pattern);
            return regex.IsMatch(streetnumber);
        }
    }
    public class ThreeUpperValidator
    {
        public static bool IsValid(string upper)
        {
            string pattern = @"^[A-Z]{3}$";
            Regex regex = new(pattern);
            return regex.IsMatch(upper);
        }
    }

    public class SalaryValidator 
    {
        public static bool IsValid(string salary)
        {
            return decimal.TryParse(salary, out _ );
        }
    }

}