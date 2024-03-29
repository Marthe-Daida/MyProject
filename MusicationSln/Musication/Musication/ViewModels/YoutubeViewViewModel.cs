﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Musication.ViewModels
{
    public class YouTubeViewViewModel : ViewModelBase
    {
        public YouTubeViewViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        private string _youTubeUrl;
        public string YouTubeUrl
        {
            get { return _youTubeUrl; }
            set { SetProperty(ref _youTubeUrl, value); }
        }

        private DelegateCommand _openYouTubeCommand;
        public DelegateCommand OpenYouTubeCommand =>
            _openYouTubeCommand ?? (_openYouTubeCommand = new DelegateCommand(ExecuteOpenYouTubeCommand));

        async void ExecuteOpenYouTubeCommand()
        {
            await OpenBrowser(new Uri(YouTubeUrl));
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            YouTubeUrl = "https://www.youtube.com/watch?v=kvGYl8SQBJ0";
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

    }
}

