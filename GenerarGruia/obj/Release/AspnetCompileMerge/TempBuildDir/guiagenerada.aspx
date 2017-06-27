<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guiagenerada.aspx.cs" Inherits="GenerarGruia.guiagenerada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>OFFCORSS - Devoluciones</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/main.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>
</head>
    <body>
        <form id="form1" runat="server">
            <div class="col-xs-12 page">
                <div class="col-xs-12 nav">
                    <div class="col-xs-4 col-sm-2 logo"></div>
                    <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-4 navs"> </div>
                </div>
                <div class="col-xs-12 body">
                    <div class="jumbotron col-xs-12 col-sm-10 col-sm-offset-1 col-md-6 col-md-offset-3">
                        <h1 class="display-3">Tu guía ha sido generada exitosamente</h1>
                        <p class="lead">
                            Hola <b><asp:Label ID="name" Text="text" runat="server" /></b> la guía <b><asp:Label ID="numguia" Text="text" runat="server" /></b>, con el pedido <b><asp:Label ID="numpedido" Text="text" runat="server" /></b>, fue generada y enviada correctamente a tu correo electrónico.
                        </p>
                        <hr class="my-4">
                    </div>
                </div>
            </div>
        </form>
         <div class="col-xs-12 footer">
            <ul class="featured col-xs-12">
                <li class="lineasDeAtencion col-xs-12 col-sm-6"> <img class="col-xs-12 col-sm-4" src="//offcorss.vteximg.com.br/arquivos/phoneIconDOptimizadoNew.png" alt="">
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
                <li class="locTienda col-xs-12 col-sm-6"> <img class="col-xs-12 col-sm-4" src="//offcorss.vteximg.com.br/arquivos/locationIconDOptimizadoNew.png" alt="">
                    <div class="cont col-xs-12 col-sm-8">
                        <h2 col-xs-12>Encuentra tu tienda</h2>
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
                    <p class='col-xs-6 col-sm-2'>All Rights Reserved </p>
                    <p class='col-xs-6 col-sm-2'>Empowered by </p>
                    <a class='col-xs-6 col-sm-2' href="http://www.vtex.com.br/"> <img src="//offcorss.vteximg.com.br/arquivos/vtexOptimizadoNew.png" alt=""></a>
                    <a class='col-xs-6 col-sm-2' href="#"> <img src="//offcorss.vteximg.com.br/arquivos/eccLogoOptimizadoNew.png" alt=""></a>
                </div>
            </div>
        </div>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src='https://www.google.com/recaptcha/api.js'></script>
        <script src="Scripts/js/index.js" type="text/javascript"></script>
    </body>
</html>
