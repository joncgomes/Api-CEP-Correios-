using ConsumindoApiCEP.Controller;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApiCEP
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsultandoCEP();
            Console.ReadKey();
        }

        static async Task ConsultandoCEP ()
        {
            try
            {
                var cep = RestService.For<ICepResponse>("http://viacep.com.br");

                Console.WriteLine("Informe o CEP Desejado:");

                Console.WriteLine("Digite o CEP: ");
                string cepInformado = Console.ReadLine().ToString();

                Console.WriteLine("Consultando Informações do CEP:" + cepInformado);

                var address = await cep.GetAddressAsync(cepInformado);

                Console.Write($"\nLogradouro:{address.Logradouro}\nBairro:{address.Bairro}\nCidade:{address.Localidade}");
               


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na Consulta de CEP: " + ex.Message);
                throw;
            }
        }
    }
}
