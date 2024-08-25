
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClienteAPI.Validations;

public class CpfValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var cpf = value as string;

        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        // Remove caracteres não numéricos
        cpf = Regex.Replace(cpf, @"[^\d]", "");

        if (cpf.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais
        if (new string(cpf[0], cpf.Length) == cpf)
            return false;

        // Calcula os dígitos verificadores
        for (int j = 9; j < 11; j++)
        {
            int soma = 0;
            for (int i = 0; i < j; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (j + 1 - i);
            }

            int digitoVerificador = soma % 11;
            digitoVerificador = digitoVerificador < 2 ? 0 : 11 - digitoVerificador;

            if (int.Parse(cpf[j].ToString()) != digitoVerificador)
                return false;
        }

        return true;
    }
}