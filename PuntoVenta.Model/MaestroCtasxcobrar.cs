namespace PuntoVenta.Model;

public partial class MaestroCtasxcobrar
{
    public int IdCxC { get; set; }

    public int? IdVenta { get; set; }

    public int? IdTipoTransaccion { get; set; }

    public int? IdTransaccion { get; set; }

    public int? IdCliente { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? MontoRecibido { get; set; }

    public decimal? Balance { get; set; }
}
