using System.Net;
using System.Text.RegularExpressions;
using System;
using RestSharp;
using Newtonsoft.Json;

var random = new Random();

//trocar pelo token e instancia da zapi
string instance = "IdInstancia";
string token = "Token";

var mes = $"mensagem";
var num = "numero";

var client = new RestClient("https://api.z-api.io/instances/" + instance + "/token/" + token + "/send-text");
var request = new RestRequest();
request.Method = Method.Post;

request.AddHeader("Content-Type", "application/json");

var messageObject = new
{
    phone = num,
    message = mes,
    delayMessage = 4
};


string jsonBody = JsonConvert.SerializeObject(messageObject);


request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
for (int i = 0; i < 2; i++)
{
    RestResponse response = await client.ExecuteAsync(request);

    if (response.StatusCode == HttpStatusCode.OK)
    {
        Console.WriteLine("Mensagem enviada com sucesso.");
    }
    else
    {
        Console.WriteLine($"Erro no envio da mensagem. Status: {response.StatusCode}, Conteúdo: {response.Content}");
    }
}

