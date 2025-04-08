namespace AzDev.Services
{
    interface IAssemblyService
    {
        void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath, string cgManifestPath);
    }
}
