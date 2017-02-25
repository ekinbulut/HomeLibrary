namespace Library.Business.Services.Integration.Parser
{
    public interface IFileReciever
    {
        bool RecieveFile(string strdocPath, byte[] bytes);
        void CreateFolder(string path);
        bool ValidatePath(string path);
    }
}