﻿using Musication.Enums.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musication.Model.Security
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int MenuOrder { get; set; }
        public string ImageName { get; set; }
        public string MenuItemName { get; set; }
        public string NavigationPath { get; set; }
        public MenuTypeEnum MenuType { get; set; }
    }
}


