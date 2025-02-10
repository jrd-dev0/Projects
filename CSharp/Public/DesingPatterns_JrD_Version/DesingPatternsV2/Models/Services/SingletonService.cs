namespace DesingPatternsV2.Models.Services
{
    public class SingletonService
    {
        public Guid Guid { get; } = Guid.NewGuid();
    }
}
