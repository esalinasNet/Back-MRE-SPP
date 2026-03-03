using System;

namespace Mre.OTI.Presupuesto.Application.Util
{
    public static class NumeroGenerator
    {
        public static string GetCodigoProceso(string ultimoNumeroRegistrado, int anioProceso) => GenerateId(ultimoNumeroRegistrado, anioProceso);
        public static string GetCodigoRandom(int minDigits, int maxDigits) => GetRandom(minDigits, maxDigits);

        private static string GenerateId(string ultimoNumeroRegistrado, int anioProceso)
        {
            if (string.IsNullOrEmpty(ultimoNumeroRegistrado))
            {
                return $"{anioProceso}-{"001"}";
            }

            var numeros = ultimoNumeroRegistrado.Split("-");
            var numero = $"{Convert.ToInt32(numeros[1]) + 1:D3}";
            return $"{anioProceso}-{numero}";
        }

        private static string GetRandom(int minDigits, int maxDigits)
        {
            Random random = new Random();
            if (minDigits < 1 || minDigits > maxDigits)
                throw new ArgumentOutOfRangeException();

            return Convert.ToString(random.Next((int)Math.Pow(10, minDigits - 1), (int)Math.Pow(10, maxDigits - 1)));
        }
    }
}
