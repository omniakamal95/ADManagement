using ADManagement.Models;
using ADManagement.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADManagement.Services.Interfaces
{
    public interface IADService
    {
        ResultViewModel CreateUser(string name, string accountName);
        ResultViewModel SearchActiveDirectory(string name);
        ResultListViewModel<User> GetAllUsers();

    }
}
