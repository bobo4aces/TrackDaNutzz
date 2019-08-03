using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackDaNutzz.Services.Helpers
{
    public class MathOperations
    {
        public static decimal Divide(object firstNumber, object secondNumber)
        {
            if (!firstNumber.GetType().IsValueType || firstNumber.GetType().IsAssignableFrom(typeof(string)))
            {
                throw new ArgumentException($"{firstNumber} is not a number");
            }
            if (!secondNumber.GetType().IsValueType || secondNumber.GetType().IsAssignableFrom(typeof(string)))
            {
                throw new ArgumentException($"{secondNumber} is not a number");
            }
            decimal first = decimal.Parse(firstNumber.ToString());
            decimal second = decimal.Parse(secondNumber.ToString());
            if (first == 0 || second == 0)
            {
                return 0;
            }
            return first / second;
        }
    }
}
