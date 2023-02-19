using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using RomanCalc.Models;
using Microsoft.VisualBasic;
using HarfBuzzSharp;

namespace RomanCalc.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string SecondNumber;
        string _Function = " ";
        private RomanNumberExtend _Result;
        private RomanNumberExtend _SecondValue;
        public MainWindowViewModel()
        {
            AddNum = ReactiveCommand.Create<string, string>(AddNumTo);
            ExecuteOperationCommand = ReactiveCommand.Create<string>(ExecuteOperation);
            Clear = ReactiveCommand.Create<string, string>(Clear2);
        }
        public string ShowValue
        {
            set
            {
                this.RaiseAndSetIfChanged(ref SecondNumber, value);
            }
            get
            {
                return SecondNumber;
            }
        }
        public ReactiveCommand<string, string> AddNum { get; }
        public ReactiveCommand<string, Unit> ExecuteOperationCommand { get; }
        public ReactiveCommand<string, string> Clear { get; }
        public string Clear2(string str)
        {
            if (_Function == " ")
            {
                ShowValue = null;
                SecondNumber = null;
                _Result = null;
                _SecondValue = null;
            }
            if (_Function == "n")
            {
                ShowValue = null;
            }
            return null;
        }
        private string AddNumTo(string str)
        {
            if (_Function == "n")
            {
                ShowValue = str;
                _Function = " ";
            }
            else
            {
                ShowValue += str;
            }
            return ShowValue;
        }
        private void ExecuteOperation(string Function)
        {
            if (RomanNumberExtend.ToInt(SecondNumber) > 0)
                _SecondValue = new RomanNumberExtend(SecondNumber);
            RomanNumber t;
            try
            {
                switch (_Function[0])
                {
                    case '+':
                        {
                            t = _Result + _SecondValue;
                            _Result = new RomanNumberExtend(t.ToString());
                            break;
                        }
                    case '*':
                        {
                            t = _Result * _SecondValue;
                            _Result = new RomanNumberExtend(t.ToString());
                            break;
                        }
                    case '/':
                        {
                            t = _Result / _SecondValue;
                            _Result = new RomanNumberExtend(t.ToString());
                            break;
                        }
                    case '-':
                        {
                            t = _Result - _SecondValue;
                            _Result = new RomanNumberExtend(t.ToString());
                            break;
                        }
                    case ' ':
                        {
                            if (RomanNumberExtend.ToInt(SecondNumber) > 0)
                                _Result = new RomanNumberExtend(SecondNumber);
                            break;
                        }
                    case 'n':
                        {
                            if (RomanNumberExtend.ToInt(SecondNumber) > 0)
                                _Result = new RomanNumberExtend(SecondNumber);
                            break;
                        }
                    default:
                        break;
                }
                if (Function == "=")
                {
                    if (_Result != null)
                        ShowValue = _Result.ToString();
                    _Function = "n";
                    _Result = null;
                }
                else
                {
                    _Function = Function;
                    ShowValue = "";
                }
            }
            catch (RomanNumberException ex)
            {
                ShowValue = $"{ex.Message}";
            }
        }
    }
}