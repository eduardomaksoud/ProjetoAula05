using Newtonsoft.Json;

namespace ProjetoAula05.Entities
{
    public class Address
    {
        #region Attributes

        private Guid? _id;
        private string? _publicArea;
        private string? _complement;
        private string? _number;
        private string? _neighborhood;
        private string? _city;
        private string? _state;
        private string? _cep;

        private Guid? _clientId;

        #endregion

        #region Properties

        public Guid? Id;

        [JsonProperty("logradouro")]
        public string? PublicArea;

        [JsonProperty("complemento")]
        public string? Complement;

        [JsonProperty("gia")]
        public string? Number;

        [JsonProperty("bairro")]
        public string? Neighborhood;

        [JsonProperty("localidade")]
        public string? City;

        [JsonProperty("uf")]
        public string? State;

        [JsonProperty("cep")]
        public string? Cep;

        public Guid? ClientId;

        #endregion
    }
}
