using System;

namespace ValidadorCpf
{
    class Program
    {
        static void Main(string[] args)
        {
            int contador = 10;
            int soma = 0;
            int resto;

            Console.WriteLine("Bem vindo ao validador de CPF!");
            Console.WriteLine();
            Console.Write("Informe o CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine(ValidaCpf(RemovePontos(cpf)));
        }

        static string RemovePontos(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        static string ValidaCpf(string cpf)
        {
            int soma = 0;
            int contador = 10;
            int resto1, resto2;

            // Verificando se o cpf é composto apenas por números repetidos
            if (cpf[0] == cpf[1] && cpf[1] == cpf[2] && cpf[2] == cpf[3] && cpf[3] == cpf[4] &&
                cpf[4] == cpf[5] && cpf[5] == cpf[6] && cpf[6] == cpf[7] && cpf[7] == cpf[8] &&
                cpf[8] == cpf[9] && cpf[9] == cpf[10])
            {
                return "Inválido";
            }

            // Validando o primeiro dígito
            for (int i = 0; i < cpf.Length - 2; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * contador;
                contador--;
            }
            resto1 = (soma * 10) % 11;
            if (resto1 == 10)
            {
                resto1 = 0;
            }

            soma = 0;
            contador = 11;

            // Validando o segundo dígito
            for (int i = 0; i < cpf.Length - 1; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * contador;
                contador--;
            }
            resto2 = (soma * 10) % 11;
            if (resto2 == 10)
            {
                resto2 = 0;
            }

            if (resto1 == int.Parse(cpf[9].ToString()) && resto2 == int.Parse(cpf[10].ToString()))
            {
                return "Válido";
            }
            else
            {
                return "Inválido";
            }
        }
    }
}
