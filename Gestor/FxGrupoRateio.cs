using Gestor.Models;
using System.Linq;

namespace Gestor
{
    public class FxGrupoRateio
    {
        public static float Gr4Fita()
        {
            float result = 0;

            using (var db = new ApplicationDbContext())
            {
                var custos = db.CustoCargoDiretos;

                for (int i = 430; i < 435; i++)
                {
                    result += custos.Single(c => c.Setor.Codigo == i.ToString()).HorasModOperadores;
                }
            }

            return result;
        }

        public static float Gr6Etc(GrupoRateio[] gr, float variavel)
        {
            float result = 0;

            using (var db = new ApplicationDbContext())
            {
                var custos = db.CustoCargoDiretos;

                float a = (custos.Single(c => c.Setor.Codigo == "411").HorasModOperadores
                        - gr[2].Graxa - gr[5].Graxa) * variavel;
                float b = gr[1].Fita + gr[1].Gxpuro + gr[1].Gxgraf;
                result = a / b;
            }

            return result;
        }

        public static float Gr7Etc(float fita, float variavel, float gxpuro, float gxgraf)
        {
            float result = 0;

            using (var db = new ApplicationDbContext())
            {
                var custos = db.CustoCargoDiretos;

                float a = custos.Single(c => c.Setor.Codigo == "412").HorasModOperadores * variavel;
                float b = fita + gxpuro + gxgraf;
                result = a / b;
            }

            return result;
        }
    }
}