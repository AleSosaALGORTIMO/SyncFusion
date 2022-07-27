using System.ComponentModel.DataAnnotations;

namespace Project.Client.Pages.Clientes
{
    public class Domain
    {

        public static  async Task<List<Cliente>> CargarClientesList()
        {

            List<TipoCtaCte> tipoCtaCteList = await CargarTipoCtaCteList();
            List<LugarEntrega> LugarEntregaList = await CargarLugarEntregaList();

            List<Pedido> PedidosList = await CargarPedidoList();
           


            List<Cliente> ClientesList = new List<Cliente>();
            Cliente cliente = new Cliente() { CUIT = "12-34567890-1", Nombre = "Juan", Mail = "aaa@qqq.com", FechaAlta = DateTime.Today.AddDays(-15), TipoCliente = eTipoCliente.Frecuente, Pedidos = PedidosList, TiposCtaCte = tipoCtaCteList, Habilitado = true };
            ClientesList.Add(cliente);
            cliente = new Cliente() { CUIT = "22-22222222-2", Nombre = "Pedro", Mail = "aaa@qqq.com", FechaAlta = DateTime.Today.AddDays(-14), TipoCliente = eTipoCliente.Frecuente, Pedidos = PedidosList, TiposCtaCte = tipoCtaCteList, Habilitado = true };
            ClientesList.Add(cliente);
            cliente = new Cliente() { CUIT = "33-33333333-3", Nombre = "Sacharias", Mail = "aaa@qqq.com", FechaAlta = DateTime.Today.AddDays(-13), TipoCliente = eTipoCliente.Frecuente, Pedidos = PedidosList, TiposCtaCte = tipoCtaCteList, Habilitado = true };
            ClientesList.Add(cliente);
            cliente = new Cliente() { CUIT = "44-44444444-4", Nombre = "Hipolito", Mail = "aaa@qqq.com", FechaAlta = DateTime.Today.AddDays(-12), TipoCliente = eTipoCliente.Ocasional, Pedidos = PedidosList, TiposCtaCte = tipoCtaCteList, Habilitado = true };
            ClientesList.Add(cliente);


            return ClientesList;



        }

        public static async Task<List<TipoCtaCte>> CargarTipoCtaCteList()
        {
            List<TipoCtaCte> tipoCtaCteList = new List<TipoCtaCte>();
            TipoCtaCte TipoCtaCte = new TipoCtaCte() { Codigo = 1, Descripcion = "TipoCtaCte 1" };
            tipoCtaCteList.Add(TipoCtaCte);
            TipoCtaCte = new TipoCtaCte() { Codigo = 2, Descripcion = "TipoCtaCte 2" };
            tipoCtaCteList.Add(TipoCtaCte);
            TipoCtaCte = new TipoCtaCte() { Codigo = 3, Descripcion = "TipoCtaCte 3" };
            tipoCtaCteList.Add(TipoCtaCte);
            TipoCtaCte = new TipoCtaCte() { Codigo = 4, Descripcion = "TipoCtaCte 4" };
            tipoCtaCteList.Add(TipoCtaCte);

              return tipoCtaCteList;



        }

        public static async Task<List<LugarEntrega>> CargarLugarEntregaList()
        {
            List<LugarEntrega> LugarEntregaList = new List<LugarEntrega>();
            LugarEntrega LugarEntrega = new LugarEntrega() { NumeroPedido = 123, LugarEntregaId=1, Calle = "Calle 1", Numero = 123, CP = "CP123", FranjaHoraria = new RangoHoras() { HoraDesde = DateTime.Now.ToString("HH:mm:ss"), HoraHasta = DateTime.Now.AddMinutes(-154).ToString("HH:mm:ss") } };
            LugarEntregaList.Add(LugarEntrega);
            LugarEntrega = new LugarEntrega() { NumeroPedido = 123, LugarEntregaId = 2,Calle = "Calle 2", Numero = 222, CP = "CP222", FranjaHoraria = new RangoHoras() { HoraDesde = DateTime.Now.AddMinutes(-111).ToString("HH:mm:ss"), HoraHasta = DateTime.Now.AddMinutes(-221).ToString("HH:mm:ss") } };
            LugarEntregaList.Add(LugarEntrega);
            LugarEntrega = new LugarEntrega() { NumeroPedido = 122, LugarEntregaId = 3 ,Calle = "Calle 2", Numero = 222, CP = "CP222", FranjaHoraria = new RangoHoras() { HoraDesde = DateTime.Now.AddMinutes(-222).ToString("HH:mm:ss"), HoraHasta = DateTime.Now.AddMinutes(-333).ToString("HH:mm:ss") } };
            LugarEntregaList.Add(LugarEntrega);

            return LugarEntregaList;



        }
        public static async Task<List<Pedido>> CargarPedidoList()
        {
            List<LugarEntrega> LugarEntregaList =await CargarLugarEntregaList();

            List<Pedido> PedidosList = new List<Pedido>();

            Pedido pedido = new Pedido() { CUIT = "22-22222222-2", Fecha = DateTime.Today, Hora = "10:00", NumeroPedido = 123, Precio = 345.44M, Articulo = "Articulo 1", PlazoEntrega = new RangoFechas() { FechaDesde = DateTime.Today, FechaHasta = DateTime.Today.AddDays(-15) }, Descripcion = "Descripcion 1 ", LugaresEntrega = LugarEntregaList };
            PedidosList.Add(pedido);
            pedido = new Pedido() { CUIT = "22-22222222-2", Fecha = DateTime.Today, Hora = "11:00", NumeroPedido = 122, Precio = 222.44M, Articulo = "Articulo 2", PlazoEntrega = new RangoFechas() { FechaDesde = DateTime.Today, FechaHasta = DateTime.Today.AddDays(-11) }, Descripcion = "Descripcion 2 ", LugaresEntrega = LugarEntregaList };
            PedidosList.Add(pedido);
            pedido = new Pedido() { CUIT = "12-34567890-1", Fecha = DateTime.Today, Hora = "11:00", NumeroPedido = 121, Precio = 222.44M, Articulo = "Articulo 2", PlazoEntrega = new RangoFechas() { FechaDesde = DateTime.Today, FechaHasta = DateTime.Today.AddDays(-33) }, Descripcion = "Descripcion 2 ", LugaresEntrega = LugarEntregaList };
            PedidosList.Add(pedido);

            return PedidosList;



        }










        public class Cliente
        {
            public string CUIT { get; set; }
            public string Nombre { get; set; }

            //[Required(ErrorMessage = "Required")]
            //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
            [EmailAddress]
            public string Mail { get; set; }

            public DateTime FechaAlta { get; set; }
            public eTipoCliente TipoCliente { get; set; }
            public List<Pedido> Pedidos { get; set; }
            public List<TipoCtaCte> TiposCtaCte { get; set; }

            public bool Habilitado { get; set; }
           
        }
        public class Pedido
        {
            public string CUIT { get; set; }
            public int NumeroPedido { get; set; }
            public DateTime Fecha { get; set; }
            public string Hora { get; set; }
         
            public Decimal Precio { get; set; }
            public string Articulo { get; set; }
            public RangoFechas PlazoEntrega { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public string Descripcion { get; set; }
            public List<LugarEntrega> LugaresEntrega { get; set; }
        }
        public class LugarEntrega
        {
            public int NumeroPedido { get; set; }
            public int LugarEntregaId { get; set; }
            public string Calle { get; set; }
            public int Numero { get; set; }
            public string CP { get; set; }
            public RangoHoras FranjaHoraria { get; set; }
              public string HoraDesde { get; set; }
            public string HoraHasta { get; set; }
        }
        public class TipoCtaCte
        {
            public int Codigo { get; set; }
            public string Descripcion { get; set; }

        }


        public enum eTipoCliente : ushort
        {
            Ocasional = 0,
            Frecuente = 1
        }

        public class RangoFechas
        {
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }

        }
        public class RangoHoras
        {
            public string HoraDesde { get; set; }
            public string HoraHasta { get; set; }

        }


    }
}
