<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneracionGuia.aspx.cs" Inherits="GenerarGruia.GeneracionGuia" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>OFFCORSS - Devoluciones</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/main.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" rel="stylesheet" />
    <link href="Content/sweetalert.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="Scripts/sweetalert.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function WarningModal(a) {
            sweetAlert("Oops...", a, "warning")
        }

        function ErrorModal(a) {
            sweetAlert("Oops...", a, "error");
        }

        function ErrorPli(a, b, c) {
            if (a.length == 0 || a == "") {
                sweetAlert("", "Por favor ingrese el re-CAPTCHA", "warning");
                $('.g-recaptcha > div').css('border', 'solid 1px orangered');
            }
            if (b == 'false') {
                sweetAlert("", "Por favor acepte las politicas", "warning");
                $('.checkbox > input').css('border', 'solid 1px orangered');
                $('.text > h5 > a').css('color', 'orangered');
                $('.checkbox > input').on('click', function () {
                    $('.text > h5 > a').css('color', '#e6c700');
                });
            }
            if (c == "-1") {
                sweetAlert("", "Por favor selecciona un motivo", "warning");
            }
        }

        function byteError(a) {
            sweetAlert("Oops...", a, "error");
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="col-xs-12 page">
            <div class="col-xs-12 nav">
                <div class="col-xs-8 col-sm-2 logo"></div>
                <div class="col-xs-4 hamburger visible-xs"><span></span><span></span><span></span></div>
                <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 navs">
                    <div class="col-xs-12 col-sm-5 no-return">
                        <h4>Productos que no puedes devolver</h4> </div>
                    <div class="col-xs-12 col-sm-3 problems">
                        <h4>¿Problemas?</h4> </div>
                    <div class="col-xs-12 col-sm-4 guide">
                        <h4>¿Cómo generar una devolución?</h4> </div>
                </div>
            </div>
            <div class="col-xs-12 body">
                <div class="col-xs-12 col-sm-4 info">
                    <div class="col-xs-12 float">
                        <div class="col-xs-12 title">
                            <h1><asp:Label ID="Name" runat="server" /></h1> </div>
                        <div class="col-xs-12 content">
                            <h2>¿Desea hacer una devolución para el pedido <a><asp:Label ID="OrderId" runat="server" /></a>?</h2> </div>
                    </div>
                </div>
                <div class="col-xs-12 popup">
                    <div class="col-xs-12 float">
                        <div class="col-xs-12 content"></div>
                        <div class="col-xs-12 col-sm-4 close">
                            <h3>Cerrar</h3> </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 generate">
               <div class="col-xs-12 col-sm-6 col-md-5 select">
                    <div class="col-xs-12 float">
                        <div class="col-xs-12 question">
                            <h3>¿Cuál es el motivo de la devolución?</h3> </div>
                        <select name="reason" class="col-xs-12"></select>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-5 col-md-offset-1 validate">
                    <asp:Button ID="Button1" Class="col-xs-12 button" runat="server" Text="Generar Guía" OnClick="GenerarGuia_Click" BorderStyle="None" Style="padding: 3.5vh 0; font-size: 24px;"></asp:Button>
                    <div class="col-xs-12 accept">
                        <div class="col-xs-1 checkbox">
                            <input type="checkbox" /> </div>
                        <div class="col-xs-10 text">
                            <h5>Acepto las <a>políticas de devolución.</a></h5> </div>
                    </div>
                    <div id="dialog">
                        <div class="col-xs-10 content">
                            <asp:Label ID="Success" runat="server" /> </div>
                        <div class="col-xs-2 close">x</div>
                    </div>
                </div>
            </div>
            <div id="myModal1" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="modal-title">
                                <h2>¿Problemas al generar la guía?</h2>
                            </div>
                            <div class="modal-body">
                                <h3>Por favor comunícate a nuestra línea 01 8000 18 0380 o envíanos un correo a la dirección <b><a href="mailto:servicioalcliente@offcorss.com" target="_blank">servicioalcliente@offcorss.com</a></b></h3>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="btn-group">
                                <button class="btn btn-primary"><span></span>OK</button>
                            </div>
                        </div>

                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dalog -->
            </div>
            <!-- /.modal -->

            <div id="myModal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="modal-title">
                                <h2>Los siguientes productos no aplican para devolución:</h2>
                            </div>
                            <div class="panel-body">
                                <ul class="col-lg-12">
                                    <li>
                                        <h3>- Interior (Medias, Bóxer, Pantaloncillo, top, panty, set interior)</h3>
                                    </li>
                                    <li>
                                        <h3>- Prendas de baño</h3>
                                    </li>
                                    <li>
                                        <h3>- Artículos de cuidado personal</h3>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="btn-group">
                                <button class="btn btn-primary"><span></span>OK</button>
                            </div>
                        </div>

                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dalog -->
            </div>
            <!-- /.modal -->
        </div>
        <asp:HiddenField ID="id_motivo" runat="server" />
        <asp:HiddenField ID="policy" runat="server" /> </form>
    <div class="col-xs-12 footer">
        <ul class="featured col-xs-12">
            <li class="lineasDeAtencion col-xs-12 col-sm-6"> <img class="col-xs-12 col-sm-4" src="//offcorss.vteximg.com.br/arquivos/phoneIconDOptimizadoNew.png" alt="" />
                <div class="cont col-xs-12 col-sm-8">
                    <div class="leftPhone col-xs-12">
                        <h2 class="col-xs-12">LÍNEA DE ATENCIÓN NACIONAL</h2>
                        <p class="col-xs-12">01 8000 18 0380 </p>
                        <p class="ringo-phone col-xs-12" style="display: none;"><strong>LÍNEA DE ATENCIÓN NACIONAL</strong>01 8000 18 0380 </p>
                    </div>
                    <div class="rightPhone col-xs-12">
                        <h2 class="col-xs-12">Venta telefonica:</h2>
                        <p class="ringo-phone col-xs-12">031 4263267 </p>
                        <p class="ringo-phone col-xs-12" style="display: none;"><strong>Venta telefonica:</strong>018007550132 </p>
                    </div>
                </div>
            </li>
            <li class="locTienda col-xs-12 col-sm-6"> <img class="col-xs-12 col-sm-4" src="//offcorss.vteximg.com.br/arquivos/locationIconDOptimizadoNew.png" alt="" />
                <div class="cont col-xs-12 col-sm-8">
                    <h2 class='col-xs-12'>Encuentra tu tienda</h2>
                    <form class="col-xs-12">
                        <select name="filtro" class="mobile-store-locator" onchange="top.location.href=this.form.filtro.options[this.form.filtro.selectedIndex].value">
                            <option value="" class="titulo-localizador">Selecciona tu ciudad</option>
                            <option value="/store-locator?ciudad=ARMENIA">Armenia</option>
                            <option value="/store-locator?ciudad=BARRANCABERMEJA">Barrancabermeja</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=BARRANQUILLA">Barranquilla</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=BOGOTÁ">Bogotá</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=BUCARAMANGA">Bucaramanga</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=CALI">Cali</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=CARTAGENA">Cartagena</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=CUCUTA">Cúcuta</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=DUITAMA">Duitama</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=FLORENCIA">Florencia</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=IBAGUE">Ibagué</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=MANIZALES">Manizales</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=MEDELLÍN">Medellín</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=MONTERIA">Montería</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=NEIVA">Neiva</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=OCAÑA">Ocaña</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=PALMIRA">Palmira</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=PASTO">Pasto</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=PEREIRA">Pereira</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=PITALITO">Pitalito</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=POPAYAN">Popayán</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=RIOHACHA">Riohacha</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=SAN ANDRÉS">San Andrés</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=SANTA MARTA">Santa Marta</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=TUNJA">Tunja</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=VALLEDUPAR">Valledupar</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=VILLAVICENCIO">Villavicencio</option>
                            <option value="http://www.offcorss.com//store-locator?ciudad=YOPAL">Yopal</option>
                        </select>
                    </form>
                </div>
            </li>
        </ul>
        <div class="contact col-xs-12">
            <ul class="bottomSecInfo col-xs-12">
                <li class="accordion col-xs-12 col-sm-6">
                    <h2 class="col-xs-12">ACERCA DE LA MARCA</h2> <a class="col-xs-12" href="http://www.offcorss.com/acerca-de-marca/quienes-somos">¿Quiénes somos?</a> <a class="col-xs-12" href="http://www.offcorss.com/acerca-de-marca/responsabilidad-social">Responsabilidad social</a> <a class="col-xs-12" href="http://oportunidades.offcorss.com/PruebaOportunidades/tabid/160/Default.aspx">Trabaja con nosotros</a> </li>
                <li class="accordion col-xs-12 col-sm-6">
                    <h2 class="col-xs-12">LINKS DE INTERÉS</h2> <a class="col-xs-12" href="http://www.offcorss.com/links-interes/preguntas-frecuentes">Preguntas frecuentes</a> <a class="col-xs-12" href="http://www.offcorss.com/links-interes/guia-de-tallas">Guía de tallas</a> <a class="col-xs-12" href="http://www.offcorss.com/links-interes/como-comprar">¿Cómo comprar en OFFCORSS?</a> <a class="col-xs-12" href="http://www.offcorss.com/links-interes/politica-entregas-devoluciones">Política de entregas y devoluciones</a> <a class="col-xs-12" href="http://www.sic.gov.co/drupal/">Estatuto de protección al consumidor</a> <a class="col-xs-12" href="http://ocblog.offcorss.com/" target="_blank">OCBLOG </a> <a class="col-xs-12" href="http://www.offcorss.com/promocionesvigentes">Promociones Vigentes </a> <a class="col-xs-12" href="http://www.offcorss.com/guias">Videos tutoriales</a> </li>
            </ul>
            <div class="info col-xs-12">
                <p class="col-xs-12 col-sm-3">Razón Social: C.I HERMECO S.A. NIT: 890924167-6 </p>
                <p class="col-xs-12 col-sm-3">Dirección: Carrera 50 # 7 – 35 Medellín, Colombia </p>
                <p class="col-xs-12 col-sm-3">Tel: 01 8000 18 0380 </p>
                <p class="col-xs-12 col-sm-3">Correo: servicioalcliente@offcorss.com </p>
            </div>
            <div class="info col-xs-12">
                <p class='col-xs-12 col-sm-4'><a href="http://www.offcorss.com/acerca-de-marca/terminos-y-condiciones">Términos y condiciones</a> | <a href="http://www.offcorss.com/acerca-de-marca/politica-privacidad">Políticas de privacidad</a></p>
                <p class='col-xs-6 col-sm-2 col-sm-offset-6'>All Rights Reserved </p>
            </div>
        </div>
    </div>
    <div class="loadingModal">
        <div class="loader-wrapper">
            <div class="loader">
                <div class="roller"></div>
                <div class="roller"></div>
            </div>
            <div id="loader2" class="loader">
                <div class="roller"></div>
                <div class="roller"></div>
            </div>
            <div id="loader3" class="loader">
                <div class="roller"></div>
                <div class="roller"></div>
            </div>
        </div>
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
    <script src="Scripts/js/index.js" type="text/javascript"></script>
</body>

</html>

