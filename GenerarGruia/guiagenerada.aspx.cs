using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenerarGruia.Models;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using MySql.Data.MySqlClient;

namespace GenerarGruia
{
    public partial class guiagenerada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Valor = Request.QueryString["num_pedido"];
            var pedido = Valor;

            datosguiaEntities context = new datosguiaEntities();

            var query = context.info_guia.Where(x => x.num_pedido == pedido).ToList();

            string num_pedido = "";
            string num_guia = "";
            string nombre = "";
            string apellido = "";
            string documento = "";
            string email = "";
            int idmotivo = 0;

            foreach (var item in query)
            {
                num_pedido = item.num_pedido;
                num_guia = Convert.ToString(item.num_guia);
                nombre = item.nombre;
                apellido = item.apellido;
                documento = item.num_documento;
                email = item.email;
                idmotivo = Convert.ToInt32(item.id_motivos);
            }

            string nomApell = $"{ nombre } { apellido } ";
            string guia = num_guia;

            name.Text = nomApell;
            numguia.Text = guia;
            numpedido.Text = num_pedido;
        }

    }
}