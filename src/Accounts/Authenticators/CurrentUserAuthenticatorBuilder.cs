using Microsoft.Azure.Commands.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class CurrentUserAuthenticatorBuilder : IAuthenticatorBuilder
    {
        public IAuthenticator Authenticator { get; private set; }

        public CurrentUserAuthenticatorBuilder()
        {
            Reset();
        }

        public bool AppendAuthenticator(Func<IAuthenticator> constructor)
        {
            if (null == Authenticator)
            {
                Authenticator = constructor();
                return true;
            }

            IAuthenticator current;
            for (current = Authenticator; current != null && current.Next != null; current = current.Next) ;
            current.Next = constructor();
            return true;
        }

        public void Reset()
        {
            AppendAuthenticator(() => new CurrentUserAuthenticator());
            //AppendAuthenticator(() => new SilentAuthenticator());
        }
    }
}
