﻿using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>

namespace P3_code
{
	public class FakeAppUserRepository : IAppUser
	{
        private static Dictionary<int, AppUser> AppUsers;
        public FakeAppUserRepository()
        {
            if (AppUsers == null)
            {
                AppUsers = new Dictionary<int, AppUser>();
                AppUsers.Add(1, new AppUser
                {
                    Id = 1,
                    LastName = "Czerwinski",
                    FirstName = "Nolan",
                });
                AppUsers.Add(2, new AppUser
                {
                    Id = 2,
                    LastName = "Kooima",
                    FirstName = "Sam",
                });
            }
        }
        private int GetNextId()
        {
            int curMaxId = 0;
            foreach (KeyValuePair<int, AppUser> keyValuePair in AppUsers)
            {
                if (keyValuePair.Key > curMaxId)
                {
                    curMaxId = keyValuePair.Key;
                }
            }
            return ++curMaxId;
        }
        public int Save(AppUser App)
        {
            int Id = GetNextId();
            App.Id = Id;
            AppUsers.Add(App.Id, App);
            return Id;
        }
        public List<AppUser> GetAll()
        {
            List<AppUser> Apps = new List<AppUser>();
            foreach (KeyValuePair<int, AppUser> emp in AppUsers)
            {
                Apps.Add(emp.Value);
            }
            return Apps;
        }
        public AppUser GetById(int Id)
        {
            AppUser App;
            bool ignore = AppUsers.TryGetValue(Id, out App);
            return App;
        }

        public bool Login(string UserName, string Password)
        {
            foreach (KeyValuePair<int, AppUser> keyValuePair in AppUsers)
            {
                if (keyValuePair.Value.UserName == UserName && keyValuePair.Value.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }

        public List<AppUser> GetAll()
        {
            return new List<AppUser>(AppUsers.Values);
        }

        public void SetAuthentication(string UserName, bool IsAuthenticated)
        {
            foreach(KeyValuePair<int, AppUser> keyValuePair in AppUsers)
            {
                if (keyValuePair.Value.UserName == UserName)
                {
                    keyValuePair.Value.IsAuthenticated = IsAuthenticated;
                }
            }
        }

        public AppUser GetByUserName(string UserName)
        {
            foreach(KeyValuePair<int, AppUser> keyValuePair in AppUsers)
            {
                if (keyValuePair.Value.UserName == UserName)
                {
                    return keyValuePair.Value;
                }
            }
        }
    }
}

