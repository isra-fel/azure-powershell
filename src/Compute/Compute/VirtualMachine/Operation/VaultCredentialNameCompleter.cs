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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    public class VaultCredentialNameCompleterAttribute : ArgumentCompleterAttribute
    {
        public VaultCredentialNameCompleterAttribute() : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$vault = (Get-SecretVault | ? {$_.IsDefault}).Name\n" +
                "if ($null -eq $vault -or -not (Test-SecretVault $vault)) { return; }\n" +
                "$names = (Get-SecretInfo -Vault $vault).Name\n" +
                "$names | Where-Object { $_ -Like \"$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}