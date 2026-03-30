using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoVendas.Validador
{
    public class ValidadorCartao
    {
        public static ValidationResult ValidarData(string? data, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(data))
                return new ValidationResult("Por favor informe a data de validade");

            var partes = data.Split('/');

            if (partes.Length != 2)
                return new ValidationResult("Formato inválido");

            if (!int.TryParse(partes[0], out int mes) ||
                !int.TryParse(partes[1], out int ano))
                return new ValidationResult("Formato inválido");

            if (mes < 1 || mes > 12)
                return new ValidationResult("Mês inválido");

            ano += 2000;

            var hoje = DateTime.Today;

            if (ano > hoje.Year + 10)
            {
                return new ValidationResult("Data de validade inválida");
            }

            if (ano < hoje.Year ||
               (ano == hoje.Year && mes < hoje.Month))
            {
                return new ValidationResult("Cartão Vencido");
            }

            return ValidationResult.Success;
        }
    }
}
