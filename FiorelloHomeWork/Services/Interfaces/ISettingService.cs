namespace FiorelloHomeWork.Services.Interfaces
{
    public interface ISettingService
    {
        public Task<Dictionary<string, string>> GetAllAsync();
    }
}
