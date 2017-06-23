using Hermeco.RestService.ClientProxy;
using Hermeco.RestService.DataContract;
using GenerarGruia.wsGeneracionGuiasSisclinet;
using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using GenerarGruia.Models;
using System.Web.Script.Serialization;
using System.Net.Mime;

namespace GenerarGruia
{
    public partial class GeneracionGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string page = Request.QueryString["num_pedido"];

                GetOrderDetailVtex($"http://offcorss.vtexcommercestable.com.br/api/oms/pvt/orders/{page}",
                    "x-vtex-api-appKey:vtexappkey-offcorss-OZNHJF;x-vtex-api-appToken:DUJHOHBZQROBWRMUHYCUKTYLMVVMCLKMSVOXYPJTADTLQIBROVYZJIZJWYVTMPXFHBJBDOWSOITGAMUDTDXGMKCJVEBZTQHLGNEPZAOAYGLAOSJKERZIRQTWYZFYMXZY",
                    "");

                using (datosguiaEntities mot = new datosguiaEntities())
                {
                    var Motivos = from motivo in mot.motivos
                                  where motivo.estado == true
                                  select new { motivo.id, text = motivo.descripcion };
                    
                    var serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(Motivos);
                    string script = "var data = " + json + ";";
                    ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "dataVar", script, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public VtexOrder GetOrderDetailVtex(string url, string headers, string parameters)
        {
            try
            {
                RestWebRequest _request = new RestWebRequest(url, HttpVerb.GET, headers, parameters);

                string _result = _request.GetResponse();

                VtexOrder deserialize = JsonHelper.JsonDeserialize<VtexOrder>(_result);

                if (deserialize.orderId1 != null)
                {
                    Name.Text = $"Hola {deserialize.clientProfileData.firstName}";
                    OrderId.Text = $"#{deserialize.orderId1}";
                }

                return deserialize;

            }
            catch (WebException ex)
            {
                var r = ex.Response.GetResponseStream();
            }

            return null;
        }

        public VtexEmail GetEmailVtex(string url, string headers, string parameters)
        {
            try
            {
                RestWebRequest _request = new RestWebRequest(url, HttpVerb.GET, headers, parameters);

                string _result = _request.GetResponse();

                VtexEmail deserialize1 = JsonHelper.JsonDeserialize<VtexEmail>(_result);

                return deserialize1;
            }
            catch (WebException ex)
            {

                var r = ex.Response.GetResponseStream();
            }

            return null;
        }
        
        public void GenerarGuia_Click(object sender, EventArgs e)
        {
            
            var privacy = Convert.ToString(policy.Value);
            var idMotivo = Convert.ToString(id_motivo.Value);

            if (privacy == "false" || idMotivo == "-1")
            {
                string privacyErr = Convert.ToString(privacy);
                string idMotivoErr = idMotivo;
                ClientScript.RegisterStartupScript(this.GetType(), "Pli", $"ErrorPli( '" + privacyErr + "', '"+ idMotivoErr + "' );", true);
            }
            else
            {
                string page = Request.QueryString["num_pedido"];
                if (page != null)
                {
                    var Information = GetOrderDetailVtex($"http://offcorss.vtexcommercestable.com.br/api/oms/pvt/orders/{page}",
                        "x-vtex-api-appKey:vtexappkey-offcorss-OZNHJF;x-vtex-api-appToken:DUJHOHBZQROBWRMUHYCUKTYLMVVMCLKMSVOXYPJTADTLQIBROVYZJIZJWYVTMPXFHBJBDOWSOITGAMUDTDXGMKCJVEBZTQHLGNEPZAOAYGLAOSJKERZIRQTWYZFYMXZY", "");

                    // informacion del Remitente
                    string nombre = Information.clientProfileData.firstName;
                    string apellidos = Information.clientProfileData.lastName;
                    string telefono = Information.clientProfileData.phone;
                    string alias = Information.clientProfileData.email;
                    string ciudad = Information.shippingData.address.city;
                    string direccion = Information.shippingData.address.street;
                    string DepartamentoDestino = Information.shippingData.address.state;
                    string CodigoPostal = Information.shippingData.address.postalCode;
                    string num_pedido = Information.orderId1;
                    string num_documento = Information.clientProfileData.document;
                    string NomApell = $"{ nombre } { apellidos }";

                    string numFactura;

                    if (Information.packageAttachment.packages.Count <= 0)
                    {
                        numFactura = "";
                    }
                    else
                    {
                        numFactura = Information.packageAttachment.packages[0].invoiceNumber;
                    }

                     

                    var infoEmail = GetEmailVtex($"http://conversationtracker.vtex.com.br/api/pvt/emailMapping?alias={alias}&an=offcorss",
                        "x-vtex-api-appKey:vtexappkey-offcorss-OZNHJF;x-vtex-api-appToken:DUJHOHBZQROBWRMUHYCUKTYLMVVMCLKMSVOXYPJTADTLQIBROVYZJIZJWYVTMPXFHBJBDOWSOITGAMUDTDXGMKCJVEBZTQHLGNEPZAOAYGLAOSJKERZIRQTWYZFYMXZY", "");

                    string email = infoEmail.email;

                    // Informacion del Destinario.
                    string nombre_Des = ConfigurationManager.AppSettings["nom_Des"];
                    string direccion_Des = ConfigurationManager.AppSettings["direccion_Des"];
                    string telefono_Des = ConfigurationManager.AppSettings["telefono_Des"];
                    string ciudad_Des = ConfigurationManager.AppSettings["ciudad_Des"];
                    string NIT_Des = ConfigurationManager.AppSettings["Ide_Num_Identific_Dest"];
                    string departamento_Des = ConfigurationManager.AppSettings["departamento_Des"];
                    string codigoPostal_Des = ConfigurationManager.AppSettings["codigoPostal_Des"];
                    string email_Des = ConfigurationManager.AppSettings["email_Des"];
                    int valorDeclarado = Convert.ToInt32(ConfigurationManager.AppSettings["ValorDeclaradoTotal"]);
                    string Des_UnidadLongitud = ConfigurationManager.AppSettings["Des_UnidadLongitud"];
                    string Des_UnidadPeso = ConfigurationManager.AppSettings["Des_UnidadPeso"];
                    string Nom_UnidadEmpaque = ConfigurationManager.AppSettings["Nom_UnidadEmpaque"];
                    string Des_DiceContener = ConfigurationManager.AppSettings["Des_DiceContener"];
                    string Ide_CodFacturacion = ConfigurationManager.AppSettings["Ide_CodFacturacion"];
                    string Fec_TiempoEntrega = ConfigurationManager.AppSettings["Fec_TiempoEntrega"];
                    int Des_TipoTrayecto = Convert.ToInt32(ConfigurationManager.AppSettings["Des_TipoTrayecto"]);
                    int Num_Piezas = Convert.ToInt32(ConfigurationManager.AppSettings["Num_Piezas"]);
                    int Des_FormaPago = Convert.ToInt32(ConfigurationManager.AppSettings["Des_FormaPago"]);
                    int Des_MedioTransporte = Convert.ToInt32(ConfigurationManager.AppSettings["Des_MedioTransporte"]);
                    int Des_TipoDuracionTrayecto = Convert.ToInt32(ConfigurationManager.AppSettings["Des_TipoDuracionTrayecto"]);
                    string Nom_TipoTrayecto = ConfigurationManager.AppSettings["Nom_TipoTrayecto"];
                    int Num_Alto = Convert.ToInt32(ConfigurationManager.AppSettings["Num_Alto"]);
                    int Num_Ancho = Convert.ToInt32(ConfigurationManager.AppSettings["Num_Ancho"]);
                    int Num_Largo = Convert.ToInt32(ConfigurationManager.AppSettings["Num_Largo"]);
                    int Num_PesoTotal = Convert.ToInt32(ConfigurationManager.AppSettings["Num_Alto"]);
                    int Ide_Producto = Convert.ToInt32(ConfigurationManager.AppSettings["Ide_Producto"]);
                    int Num_BolsaSeguridad = Convert.ToInt32(ConfigurationManager.AppSettings["Num_BolsaSeguridad"]);
                    int Num_VolumenTotal = Convert.ToInt32(ConfigurationManager.AppSettings["Num_VolumenTotal"]);
                    int Num_PesoFacturado = Convert.ToInt32(ConfigurationManager.AppSettings["Num_PesoFacturado"]);

                    string ruta = ConfigurationManager.AppSettings["ruta_archivo"];

                    // Autenticación al servicio.
                    string login = ConfigurationManager.AppSettings["login"];
                    string pwd = ConfigurationManager.AppSettings["pw"];
                    string Id_CodFacturacion = ConfigurationManager.AppSettings["Id_CodFacturacion"];
                    string Nombre_Cargue = ConfigurationManager.AppSettings["Nombre_Cargue"];

                    datosguiaEntities context = new datosguiaEntities();

                    var query = context.info_guia.Where(x => x.num_pedido == num_pedido ).ToList();
                    
                    if (query.Count > 0)
                    {
                        infoWarning(num_pedido);
                    }
                    else
                    {
                        #region GenGguia
                        GeneracionGuias prGuias = new GeneracionGuias();

                        prGuias.Url = "http://web.servientrega.com:8081/GeneracionGuias.asmx";

                        CargueMasivoExternoDTO[] cargueExtern = new CargueMasivoExternoDTO[1];

                        int cantEnvios = 1;
                        cargueExtern[0] = new CargueMasivoExternoDTO();
                        cargueExtern[0].objEnvios = new EnviosExterno[cantEnvios];

                        //2. Inicio Parametros para autenticación al servicio
                        AuthHeader objautenti = new AuthHeader();

                        objautenti.login = login;//Login de acceso de SISCLINET
                        objautenti.pwd = prGuias.EncriptarContrasena(pwd); //Encriptar la contraseña del cliente
                        objautenti.Id_CodFacturacion = Id_CodFacturacion;//Código de Facturación de SISCLINET 
                        objautenti.Nombre_Cargue = Nombre_Cargue;//Nombre del cargue, aparecerá en la impresión de guías desde la aplicación SISCLINET 

                        prGuias.AuthHeaderValue = objautenti; //Asocio la autenticación al servicio web 

                        for (int i = 0; i < cantEnvios; i++)
                        {
                            //3.Set de parametros del envío
                            cargueExtern[0].objEnvios[i] = new EnviosExterno();
                            var arrEnvios = new EnviosExterno();
                            arrEnvios.Num_Guia = 0;
                            arrEnvios.Num_Sobreporte = 0;
                            arrEnvios.Num_SobreCajaPorte = "0";
                            arrEnvios.Fec_TiempoEntrega = Fec_TiempoEntrega;
                            arrEnvios.Des_TipoTrayecto = Des_TipoTrayecto;
                            arrEnvios.Ide_CodFacturacion = Ide_CodFacturacion;
                            arrEnvios.Num_Piezas = Num_Piezas;
                            arrEnvios.Des_FormaPago = Des_FormaPago; // Siempre va 2 Crédito 
                            arrEnvios.Des_MedioTransporte = Des_MedioTransporte;
                            arrEnvios.Des_TipoDuracionTrayecto = Des_TipoDuracionTrayecto;
                            arrEnvios.Nom_TipoTrayecto = Nom_TipoTrayecto;
                            arrEnvios.Num_Alto = Num_Alto;
                            arrEnvios.Num_Ancho = Num_Alto;
                            arrEnvios.Num_Largo = Num_Alto;
                            arrEnvios.Num_PesoTotal = Num_Alto;
                            arrEnvios.Des_UnidadLongitud = Des_UnidadLongitud;
                            arrEnvios.Des_UnidadPeso = Des_UnidadPeso;
                            arrEnvios.Nom_UnidadEmpaque = Nom_UnidadEmpaque;
                            arrEnvios.Gen_Sobreporte = false;
                            arrEnvios.Gen_Cajaporte = false;
                            arrEnvios.Doc_Relacionado = num_pedido;
                            arrEnvios.Des_VlrCampoPersonalizado1 = NomApell;
                            arrEnvios.Ide_Num_Referencia_Dest = "";
                            arrEnvios.Num_Factura = "";
                            arrEnvios.Ide_Producto = Ide_Producto;//tipo de mercancia a cargar
                            arrEnvios.Num_BolsaSeguridad = Num_BolsaSeguridad;
                            arrEnvios.Num_VolumenTotal = Num_VolumenTotal;
                            arrEnvios.Num_PesoFacturado = 0;
                            arrEnvios.Des_TipoGuia = 2;
                            arrEnvios.Des_CiudadOrigen = ciudad;
                            arrEnvios.Num_ValorDeclaradoTotal = valorDeclarado;
                            arrEnvios.Num_ValorLiquidado = 0;
                            arrEnvios.Num_VlrSobreflete = 0;
                            arrEnvios.Num_VlrFlete = 0;
                            arrEnvios.Num_Descuento = 0;
                            arrEnvios.Num_ValorDeclaradoSobreTotal = "60000";
                            arrEnvios.Des_Telefono = telefono_Des;
                            arrEnvios.Des_Ciudad = ciudad_Des;
                            arrEnvios.idePaisOrigen = 1;
                            arrEnvios.idePaisDestino = 1;
                            arrEnvios.Nom_Remitente = nombre;
                            arrEnvios.Des_DepartamentoDestino = departamento_Des;
                            arrEnvios.Des_Direccion = direccion_Des;
                            arrEnvios.Nom_Contacto = nombre_Des;
                            arrEnvios.Ide_Num_Identific_Dest = num_documento;
                            arrEnvios.Des_CorreoElectronico = email_Des;
                            arrEnvios.Est_CanalMayorista = false;
                            arrEnvios.Des_DepartamentoOrigen = "Bogota";
                            arrEnvios.Des_DiceContener = Des_DiceContener;
                            arrEnvios.Des_codigopostal = codigoPostal_Des;
                            arrEnvios.Des_CiudadRecogida = ciudad;
                            arrEnvios.Des_CiudadRemitente = "Bogota";
                            arrEnvios.Des_DireccionRecogida = "0";
                            arrEnvios.Des_TelefonoRecogida = "0";
                            arrEnvios.Nom_RemitenteCanal = "";
                            arrEnvios.Num_Celular = "";
                            arrEnvios.Recoleccion_Esporadica = "";
                            arrEnvios.Rem_codigopostal = "";
                            arrEnvios.Des_DiceContenerSobre = "";
                            arrEnvios.Num_IdentiRemitente = "";
                            arrEnvios.Des_DireccionRemitente = direccion;
                            arrEnvios.Num_TelefonoRemitente = telefono;
                            cargueExtern[0].objEnvios[i] = arrEnvios;
                        }

                        //4. Consumo del método CargueMasivoExterno y captura la Guia de retorno 
                        string[] respuesta = new string[1];
                        byte[] bytereport = new byte[1];
                        int sFormatoimpresionguia = -99;
                        string sfile;

                        if (prGuias.CargueMasivoExterno(ref cargueExtern, ref respuesta))
                        {
                            //5. GenerarGuiaSticker como stream y retorno array de bytes  
                            sFormatoimpresionguia = cargueExtern[0].objEnvios[0].Des_TipoGuia;
                            prGuias.GenerarGuiaSticker(decimal.Parse(respuesta[0].ToString()),
                            decimal.Parse(respuesta[respuesta.Length - 1].ToString()),
                            objautenti.Id_CodFacturacion, sFormatoimpresionguia,
                            cargueExtern[0].objEnvios[0].Id_ArchivoCargar,
                            false,
                            ref bytereport);

                            if (bytereport[0] == 0)
                            {
                                ErrByte();
                            }
                        }

                        int num_guia = Convert.ToInt32(cargueExtern[0].objEnvios[0].Num_Guia);

                        if (num_guia != 0)
                        {

                            string workingDirectory = Path.Combine(Server.MapPath(ruta));

                            //6. Impresión de los bytes de la guía en el navegador 
                            if (sFormatoimpresionguia == 1) //6. Impresión de guía bond 
                            {
                                //sfile = "c:\\reportsticker_" + respuesta[0] + ".pdf";    
                                sfile = $@"{workingDirectory}\{NomApell}_{num_guia}.pdf";
                            }
                            else //6. Impresión de guía Sticker    
                            {
                                sfile = $@"{workingDirectory}\{NomApell}_{num_guia}.pdf";
                            }

                            File.WriteAllBytes(sfile, bytereport);

                            #region FunEmail
                            if (SendMail(sfile, email, NomApell))
                            {
                                int motivos = Convert.ToInt32(id_motivo.Value);
                                #region InsertDataGuia
                                try
                                {
                                    info_guia bd = new info_guia
                                    {
                                        num_pedido = num_pedido,
                                        num_guia = num_guia,
                                        nombre = nombre,
                                        apellido = apellidos,
                                        telefono = telefono,
                                        num_documento = num_documento,
                                        email = email,
                                        direccion = direccion,
                                        codigoPostal = CodigoPostal,
                                        id_motivos = motivos
                                    };
                                    context.info_guia.Add(bd);
                                    context.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.InnerException);
                                }

                                #endregion InsertDataGuia

                                string guia = Convert.ToString(num_guia);
                                //string motivo = Convert.ToString(motivos);

                                datosguiaEntities mot = new datosguiaEntities();
                                var query1 = from m in context.motivos
                                             where m.id == motivos
                                             select m;

                                var motinfo = query1.FirstOrDefault<motivos>();

                                string descMotivo = motinfo.descripcion;

                                SendMailAdmin(NomApell, email, num_documento, num_pedido, descMotivo, guia, sfile, numFactura);
                                Response.Redirect($"guiagenerada.aspx?num_pedido={page}");
                            }
                            else
                            {
                                string textError = $"Lo sentimos, la guía no pudo ser generada correctamente. Por favor comuniquese con el centro de ayuda de OFFCORSS";
                                ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorModal('" + textError + "');", true);
                            }
                            #endregion funEmail

                            #endregion GenGguia
                        }
                        else
                        {
                            infoErrorOrder(num_pedido);
                        }
                    }
                }
                else
                {
                    infoErrorOrderNull();
                }
            }
        }

        public static string BodyMail(string name)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine(@"<!DOCTYPE html>");
            body.AppendLine(@"<html lang='en'> ");
            body.AppendLine(@"<head>");
            body.AppendLine(@"<meta charset='UTF-8'> ");
            body.AppendLine(@"<title> Proceso de devolución</title>");
            body.AppendLine(@"<link href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i' rel='stylesheet'> ");
            body.AppendLine(@"<style>");
            body.AppendLine(@".shadow { ");
            body.AppendLine(@"color: #555;");
            body.AppendLine(@"-webkit-text-fill-color: white;");
            body.AppendLine(@"-webkit-text-stroke-width: 1px;");
            body.AppendLine(@"-webkit-text-stroke-color: black;");
            body.AppendLine(@"text-decoration: none;");
            body.AppendLine(@"text-shadow: 3px 3px 1px #38B4B6;");
            body.AppendLine(@"font-weight: 900;");
            body.AppendLine(@"}");
            body.AppendLine(@".spacer{");
            body.AppendLine(@"height: 20px; ");
            body.AppendLine(@"}");
            body.AppendLine(@"</style>");
            body.AppendLine(@"</head>");
            body.AppendLine(@"<body style='font-family:'Roboto' ,arial;max-width:600px; width:100%;'> ¿No puede visualizar el correo? <a href='https://alejandrochvs.github.io/OffcorssDevoluciones/HTMLMail/Mockup/'>Click aquí</a> para abrirlo en el navegador.");
            body.AppendLine(@"<table>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td style='border-bottom: solid 2px #38B4B6;'><img src=""cid:header"" alt='' width='600px'></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td><img style='margin-right:50px;' src=""cid:hello"" alt='' width='115px'></td>");
            body.AppendLine(@"<td>");
            body.AppendLine($@"<h4 style='text-align:center;color:#444;'> {name},</h4></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='padding: 0px 40px;text-align:center;margin:40px 0;margin-top:0px;width:600px'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr style='color:#555;text-align: center;'>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<h3 style='margin:0;font-weight:400;'> ESTE <M class='shadow'>PASO A PASO</M> TE AYUDARÁ</h3></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"<tr style='color:#555;text-align: center;'>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<h2 style='color:#38B4B6;margin:0;font-weight:900;'>EN EL PROCESO DE DEVOLUCIONES.</h2> </tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='width:600px;padding: 0px 30px;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td><img style='margin-right:25px;' src=""cid:FirstInstruction"" alt='' height='90px'></td>");
            body.AppendLine(@"<td style='border-bottom: dashed lightgray 3px;'>");
            body.AppendLine(@"<h3 style='color:#777;font-weight:300'> Imprime tu guía y llévala con la prenda a cualquier punto");
            body.AppendLine(@"<R style='color:#CC6666;'><b> Servientrega.</b></R></h3></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"<tr class='spacer'><td></td></tr>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td><img style='margin-right:25px;' src=""cid:SecondInstruction"" alt='' height='90px'></td>");
            body.AppendLine(@"<td style='border-bottom: dashed lightgray 3px;'><h3 style='color:#777;font-weight:300'>Cuando recibamos tu prenda, te enviaremos un vale para que compres lo que más te guste en<a href='http://www.offcorss.com' style='text-decoration:none;'><BL style='color:#38B4B6;'><b> www.offcorss.com.</b></BL></a></h3></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='color: white;background: #38B4B6;width:600px;max-width:600px;text-align:center;margin-top:40px;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<h3 style='font-weight:300'> Si necesitas ayuda, llámanos al <b> 01 8000 18 0380 </b><br/> o escríbenos a <b>servicioalcliente@offcorss.com</b></h3></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='border-bottom: solid 1px #777;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='http://www.offcorss.com/ropa-nino?PS=8&O=OrderByReleaseDateDESC'><img src=""cid:boy"" alt='' width='96px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='http://www.offcorss.com/ropa-nina?PS=8&O=OrderByReleaseDateDESC'><img src=""cid:girl"" alt='' width='96px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='http://www.offcorss.com/ropa-bebe-nino?PS=8&O=OrderByReleaseDateDESC'><img src=""cid:bboy"" alt='' width='96px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='http://www.offcorss.com/ropa-bebe-nina?PS=8&O=OrderByReleaseDateDESC'><img src=""cid:bgirl"" alt='' width='96px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='http://www.offcorss.com/ropa-recien-nacido-nino?PS=8&O=OrderByReleaseDateDESC'><img src=""cid:nbboy"" alt='' width='96px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td> ");
            body.AppendLine(@"<a href='http://www.offcorss.com/ropa-recien-nacido-nina?PS=8&O=OrderByReleaseDateDESC'><img src=""cid:nbgirl"" alt='' width='96px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='border-bottom: solid 1px #777;margin-bottom:30px;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td><img src=""cid:call"" alt='' width='600px'></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='width: 600px;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td style='text-align:center;'>");
            body.AppendLine(@"<h5 style='color:#444;margin:0;margin-bottom:10px;'><b> Síguenos </b></h5></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='width:200px;margin-left:200px;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='https://www.facebook.com/offcorss/'><img src=""cid:fb"" alt='' width='25px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='https://twitter.com/offcorss?lang=es'><img src=""cid:tw"" alt='' width='25px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='https://www.youtube.com/user/OFFCORSSenLinea'><img src=""cid:yt"" alt='' width='25px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<a href='https://www.instagram.com/offcorss/?hl=es'><img src=""cid:in"" alt='' width='25px'></a>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='border-top: solid 1px #777;margin-top:30px'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td><img src=""cid:pay"" alt='' width='600px'></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"</tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"<table style='background:#38B4B6;max-width:600px;width:600px;'>");
            body.AppendLine(@"<tbody>");
            body.AppendLine(@"<tr>");
            body.AppendLine(@"<td style='border-bottom:solid 2px white;'><a href='http://www.offcorss.com/'><img src=""cid:footer"" alt='' width='600px'></a></td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@"<tr style='background:#38B4B6;'>");
            body.AppendLine(@"<td>");
            body.AppendLine(@"<p style='color: white; font-size:13px; padding: 0px 10px; '>En caso de que no sea por calidad, para aceptar tu devolución, el producto deberá devolverse en óptimas condiciones, sin rastros de haber sido utilizado, no debe estar modificado o alterado de su estado original y debe estar en un buen estado y limpio.Para hacer la devolución del envío puedes utilizar el mismo empaque en que te entregamos tu pedido o utilizar un empaque de tu preferencia, sin embargo, es importante que el empaque sea el adecuado según la naturaleza del producto para que este no se pueda ver afectado durante el proceso de transporte.  La guía es válida sólo por las siguientes 72 horas una vez la recibas en tu correo electrónico, así que deberás asegurarte de coordinar el envío en este tiempo. Sólo es posible generar una guía de devolución por pedido. Los datos que registraremos en la guía de devolución serán los mismos que registraste en tu pedido. Si no cumples con alguno de estos ítems deberás comunicarte a nuestra línea de atención nacional 01 8000 18 0380 o escribirnos a <b>servicioalcliente@offcorss.com</b> para ayudarte con tu proceso.  Para más información, ingresa a <a href='http://www.offcorss.com/links-interes/politica-entregas-devoluciones' style='color:white;font-weight:bold;'>http://www.offcorss.com/links-interes/politica-entregas-devoluciones.</a></p>");
            body.AppendLine(@"</td>");
            body.AppendLine(@"</tr>");
            body.AppendLine(@" </tbody>");
            body.AppendLine(@"</table>");
            body.AppendLine(@"</body>");
            body.AppendLine(@"</html>");
            return body.ToString();
        }
        
        public Boolean SendMail(string ruta, string correo, string nombre)
        {
            try
            {
                #region img-mail
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(BodyMail(nombre), Encoding.UTF8, MediaTypeNames.Text.Html);

                LinkedResource img1 = new LinkedResource(Server.MapPath("/img/footer.jpg"), MediaTypeNames.Image.Jpeg);
                img1.ContentId = "footer";
                htmlView.LinkedResources.Add(img1);

                LinkedResource img2 = new LinkedResource(Server.MapPath("/img/pay.jpg"), MediaTypeNames.Image.Jpeg);
                img2.ContentId = "pay";
                htmlView.LinkedResources.Add(img2);

                //header
                LinkedResource img3 = new LinkedResource(Server.MapPath("/img/header.jpg"), MediaTypeNames.Image.Jpeg);
                img3.ContentId = "header";
                htmlView.LinkedResources.Add(img3);

                //hello
                LinkedResource img4 = new LinkedResource(Server.MapPath("/img/hello.png"), MediaTypeNames.Image.Jpeg);
                img4.ContentId = "hello";
                htmlView.LinkedResources.Add(img4);

                //FirstInstruction
                LinkedResource img5 = new LinkedResource(Server.MapPath("/img/FirstInstruction.jpg"), MediaTypeNames.Image.Jpeg);
                img5.ContentId = "FirstInstruction";
                htmlView.LinkedResources.Add(img5);

                //SecondInstruction
                LinkedResource img6 = new LinkedResource(Server.MapPath("/img/SecondInstruction.jpg"), MediaTypeNames.Image.Jpeg);
                img6.ContentId = "SecondInstruction";
                htmlView.LinkedResources.Add(img6);

                //boy
                LinkedResource img7 = new LinkedResource(Server.MapPath("/img/boy.jpg"), MediaTypeNames.Image.Jpeg);
                img7.ContentId = "boy";
                htmlView.LinkedResources.Add(img7);

                //girl
                LinkedResource img8 = new LinkedResource(Server.MapPath("/img/girl.jpg"), MediaTypeNames.Image.Jpeg);
                img8.ContentId = "girl";
                htmlView.LinkedResources.Add(img8);

                //bboy
                LinkedResource img9 = new LinkedResource(Server.MapPath("/img/bboy.jpg"), MediaTypeNames.Image.Jpeg);
                img9.ContentId = "bboy";
                htmlView.LinkedResources.Add(img9);

                //bgirl
                LinkedResource img10 = new LinkedResource(Server.MapPath("/img/bgirl.jpg"), MediaTypeNames.Image.Jpeg);
                img10.ContentId = "bgirl";
                htmlView.LinkedResources.Add(img10);

                //nbboy
                LinkedResource img11 = new LinkedResource(Server.MapPath("/img/nbboy.jpg"), MediaTypeNames.Image.Jpeg);
                img11.ContentId = "nbboy";
                htmlView.LinkedResources.Add(img11);

                //nbgirl
                LinkedResource img12 = new LinkedResource(Server.MapPath("/img/nbgirl.jpg"), MediaTypeNames.Image.Jpeg);
                img12.ContentId = "nbgirl";
                htmlView.LinkedResources.Add(img12);

                //call
                LinkedResource img13 = new LinkedResource(Server.MapPath("/img/call.jpg"), MediaTypeNames.Image.Jpeg);
                img13.ContentId = "call";
                htmlView.LinkedResources.Add(img13);

                //fb
                LinkedResource img14 = new LinkedResource(Server.MapPath("/img/fb.jpg"), MediaTypeNames.Image.Jpeg);
                img14.ContentId = "fb";
                htmlView.LinkedResources.Add(img14);

                //tw
                LinkedResource img15 = new LinkedResource(Server.MapPath("/img/tw.jpg"), MediaTypeNames.Image.Jpeg);
                img15.ContentId = "tw";
                htmlView.LinkedResources.Add(img15);

                //yt
                LinkedResource img16 = new LinkedResource(Server.MapPath("/img/yt.jpg"), MediaTypeNames.Image.Jpeg);
                img16.ContentId = "yt";
                htmlView.LinkedResources.Add(img16);

                //in
                LinkedResource img17 = new LinkedResource(Server.MapPath("/img/in.jpg"), MediaTypeNames.Image.Jpeg);
                img17.ContentId = "in";
                htmlView.LinkedResources.Add(img17);

                #endregion


                string htmlemail = BodyMail(nombre);

                string emailRemite = ConfigurationManager.AppSettings["email"];
                string passRemite = ConfigurationManager.AppSettings["password"];
                string smtp = ConfigurationManager.AppSettings["smt"];

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(emailRemite, "OFFCORS: Devoluciones", Encoding.UTF8);
                mail.Subject = "Guía de devolución";
                //mail.IsBodyHtml = true;
                //mail.Body = BodyMail(); ;
                mail.AlternateViews.Add(htmlView);
                mail.To.Add(correo);
                mail.Attachments.Add(new Attachment(ruta));

                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new NetworkCredential(emailRemite, passRemite);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        /* =========================================================================================================================================================*/

        public static string Mailbody(string nombre, string correo, string cedula, string pedido, string motivo, string guia, string factura)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("<!DOCTYPE html>");
            body.AppendLine("<html>");
            body.AppendLine("<head>");
            body.AppendLine("<meta charset = 'utf-8'>");
            body.AppendLine("<head>");
            body.AppendLine("<body>");
            body.AppendLine("<table>");
            body.AppendLine("<label>Cordial saludo,</label>");
            body.AppendLine("</table>");
            body.AppendLine("<br/>");
            body.AppendLine("<table>");
            body.AppendLine($"<label> A continuación se muestra la información del cliente que solicita devolución, por favor su ayuda con el proceso: </label>");
            body.AppendLine("</table>");
            body.AppendLine("<br/>");
            body.AppendLine("<table>");
            body.AppendLine($"<label> Nombre del cliente: <strong>{nombre}</strong></label>");
            body.AppendLine("</table>");
            body.AppendLine("<table>");
            body.AppendLine($" Se le asignó la guía: <strong>{guia}</strong>");
            body.AppendLine("</table>");
            body.AppendLine("<table>");
            body.AppendLine($"<label> Cédula: <strong>{cedula}</strong></label>");
            body.AppendLine("</table>");
            body.AppendLine("<table>");
            body.AppendLine($"<label> Número de pedido: <strong>{pedido}</strong></label>");
            body.AppendLine("</table>");
            body.AppendLine("<table>");
            body.AppendLine($"<label> Motivo de devolución: <strong>{motivo}</strong></label>");
            body.AppendLine("</table>");

            body.AppendLine("<table>");
            body.AppendLine($"<label> Número de factura: <strong>{factura}</strong></label>");
            body.AppendLine("</table>");

            body.AppendLine("</body>");
            body.AppendLine("</html>");
            return body.ToString();
        }

        public static Boolean SendMailAdmin(string nombre, string correo, string cedula, string pedido, string motivo, string guia, string ruta, string factura)
        {
            try
            {
                string destinatario = ConfigurationManager.AppSettings["servicesclient"];
                string remite = ConfigurationManager.AppSettings["email"];
                string passRemite = ConfigurationManager.AppSettings["password"];
                string smtp = ConfigurationManager.AppSettings["smt"];

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(correo, "Devolución de producto", Encoding.UTF8);
                mail.Subject = $"TV-Solicitud Devolución Automática";
                mail.IsBodyHtml = true;
                mail.Body = Mailbody(nombre, correo, cedula, pedido, motivo, guia, factura); ;
                mail.To.Add(remite);
                mail.Attachments.Add(new Attachment(ruta));

                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new NetworkCredential(remite, passRemite);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void infoWarning(string num_pedido)
        {
            string textWarning = $"Ya se ha generado una guía de devolución para el pedido número: {num_pedido}. Si necesitas una nueva guía, por favor comunícate a nuestra línea  01 8000 18 0380 o envíanos un correo a la dirección servicioalcliente@offcorss.com";
            ClientScript.RegisterStartupScript(this.GetType(), "Warning", "WarningModal('" + textWarning + "');", true);
        }

        public void infoErrorOrder(string num_pedido)
        {
            string textError = $"Lo sentimos ha ocurrido un error al generar la guía del pedido #{num_pedido}, por favor comunícate a nuestra línea  01 8000 18 0380 o envíanos un correo a la dirección servicioalcliente@offcorss.com";
            ClientScript.RegisterStartupScript(this.GetType(), "Error", "ErrorModal('" + textError + "');", true);
        }

        public void infoErrorOrderNull()
        {
            string textError = $"Por favor ingrese un número de pedido valido o pongase en contacto con nuestro personal en nuestra linea 01 8000 18 0380 o envíanos un correo a la dirección servicioalcliente@offcorss.com";
            ClientScript.RegisterStartupScript(this.GetType(), "Error", "ErrorModal('" + textError + "');", true);
        }

        public void ErrByte() {
            string byteError = $"Ah ocurrido un error interno porfavor vuelva a intentar de nuevo generar su guía de devolución\n Sí el error persiste por favor comunicate a la linea 01 8000 18 0380 o envíanos un correo a la dirección servicioalcliente@offcorss.com";
            ClientScript.RegisterStartupScript(this.GetType(), "byteError", "ErrorModal('" + byteError + "');", true);
        }
    }
}