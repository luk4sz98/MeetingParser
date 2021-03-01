using System;
using MeetingParser.Interfaces;
using MeetingParser.Enums;

namespace MeetingParser.Services
{
    public class UIElements : IUIElements
    {
        private readonly IPrinter _printer;
        private readonly IUserInputService _userInput;
        private string target;
        private string city;


        public UIElements(IPrinter printer, IUserInputService userInput)
        {
            _printer = printer;
            _userInput = userInput;
        }

        public string GetTarget()
        {
            while (true)
            {
                _printer.PrintTypeChoice();

                if (TargetInput())
                {
                    break;
                }
            }

            return target;
        }

        public string GetCity()
        {
            while (true)
            {
                _printer.PrintCityChoice();

                if(CityInput())
                {
                    break;
                }
            }

            return city;
        }

        #region Inputs

        private bool CityInput()
        {
            switch (_userInput.GetCityChoice())
            {
                case Cities.Kraków:
                    {
                        city = "krakow";
                    }
                    break;

                case Cities.Warszawa:
                    {
                        city = "warszawa";
                    }
                    break;

                case Cities.Wrocław:
                    {
                        city = "wroclaw";
                    }
                    break;

                case Cities.Trójmiasto:
                    {
                        city = "trojmiasto";
                    }
                    break;

                case Cities.Poznań:
                    {
                        city = "poznan";
                    }
                    break;

                case Cities.Katowice:
                    {
                        city = "katowice";
                    }
                    break;
                default:
                    {
                        _printer.PrintInvalidInputMessage();
                        return false;
                    }
            }
            return true;
        }

        private bool TargetInput()
        {
            switch (_userInput.GetTypeChoice())
            {
                case TypesOfEvent.IT:
                    {
                        target = "it";
                    }
                    break;
                case TypesOfEvent.Startup:
                    {
                        target = "startup";
                    }
                    break;
                case TypesOfEvent.EMarketing:
                    {
                        target = "emarketing";
                    }
                    break;
                case TypesOfEvent.UX:
                    {
                        target = "ux";
                    }
                    break;
                default:
                    {
                        _printer.PrintInvalidInputMessage();
                        return false;
                    }
            }

            return true;
        }
        #endregion

    }
}
