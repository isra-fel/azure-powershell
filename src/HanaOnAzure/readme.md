<!-- region Generated -->
# Az.Hana
This directory contains the PowerShell module for the Hana service.

---
## Status
[![Az.Hana](https://img.shields.io/powershellgallery/v/Az.Hana.svg?style=flat-square&label=Az.Hana "Az.Hana")](https://www.powershellgallery.com/packages/Az.Hana/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.4 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Hana`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/hanaonazure/resource-manager/readme.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Hana
subject-prefix: Sap

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet, update-* is enough
  - where:
      verb: Set
    remove: true
  # Remove commands of Hana instance, which need to be reconsidered
  - where:
      subject: HanaInstance
    remove: true
  # Rename some parameters to follow powershell convention
  - where:
      parameter-name: LogAnalyticsWorkspaceArmId
    set:
      parameter-name: LogAnalyticsWorkspaceResourceId
  - where:
      parameter-name: MonitorSubnet
    set:
      parameter-name: MonitorSubnetResourceId
  # Make location required
  # Fixme: when service team makes the change, remove this line
  - from: swagger-document
    where: $.definitions.TrackedResource
    transform: $['required'] = ['location']
  # Hide New-*ProviderInstance for customization
  - where:
      verb: New
      subject: ProviderInstance
    hide: true
```
