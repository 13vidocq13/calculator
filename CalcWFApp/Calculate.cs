using System;

namespace CalcWFApp
{
    public static class Calculate
    {
        public static double? CalculateOperator(double? firstArgument, double? secondArgument, Operator o)
        {
            switch (o)
            {
                case Operator.Plus:
                    return firstArgument + secondArgument;
                case Operator.Minus:
                    return firstArgument - secondArgument;
                case Operator.Multiply:
                    return firstArgument * secondArgument;
                case Operator.Divide:
                    return firstArgument / secondArgument;
                default:
                    return null;
            }
        }

        public static double? CalculateOperatorRoot(double? digit)
        {
            if (digit != null)
                return Math.Sqrt((double)digit);

            return null;
        }

        public static double CalculateOperatorPercent(double? firstArgument, double? secondArgument)
        {
            double result;

            if (firstArgument != null && secondArgument != null)
            {
                result = (double)(firstArgument * secondArgument / 100);
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public static double? CalculateOperatorOneX(double? digit)
        {
            return 1/digit;
        }
    }
}
