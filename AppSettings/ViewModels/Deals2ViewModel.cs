using System;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppsettingsWpf.Commands;

using AppsettingsWpf.DAL.Entityes;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using AppsettingsWpf.DAL;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Extensions.Configuration;
using AppsettingsWpf.Views.Windows;

namespace AppsettingsWpf.ViewModels
{
    public class Deals2ViewModel : ViewModelBase
    {
        IConfiguration _configuration;
        private IRepository<Deal> _dealsRepository;        
        private IRepository<Picture> _pictureRepository;

        public Deals2ViewModel(IConfiguration configuration,
                               IRepository<Deal> DealsRepository,                               
                               IRepository<Picture> pictureRepository)
        {
            _configuration = configuration;
            _dealsRepository = DealsRepository;            
            _pictureRepository = pictureRepository;            
        }

        private string _title = "Заголовок. DealsViewModel ";

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        #region Deals : BindingList<Deal> - Коллекция сделки
        private Deal _selectedDeal;

        public Deal SelectedDeal
        {
            get { return _selectedDeal; }
            set
            {
                _selectedDeal = value;
                OnPropertyChanged(nameof(SelectedDeal));
            }
        }



        private BindingList<Deal> _deals;

        public BindingList<Deal> Deals
        {
            get { return _deals; }
            set
            {
                _deals = value;
                OnPropertyChanged(nameof(Deals));
            }
        }
        #endregion

        #region  Command LoadDataCommand - Команда загрузки данных из репозитория
        /// <summary>Отобразить представление статистики</summary>
        private ICommand _loadDataCommand;

        public ICommand LoadDataCommand
        {
            get
            {
                return _loadDataCommand ??
                    (_loadDataCommand = new RelayCommand(() => OnLoadDataExecuted()));
            }
        }

        private async Task OnLoadDataExecuted()
        {
            try
            {
                
                // Deals 
                var items = await _dealsRepository.Items.ToArrayAsync();
                Deals = new BindingList<Deal>(items);
                SelectedDeal = Deals[1];
                

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

        }

        #endregion

        #region  Command OpenAppSettingsCommand - Отобразить окно настроек
        private ICommand _openAppSettingsCommand;

        public ICommand OpenAppSettingsCommand
        {
            get
            {
                return _openAppSettingsCommand ??
                    (_openAppSettingsCommand = new RelayCommand(() => OnOpenAppSettingsExecuted()));
            }
        }

        private async Task OnOpenAppSettingsExecuted()
        {
            AppSettingsViewModel appSettingsViewModel = new AppSettingsViewModel(_configuration);

            AppSettingsWindow appSettingsWindow = new AppSettingsWindow();
            appSettingsWindow.DataContext = appSettingsViewModel;
            appSettingsWindow.Show();
        }

        #endregion




        #region MethodsPrivate
        private void SaveToFile(string nameFile)
        {
            var image = Clipboard.GetImage();

            // Папка
            // var directoryPath =  @"AppFiles\Imgs\";
            var directoryPath = _configuration["Path"];
            // Создаем папку, если она еще не существует
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath));

            // Полный путь
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, nameFile);
            // var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, "img1.jpg");


            // Сохраняем в файл
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(fileStream);
            }

        }

        #endregion

    }
}

