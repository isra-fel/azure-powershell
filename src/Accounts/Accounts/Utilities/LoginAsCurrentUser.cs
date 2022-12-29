// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Microsoft.Azure.Commands.Profile
{
    public static class LoginAsCurrentUser
    {
        //private static string[] Scopes = new[] { "https://management.core.windows.net//.default" };

        //public static bool TryLogin()
        //{
        //    try
        //    {
        //        AuthenticateAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        //    }
        //    catch (Exception)
        //    {
        //        Debugger.Break();
        //        return false;
        //    }
        //    return true;
        //}

        //private static void Login()
        //{
        //    SetContextWithOverwritePrompt((localProfile, profileClient, name) =>
        //    {
        //        IAzureEnvironment _environment = null;
        //        if (AzureEnvironment.PublicEnvironments.ContainsKey(EnvironmentName.AzureCloud))
        //        {
        //            _environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
        //        }
        //        var azureAccount = new AzureAccount();
        //        azureAccount.Type = AzureAccount.AccountType.User;
        //        bool shouldPopulateContextList = true;
        //        //if (this.IsParameterBound(c => c.SkipContextPopulation))
        //        //{
        //        //    shouldPopulateContextList = false;
        //        //}

        //        //profileClient.WarningLog = (message) => _tasks.Enqueue(new Task(() => this.WriteWarning(message)));
        //        //profileClient.DebugLog = (message) => _tasks.Enqueue(new Task(() => this.WriteDebugWithTimestamp(message)));
        //        var task = new Task<AzureRmProfile>(() => profileClient.Login(
        //             azureAccount,
        //             _environment,
        //             null, // Tenant,
        //             null, // subscriptionId,
        //             null, // subscriptionName,
        //             null, // password,
        //             false, // SkipValidation, ?
        //             null, // WriteWarningEvent, //Could not use WriteWarning directly because it may be in worker thread
        //             name,
        //             shouldPopulateContextList,
        //             int.MaxValue, // MaxContextPopulation, ?
        //             null)); // resourceId));
        //        task.Start();
        //        //while (!task.IsCompleted)
        //        //{
        //        //    HandleActions();
        //        //    Thread.Yield();
        //        //}

        //        //HandleActions();

        //        //try
        //        //{
        //        //Must not use task.Result as it wraps inner exception into AggregateException
        //        var result = (PSAzureProfile)task.GetAwaiter().GetResult();
        //        //WriteObject(result);
        //        //}
        //        //catch (AuthenticationFailedException ex)
        //        //{
        //        //    string message = string.Empty;
        //        //    if (IsUnableToOpenWebPageError(ex))
        //        //    {
        //        //        WriteWarning(Resources.InteractiveAuthNotSupported);
        //        //        WriteDebug(ex.ToString());
        //        //    }
        //        //    else if (TryParseUnknownAuthenticationException(ex, out message))
        //        //    {
        //        //        WriteDebug(ex.ToString());
        //        //        throw ex.WithAdditionalMessage(message);
        //        //    }
        //        //    else
        //        //    {
        //        //        if (IsUsingInteractiveAuthentication())
        //        //        {
        //        //            //Display only if user is using Interactive auth
        //        //            WriteWarning(Resources.SuggestToUseDeviceCodeAuth);
        //        //        }
        //        //        WriteDebug(ex.ToString());
        //        //        throw;
        //        //    }
        //        //}
        //    });
        //}

        //private static void SetContextWithOverwritePrompt(Action<AzureRmProfile, RMProfileClient, string> setContextAction)
        //{
        //    string name = null;
        //    //if (MyInvocation.BoundParameters.ContainsKey(nameof(ContextName)))
        //    //{
        //    //    name = ContextName;
        //    //}

        //    //AzureRmProfile profile = null;
        //    //bool? originalShouldRefreshContextsFromCache = null;
        //    //try
        //    //{
        //    //    profile = DefaultProfile as AzureRmProfile;
        //    //    if (profile != null)
        //    //    {
        //    //        originalShouldRefreshContextsFromCache = profile.ShouldRefreshContextsFromCache;
        //    //        profile.ShouldRefreshContextsFromCache = false;
        //    //    }
        //    //    if (!CheckForExistingContext(profile, name)
        //    //        || Force.IsPresent
        //    //        || ShouldContinue(string.Format(Resources.ReplaceContextQuery, name),
        //    //        string.Format(Resources.ReplaceContextCaption, name)))
        //    //    {
        //    ModifyContext((prof, client) => setContextAction(prof, client, name));
        //    //    }
        //    //}
        //    //finally
        //    //{
        //    //    if (profile != null && originalShouldRefreshContextsFromCache.HasValue)
        //    //    {
        //    //        profile.ShouldRefreshContextsFromCache = originalShouldRefreshContextsFromCache.Value;
        //    //    }
        //    //}
        //}

        //private static void ModifyContext(Action<AzureRmProfile, RMProfileClient> contextAction)
        //{
        //    using (var profile = GetDefaultProfile())
        //    {
        //        var client = new RMProfileClient(profile)
        //        {
        //            WarningLog = (s) => WriteWarning(s)
        //        };
        //        contextAction(profile.ToProfile(), client);
        //    }
        //}

        //private static IProfileOperations GetDefaultProfile()
        //{
        //    IProfileOperations result = null;
        //    var currentProfile = DefaultProfile as AzureRmProfile;
        //    switch (GetContextModificationScope())
        //    {
        //        case ContextModificationScope.Process:
        //            result = currentProfile;
        //            break;
        //        case ContextModificationScope.CurrentUser:
        //            result = new AzureRmAutosaveProfile(currentProfile, ProtectedFileProvider.CreateFileProvider(Path.Combine(AzureSession.Instance.ARMProfileDirectory, AzureSession.Instance.ARMProfileFile), FileProtection.ExclusiveWrite));
        //            break;
        //    }

        //    return result;
        //}

        //private async static Task AuthenticateAsync()
        //{
        //    var brokerOptions = new WindowsBrokerOptions
        //    {
        //        ListWindowsWorkAndSchoolAccounts = false,
        //        MsaPassthrough = true,
        //    };
        //    IPublicClientApplication app = PublicClientApplicationBuilder.Create(Constants.PowerShellClientId)
        //        .WithAuthority(AzureCloudInstance.AzurePublic, "organizations")
        //        .WithWindowsBrokerOptions(brokerOptions)
        //        .WithBrokerPreview()
        //        .WithParentActivityOrWindow(() => GetConsoleOrTerminalWindow())
        //        .WithLogging((LogLevel level, string message, bool containsPii) => { Console.WriteLine($"[{level,-6}] {message}"); }, LogLevel.Verbose)
        //        .Build();
        //    var result = await app.AcquireTokenSilent(Scopes, PublicClientApplication.OperatingSystemAccount).ExecuteAsync();
        //    Debugger.Break();
        //}

        //enum GetAncestorFlags
        //{
        //    GetParent = 1,
        //    GetRoot = 2,
        //    /// <summary>
        //    /// Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.
        //    /// </summary>
        //    GetRootOwner = 3
        //}

        ///// <summary>
        ///// Retrieves the handle to the ancestor of the specified window.
        ///// </summary>
        ///// <param name="hwnd">A handle to the window whose ancestor is to be retrieved.
        ///// If this parameter is the desktop window, the function returns NULL. </param>
        ///// <param name="flags">The ancestor to be retrieved.</param>
        ///// <returns>The return value is the handle to the ancestor window.</returns>
        //[DllImport("user32.dll", ExactSpelling = true)]
        //static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);

        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetConsoleWindow();

        //public static IntPtr GetConsoleOrTerminalWindow()
        //{
        //    IntPtr consoleHandle = GetConsoleWindow();
        //    IntPtr handle = GetAncestor(consoleHandle, GetAncestorFlags.GetRootOwner);

        //    return handle;
        //}
    }
}
