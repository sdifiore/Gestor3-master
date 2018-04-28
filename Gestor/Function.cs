using Gestor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Gestor
{
    public class Function
    {
        public static float Ceiling(float value, float significance)
        {
            float result = (value % significance) > Global.Tolerance
                ? ((int)(value / significance) * significance) + significance
                : (float)Math.Ceiling(value);

            return result;
        }

        public static int Floor(float value, float significance)
        {

            int result = (value % significance) > Global.Tolerance
                ? ((int)((value / significance) * significance))
                : (int)Math.Floor(value);

            return result;
        }

        public static float Multiplo(float valor, float limite)
        {
            while ((valor % limite) != 0)
            {
                valor--;
            }

            return valor;
        }

        public static float MinCeiling(float valor, float multiplo)
        {
            double acumulo = valor;

            if (Math.Abs(multiplo) > Global.Tolerance)
            {
                acumulo = Math.Truncate(valor / multiplo) * multiplo;

                while (acumulo < valor)
                {
                    acumulo = acumulo + multiplo;
                }
            }

            return (float)acumulo;
        }

        public static string Right(string texto, int posicoes)
        {
            return texto.Substring(texto.Length - posicoes, posicoes);
        }

        public static float Number(string value)
        {
            var convert = new Regex(@"([-+]?[0-9]*\.*\,?[0-9]+)");
            Match match = convert.Match(value);
            float result = match.Success
                ? float.Parse(match.Value)
                : 0;

            return result;
        }

        public static float Round(float value, int pos)
        {
            float result = (float)(Math.Round(value * Math.Pow(10, pos)) / Math.Pow(10, pos));

            return result;
        }

        public static string Uf(string uf)
        {
            string result;
            using (var db = new ApplicationDbContext())
            {
                var temp = db.Ufs.SingleOrDefault(u => u.Nome == uf);
                result = temp == null
                    ? ""
                    : temp.Sigla;
            }

            return result;
        }

        public static float ParseFloat(string celula)
        {
            float valor;
            float result = float.TryParse(celula, out valor)
                ? valor
                : 0;

            return result;
        }

        public static int ParseInt(string celula)
        {
            int valor;
            int result = int.TryParse(celula, out valor)
                ? valor
                : 0;

            return result;
        }

        public static DateTime ParseDate(string celula)
        {
            DateTime valor;
            DateTime result = DateTime.TryParse(celula, out valor)
                ? valor
                : DateTime.Parse("01/01/01");

            return result;
        }

        public static int Categoria(string celula)
        {
            var result = new Categoria();
            using (var db = new ApplicationDbContext())
            {
                celula = $"{celula}  ";
                var comp = celula.Substring(0, 2);
                result = db.Categorias.SingleOrDefault(c => c.Apelido == comp);
                if (result == null) return 12;
            }

            return result.CategoriaId;
        }

        public static int Familia(string celula)
        {
            var result = new Familia();
            using (var db = new ApplicationDbContext())
            {
                celula = $"{celula}   ";
                var comp = celula.Substring(0, 3);
                result = db.Familias.SingleOrDefault(c => c.Apelido == comp);
                if (result == null) return 15;
            }

            return result.FamiliaId;
        }

        public static int Linha(string celula)
        {

            var result = new Linha();
            using (var db = new ApplicationDbContext())
            {
                celula = $"{celula}    ";
                var comp = celula.Substring(0, 4);
                result = db.Linhas.SingleOrDefault(c => c.Apelido == comp);
                if (result == null) return 12;
            }

            return result.LinhaId;
        }

        public static int Marca(string celula)
        {
            var result = new Marca();
            using (var db = new ApplicationDbContext())
            {
                result = db.Marcas.SingleOrDefault(m => m.Descricao == celula);
                if (result == null) return 4;
            }

            return result.Id;
        }

        public static int TipoVenda(string celula)
        {
            var result = new TipoVenda();
            using (var db = new ApplicationDbContext())
            {
                result = db.TiposVenda.SingleOrDefault(t => t.Tipo == celula);
                if (result == null) return 3;
            }

            return result.Id;
        }

        public static int TipoCliente(string celula)
        {
            var result = new TipoCliente();
            using (var db = new ApplicationDbContext())
            {
                result = db.TiposCliente.SingleOrDefault(t => t.Nome == celula);
                if (result == null) result = db.TiposCliente.Single(t => t.Codigo == 4); 
            }

            return result.Id;
        }

        public static int CategoriaCliente(string celula)
        {
            var result = new CategoriaCliente();
            using (var db = new ApplicationDbContext())
            {
                int valor;
                celula = $"{celula}  ";
                var comp = int.TryParse(celula.Substring(0, 2), out valor)
                    ? valor
                    : 0;

                result = db.CategoriasCliente.SingleOrDefault(c => c.Codigo == comp);
                if (result == null) result = db.CategoriasCliente.Single(c => c.Codigo == 999);
            }

            return result.Id;
        }

        public static bool Faturado(string celula)
        {
            bool result = celula == "Faturado"
                ? true
                : false;

            return result;
        }

        public static int Unidade(string celula)
        {
            int result;
            var comp = celula.ToLower().Trim();
            using (var db = new ApplicationDbContext())
            {
                if (comp == "cx" || comp == "caixa")
                    result = db.Unidades.Single(u => u.Apelido == "cx").UnidadeId;
                else if (comp == "pc" || comp == "pç" || comp == "peça" || comp == "peca" || comp == "pc ")
                    result = db.Unidades.Single(u => u.Apelido == "pc").UnidadeId;
                else if (comp == "kg" || comp == "kilograma" || comp == "kilo")
                    result = db.Unidades.Single(u => u.Apelido == "kg").UnidadeId;
                else if (comp == "m" || comp == "mt" || comp == "metro")
                    result = db.Unidades.Single(u => u.Apelido == "mt").UnidadeId;
                else if (comp == "rl" || comp == "rolo")
                    result = db.Unidades.Single(u => u.Apelido == "rl").UnidadeId;
                else if (comp == "ml" || comp == "milheiro")
                    result = db.Unidades.Single(u => u.Apelido == "ml").UnidadeId;
                else if (comp == "hr" || comp == "hora")
                    result = db.Unidades.Single(u => u.Apelido == "hr").UnidadeId;
                else if (comp == "un" || comp == "unidade" || comp == "unitário" || comp == "unitario")
                    result = db.Unidades.Single(u => u.Apelido == "un").UnidadeId;
                else if (comp == "lt" || comp == "litro" || comp == "l")
                    result = db.Unidades.Single(u => u.Apelido == "lt").UnidadeId;
                else result = db.Unidades.Single(u => u.Apelido == "na").UnidadeId;
            }

            return result;
        }

        public static int GrupoRateio(string celula)
        {
            int result;
            celula = celula.ToLower();

            using (var db = new ApplicationDbContext())
            {
                var rateio = db.Rateios.SingleOrDefault(r => r.Grupo.ToLower() == celula);
                if (rateio == null) rateio = db.Rateios.Single(r => r.Grupo == "ND");
                result = rateio.RateioId;
            }

            return result;
        }

        public static bool Juridico(string celula)
        {
            bool result = celula == "J"
                ? true
                : false;

            return result;
        }

        public static bool TemPeso(string celula)
        {
            bool result = celula == "com peso"
                ? true
                : false;

            return result;
        }
    }
}