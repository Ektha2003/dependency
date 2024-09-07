namespace ServiceContract
{
    public interface ICitiesService
    {
        Guid Id { get; }
        List<String> GetCities();
    }
}
