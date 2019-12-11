using Musication.Model;
using Musication.Model.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Musication.Services.Interfaces
{
    public interface IDatabase
    {
        Task<int> SaveItemAsync(UserProfile item);
    }
}
