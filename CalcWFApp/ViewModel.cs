using System.Media;

namespace CalcWFApp
{
    public enum Operator
    {
        None = 0, Plus, Minus, Multiply, Divide, Equals, Root, Percent, OneX, PlusMinus
    }

    class ViewModel
    {
        private string _resultString = "0", _actionString, _currentArgumentString, _errorText;
        private Operator _currentOperator;
        private double? _firstArgument, _secondArgument, _currentArgument;
        private bool _lastSymbolIsOperator, _isRootOrPercentOrOneX, _isEqual, _isHaveError;

        public string Result
        {
            get { return _resultString; }
        }

        public string ActionString
        {
            get { return _actionString; }
        }

        public bool IsHaveError
        {
            get { return _isHaveError; }
        }

        public void AddDigit(int digit)
        {
            if (_resultString == "0" || _lastSymbolIsOperator || _isEqual)
            {
                if (_isEqual)
                    _firstArgument = null;

                _resultString = digit.ToString();
            }
            else
            {
                _resultString += digit;
            }

            _currentArgumentString = _resultString;
            DigitTransform();

            ResetFlags();
        }

        public void AddOperator(Operator o)
        {
            if (_lastSymbolIsOperator)
            {
                _actionString = _actionString.Substring(0, _actionString.Length - 1) + OperatorsTransformView(o);
            }
            else
            {
                _actionString += !_isRootOrPercentOrOneX ?
                        " " + _resultString + " " + OperatorsTransformView(o) : " " + OperatorsTransformView(o);

                if (!_isEqual)
                {
                    if (_currentOperator == Operator.Divide && CheckCannotDivideByZero())
                        return;

                    AddArgument();
                    CheckCalc();
                }
            }

            ResetFlags();
            _lastSymbolIsOperator = true;
            _currentOperator = o;
        }

        void ResetFlags()
        {
            _lastSymbolIsOperator = false;
            _isRootOrPercentOrOneX = false;
            _isEqual = false;
            _isHaveError = false;
        }

        public void OperatorRoot()
        {
            _actionString += OperatorsTransformView(Operator.Root);
            DigitTransform();

            if (CheckInvalidInput())
                return;

            _currentArgument = Calculate.CalculateOperatorRoot(_currentArgument);
            _resultString = _currentArgument.ToString();
            AddArgument();
            _isRootOrPercentOrOneX = true;
        }

        public void OperatorPercent()
        {
            DigitTransform();
            AddArgument();
            _currentArgument = Calculate.CalculateOperatorPercent(_firstArgument, _secondArgument);
            _resultString = _currentArgument.ToString();
            _actionString += _resultString;
            AddArgument();
            _isRootOrPercentOrOneX = true;
        }

        public void OperatorOneX()
        {
            _actionString += OperatorsTransformView(Operator.OneX);

            if (CheckCannotDivideByZero())
                return;

            _currentArgument = Calculate.CalculateOperatorOneX(_currentArgument);
            _resultString = _currentArgument.ToString();
            AddArgument();
            _isRootOrPercentOrOneX = true;
        }

        public void OperatorEquals()
        {
            if (_currentOperator == Operator.Divide && CheckCannotDivideByZero())
                return;

            if (_actionString != null)
            {
                DigitTransform();
            }

            AddArgument();
            CheckCalc();
            _actionString = null;
            ResetFlags();
            _isEqual = true;
        }

        public void RemoveDigit()
        {
            if (_isEqual || _isRootOrPercentOrOneX || _lastSymbolIsOperator)
            {
                SystemSounds.Hand.Play();
                return;
            }

            if (string.IsNullOrEmpty(_currentArgumentString) || _currentArgumentString.Length <= 1)
            {
                _currentArgumentString = "0";
            }
            else
            {
                _currentArgumentString = _currentArgumentString.Substring(0, _currentArgumentString.Length - 1);
            }

            DigitTransform();
            _resultString = _currentArgumentString;
        }

        public void PlusMinus()
        {
            if (string.IsNullOrEmpty(_resultString) || _resultString == "0")
                return;

            DigitTransform();
            _currentArgument = -_currentArgument;

            _currentArgumentString = _currentArgument.ToString();
            _resultString = _currentArgument.ToString();

            if (_isEqual)
                _firstArgument = _currentArgument;

            if (_lastSymbolIsOperator && !string.IsNullOrEmpty(_actionString))
            {
                _actionString += OperatorsTransformView(Operator.PlusMinus);
                _isRootOrPercentOrOneX = true;
                _lastSymbolIsOperator = false;
            }

            //if (!string.IsNullOrEmpty(_actionString))
            //{
            //    _actionString += OperatorsTransformView(Operator.PlusMinus);
            //    _isRootOrPercentOrOneX = true;
            //}
            //else
            //{
            //    _isRootOrPercentOrOneX = false;
            //}
        }

        public void C()
        {
            ResetFlags();
            _firstArgument = null;
            _secondArgument = null;
            _currentArgument = null;
            _resultString = "0";
            _actionString = null;
            _currentArgumentString = null;
            _errorText = null;
        }

        public void CE()
        {
            ResetFlags();
            _resultString = "0";
            _currentArgumentString = "0";
            _errorText = null;
            DigitTransform();
        }

        public void AddComma()
        {
            if (_resultString.Contains(","))
                return;

            _resultString += ",";
        }

        /*----------------------------------------------------------------------------------------------------------------*/
        public void ShowError()
        {
            _resultString = _errorText;
            _isHaveError = true;
            SystemSounds.Hand.Play();
        }

        bool CheckCannotDivideByZero()
        {
            if (_currentArgument == null || _currentArgument == 0)
            {
                _errorText = "Cannot divide by zero";
                ShowError();
                return true;
            }

            return false;
        }

        bool CheckInvalidInput()
        {
            if (_currentArgument < 0)
            {
                _errorText = "Invalid input";
                ShowError();
                return true;
            }

            return false;
        }

        void AddArgument()
        {
            if (_firstArgument == null)
            {
                _firstArgument = (_currentArgument != null) ? _currentArgument : 0;
            }
            else
            {
                _secondArgument = _currentArgument;
            }
        }

        string OperatorsTransformView(Operator o)
        {
            switch (o)
            {
                case Operator.Plus:
                    return "+";
                case Operator.Minus:
                    return "-";
                case Operator.Multiply:
                    return "*";
                case Operator.Divide:
                    return "/";
                case Operator.Root:
                    return " sqrt(" + _resultString + ")";
                case Operator.OneX:
                    return " rp(" + _resultString + ")";
                case Operator.PlusMinus:
                    return " negate(" + _resultString + ")";
                default:
                    return string.Empty;
            }
        }

        void DigitTransform()
        {
            double d;
            double.TryParse(_resultString, out d);
            _currentArgument = d;
        }

        void CheckCalc()
        {
            if (_secondArgument == null)
                return;

            _firstArgument = Calculate.CalculateOperator(_firstArgument, _secondArgument, _currentOperator);
            _resultString = _firstArgument.ToString();
            _secondArgument = null;
        }
    }
}
