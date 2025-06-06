<!-- region Generated -->
# Az.ImportExport
This directory contains the PowerShell module for the ImportExport service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ImportExport`, see [how-to.md](how-to.md).
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
commit: a59006e985447b922b68210244e5fd024a30f1b4
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/storageimportexport/resource-manager/readme.md

title: ImportExport
module-version: 0.1.0
subject-prefix: ''

directive:
  - from: swagger-document
    where: $..get
    transform: delete $.externalDocs
  - from: swagger-document
    where: $..post
    transform: delete $.externalDocs
  - from: swagger-document
    where: $..delete
    transform: delete $.externalDocs
  - from: swagger-document
    where: $..put
    transform: delete $.externalDocs
  - from: swagger-document
    where: $..patch
    transform: delete $.externalDocs

  - from: swagger-document
    where: $.definitions.PutJobParameters.properties.tags
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "Specifies the tags that will be assigned to the job."
        }

  - from: swagger-document
    where: $.definitions.UpdateJobParameters.properties.tags
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "Specifies the tags that will be assigned to the job."
        }

  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentityExpanded$
    remove: true

  - where:
      subject: Job
      parameter-name: BlobPath
    set:
      parameter-name: BlobListBlobPath

  - where:
      subject: Job
      parameter-name: EncryptionKeyKekVaultResourceId
    set:
      parameter-name: EncryptionKeyKekVaultId

  - where:
      subject: Job
    set:
      subject: ImportExport
  - where:
      subject: Location
    set:
      subject: ImportExportLocation
  - where:
      subject: BitLockerKey
    set:
      subject: ImportExportBitLockerKey
    hide: true

```
