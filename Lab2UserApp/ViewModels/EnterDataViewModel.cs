using KMA.ProgrammingInCSharp2023.Lab2UserApp.Managers;
using KMA.ProgrammingInCSharp2023.Lab2UserApp.Tools;
using KMA.ProgrammingInCSharp2023.Lab2UserApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace KMA.ProgrammingInCSharp2023.Lab2UserApp.ViewModels
{
    class EnterDataViewModel : INotifyPropertyChanged, ILoaderOwner
    {
        #region Fields

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isEnabled = true;

        #endregion

        #region Properties

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal EnterDataViewModel()
        {
            LoaderManager.Instance.Initialize(this);
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
