namespace WebApplicationApiDemo.General.Interfaces
{
    public interface IMerchService
    {
        void CreateMerch(Guid userId);
        void DeleteMerch(Guid userId);
    }
}
