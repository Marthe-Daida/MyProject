using Musication.Enums.Security;
using Musication.Messages.Security;
using Musication.Model.Security;
using Musication.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Musication.ViewModels
{
    public class MainViewViewModel : ViewModelBase
    {
        private ISecurityService _securityService;
        private IEventAggregator _eventAggregator;

        private DelegateCommand<MenuItem> _navigateCommand;
        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public DelegateCommand<MenuItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<MenuItem>(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand(MenuItem menu)
        {
            if (menu.MenuType == MenuTypeEnum.LogOut)
                _securityService.LogOut();
            else
                await NavigationService.NavigateAsync(menu.NavigationPath);

        }

        public MainViewViewModel(INavigationService navigationService, ISecurityService securityService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            Title = "Main Page";

            _securityService = securityService;
            _eventAggregator = eventAggregator;

            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());

            _eventAggregator.GetEvent<LoginMessage>().Subscribe(LoginEvent);
            _eventAggregator.GetEvent<LogOutMessage>().Subscribe(LogOutEvent);
        }

        public void LoginEvent(UserProfile userProfile)
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());

            NavigationService.NavigateAsync("NavigationPage/MapsView");
        }

        public void LogOutEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());

            NavigationService.NavigateAsync("NavigationPage/LoginView");
        }

    }
}
