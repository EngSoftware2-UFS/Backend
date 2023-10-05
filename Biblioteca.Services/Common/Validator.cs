using System.Text.RegularExpressions;

namespace Biblioteca.Services.Common
{
    internal static class Validator
    {
        internal static bool IsEmail(string email)
        {
            var emailRx = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            if (!emailRx.IsMatch(email))
                return false;

            return true;
        }

        internal static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            var onlyDigitsRX = new Regex(@"^\d{11}$");
            if (!onlyDigitsRX.IsMatch(cpf))
                return false;

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        internal static bool IsIsbn(string isbn)
        {
            isbn = isbn.Trim();
            string isbnDigits = Regex.Replace(isbn, @"[^\d]", "");
            var rx = new Regex(@"^\d{13}$");
            if (!rx.IsMatch(isbnDigits))
                return false;

            int soma = 0;
            for (var i = 0; i < isbnDigits.Length - 1; i++)
            {
                var digit = Convert.ToInt32(isbnDigits[i]);
                if (i % 2 == 0)
                    soma += (digit * 3);
                else
                    soma += digit;
            }

            var verifiedDigit = 10 - (soma % 10);
            if (verifiedDigit == 10)
                verifiedDigit = 0;

            string lastDigitStr = isbnDigits[isbnDigits.Length - 1].ToString();
            var lastDigit = Convert.ToInt32(lastDigitStr);

            if ((soma + verifiedDigit) % 10 != 0) return false;
            if (lastDigit != verifiedDigit) return false;
            if ((soma + lastDigit) % 10 != 0) return false;

            return true;
        }
    }
}
