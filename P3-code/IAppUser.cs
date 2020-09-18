using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_code
{
    public interface IAppUser
    {
        public bool Login(string UserName, string Password);

        public List<AppUser> GetAll();

        public void SetAuthentication(string UserName, bool IsAuthenticated);

        public AppUser GetByUserName(string UserName);
    }
}


