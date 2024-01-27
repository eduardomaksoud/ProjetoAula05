using Dapper;
using ProjetoAula05.Entities;
using System.Data.SqlClient;

namespace ProjetoAula05.Repositories
{
    public class ClientRepository
    {
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = BDAula05; Integrated Security = True;";
        public void Insert(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("SP_INSERIR_CLIENTE", new
                {
                    @Name = client.Name,
                    @Cpf = client.Cpf,
                    @PublicArea = client.Address?.PublicArea,
                    @Complement = client.Address?.Complement,
                    @Number = client.Address?.Number,
                    @Neighborhood = client.Address?.Neighborhood,
                    @City = client.Address?.City,
                    @State = client.Address?.State,
                    @Cep = client.Address?.Cep
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Client? GetByCpf(string cpf)
        {
            using (var connection = new SqlConnection(_connectionString))

            {
                return connection.Query<Client>(@"
                    SELECT * FROM CLIENT
                    WHERE CPF = @CPF
                ",
                new { @CPF = cpf }).FirstOrDefault();


            }
        }
    }
}
