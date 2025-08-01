
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an in-memory object for BgpAdvertisement.
.Description
Create an in-memory object for BgpAdvertisement.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.BgpAdvertisement
.Link
https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudBgpAdvertisementObject
#>
function New-AzNetworkCloudBgpAdvertisementObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.BgpAdvertisement')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The indicator of if this advertisement is also made to the network fabric associated with the Network Cloud Cluster. This field is ignored if fabricPeeringEnabled is set to False.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.AdvertiseToFabric])]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.AdvertiseToFabric]
        $AdvertiseToFabric,
        [Parameter(HelpMessage="The names of the BGP communities to be associated with the announcement, utilizing a BGP community string in 1234:1234 format.")]
        [string[]]
        $Community,
        [Parameter(Mandatory, HelpMessage="The names of the IP address pools associated with this announcement.")]
        [string[]]
        $IPAddressPool,
        [Parameter(HelpMessage="The names of the BGP peers to limit this advertisement to. If no values are specified, all BGP peers will receive this advertisement.")]
        [string[]]
        $Peer
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.BgpAdvertisement]::New()

        if ($PSBoundParameters.ContainsKey('AdvertiseToFabric')) {
            $Object.AdvertiseToFabric = $AdvertiseToFabric
        }
        if ($PSBoundParameters.ContainsKey('Community')) {
            $Object.Community = $Community
        }
        if ($PSBoundParameters.ContainsKey('IPAddressPool')) {
            $Object.IPAddressPool = $IPAddressPool
        }
        if ($PSBoundParameters.ContainsKey('Peer')) {
            $Object.Peer = $Peer
        }
        return $Object
    }
}

