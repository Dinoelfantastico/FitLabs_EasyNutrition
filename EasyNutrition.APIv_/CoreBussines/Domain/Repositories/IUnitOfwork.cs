namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IUnitOfwork
    {
        Task CompleteAsync();
    }
}
