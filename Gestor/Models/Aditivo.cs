
namespace Gestor.Models
{
    public class Aditivo
    {
        public int Id { get; set; }

        public int CargaId { get; set; }

        public Carga Carga { get; set; }

        public int InsumoId { get; set; }

        public Insumo Insumo { get; set; }
    }
}