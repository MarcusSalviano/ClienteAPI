
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClienteAPI.Models;

public class CepValidationAttribute : ValidationAttribute
{ 
    public override bool IsValid(object value)
    {
        var cep = value as string;
        var apenasDigitos = new Regex(@"[^\d]");
        cep =  apenasDigitos.Replace(cep, "");

        // URL da API
        string apiUrl = $"https://viacep.com.br/ws/{cep}/json/";

        // Criação do HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    if (responseBody.Contains("erro"))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (HttpRequestException e)
            {
                return false;
            }
        }
        return true;
    }
}