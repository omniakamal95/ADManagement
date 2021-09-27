using ADManagement.Services.Interfaces;
using ADManagement.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices.ActiveDirectory;
using ADManagement.Models;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace ADManagement.Services
{
    public class ADService : IADService
    {
        public ResultViewModel CreateUser(string name, string accountName)
        {
            ResultViewModel result = new ResultViewModel()
            {
                Message = "An Error Occured",
                Success = false
            };

            var ctx = new PrincipalContext(ContextType.Domain, "192.168.159.128", "CN=Users,DC=smplIDtest,DC=com", "SMPLIDTEST/Administrator", "No@123456");
            UserPrincipal userPrin = new UserPrincipal(ctx);

            userPrin.Name = name;
            userPrin.SamAccountName = accountName;
            userPrin.DisplayName = name;
            userPrin.UserPrincipalName = name;
            userPrin.Save();

            result.Message = "User Created Successfully";
            result.Success = true;
            return result;
        }

        public ResultListViewModel<User> GetAllUsers()
        {
            ResultListViewModel<User> result = new ResultListViewModel<User>()
            {
                Message = "An Error Occured",
                Success = false
            };
            List<User> AdUsers = new List<User>();
            var ctx = new PrincipalContext(ContextType.Domain, "192.168.159.128", "CN=Users,DC=smplIDtest,DC=com", "smplIDtest/Administrator", "No@123456");
            UserPrincipal userPrin = new UserPrincipal(ctx);
            userPrin.Name = "*";
            var searcher = new PrincipalSearcher();
            searcher.QueryFilter = userPrin;
            var results = searcher.FindAll();
            foreach (Principal p in results)
            {
                AdUsers.Add(new User
                {
                    DisplayName = p.DisplayName,
                    Samaccountname = p.SamAccountName
                });
            }
            result.Message = "Users Retrieved Successfully";
            result.Success = true;
            result.ReturnObjectList = AdUsers;

            return result;
        }

       

        public ResultViewModel SearchActiveDirectory(string name)
        {
            ResultListViewModel<User> result = new ResultListViewModel<User>()
            {
                Message = "No Users Found",
                Success = false
            };
            List<User> AdUsers = new List<User>();
            var ctx = new PrincipalContext(ContextType.Domain, "192.168.159.128", "CN=Users,DC=smplIDtest,DC=com", "smplIDtest/Administrator", "No@123456");
            UserPrincipal userPrin = new UserPrincipal(ctx);
            userPrin.Name = name;
            var searcher = new PrincipalSearcher();
            searcher.QueryFilter = userPrin;
            var results = searcher.FindAll();
            foreach (Principal p in results)
            {
                AdUsers.Add(new User
                {
                    DisplayName = p.DisplayName,
                    Samaccountname = p.SamAccountName
                });
            }
            result.Message = "Users Retrieved Successfully";
            result.Success = true;
            result.ReturnObjectList = AdUsers;

            return result;

        }

       
      
    }

}
