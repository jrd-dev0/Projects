namespace DesingPatternsV2.Models.Repositories
{
    public interface IVeiculoRepository
    {
        Veiculo GetById(Guid id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Update(Veiculo veiculo);
        
        void Delete(Veiculo veiculo);
    }
}
