using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp2023.Lab2UserApp.Managers
{
    interface ILoaderOwner : INotifyPropertyChanged
    {
        public bool IsEnabled
        {
            get;
            set;
        }

        public Visibility LoaderVisibility
        {
            get;
            set;
        }
    }
}
