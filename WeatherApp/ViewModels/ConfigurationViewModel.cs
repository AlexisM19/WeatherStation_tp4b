﻿using System;
using WeatherApp.Commands;

namespace WeatherApp.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        private string apiKey;        

        public string ApiKey { 
            get => apiKey;
            set
            {
                apiKey = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand<string> SaveConfigurationCommand { get; set; }


        public ConfigurationViewModel()
        {
            Name = GetType().Name;

            ApiKey = GetApiKey();

            SaveConfigurationCommand = new DelegateCommand<string>(SaveConfiguration);
        }

        private void SaveConfiguration(string obj)
        {
            /// TODO 04 : Les tâches manquantes sont dans les XAML.
            /// TODO 04a : Sauvegarder la configuration
            Properties.Settings.Default.apiKey = obj;
            Properties.Settings.Default.Save();
            ApiKey = obj;
        }

        private string GetApiKey()
        {
            /// TODO 05 : Retourner la configuration
            return Properties.Settings.Default.apiKey;
        }

    }
}
