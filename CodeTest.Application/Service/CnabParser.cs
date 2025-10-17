using CodeTest.Domain;
using System.Globalization;

namespace CodeTest.Application.Service
{
    public class CnabParser : ICnabParser
    {
        public Cnab Parse(string line)
        {
            if (line.Length < 80)
                throw new FormatException($"Linha CNAB inválida: esperados 80 caracteres, recebidos {line.Length}");

            var timeString = line.Substring(42, 6);
            if (!TimeSpan.TryParseExact(timeString, "hhmmss", CultureInfo.InvariantCulture, out var time))
                throw new FormatException($"Hora inválida no CNAB: '{timeString}'");

            return new Cnab
            {
                Type = int.Parse(line.Substring(0, 1)),
                Date = DateTime.ParseExact(line.Substring(1, 8), "yyyyMMdd", CultureInfo.InvariantCulture),
                Value = decimal.Parse(line.Substring(9, 10)) / 100,
                CPF = line.Substring(19, 11),
                Card = line.Substring(30, 12),
                Time = time,
                StoreOwner = line.Substring(48, 14).Trim(),
                StoreName = line.Substring(62, 19).Trim()
            };
        }

    }



}
