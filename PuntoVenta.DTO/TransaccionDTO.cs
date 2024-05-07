namespace PuntoVenta.DTO
{
    public class TransaccionDTO
    {
        public int IdTransaccion { get; set; }

        public int? IdVenta { get; set; }

        public DateTime? Fecha { get; set; }

        public int? TipoTransaccionId { get; set; }

        public decimal? Total { get; set; }
    }
}
