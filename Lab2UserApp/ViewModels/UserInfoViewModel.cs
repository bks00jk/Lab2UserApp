﻿using KMA.ProgrammingInCSharp2023.Lab2UserApp.Managers;
using KMA.ProgrammingInCSharp2023.Lab2UserApp.Tools;
using KMA.ProgrammingInCSharp2023.Lab2UserApp.Tools.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp2023.Lab2UserApp.ViewModels
{
    internal class UserInfoViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = DateTime.Today;
        private RelayCommand<object> _proceedCommand; 
        #endregion

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }

            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }


        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) &&
                   !string.IsNullOrWhiteSpace(Email);
        }
        public RelayCommand<object> Proceed
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(
                    PersonInfoImplementation, o => CanExecuteCommand());
            }
        }

        private async void PersonInfoImplementation(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                try
                {
                    _person = new Person(FirstName, LastName, Email, BirthDate);
                }
                catch(InvalidEmailException e)
                {
                    MessageBox.Show(e.Message, "Wrong Email", MessageBoxButton.OK);
                    return;
                }
                catch (PastBirthdayException e)
                {
                    MessageBox.Show(e.Message, "Wrong Date", MessageBoxButton.OK);
                    return;
                }
                catch (FutureBirthdayException e)
                {
                    MessageBox.Show(e.Message, "Wrong Date", MessageBoxButton.OK);
                    return;
                }
                catch (InvalidNameException e)
                {
                    MessageBox.Show(e.Message, "Wrong Name or Surname", MessageBoxButton.OK);
                    return;
                }

                if (_person.IsBirthday)
                {
                    MessageBox.Show("Happy Birthday! \nWe wish you all the best!", "Congratulations", MessageBoxButton.OK);
                }
                String info =
                     $"Name: {_person.FirstName}\nSurname: {_person.LastName}\nEmail: {_person.Email}\nBirthday: {_person.BirthDate}\n" +
                     $"Is Adult: {_person.IsAdult}\nSun Sign: {_person.SunSign}\nChinese Sign: {_person.ChineseSign}\nIs Birthday: {_person.IsBirthday}";
                MessageBox.Show(info, "User Info", MessageBoxButton.OK);
            });
            LoaderManager.Instance.HideLoader();
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion

    }
}
