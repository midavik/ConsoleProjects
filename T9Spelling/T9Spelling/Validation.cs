using System;
using System.Text.RegularExpressions;

namespace T9Spelling
{
    public class Validation
    {
        // Allow lower characters a-z and space characters ' '
        public static bool ValidateMessage(string message)
        {
            //return Regex.IsMatch(message, @"^[a-z]*$");//, RegexOptions.ExplicitCapture);
            //return Regex.IsMatch(message, @"^[a-z\s]", RegexOptions.ExplicitCapture);

            try
            {
                if (Regex.IsMatch(message, @"^[a-z\s]{1,}$") && message.Length >= 1 && message.Length <= 1000)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidateNumberOfCases(string number)
        {
            try
            {
                int n;
                if (int.TryParse(number, out n) && n >= 1 && n <= 100)
                    return true;
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool FileExists(string fileName)
        {
            try
            {
                return System.IO.File.Exists(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


    }
}

