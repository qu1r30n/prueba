using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Threading;

using chatbot_wathsapp.clases.herramientas;
using OpenQA.Selenium.Interactions;



namespace chatbot_wathsapp.clases
{
    class chatbot_clase
    {
        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        var_fun_GG var_GG = new var_fun_GG();
        Tex_base bas = new Tex_base();
        mult simul = new mult();
        
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_dir_arch_conf_chatbot =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[5, 0],//"config\\chatbot\\info_para_comandos_chatbot\\00_paginaweb.txt",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[6, 0],//"config\\chatbot\\info_para_comandos_chatbot\\01_ya_entrado_en_la_mensajeria.txt",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[7, 0],//"config\\chatbot\\info_para_comandos_chatbot\\02_chequeo_no_leidos.txt",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[8, 0],//"config\\chatbot\\info_para_comandos_chatbot\\03_clickeo.txt",
            /*4*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[9, 0],//"config\\chatbot\\info_para_comandos_chatbot\\04_lectura_del_mensage.txt",
            /*5*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[10, 0],//"config\\chatbot\\info_para_comandos_chatbot\\05_reconocer_textbox_de_envio.txt",
            /*6*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[11, 0],//"config\\chatbot\\info_para_comandos_chatbot\\06_buscar_nombre.txt",
            /*7*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[12, 0],//"config\\chatbot\\info_para_comandos_chatbot\\07_nombre_del_clikeado.txt",

        };

        string[] G_dir_arch_mensages =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[13, 0],//"config\\chatbot\\01_mensaje_bienvenida_inicio.txt,",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[14, 0],//"config\\chatbot\\02_mensaje_bienvenida_final.txt",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[15, 0],//"config\\chatbot\\03_productos.txt",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[16, 0]//"config\\chatbot\\04_mensaje_extra_despues_de_la_venta.txt"
        };
        string[,] G_contactos_lista_para_mandar_informacion =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[17, 0],"encargados" },//"config\\chatbot\\05_encargados.txt",
            /*1*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18, 0],"supervisores" },//"config\\chatbot\\06_supervisores.txt",
            /*2*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[19, 0],"contadores" },//"config\\chatbot\\07_contadores.txt",
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[20, 0],"vendedores" },//"config\\chatbot\\08_vendedores.txt",
            /*4*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[21, 0],"repartidores" },//"config\\chatbot\\09_repartidores.txt",
            /*5*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[22, 0],"reg_mensage" },//"config\\chatbot\\10_reg_mensaje.txt"
            /*6*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[26, 0],"confirmadores" },//"config\\chatbot\\11_confirmadores.txt
            /*7*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[23, 0],"programador" }//"config\\chatbot\\configuracion_programador.txt",
        };

        public string[,] G_dir_para_registros_y_configuraciones =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[25,0] ,"folios_a_procesar" },//"config\\chatbot\\registros\\folios_a_checar\\folio_ventas.txt,"
            /*1*/{ "config\\chatbot\\registros\\" + Tex_base.GG_año_mes_dia_para_registros_ + "_reg.txt", "registro" },
            /*2*/{ "config\\chatbot\\registros\\" + Tex_base.GG_año_mes_dia_para_registros_ + "_usuarios_reg.txt", "registro_usuario_venta_por_dia" },
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[24, 0], "chequeo_recarga_de_arreglos" }
        };
        
        string[][] G_info_de_configuracion_chatbot = null;

        string G_direccion_negocio = Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0];//string G_direccion_negocio = "config\\sismul2\\negocio.txt";


        string[,] G_productos = new string[10,3];



        public void configuracion_de_inicio()
        {
            

            G_info_de_configuracion_chatbot = extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);

            //<span class="l7jjieqr cfzgl7ar ei5e7seu h0viaqh7 tpmajp1w c0uhu3dl riy2oczp dsh4tgtl sy6s5v3r gz7w46tb lyutrhe2 qfejxiq4 fewfhwl7 ovhn1urg ap18qm3b ikwl5qvt j90th5db aumms1qt"
            //aria-label="No leídos">1</span>

            int tiempo_en_segunds_espera = 40;
            int tiempo_en_minutos = 5;


            //damos algunas opciones para iniciar el chomer
            var opciones = new ChromeOptions();
            opciones.AddArguments("--start-maximized");
            opciones.AddExcludedArgument("enable-automation");

            //declaramos el elemento manejadores
            var manejadores = new ChromeDriver(opciones);
            manejadores.Navigate().GoToUrl(G_info_de_configuracion_chatbot[0][1]);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            Thread.Sleep(tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera

            //esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej =>
            {
                //IWebElement elemento_app = manej.FindElement(By.Id("app"));
                IWebElement elementoSide = manej.FindElement(By.Id(G_info_de_configuracion_chatbot[1][1]));
                return elementoSide;
            });

            procesos(manejadores, esperar);

        }

        public void procesos(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son del no leido--------------------------------------------------------------------
            string elementos = G_info_de_configuracion_chatbot[2][1];
            string elementos_clase = elementos + G_info_de_configuracion_chatbot[3][1];
            //-----------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------


            while (true)
            {
                try
                {


                    //checa si estan los elementos  esto sustitulle al // esperar.Until(manej => manej.FindElement(By.XPath(elementos)));//busca el elemento del no leido
                    //porque siempre marcaba error
                    bool elementoEncontrado = false;
                    elementoEncontrado = esperar.Until(manej =>
                    {
                        var cuantos_elementos = manej.FindElements(By.XPath(elementos));
                        if (cuantos_elementos.Count > 0)
                        {
                            // Si el elemento está presente, retorna verdadero
                            //clickea
                            manejadores.FindElement(By.XPath(elementos_clase)).Click();//clickea el elemento del no leido
                            string[] textosDelMensaje = leer_mensages_recibidos_del_mensage_clickeado(manejadores, esperar);
                            string nom_del_click = nombre_del_clickeado(manejadores, esperar);

                            //fin mensaje que resibio--------------------------------------------------------------

                            Thread.Sleep(1000);
                            try
                            {

                                modelo_para_mandar_mensage(manejadores, esperar, nom_del_click, textosDelMensaje);

                            }
                            catch
                            {
                            }


                            Thread.Sleep(3000);

                            return true;
                        }
                        else
                        {
                            // Si el elemento no está presente, espera y luego vuelve a intentar
                            Thread.Sleep(3000); // Puedes ajustar el tiempo de espera según tu escenario
                            return false;
                        }
                    });
                    //---------------------------------------------------------------------------------------------
                    //

                }
                catch (NoSuchElementException ex) { }

                catch (Exception ex) { }

                catch { }

            }

        }




        private void modelo_para_mandar_mensage(IWebDriver manejadores, WebDriverWait esperar, string nom_mensage_clickeado, object texto_recibidos_arreglo_objeto)
        {
            recargar_arreglos();

            string nombre_Del_que_envio_el_mensage = nombre_del_clickeado(manejadores, esperar);

            string[] textos_recibidos_srting_arr = op_arr.convierte_objeto_a_arreglo(texto_recibidos_arreglo_objeto);


            string ultimo_mensaje = textos_recibidos_srting_arr[textos_recibidos_srting_arr.Length - 1];
            ultimo_mensaje = ultimo_mensaje.ToLower();
            string[] lineas_del_mensaje = ultimo_mensaje.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int indice_productos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[2]));


            string[] nombre_de_productos = new string[Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length];
            double[] precio_a_pagar_por_producto = new double[Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length];
            double[] cantidad_de_productos = new double[Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length];



            string mensaje_de_bienvenida_a_enviar = op_tex.concatenacion_filas_de_un_archivo(G_dir_arch_mensages[0]);
            string mensaje_de_productos_a_enviar = null;
            string mensaje_de_bienvenida_final_a_enviar = op_tex.concatenacion_filas_de_un_archivo(G_dir_arch_mensages[1]);


            string mensage_bienvenida_total = null;


            double total_a_pagar_de_todo = 0;
            string respuesta_a_mandar_mensage = "";

            bool hubo_platillos = false;


            for (int j = 0; j < lineas_del_mensaje.Length; j++)
            {
                bool hubo_cambio_de_menu = cargar_menus_retorna_numero_menu_por_10(lineas_del_mensaje[j]);

                mensaje_de_productos_a_enviar = op_tex.concatenacion_filas_de_un_arreglo_bidimencional(G_productos, true);
                mensage_bienvenida_total = mensaje_de_bienvenida_a_enviar + "\n" + mensaje_de_productos_a_enviar + "\n" + mensaje_de_bienvenida_final_a_enviar;

                string[] ultimo_mensaje_espliteado = lineas_del_mensaje[j].Split(':');
                for (int k = 0; k < ultimo_mensaje_espliteado.Length; k++)
                {
                    ultimo_mensaje_espliteado[k] = ultimo_mensaje_espliteado[k].Trim();
                }

                bool si_confirmo = confirmaciones_de_usuarios_confirmadores_o_funciones_extras(manejadores, esperar, nombre_Del_que_envio_el_mensage, ultimo_mensaje_espliteado, ":");

                if (si_confirmo == false)
                {
                    string contactos = "";


                    if (ultimo_mensaje_espliteado.Length > 1)
                    {



                        switch (ultimo_mensaje_espliteado[0])
                        {
                            case "ubi":

                                contactos = G_contactos_lista_para_mandar_informacion[1, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[4, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[5, 1];
                                respuesta_a_mandar_mensage = nombre_Del_que_envio_el_mensage + "\nubicacion recibida: " + G_caracter_separacion_funciones_espesificas[0];
                                acumulador_de_mensajes(contactos, respuesta_a_mandar_mensage);
                                break;

                            case "ext":
                                contactos = G_contactos_lista_para_mandar_informacion[0, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[1, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[4, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[5, 1];
                                respuesta_a_mandar_mensage = nombre_Del_que_envio_el_mensage + "\ninformacion extra recibida: " + G_caracter_separacion_funciones_espesificas[0];

                                acumulador_de_mensajes(contactos, respuesta_a_mandar_mensage);

                                break;

                            case "can":
                                contactos = G_contactos_lista_para_mandar_informacion[0, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[1, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[2, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[4, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[5, 1] + G_caracter_separacion[0] + G_contactos_lista_para_mandar_informacion[6, 1];
                                respuesta_a_mandar_mensage = nombre_Del_que_envio_el_mensage + "\ncancelacion recibida: " + G_caracter_separacion_funciones_espesificas[0];
                                acumulador_de_mensajes(contactos, respuesta_a_mandar_mensage);

                                break;


                            default:
                                try
                                {
                                    //el platillo : la cantidad del platillo
                                    int numero_de_platillo = Convert.ToInt32(ultimo_mensaje_espliteado[0]);
                                    Double cantidad_de_platillos = Convert.ToDouble(ultimo_mensaje_espliteado[1]);
                                    for (int k = G_donde_inicia_la_tabla; k < G_productos.GetLength(0); k++)
                                    {
                                        string[] productos = Tex_base.GG_base_arreglo_de_arreglos[indice_productos][k].Split(G_caracter_separacion[0][0]);

                                        if (numero_de_platillo == k)
                                        {

                                            double total = Convert.ToDouble(productos[1]) * cantidad_de_platillos;
                                            total_a_pagar_de_todo = total_a_pagar_de_todo + total;
                                            precio_a_pagar_por_producto[numero_de_platillo] = precio_a_pagar_por_producto[numero_de_platillo] + total;
                                            cantidad_de_productos[numero_de_platillo] = cantidad_de_productos[numero_de_platillo] + cantidad_de_platillos;
                                        }

                                        nombre_de_productos[k] = productos[0];
                                    }
                                    hubo_platillos = true;
                                }
                                catch (Exception)
                                {
                                    acumulador_de_mensajes("usuario_actual", mensage_bienvenida_total);
                                    // error manda mensaje de bienvenvenida y mensage a registros
                                    contactos = G_contactos_lista_para_mandar_informacion[5, 1];
                                    respuesta_a_mandar_mensage = nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n" + "------------------------------------------------------------------------";
                                    acumulador_de_mensajes(contactos, respuesta_a_mandar_mensage);


                                }
                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            //mando solo numeros de platillos
                            int solo_numeros_para_el_pedido = Convert.ToInt32(ultimo_mensaje_espliteado[0]);
                            for (int i = 0; i < ultimo_mensaje_espliteado[0].Length; i++)
                            {

                                int numero_de_platillo = Convert.ToInt32(("" + ultimo_mensaje_espliteado[0][i]));

                                nombre_de_productos[numero_de_platillo] = G_productos[numero_de_platillo, 0];
                                double precio = Convert.ToDouble(G_productos[numero_de_platillo, 1]);
                                precio_a_pagar_por_producto[numero_de_platillo] = precio_a_pagar_por_producto[numero_de_platillo] + precio;
                                total_a_pagar_de_todo = total_a_pagar_de_todo + precio;
                                cantidad_de_productos[numero_de_platillo] = cantidad_de_productos[numero_de_platillo] + 1;
                            }
                            hubo_platillos = true;
                        }
                        catch (Exception)
                        {

                            //mando una palabra
                            acumulador_de_mensajes("usuario_actual", mensage_bienvenida_total);
                            contactos = G_contactos_lista_para_mandar_informacion[5, 1];
                            respuesta_a_mandar_mensage = nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n" + "------------------------------------------------------------------------";
                            acumulador_de_mensajes(contactos, respuesta_a_mandar_mensage);

                        }

                    }


                    //preparando mensajes para encargados
                    string encargado_cantidades_nom_producto = "";
                    string contador_ventas = "";
                    string respuesta_de_mensaje = "";
                    string respuesta_de_mensaje_para_folio = "";

                    if (hubo_platillos == true)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < nombre_de_productos.Length; i++)
                        {
                            if (precio_a_pagar_por_producto[i] > 0)
                            {
                                encargado_cantidades_nom_producto = op_tex.concatenacion_caracter_separacion(encargado_cantidades_nom_producto, cantidad_de_productos[i] + G_caracter_separacion[0] + nombre_de_productos[i], '\n');
                                contador_ventas = op_tex.concatenacion_caracter_separacion(contador_ventas, "comida" + G_caracter_separacion[0] + precio_a_pagar_por_producto[i], '\n');
                                string todos_juntos = cantidad_de_productos[i] + G_caracter_separacion[0] + nombre_de_productos[i] + G_caracter_separacion[0] + precio_a_pagar_por_producto[i];
                                respuesta_de_mensaje = op_tex.concatenacion_caracter_separacion(respuesta_de_mensaje, todos_juntos, '\n');

                                string todos_juntos_para_folio = cantidad_de_productos[i] + G_caracter_separacion[2] + nombre_de_productos[i] + G_caracter_separacion[2] + precio_a_pagar_por_producto[i];
                                respuesta_de_mensaje_para_folio = op_tex.concatenacion_caracter_separacion(respuesta_de_mensaje_para_folio, todos_juntos_para_folio, G_caracter_separacion[1]);
                            }

                        }
                        
                        string folio = GenerarCadenaConFechaHoraAleatoria(4) + "" + DateTime.Now.ToString("yyMMddHHmmss");
                        folio = folio.ToLower();
                        respuesta_de_mensaje = respuesta_de_mensaje + "\n" + "total a pagar " + total_a_pagar_de_todo;
                        contador_ventas = contador_ventas + "\n" + "total a pagar " + total_a_pagar_de_todo + "\n" + folio;
                        string mensaje_despues_de_la_venta_a_enviar = op_tex.concatenacion_filas_de_un_archivo(G_dir_arch_mensages[3]);
                        respuesta_de_mensaje = respuesta_de_mensaje + "\n" + mensaje_despues_de_la_venta_a_enviar + "\nfolio:\n" + folio;

                        contactos = G_contactos_lista_para_mandar_informacion[5, 1];
                        respuesta_a_mandar_mensage = nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n" + "------------------------------------------------------------------------";
                        acumulador_de_mensajes("usuario_actual", respuesta_a_mandar_mensage);
                        
                        

                        acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[0,1], encargado_cantidades_nom_producto);
                        acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[1, 1], respuesta_de_mensaje);
                        acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[2, 1], contador_ventas);
                        acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[4, 1], respuesta_de_mensaje);

                        //agregar archivos registros

                        int indice_folios = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[0, 0]));


                        string carpetas = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(G_dir_arch_mensages[0], "\\", 1);
                        string dir_archivo_v_usuarios = carpetas + "\\reg\\" + DateTime.Now.ToString("yyyyMMdd") + "_v_us.txt";
                        string dir_archivo_reg = carpetas + "\\reg\\" + DateTime.Now.ToString("yyyyMMdd") + "_reg.txt";
                        int indice_nego = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direccion_negocio));


                        string usuario = op_arr.busqueda_profunda_arreglo(Tex_base.GG_base_arreglo_de_arreglos[indice_nego], "8|6", nom_mensage_clickeado, donde_iniciar: 1);

                        if (usuario != null)
                        {
                            string[] usuario_espliteado = usuario.Split(G_caracter_separacion[0][0]);
                            string tem_info_si_no_es_vendedor = folio + G_caracter_separacion[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + G_caracter_separacion[0] + total_a_pagar_de_todo + G_caracter_separacion[0] + "venta" + G_caracter_separacion[0] + respuesta_de_mensaje_para_folio + G_caracter_separacion[0] + usuario_espliteado[0] + G_caracter_separacion[0] + nom_mensage_clickeado + G_caracter_separacion[0] + "repartidor" + G_caracter_separacion[0] + "datos_comprador" + G_caracter_separacion[0] + "datos_extras";
                            bas.Agregar(G_dir_para_registros_y_configuraciones[0, 0], tem_info_si_no_es_vendedor);

                        }

                        else
                        {

                            string tem_info = folio + G_caracter_separacion[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + G_caracter_separacion[0] + total_a_pagar_de_todo + G_caracter_separacion[0] + "venta" + G_caracter_separacion[0] + respuesta_de_mensaje_para_folio + G_caracter_separacion[0] + "no_es_vendedor" + G_caracter_separacion[0] + nom_mensage_clickeado + G_caracter_separacion[0] + "repartidor" + G_caracter_separacion[0] + "datos_comprador" + G_caracter_separacion[0] + "datos_extras";
                            bas.Agregar(G_dir_para_registros_y_configuraciones[0, 0], tem_info);
                        }


                    }


                }
            }
            //mandar mensages
            string[,] mensajes_para_y_mensaje = acumulador_de_mensajes(operacion: "retornar");
            for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
            {
                if (mensajes_para_y_mensaje[i, 0] != "usuario_actual")
                {

                    for (int k = i + 1; k < mensajes_para_y_mensaje.GetLength(0); k++)
                    {
                        if (mensajes_para_y_mensaje[k, 0] == "usuario_actual")
                        {
                            // Almacenar la fila actual en una variable temporal
                            string tempUsuario = mensajes_para_y_mensaje[i, 0];
                            string tempMensaje = mensajes_para_y_mensaje[i, 1];

                            // Intercambiar toda la fila
                            mensajes_para_y_mensaje[i, 0] = mensajes_para_y_mensaje[k, 0];
                            mensajes_para_y_mensaje[i, 1] = mensajes_para_y_mensaje[k, 1];
                            mensajes_para_y_mensaje[k, 0] = tempUsuario;
                            mensajes_para_y_mensaje[k, 1] = tempMensaje;

                        }
                    }
                }
            }
            if (mensajes_para_y_mensaje != null)
            {
                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    mandar_mensage_usuarios(manejadores, esperar, mensajes_para_y_mensaje[i, 0], mensajes_para_y_mensaje[i, 1]);
                }
            }

        }

        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {

            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath(G_info_de_configuracion_chatbot[6][1] + nombre_o_numero + "')]"));
            string a = elemento.Text;
            elemento.Click();

        }



        private void mandar_mensage_usuarios(IWebDriver manejadores, WebDriverWait esperar, object nombre_contacto, string mensage = null, object caracter_separacion_objeto_usuarios = null, object caracter_separacion_objeto_mensages = null)
        {
            
            string[] caracter_separacion_usuarios = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto_usuarios);
            string[] caracter_separacion_mensajes = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_objeto_mensages);
            string[] supervisores = op_arr.convierte_objeto_a_arreglo(nombre_contacto, caracter_separacion_usuarios[0]);
            string[] mensage_espliteados = op_arr.convierte_objeto_a_arreglo(mensage, caracter_separacion_mensajes[0]);

            for (int k = 0; k < supervisores.Length; k++)
            {


                for (int h = 0; h < G_contactos_lista_para_mandar_informacion.GetLength(0); h++)
                {

                    if (supervisores[k] == G_contactos_lista_para_mandar_informacion[h, 1])
                    {
                        // Simular la presión de la tecla Escape
                        Actions action = new Actions(manejadores);
                        action.SendKeys(Keys.Escape).Perform();

                        int indice_supervisor = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[h, 0]));
                        for (int l = G_donde_inicia_la_tabla; l < Tex_base.GG_base_arreglo_de_arreglos[indice_supervisor].Length; l++)
                        {
                            buscar_nombre_y_dar_click(manejadores, esperar, Tex_base.GG_base_arreglo_de_arreglos[indice_supervisor][l]);
                            mandar_mensage(esperar, mensage_espliteados[k]);
                        }

                    }
                }

                if (supervisores[k] == "usuario_actual")
                {
                    mandar_mensage(esperar, mensage_espliteados[k]);
                }
                

            }

        }

        WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, object texto_enviar_arreglo_objeto)
        {
            string[] texto_enviar_arreglo_string = op_arr.convierte_objeto_a_arreglo(texto_enviar_arreglo_objeto, "\n");


            G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][1];
            var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            string texto_enviar = string.Join("\n", texto_enviar_arreglo_string);

            escribir_msg.SendKeys(texto_enviar);
            Thread.Sleep(3000); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Enter);
            
        }

        private string[] leer_mensages_recibidos_del_mensage_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son los de buscar el mensage que nos llego
            string elementos2 = G_info_de_configuracion_chatbot[4][1];

            ReadOnlyCollection<IWebElement> elementos_ = esperar.Until(manej3 => manej3.FindElements(By.XPath(elementos2)));

            string[] textosDelMensaje = new string[elementos_.Count];
            for (int i = 0; i < elementos_.Count; i++)
            {
                textosDelMensaje[i] = elementos_[i].Text;
            }
            return textosDelMensaje;
        }

        private string nombre_del_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {
            string nombre_a_devolver = esperar.Until(manej2 =>
            {
                try
                {
                    return manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7][1])).Text;
                }
                catch
                {

                    return manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7][2])).Text;

                }

            });



            return nombre_a_devolver;

        }

        private string GenerarCadenaConFechaHoraAleatoria(int cant_caracteres = 4)
        {
            // Obtiene la hora actual con segundos
            string HoraConSegundos = DateTime.Now.ToString("HHmmss");

            // Inicializa la semilla usando el reloj del sistema
            int semilla = Environment.TickCount;
            Random aleatorio = new Random(semilla);

            // Genera una cadena aleatoria de longitud variable (entre 0 y 10 caracteres)
            int longitud = aleatorio.Next(cant_caracteres);
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] cadenaAleatoria = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                cadenaAleatoria[i] = caracteres[aleatorio.Next(caracteres.Length)];
            }

            // Combina la fecha y hora con la cadena aleatoria
            string resultado = HoraConSegundos + new string(cadenaAleatoria);

            return resultado;
        }

        private string[][] extraer_info_de_archivos_de_configuracion_chatbot(string[] direcciones)
        {

            string[][] info_a_retornar = null;
            for (int i = 0; i < direcciones.Length; i++)
            {
                int indice_configuracion_archivos_chatbot = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direcciones[i]));
                info_a_retornar = op_arr.agregar_arreglo_a_arreglo_de_arreglos(info_a_retornar, Tex_base.GG_base_arreglo_de_arreglos[indice_configuracion_archivos_chatbot]);
            }

            return info_a_retornar;
        }

        public void recargar_arreglos()
        {
            string[] chequeo = bas.Leer_inicial(G_dir_para_registros_y_configuraciones[3, 0]);
            if (chequeo.Length > G_donde_inicia_la_tabla)
            {
                if (chequeo[G_donde_inicia_la_tabla] == "1")
                {
                    for (int i = 0; i < G_dir_arch_mensages.Length; i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[i]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_dir_arch_mensages[i]);
                    }

                    for (int i = G_donde_inicia_la_tabla; i < G_contactos_lista_para_mandar_informacion.GetLength(0); i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[i, 0]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_contactos_lista_para_mandar_informacion[i, 0]);
                    }

                    for (int i = 0; i < G_dir_para_registros_y_configuraciones.GetLength(0); i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[i,0]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_dir_para_registros_y_configuraciones[i,0]);
                    }

                }
            }


        }

        public void comandos_us_con_privilegios(IWebDriver manejadores, WebDriverWait esperar, string nombre, object comando, string caracter_de_separacion_si_es_string = null)
        {
            string[] comando_espliteado = op_arr.convierte_objeto_a_arreglo(comando, caracter_de_separacion_si_es_string);
            string[] grupos_en_los_que_esta = pociciones_en_los_que_se_encutra(nombre);


            switch (comando_espliteado[0])
            {
                case "con":
                    string[] grupos_donde_puede_ejecutarse = { G_contactos_lista_para_mandar_informacion[6, 1] };

                    string[] grupos_a_aceptados = op_arr.que_elementos_se_encuentra_dentro_de_un_arreglo(grupos_en_los_que_esta, grupos_donde_puede_ejecutarse);
                    
                    if (grupos_a_aceptados!=null)
                    {
                        int indice_folios = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[0, 0]));
                        int indice_reg_mov_usuarios = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[2, 0]));
                        

                        
                    }
                    break;

                default:
                    break;
            }
        }

        public bool confirmaciones_de_usuarios_confirmadores_o_funciones_extras(IWebDriver manejadores, WebDriverWait esperar, string nombre, string[] comando, object caraccaracter_de_separacion_objet_para_comando = null)
        {
            string[] caracter_de_separacion_si_es_string = var_GG.GG_funcion_caracter_separacion(caraccaracter_de_separacion_objet_para_comando);
            
            string[] grupos_en_los_que_esta = pociciones_en_los_que_se_encutra(nombre);
            bool esta_en_confirmadores = false;


            for (int i = 0; i < grupos_en_los_que_esta.Length; i++)
            {
                // area del grupo de confirmadores
                if (grupos_en_los_que_esta[i] == G_contactos_lista_para_mandar_informacion[6, 1])
                {
                    for (int j = 0; j < comando.Length; j++)
                    {
                        string[] comandos_espliteado = op_arr.convierte_objeto_a_arreglo(comando[j], caracter_de_separacion_si_es_string[0]);
                        if (comandos_espliteado.Length < 1)
                        {
                            switch (comandos_espliteado[0])
                            {
                                case "conf":
                                    break;
                                default:
                                    break;
                            }
                        }

                        else
                        {
                            for (int k = G_donde_inicia_la_tabla; k < Tex_base.GG_base_arreglo_de_arreglos[25].Length; k++)
                            {
                                string[] movimiento_a_confirmar = Tex_base.GG_base_arreglo_de_arreglos[25][k].Split(G_caracter_separacion[0][0]);
                                if (comandos_espliteado[j] == movimiento_a_confirmar[0])
                                {
                                    if ("venta" == movimiento_a_confirmar[3])
                                    {
                                        if ("no_es_vendedor" != movimiento_a_confirmar[5])
                                        {
                                            simul.entrada_dinero_simple_y_complejo(simul.G_direccion_negocio, movimiento_a_confirmar[5], movimiento_a_confirmar[2]);
                                            
                                        }
                                        bas.eliminar_fila(G_dir_para_registros_y_configuraciones[0, 0], 0, movimiento_a_confirmar[0]);
                                    }
                                }
                            }

                        }

                    }

                    esta_en_confirmadores = true;
                    mandar_mensage_usuarios(manejadores, esperar, "usuario_actual", "ok");

                    return esta_en_confirmadores;
                }
                //area configuraciones del programador
                else if (grupos_en_los_que_esta[i] == G_contactos_lista_para_mandar_informacion[7, 1])
                {

                }

            }
            return esta_en_confirmadores;
        }

        public string[] pociciones_en_los_que_se_encutra(string nombre)
        {
            string[] grupos_en_los_que_esta = null;
            int contactos_listas = G_contactos_lista_para_mandar_informacion.GetLength(0);
            for (int i = 0; i < contactos_listas; i++)
            {
                int indice_dir_contactos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[i, 0]));
                int contactos_listas2 = Tex_base.GG_base_arreglo_de_arreglos[indice_dir_contactos].Length;
                for (int j = G_donde_inicia_la_tabla; j < contactos_listas2; j++)
                {
                    string temp = Tex_base.GG_base_arreglo_de_arreglos[indice_dir_contactos][j];
                    if (temp == nombre)
                    {
                        grupos_en_los_que_esta = op_arr.agregar_registro_del_array(grupos_en_los_que_esta, G_contactos_lista_para_mandar_informacion[i, 1]);
                        break;
                    }
                }


            }
            return grupos_en_los_que_esta;
        }

        public void registro_chatbot(string folio, string añomesdiahoraminutosegundo, string total, string operacion, string[,] nom_produc_precio, string vendedor, string num_celular_vendeor, string[,] datos_comprador, string[,] datos_extra = null)
        {

            string cadena_folio = folio + "|" + añomesdiahoraminutosegundo + "|" + total + "|" + operacion + "|" + op_arr.join_para_bidimensional(nom_produc_precio) + "|" + vendedor + "|" + num_celular_vendeor + "|" + op_arr.join_para_bidimensional(datos_comprador) + "|" + op_arr.join_para_bidimensional(datos_extra);
            //folio_venta|añomesdiahoraminutosegundo|total|operacion|producto1¬precio1°pedido2¬precio2|vendedor|num_celular_vendedor|repartidor|datos_comprador°datos_comprador|datos_extra1°dato_extra2
            bas.Agregar(G_dir_para_registros_y_configuraciones[0, 0], cadena_folio);
            bas.Agregar(G_dir_para_registros_y_configuraciones[1, 0], cadena_folio);
            bas.Editar_o_incr_espesifico_si_no_esta_agrega_linea(G_dir_para_registros_y_configuraciones[2, 0], 0, vendedor, "1", total, "1", vendedor + G_caracter_separacion[0] + total);

        }

        string[,] mensajes_acumulados = null;
        public string[,] acumulador_de_mensajes(string nombre=null,string mensge = null,string operacion="agregar")
        {
            if (operacion == "agregar")
            {
                mensajes_acumulados = op_arr.agregar_registro_del_array_bidimensional(mensajes_acumulados, nombre + G_caracter_separacion_funciones_espesificas[0] + mensge, G_caracter_separacion_funciones_espesificas[0]);
                return null;
            }
            else if (operacion == "retornar")
            {
                string[,] tem_mensages = mensajes_acumulados;
                mensajes_acumulados = null;
                return tem_mensages;
            }
            return null;
        }

        bool cargar_menus_retorna_numero_menu_por_10(string menu_string)
        {
            
            string primera_letra = "" + menu_string[0];
            primera_letra = primera_letra.ToLower();

            int indice_productos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[2]));

            
            if (primera_letra == "m")
            {
                
                string num_menu_sin_la_m = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(menu_string, restar_cuantas_ultimas_o_primeras_celdas: 1, restar_primera_celda: true);
                try
                {
                    int num_m = Convert.ToInt32(num_menu_sin_la_m);
                    G_productos = new string[10, 3];
                    int num_m_por_10 = (num_m * 10);
                    if (Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length >= (num_m_por_10))
                    {


                        int temp_donde_iniciar = 0;



                        if (num_m < 1)
                        {
                            temp_donde_iniciar = G_donde_inicia_la_tabla;
                        }


                        for (int k = temp_donde_iniciar; k < 10; k++)
                        {
                            if ((k+num_m_por_10) >= Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length)
                            {
                                break;
                            }
                            string[] producto_espliteado = Tex_base.GG_base_arreglo_de_arreglos[indice_productos][num_m_por_10 + k].Split(G_caracter_separacion[0][0]);
                            G_productos[k, 0] = producto_espliteado[0];
                            G_productos[k, 1] = producto_espliteado[1];
                            G_productos[k, 2] = "0";


                        }

                        return true;
                    }
                }
                catch{}
                
            }

            return false;


        }

    }
}
