using Azure.Core;
using Azure.Identity;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    internal class CurrentUserAuthenticator : DelegatingAuthenticator
    {
        //private static string[] Scopes = new[] { "https://management.core.windows.net//.default" };

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var interactiveParameters = parameters as InteractiveParameters;
            var onPremise = parameters.Environment.OnPremise;
            //null instead of "organizations" should be passed to Azure.Identity to support MSA account 
            var tenantId = onPremise ? AdfsTenant :
                parameters.TenantId;
            //(string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var tokenCacheProvider = parameters.TokenCacheProvider;
            var resource = parameters.Environment.GetEndpoint(parameters.ResourceId) ?? parameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var clientId = AuthenticationHelpers.PowerShellClientId;
            var authority = parameters.Environment.ActiveDirectoryAuthority;
            return SignInWithOsUser(tokenCacheProvider, clientId, authority, tenantId, scopes);

            //var requestContext = new TokenRequestContext(scopes);

            //var options = new InteractiveBrowserCredentialOptions()
            //{
            //    ClientId = clientId,
            //    TenantId = tenantId,
            //    TokenCachePersistenceOptions = tokenCacheProvider.GetTokenCachePersistenceOptions(),
            //    AuthorityHost = new Uri(authority),
            //    RedirectUri = GetReplyUrl(onPremise, interactiveParameters),
            //    LoginHint = interactiveParameters.UserId,
            //};
            //var browserCredential = new InteractiveBrowserCredential(options);

            //TracingAdapter.Information($"{DateTime.Now:T} - [{nameof(CurrentUserAuthenticator)}] Calling InteractiveBrowserCredential.AuthenticateAsync with TenantId:'{options.TenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}', RedirectUri:'{options.RedirectUri}'");
            //var authTask = browserCredential.AuthenticateAsync(requestContext, cancellationToken);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is InteractiveParameters || parameters is SilentParameters;
        }

        private static async Task<IAccessToken> SignInWithOsUser(PowerShellTokenCacheProvider tokenCacheProvider, string clientId, string authority, string tenantId, string[] scopes)
        {
            var brokerOptions = new WindowsBrokerOptions
            {
                ListWindowsWorkAndSchoolAccounts = false,
                MsaPassthrough = true,
            };
            //var app = PublicClientApplicationBuilder.Create(clientId)
            //    .WithAuthority(authority, tenantId)
            //    .WithWindowsBrokerOptions(brokerOptions)
            //    .WithBrokerPreview()
            //    .WithParentActivityOrWindow(() => GetConsoleOrTerminalWindow())
            //    .WithLogging((LogLevel level, string message, bool containsPii) => { Console.WriteLine($"[{level.ToString().PadRight(10)}] {message}"); }, LogLevel.Verbose)
            //    .Build();
            var app = tokenCacheProvider.CreatePublicClient($"{authority}{tenantId}", brokerOptions);
            var result = await app.AcquireTokenSilent(scopes, PublicClientApplication.OperatingSystemAccount).ExecuteAsync();
            TracingAdapter.Information($"Acquired authentication result. Token: [{result.AccessToken.Substring(0, 6)}]. Token type: [{result.TokenType}].");
            return new AuthenticationResultToken(result);
        }

        enum GetAncestorFlags
        {
            GetParent = 1,
            GetRoot = 2,
            /// <summary>
            /// Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.
            /// </summary>
            GetRootOwner = 3
        }

        /// <summary>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose ancestor is to be retrieved.
        /// If this parameter is the desktop window, the function returns NULL. </param>
        /// <param name="flags">The ancestor to be retrieved.</param>
        /// <returns>The return value is the handle to the ancestor window.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        public static IntPtr GetConsoleOrTerminalWindow()
        {
            IntPtr consoleHandle = GetConsoleWindow();
            IntPtr handle = GetAncestor(consoleHandle, GetAncestorFlags.GetRootOwner);

            return handle;
        }
    }
}
