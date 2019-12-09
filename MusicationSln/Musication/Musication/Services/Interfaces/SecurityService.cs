using Musication.Enums.Security;
using Musication.Messages.Security;
using Musication.Model.Security;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musication.Services.Interfaces
{
    public class SecurityService : ISecurityService
    {
        private IEventAggregator _eventAggregator;
        public IList<MenuItem> _allMenuItems;

        public bool LoggedIn { get; set; }

        public SecurityService(IEventAggregator eventAggregator)
        {
            CreateMenuItems();

            _eventAggregator = eventAggregator;
        }

        public IList<MenuItem> GetAllowedAccessItems()
        {
            if (LoggedIn)
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.Secured || item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.LogOut)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
            else
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.Login)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
        }

        public bool LogIn(string userName, string password)
        {
            // Do Your Stuff to Check if Legit (ie API Calls)

            LoggedIn = true;

            return true;
        }

        public void LogOut()
        {
            LoggedIn = false;

            _eventAggregator.GetEvent<LogOutMessage>().Publish();
        }



        private void CreateMenuItems()
        {
            _allMenuItems = new List<MenuItem>();

            var menuItem = new MenuItem();
            menuItem.MenuItemId = 1;
            menuItem.MenuItemName = "Login";
            menuItem.NavigationPath = "NavigationPage/LoginView";
            menuItem.MenuType = MenuTypeEnum.Login;
            menuItem.MenuOrder = 1;
            menuItem.ImageName = "login.png";

            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 2;
            menuItem.MenuItemName = "Logout";
            menuItem.NavigationPath = "";
            menuItem.MenuOrder = 99;
            menuItem.MenuType = MenuTypeEnum.LogOut;
            menuItem.ImageName = "logout.png";


            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 3;
            menuItem.MenuItemName = "Maps View";
            menuItem.NavigationPath = "NavigationPage/MapsView";
            menuItem.MenuOrder = 3;
            menuItem.MenuType = MenuTypeEnum.UnSecured;
            menuItem.ImageName = "map.png";



            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 4;
            menuItem.MenuItemName = "Music Theory Book";
            menuItem.NavigationPath = "NavigationPage/ViewPdf";
            menuItem.MenuOrder = 4;
            menuItem.MenuType = MenuTypeEnum.UnSecured;
            menuItem.ImageName = "theory.png";


            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.MenuItemId = 5;
            menuItem.MenuItemName = "About";
            menuItem.NavigationPath = "NavigationPage/EmbeddedHtmlView";
            menuItem.MenuOrder = 5;
            menuItem.MenuType = MenuTypeEnum.UnSecured;
            menuItem.ImageName = "about.png";


            _allMenuItems.Add(menuItem);


            menuItem = new MenuItem();
            menuItem.MenuItemId = 6;
            menuItem.MenuItemName = "Youtube Viewer";
            menuItem.NavigationPath = "";
            menuItem.MenuOrder = 6;
            menuItem.MenuType = MenuTypeEnum.UnSecured;
            menuItem.ImageName = "video.png";


            _allMenuItems.Add(menuItem);

        }
    }
}

            
          
        

