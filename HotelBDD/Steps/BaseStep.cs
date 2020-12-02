using BoDi;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBDD.Steps
{
    [Binding]
    public class BaseStep
    {
        private string _host = "https://localhost:44334";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private string _name;
        private string _cpf;
        private string _hash;
        private string _descricao;
        private double _value;
        private int _andar;
        private int _numeroQuarto;
        private string _situacao;
        private int _idTipoQuarto;
        private int _idCliente;
        private int _idQuarto;
        private int _qdeDiaria;
        private DateTime _data;

        public BaseStep(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario]
        public void Setup()
        {
            _restClient = new RestClient();
            _objectContainer.RegisterInstanceAs(_restClient);
            _restRequest = new RestRequest();
            _objectContainer.RegisterInstanceAs(_restRequest);
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restResponse);
            _restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        [Given(@"que o endpoint é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http é '(.*)'")]
        public void DadoQueOMetodoHttpEh(string metodo)
        {
            if (metodo.ToUpper() == "GET")
                _restRequest.Method = Method.GET;

            if (metodo.ToUpper() == "POST")
                _restRequest.Method = Method.POST;

            if (metodo.ToUpper() == "PUT")
                _restRequest.Method = Method.PUT;

            if (metodo.ToUpper() == "DELETE")
                _restRequest.Method = Method.DELETE;

            if (metodo.ToUpper() == "PATCH")
                _restRequest.Method = Method.PATCH;
        }

        [Given(@"que o id é (.*)")]
        public void DadoQueOIdDoClienteEh(int id) => _id = id;

        [Given(@"que o nome é (.*)")]
        public void DadoQueONomeDoClienteEh(string name) => _name = name;

        [Given(@"que o cpf é (.*)")]
        public void DadoQueOCPFDoClienteEh(string cpf) => _cpf = cpf;

        [Given(@"que o hash é (.*)")]
        public void DadoQueOHashDoClienteEh(string hash) => _hash = hash;

        [Given(@"que o value é (.*)")]
        public void DadoQueAValorDoTipoQuartoEh(double value) => _value = value;

        [Given(@"que o descricao é (.*)")]
        public void DadoQueADescricaoDoTipoQuartoEh(string descricao) => _descricao = descricao;

        [Given(@"que o andar é (.*)")]
        public void DadoQueOAndarDoQuartoEh(int andar) => _andar = andar;

        [Given(@"que o numero do quarto é (.*)")]
        public void DadoQueONumeroDoQuartoEh(int numero) => _numeroQuarto = numero;

        [Given(@"que o situacao é (.*)")]
        public void DadoQueASituacaoDoQuartoEh(string situacao) => _situacao = situacao;

        [Given(@"que o id do tipo do quarto é (.*)")]
        public void DadoQueIDDoTipoDeQuartoEh(int id) => _idTipoQuarto = id;

        [Given(@"que o quantidade diaria é (.*)")]
        public void DadoQueQdeDiariaEh(int diaria) => _qdeDiaria = diaria;

        [Given(@"que o data é (.*)")]
        public void DadoQueDataEh(DateTime data) => _data= data;

        [Given(@"que o id do cliente é (.*)")]
        public void DadoQueIDDoClienteEh(int id) => _idCliente = id;

        [Given(@"que o id do id do quarto é (.*)")]
        public void DadoQueIDDoQuartoEh(int id) => _idQuarto = id;

        [When(@"obter o cliente")]
        public void QuandoObterACliente() => Client();

        [When(@"gravar o cliente")]
        public void QuandoGravarACliente() => GravarClient();

        [When(@"gravar o tipo de quarto")]
        public void QuandoGravarOTipoQuarto() => GravarTipoQuarto();

        [When(@"obter o tipo de quarto")]
        public void QuandoObterOTipoQuarto() => TipoQuarto();

        [When(@"obter o room")]
        public void QuandoObterOQuarto() => Room();

        [When(@"gravar o room")]
        public void QuandoGravarOQuarto() => GravarQuarto();

        [When(@"alterar o quarto")]
        public void QuandoAlterarOQuarto() => AlterarQuarto();

        [When(@"gravar o operacao")]
        public void QuandoGravarOperacao() => GravarOcupacao();

        [Then(@"a resposta será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);

        public void Client()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_id != 0)
                _restRequest.AddParameter("id", _id);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void GravarClient()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                name = _name,
                cpf = _cpf,
                hashs = _hash
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void GravarTipoQuarto()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                description = _descricao,
                value = _value
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void TipoQuarto()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_id != 0)
                _restRequest.AddParameter("id", _id);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void Room()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_id != 0)
                _restRequest.AddParameter("roomId", _id);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void GravarQuarto()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                  buildingFloor = _andar,
                  roomNum = _numeroQuarto,
                  situation= _situacao,
                  typeRoomId = _idTipoQuarto
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void AlterarQuarto()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                id = _id,
                situation = _situacao
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void GravarOcupacao()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                  dailyAmount = _qdeDiaria,
                  date = _data,
                  situation = _situacao,
                  clientId = _idCliente,
                  roomId = _idQuarto
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
