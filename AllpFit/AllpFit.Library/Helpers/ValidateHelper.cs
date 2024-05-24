using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AllpFit.Library.Helpers
{
    public static class ValidateHelper
    {
        public static bool ValidateCPF(string cpf)
        {
            // Remove non-digit characters
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Check if the CPF number has 11 digits
            if (cpf.Length != 11)
                return false;

            // Check if the CPF number is composed of all identical digits
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Calculate validation digits
            int total;
            int digit;
            for (int position = 9; position < 11; position++)
            {
                total = 0;
                for (int i = 0; i < position; i++)
                {
                    total += (int)char.GetNumericValue(cpf[i]) * ((position + 1) - i);
                }

                digit = total % 11;
                digit = digit < 10 ? digit : 0;

                if ((int)char.GetNumericValue(cpf[position]) != digit)
                    return false;
            }

            return true;
        }

        public static bool ValidateEmail(string email) => new EmailAddressAttribute().IsValid(email);

        public static bool ValidatePhoneNumber(string phoneNumber)
        {

            // Remove espaços, hífens, parênteses e outros caracteres não numéricos
            string cleanedNumber = Regex.Replace(phoneNumber, "[^0-9]", "");

            // Regex para validar número de telefone fixo ou celular
            // Formatos: (XX) XXXX-XXXX para fixo ou (XX) 9XXXX-XXXX para celular
            string pattern = @"^(\d{2})(9?\d{4})(\d{4})$";  // Código de área + Número

            return Regex.IsMatch(cleanedNumber, pattern);
        }
    }
}
