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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    public class VaultCredential
    {
        public InputType InputType = InputType.Raw;
        public string Key = "";
        public PSCredential Raw;

        public VaultCredential(PSCredential pc)
        {
            InputType = InputType.Raw;
            Raw = pc;
        }

        public VaultCredential(string key)
        {
            InputType = InputType.ByKey;
            Key = key;
        }

        public static implicit operator PSCredential(VaultCredential vc)
        {
            switch (vc.InputType)
            {
                case InputType.Raw:
                    return vc.Raw;
                case InputType.ByKey:
                    return ExecuteScript<PSCredential>($"Get-Secret -Name {vc.Key}").First();
            }
            throw new Exception();
        }

        public static implicit operator VaultCredential(PSCredential pc) => new VaultCredential(pc);
        public static implicit operator VaultCredential(string key) => new VaultCredential(key);

        private static List<T> ExecuteScript<T>(string contents)
        {
            List<T> output = new List<T>();

            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                powershell.AddScript(contents);
                Collection<T> result = powershell.Invoke<T>();


                if (result != null && result.Count > 0)
                {
                    output.AddRange(result);
                }
            }

            return output;
        }
    }

    public enum InputType
    {
        Raw,
        ByKey
    }
}