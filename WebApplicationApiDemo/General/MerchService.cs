using WebApplicationApiDemo.General.Interfaces;

namespace WebApplicationApiDemo.General
{
    public class MerchService : IMerchService
    {
        public void CreateMerch(Guid userId)
        {
            Console.WriteLine($"Creating merch for user with ID: {userId}");
        }

        public void DeleteMerch(Guid userId)
        {
            Console.WriteLine($"Deleting merch for user with ID: {userId}");
        }
    }
}
