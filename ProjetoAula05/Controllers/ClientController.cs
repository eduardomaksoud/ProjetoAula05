using Newtonsoft.Json;
using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;

namespace ProjetoAula05.Controllers
{
    public class ClientController
    {
        private ClientRepository _clientRepository = new ClientRepository();
        public async Task RegisterClientAsync()
        {
            Console.WriteLine("Welcome to the Client Registration System!");

            // Ask for CPF
            Console.Write("Enter client CPF: ");
            string cpf = Console.ReadLine();

            // Check if client exists
            if (_clientRepository.GetByCpf(cpf) != null)
            {
                Console.WriteLine("Client already registered.");
            }
            else
            {
                // Client registration phase
                Console.WriteLine("Client not found. Let's register a new client.");

                // Ask for name
                Console.Write("Enter client name: ");
                string name = Console.ReadLine();

                // Ask for CEP
                Console.Write("Enter client CEP: ");
                string cep = Console.ReadLine();

                // Call API to get address information
                Address address = await GetAddressFromApiAsync(cep).ConfigureAwait(false);

                if (address != null)
                {
                    // Display the address information
                    Console.WriteLine("Address Information:");
                    Console.WriteLine($"Public Area: {address.PublicArea}");
                    Console.WriteLine($"Complement: {address.Complement}");
                    Console.WriteLine($"Number: {address.Number}");
                    Console.WriteLine($"Neighborhood: {address.Neighborhood}");
                    Console.WriteLine($"City: {address.City}");
                    Console.WriteLine($"State: {address.State}");

                    // Save the new client to the database
                    Client newClient = new Client { Cpf = cpf, Name = name, Address = address };
                    _clientRepository.Insert(newClient);

                    Console.WriteLine("Client registered successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve address information from the API.");
                }
            }
        }

        private async Task<Address> GetAddressFromApiAsync(string cep)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://viacep.com.br/ws/{cep}/json/";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        // Deserialize the JSON manually
                        Address address = JsonConvert.DeserializeObject<Address>(jsonResponse);
                        return address;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Return null in case of an error
                return null;
            }
        }


    }
}
