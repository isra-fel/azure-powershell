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

namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class AdlsGen1Tests : DataShareTestRunner
    {
        public AdlsGen1Tests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }
        //Retire Azure Data Lake Storage Gen1 on 29 February 2024. https://azure.microsoft.com/en-us/updates?id=action-required-switch-to-azure-data-lake-storage-gen2-by-29-february-2024
        [Fact(Skip = "The Gen1 was retired.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsGen1Crud()
        {
            TestRunner.RunTestScript("Test-AdlsGen1Crud");
        }
    }
}
