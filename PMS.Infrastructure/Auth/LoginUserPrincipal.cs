using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PMS.Infrastructure.Auth
{
    public class LoginUserPrincipal : IPrincipal
    {
        public LoginUserPrincipal(string EID)
        {
            Identity = new GenericIdentity(EID);
        }

        /// <summary>
        ///     标识
        /// </summary>
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

    }
}
