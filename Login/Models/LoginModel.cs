using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace Login.Models
{
    public class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username == value)
                    return;

                _username = value;

                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                    return;

                _password = value;

                OnPropertyChanged();
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value)
                    return;

                _email = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
