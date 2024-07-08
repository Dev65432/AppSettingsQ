using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Microsoft.Extensions.Configuration;
using System.Windows.Input;
using AppsettingsWpf.Commands;
using System.Threading.Tasks;

namespace AppsettingsWpf.ViewModels
{
    public class AppSettingsViewModel : ViewModelBase
    {
        IConfiguration _configuration;

        public AppSettingsViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
            
            StartUp();
        }

        public void StartUp()
        {
            PathToImg = _configuration["PathToImg"];
            
            IsButtonEnabled = false;
        }

        private string _pathToImg;

        public string PathToImg
        {
            get 
            {
                // _pathToFastStoneExe = _configuration["FastStonePath"];
                
                return _pathToImg; 
            }
            set 
            {

                _pathToImg = value;                
                OnPropertyChanged(nameof(PathToImg));

                UpdateButtonState();
            }
        }


        #region Кнопка Сохранить
        // private Brush _buttonColor = Brushes.Gray;
        private Brush _buttonColor;
        public Brush ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                OnPropertyChanged(nameof(ButtonColor));
            }
        }

        private bool _isButtonEnabled = false;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }
        
        private void UpdateButtonState()
        {
            IsButtonEnabled = true;
            ButtonColor = Brushes.Red;
            // ButtonColor = IsButtonEnabled ? Brushes.Green : Brushes.Gray;
            // ButtonColor = IsButtonEnabled ? Brushes.Green : Brushes.Gray;
        }

        #endregion

        #region  Command SaveSettingsCommand - Команда загрузки данных из репозитория
        /// <summary>Отобразить представление статистики</summary>
        private ICommand _SaveSettingsCommand;

        public ICommand SaveSettingsCommand
        {
            get
            {
                return _SaveSettingsCommand ??
                    (_SaveSettingsCommand = new RelayCommand(() => SaveSettingsExecuted()));
            }
        }

        private async Task SaveSettingsExecuted()
        {
            _configuration["PathToImg"] = PathToImg;

            var fgfg = _configuration["PathToImg"];


            // Сохранение изменений в файл appsettings.json
            IConfigurationRoot configurationRoot = (IConfigurationRoot)_configuration;
            configurationRoot.Reload(); 

            IsButtonEnabled = false;
        }

        #endregion
    }
}

