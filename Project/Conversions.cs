//========================================================================================================================
// Component: BaseUtils - Common utility methods
// Copyright: Dale Medical Products
//
// Conversions.cs
//      This class contains data convertion and reformatting methods
//========================================================================================================================
using System;
using System.Linq;
using System.Globalization;

namespace BaseUtils
{
    public static class Conversions
    {
        #region Public Methods
        //================================================================================================================
        //================================================================================================================

        public static string DBValue2String(object sourceValue)
        //================================================================================================================
        // Convert the given database value to a string
        //
        // Parameters
        //      sourceValue: Value to convert
        //
        // Returns
        //      The value converted to a string and trimmed or an empty string if the value is null
        //================================================================================================================
        {
            string convertedValue = "";

            if ((sourceValue != null) && (sourceValue != System.DBNull.Value))
                convertedValue = sourceValue.ToString().Trim();

            return convertedValue;
        }

        public static string ReformatYearBasedDate(string sourceValue)
        //================================================================================================================
        // Reformat a date string from the YYYYMMDD format to the MM/DD/YYYY format
        //
        // Parameters
        //      sourceValue: Date string to convert
        //
        // Returns
        //      Refromatted date string
        //================================================================================================================
        {
            string convertedValue = sourceValue;

            if ((sourceValue != null) && (sourceValue.Length == 8))
            {
                convertedValue = sourceValue.Substring(4, 2) + "/";
                convertedValue += sourceValue.Substring(6, 2) + "/";
                convertedValue += sourceValue.Substring(0, 4);
            }

            return convertedValue;
        }

        public static string ByteArray2String(byte[] byteBuffer)
        //================================================================================================================
        // Convert the given byte array to a string
        //
        // Parameters
        //      byteBuffer: Byte array to convert
        //
        // Returns
        //      String
        //================================================================================================================
        {
            string result = "";

            if (byteBuffer != null)
            {
                foreach (byte b in byteBuffer)
                {
                    result += (char)b;
                }
            }

            return result;
        }

        public static DateTime String2Date(string sourceValue)
        //================================================================================================================
        // Convert the given string to a date
        //
        // Parameters
        //      sourceValue: Date string to convert
        //
        // Returns
        //      DateTime value or a defualt date of 01/01/0001
        //================================================================================================================
        {
            DateTime convertedValue = DateTime.MinValue;

            if ((sourceValue != null) && (!String.IsNullOrEmpty(sourceValue.Trim())))
            {
                if (DateTime.TryParse(sourceValue, out DateTime tempDate))
                {
                    convertedValue = tempDate;
                }
            }

            return convertedValue;
        }

        public static int String2Int(string sourceValue)
        //================================================================================================================
        // Convert the given string to an integer
        //
        // Parameters
        //      sourceValue: String to convert
        //
        // Returns
        //      Integer value or zero
        //================================================================================================================
        {
            int convertedValue = 0;

            if ((sourceValue != null) && (!String.IsNullOrEmpty(sourceValue.Trim())))
            {
                // Remove any formatting characters from the string
                string sourceValueNoFormat = sourceValue;
                sourceValueNoFormat = sourceValueNoFormat.Replace(",", "");
                sourceValueNoFormat = sourceValueNoFormat.Replace("$", "");
                sourceValueNoFormat = sourceValueNoFormat.Replace(".", "");

                if (Int32.TryParse(sourceValueNoFormat, out int tempResult))
                {
                    convertedValue = tempResult;
                }
                else
                {
                    // If the value could not be converted directly, attempt to manually
                    // convert it taking into account that negative numbers may be enclosed in ().
                    string validChars = Properties.Resources.ValidNumericChars;
                    char nextChar;
                    string convertedResult = "";

                    for (int i = 0; i < sourceValueNoFormat.Length; i++)
                    {
                        // Pull off the next character
                        nextChar = sourceValueNoFormat[i];

                        // Add it to the conversion string if it is a valid character
                        // Otherwise exit the loop
                        if (validChars.Contains(nextChar))
                            convertedResult += nextChar.ToString(CultureInfo.InvariantCulture);
                        else
                            break;
                    }

                    // Attempt to conver the string
                    if (!String.IsNullOrEmpty(convertedResult))
                        if (Int32.TryParse(convertedResult, out tempResult))
                            convertedValue = tempResult;
                }
            }

            return convertedValue;
        }

        public static double String2Double(string sourceValue)
        //================================================================================================================
        // Convert the given string to a double
        //
        // Parameters
        //      sourceValue: String to convert
        //
        // Returns
        //      Decimal value or zero
        //================================================================================================================
        {
            double convertedValue = 0;

            if ((sourceValue != null) && (!String.IsNullOrEmpty(sourceValue.Trim())))
            {
                // Remove any formatting characters from the string
                string sourceValueNoFormat = sourceValue;
                sourceValueNoFormat = sourceValueNoFormat.Replace(",", "");
                sourceValueNoFormat = sourceValueNoFormat.Replace("$", "");

                if (double.TryParse(sourceValueNoFormat, out double tempResult))
                {
                    convertedValue = tempResult;
                }
                else
                {
                    // If the value could not be converted directly, attempt to manually
                    // convert it taking into account that negative numbers may be enclosed in ().
                    string validChars = Properties.Resources.ValidNumericChars;
                    char nextChar;
                    string convertedResult = "";

                    for (int i = 0; i < sourceValueNoFormat.Length; i++)
                    {
                        // Pull off the next character
                        nextChar = sourceValueNoFormat[i];

                        // Add it to the conversion string if it is a valid character
                        // Otherwise exit the loop
                        if (validChars.Contains(nextChar))
                        {
                            // The $ character is allowed but not added to the conversion string
                            if (nextChar.ToString(CultureInfo.InvariantCulture) != "$")
                                convertedResult += nextChar.ToString(CultureInfo.InvariantCulture);
                        }
                        else
                            break;
                    }

                    // Attempt to conver the string
                    if (!String.IsNullOrEmpty(convertedResult))
                        if (double.TryParse(convertedResult, out tempResult))
                            convertedValue = tempResult;
                }
            }

            return convertedValue;
        }

        public static double String2Percent(string sourceValue)
        //================================================================================================================
        // Convert the given string to a percentage
        //
        // Parameters
        //      sourceValue: String to convert
        //
        // Returns
        //      Percent value or zero
        //
        // Developer Note
        //      This method assumes the string is in the format NN.NN% or NN.NN
        //================================================================================================================
        {
            double convertedValue = 0;

            if ((sourceValue != null) && (!String.IsNullOrEmpty(sourceValue.Trim())))
            {
                // Developer Notes
                //      Because we use the String2Double function to first convert the value, we must make sure that the "%"
                //      sign is removed or the String2Double function truncates the decimal part.
                //
                string sourceValueNoFormat = sourceValue.Replace("%", "");

                // First convert the percentage to a number
                // Then divide by 100 to get a decimal percentage
                convertedValue = String2Double(sourceValueNoFormat);
                convertedValue = (convertedValue / 100.00);
            }

            return convertedValue;
        }

        //================================================================================================================
        //================================================================================================================
        #endregion  // Public Methods
    }
}
