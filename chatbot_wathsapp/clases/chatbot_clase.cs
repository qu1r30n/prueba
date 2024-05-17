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
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[16, 0],//"config\\chatbot\\04_mensaje_extra_despues_de_la_venta.txt"
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[29, 0]//"config\\chatbot\\03_productos.txt",

        };
        string[,] G_contactos_lista_para_mandar_informacion =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[17, 0],"encargados" },
            /*1*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18, 0],"supervisores" },
            /*2*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[19, 0],"contadores" },
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[20, 0],"vendedores" },
            /*4*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[21, 0],"repartidores" },
            /*5*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[22, 0],"reg_mensage" },
            /*6*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[26, 0],"tesoreros" },
            /*7*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[23, 0],"programador" },
            /*8*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[31, 0],"pedidos_horario" },
            /*9*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[30, 0],"confirmadores" },
            /*10*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[35, 0],"cocina_fonda" },
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


        string[,] G_productos = new string[10, 3];



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
            //Thread.Sleep(tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera

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


                            Thread.Sleep(1000);

                            return true;
                        }
                        else
                        {
                            // Si el elemento no está presente, espera y luego vuelve a intentar
                            Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
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




        private void modelo_para_mandar_mensage(IWebDriver manejadores, WebDriverWait esperar, string nombre_Del_que_envio_el_mensage, object texto_recibidos_arreglo_objeto)
        {
            recargar_arreglos();

            //la comparacion de registro y vendedores es temporal por que se deve hacer desde los archivos
            if (nombre_Del_que_envio_el_mensage != "Reg_mensaje")
            {

                string[] textos_recibidos_srting_arr = op_arr.convierte_objeto_a_arreglo(texto_recibidos_arreglo_objeto);


                string ultimo_mensaje = textos_recibidos_srting_arr[textos_recibidos_srting_arr.Length - 1].ToLower();//ultimo mensaje lo pone en minusculas
                mandar_mensage_usuarios(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n--------------------------------------------------------------------");
                buscar_nombre_y_dar_click(manejadores, esperar, nombre_Del_que_envio_el_mensage);//regresar al usuario


                string[] lineas_del_mensaje = ultimo_mensaje.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                int indice_productos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[2]));




                string menu_actual = horarios_menus();

                bool si_confirmo = confirmaciones_de_usuarios_confirmadores_o_funciones_extras(manejadores, esperar, nombre_Del_que_envio_el_mensage, lineas_del_mensaje, ":");
                if (G_pedido_a_procesar_cierre_de_cuenta_mesa != "" && G_pedido_a_procesar_cierre_de_cuenta_mesa != null)
                {
                    lineas_del_mensaje = G_pedido_a_procesar_cierre_de_cuenta_mesa.Split('\n');
                    G_pedido_a_procesar_cierre_de_cuenta_mesa = null;
                }
                if (si_confirmo == false)
                {
                    bool se_hiso_pedido = false;
                    for (int j = 0; j < lineas_del_mensaje.Length; j++)
                    {
                        bool hubo_cambio_de_menu = cargar_menus(lineas_del_mensaje[j]);
                        if (hubo_cambio_de_menu)
                        {
                            menu_actual = lineas_del_mensaje[j];
                            if (lineas_del_mensaje.Length == 1)
                            {
                                enviar_mensage_inicial();
                            }
                        }
                        else
                        {


                            try
                            {
                                Convert.ToInt32(lineas_del_mensaje[j]);
                                compra_solo_numeros_o_con_cantidades(lineas_del_mensaje[j], menu_actual);
                                se_hiso_pedido = true;

                            }
                            catch
                            {
                                //en este se haran los breaks dentro para que no afecten
                                if (lineas_del_mensaje.Length == 1)
                                {

                                    enviar_mensage_inicial();
                                }

                            }
                        }
                    }
                    if (se_hiso_pedido)
                    {
                        string[] pedido = compra_solo_numeros_o_con_cantidades(operacion: "retornar");
                        formato_para_mandar_mensajes_de_los_productos_pedidos(manejadores, esperar, nombre_Del_que_envio_el_mensage, pedido);
                    }
                    else
                    {
                        mandar_mensages_acumulados(manejadores, esperar);
                    }


                }
                if (mensajes_acumulados != null)
                {
                    mandar_mensages_acumulados(manejadores, esperar);
                }

            }
            
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();


        }

        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();

            //buscamos persona en el buscador de personas
            //aqui hacemos que reconosca la barra de texto y escriba

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][2];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));

            escribir_msg.SendKeys(nombre_o_numero);
            escribir_msg.SendKeys(Keys.Enter);


            /* lla funciona con el enter que se le da en busqueda asi que no es nesesario
            //damos click
            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            string buscar_elemento = G_info_de_configuracion_chatbot[6][1] + nombre_o_numero + "')]";
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath(buscar_elemento));
            string a = elemento.Text;
            elemento.Click();
            */

            //limpiamos_lo_que_se_puso_en_el_buscador_de_contactos
            escribir_msg.Click(); // Enfocar el elemento
            for (int i = 0; i < nombre_o_numero.Length; i++)
            {
                escribir_msg.SendKeys(Keys.Backspace); // Borrar el contenido del textbox
            }


        }

        private void mandar_mensage_usuarios(IWebDriver manejadores, WebDriverWait esperar, object nombre_contacto, string mensage = null, object caracter_separacion_objeto_usuarios = null, object caracter_separacion_objeto_mensages = null)
        {

            string[] caracter_separacion_usuarios = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto_usuarios);
            string[] caracter_separacion_mensajes = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_objeto_mensages);
            string[] supervisores = op_arr.convierte_objeto_a_arreglo(nombre_contacto, caracter_separacion_usuarios[0]);
            string[] mensage_espliteados = op_arr.convierte_objeto_a_arreglo(mensage, caracter_separacion_mensajes[0]);
            bool encontro_al_supervisor = false;
            for (int k = 0; k < supervisores.Length; k++)
            {


                for (int h = 0; h < G_contactos_lista_para_mandar_informacion.GetLength(0); h++)
                {

                    if (supervisores[k] == G_contactos_lista_para_mandar_informacion[h, 1])
                    {
                        encontro_al_supervisor = true;
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
                    encontro_al_supervisor = true;
                    mandar_mensage(esperar, mensage_espliteados[k]);
                }

                if (encontro_al_supervisor==false)
                {
                    if (nombre_contacto is string)
                    {
                        buscar_nombre_y_dar_click(manejadores, esperar, (string)nombre_contacto);
                        mandar_mensage(esperar, mensage_espliteados[k]);
                    }
                    
                }



            }


        }

        //WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, object texto_enviar_arreglo_objeto)
        {
            string[] texto_enviar_arreglo_string = op_arr.convierte_objeto_a_arreglo(texto_enviar_arreglo_objeto, "\n");


            //G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][1];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            string texto_enviar = string.Join("\n", texto_enviar_arreglo_string);

            escribir_msg.SendKeys(texto_enviar);
            Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
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
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[i, 0]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_dir_para_registros_y_configuraciones[i, 0]);
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

                    if (grupos_a_aceptados != null)
                    {
                        int indice_folios = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[0, 0]));
                        int indice_reg_mov_usuarios = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_para_registros_y_configuraciones[2, 0]));



                    }
                    break;

                default:
                    break;
            }
        }

        string G_variable_transferencia_grupos = "";
        string G_variable_transferencia_grupos2 = "";

        string[][] G_mesas_productos_acumulados_strings = null;
        string[][] G_mesas_resumen_produc_acum_mesa = null;
        string G_pedido_a_procesar_cierre_de_cuenta_mesa = "";
        public bool confirmaciones_de_usuarios_confirmadores_o_funciones_extras(IWebDriver manejadores, WebDriverWait esperar, string nombre, string[] comando, object caraccaracter_de_separacion_objet_para_comando = null,string letra_mesa="m",string letra_pagina_menu="p")
        {

            string[] caracter_de_separacion_si_es_string = var_GG.GG_funcion_caracter_separacion(caraccaracter_de_separacion_objet_para_comando);

            string[] grupos_en_los_que_esta = pociciones_en_los_que_se_encutra(nombre);
            bool esta_en_confirmadores = false;

            if (grupos_en_los_que_esta != null) 
            {
                for (int i = 0; i < grupos_en_los_que_esta.Length; i++)
                {
                    // area del grupo de tesoreros
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
                                //aqui se checa los folios y si coinside y es vendedor se hacen las comiciones
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
                        mandar_mensage_usuarios(manejadores, esperar, "usuario_actual", "comicion hecha");

                        return esta_en_confirmadores;
                    }

                    //area configuraciones del programador
                    else if (grupos_en_los_que_esta[i] == G_contactos_lista_para_mandar_informacion[7, 1])
                    {

                    }

                    // area del grupo de confirmadores
                    else if (grupos_en_los_que_esta[i] == G_contactos_lista_para_mandar_informacion[9, 1])
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
                                bool encontro_folio = false;
                                //aqui se checa los folios y si coinside y es vendedor se hacen las comiciones
                                for (int k = G_donde_inicia_la_tabla; k < Tex_base.GG_base_arreglo_de_arreglos[25].Length; k++)
                                {
                                    string[] movimiento_a_confirmar = Tex_base.GG_base_arreglo_de_arreglos[25][k].Split(G_caracter_separacion[0][0]);
                                    if (comandos_espliteado[j] == movimiento_a_confirmar[0])
                                    {
                                        encontro_folio = true;
                                        if ("venta" == movimiento_a_confirmar[3])
                                        {
                                            mandar_mensage(esperar, "mensage enviado a la persona del pedido");
                                            mandar_mensage_usuarios(manejadores, esperar, movimiento_a_confirmar[6], "esta en proceso tu pedido\n"+ movimiento_a_confirmar[0]+"\n------------------------------------------------");
                                            
                                        }
                                    }
                                }
                                if (encontro_folio==false)
                                {
                                    mandar_mensage(esperar, "no se encontro el folio");
                                }

                            }


                        }

                        esta_en_confirmadores = true;
                        //mandar_mensage_usuarios(manejadores, esperar, "usuario_actual", "ok");

                        return esta_en_confirmadores;
                    }

                    // area del grupo de cocina_fonda
                    else if (grupos_en_los_que_esta[i] == G_contactos_lista_para_mandar_informacion[10, 1])
                    {

                        string nuero_de_mesa_string = null;
                        int solo_num_mesa = 0;
                        string pagina_del_menu_string = letra_pagina_menu + "0";

                        string[] pedido_mesa = null;

                        
                        for (int j = 0; j < comando.Length; j++)
                        {
                            
                            bool es_mesa_o_pagina = false;
                            if (("" + comando[j][0]) == letra_mesa)
                            {

                                string temp_nuero_de_mesa_string = quitando_el_primeros_caracters_y_checa_si_es_int(comando[j]);
                                if (temp_nuero_de_mesa_string != null)
                                {
                                    solo_num_mesa = Convert.ToInt32(temp_nuero_de_mesa_string);
                                    G_mesas_productos_acumulados_strings = op_arr.si_el_multiarreglo_no_tiene_la_cantidad_de_arreglos_se_le_agrega(G_mesas_productos_acumulados_strings, solo_num_mesa + 1);
                                    G_mesas_resumen_produc_acum_mesa = op_arr.si_el_multiarreglo_no_tiene_la_cantidad_de_arreglos_se_le_agrega(G_mesas_resumen_produc_acum_mesa, solo_num_mesa + 1);

                                    nuero_de_mesa_string = comando[j];
                                    es_mesa_o_pagina = true;
                                }
                                esta_en_confirmadores = true;
                            }

                            else if (("" + comando[j][0]) == letra_pagina_menu)
                            {
                                
                                if (cargar_menus(comando[j]))
                                {
                                    pagina_del_menu_string = comando[j];
                                    es_mesa_o_pagina = true;
                                    cargar_menus(pagina_del_menu_string);
                                    if (comando.Length==1)
                                    {
                                        enviar_mensage_inicial();
                                    }
                                }
                                esta_en_confirmadores = true;
                            }
                            if (es_mesa_o_pagina == false)
                            {
                                if (comando[j] == "cerrar cuenta")
                                {
                                    string[] cuenta = mesas_compra_solo_numeros_o_con_cantidades(nuero_de_mesa_string, operacion: "cuanto_lleva");
                                    if (cuenta != null)
                                    {


                                        for (int k = 0; k < cuenta.Length; k++)
                                        {
                                            string[] tem = cuenta[0].Split(G_caracter_separacion[0][0]);
                                            string[] tem2 = tem[1].Split(G_caracter_separacion[1][0]);
                                            string productos = "";
                                            for (int l = 0; l < tem2.Length; l++)
                                            {
                                                string[] tem3 = tem2[l].Split(G_caracter_separacion[2][0]);
                                                string pagina = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(tem3[0], restar_cuantas_ultimas_o_primeras_celdas: 1, restar_primera_celda: true);

                                                int veses_producto = Convert.ToInt32(tem3[3]);

                                                for (int m = 1; m < veses_producto; m++)
                                                {
                                                    productos = productos + tem3[0][0];
                                                }
                                                if (veses_producto == 1)
                                                {
                                                    productos = "" + tem3[0][0];
                                                }

                                                G_pedido_a_procesar_cierre_de_cuenta_mesa = op_tex.concatenacion_caracter_separacion(G_pedido_a_procesar_cierre_de_cuenta_mesa, pagina + "\n" + productos, "\n");
                                            }

                                        }
                                        mesas_compra_solo_numeros_o_con_cantidades(nuero_de_mesa_string, operacion: "cerrar_cuenta");

                                        esta_en_confirmadores = false;
                                    }
                                    else
                                    {
                                        mandar_mensage(esperar, "falto poner la mes de la cuenta");
                                        esta_en_confirmadores = true;
                                    }
                                }

                                else if (comando[j] == "cuánto")
                                {
                                    string[] cuenta = mesas_compra_solo_numeros_o_con_cantidades(nuero_de_mesa_string, operacion: "cuanto_lleva");
                                    if (cuenta != null)
                                    {
                                        string[] tem_mesa = cuenta[0].Split(G_caracter_separacion[0][0]);
                                        string[] tem_productos = tem_mesa[1].Split(G_caracter_separacion[1][0]);
                                        string mensage_cuenta = "";
                                        for (int m = 0; m < tem_productos.Length; m++)
                                        {
                                            string[] info_producto = tem_productos[m].Split(G_caracter_separacion[2][0]);
                                            double costo_producto_cantidad = (Convert.ToDouble(info_producto[2]) * Convert.ToDouble(info_producto[3]));
                                            mensage_cuenta = op_tex.concatenacion_caracter_separacion(mensage_cuenta, info_producto[1] + G_caracter_separacion[0] + "p/u: " + info_producto[2] + G_caracter_separacion[0] + "cantidad: " + info_producto[3] + G_caracter_separacion[0] + costo_producto_cantidad, "\n");
                                        }
                                        mensage_cuenta = op_tex.concatenacion_caracter_separacion(mensage_cuenta, "total: " + tem_mesa[2], "\n");
                                        mensage_cuenta = letra_mesa + nuero_de_mesa_string + "\n" + mensage_cuenta + "\n-------------------------------------------------------------";
                                        acumulador_de_mensajes("usuario_actual", mensage_cuenta);
                                        if (G_pedido_a_procesar_cierre_de_cuenta_mesa == null)
                                        {
                                            esta_en_confirmadores = true;
                                        }
                                    }
                                    else
                                    {
                                        mandar_mensage(esperar, "falto poner la mes de la cuenta");
                                        esta_en_confirmadores = true;
                                    }
                                }
                                else if (comando[j] == "editar")
                                {

                                    esta_en_confirmadores = true;
                                }
                                else if (comando[j] == "cancelar")
                                {
                                    string[] cuenta = mesas_compra_solo_numeros_o_con_cantidades(nuero_de_mesa_string, operacion: "cancelar");
                                    if (cuenta!=null)
                                    {
                                        acumulador_de_mensajes("usuario_actual", "cuenta_cancelada");
                                        esta_en_confirmadores = true;
                                    }
                                    else
                                    {
                                        mandar_mensage(esperar, "falto poner la mes de la cuenta");
                                        esta_en_confirmadores = true;
                                    }
                                    
                                }

                                else
                                {
                                    try
                                    {
                                        Convert.ToInt32(comando[j]);


                                        mesas_compra_solo_numeros_o_con_cantidades(nuero_de_mesa_string, comando[j], pagina_del_menu_string);
                                        if (j>=comando.Length-1)
                                        {
                                            
                                            for (int k = 0; k < G_mesas_resumen_produc_acum_mesa.Length; k++)
                                            {
                                                if (G_mesas_productos_acumulados_strings[k] != null)
                                                {
                                                    if (G_mesas_resumen_produc_acum_mesa[k] == null)
                                                    {
                                                        G_mesas_resumen_produc_acum_mesa[k] = new string[G_mesas_productos_acumulados_strings[k].Length];
                                                        Array.Copy(G_mesas_productos_acumulados_strings[k], G_mesas_resumen_produc_acum_mesa[k], G_mesas_productos_acumulados_strings[k].Length);
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }

                                            if (G_mesas_resumen_produc_acum_mesa[solo_num_mesa] != null)
                                            {
                                                pedido_mesa = G_mesas_resumen_produc_acum_mesa[solo_num_mesa][0].Split(G_caracter_separacion[0][0]);
                                                pedido_mesa[1] = G_variable_transferencia_grupos;
                                                pedido_mesa[2] = G_variable_transferencia_grupos2;
                                                G_mesas_resumen_produc_acum_mesa[solo_num_mesa][0] = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(pedido_mesa);
                                            }
                                            string[] produc_esp_1 = G_variable_transferencia_grupos.Split(G_caracter_separacion[1][0]);
                                            string mensage_respuesta = "";
                                            for (int k = 0; k < produc_esp_1.Length; k++)
                                            {
                                                string[] produc_esp_2 = produc_esp_1[k].Split(G_caracter_separacion[2][0]);
                                                //4p0¬chilaquiles¬35¬1
                                                mensage_respuesta = op_tex.concatenacion_caracter_separacion(mensage_respuesta, produc_esp_2[1] + "\np/u: " + produc_esp_2[2] + "|cantidad: " + produc_esp_2[3] + "| " + (Convert.ToDouble(produc_esp_2[2]) * Convert.ToDouble(produc_esp_2[3])), "\n");
                                            }
                                            mandar_mensage(esperar, mensage_respuesta + "\ntotal: " + G_variable_transferencia_grupos2);
                                        }
                                        
                                    }
                                    catch(Exception a)
                                    {
                                        enviar_mensage_inicial();
                                        
                                    }
                                    esta_en_confirmadores = true;
                                }
                            }
                            
                        }
                        
                        
                    }

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
        public string[,] acumulador_de_mensajes(string nombre = null, string mensge = null, string operacion = "agregar")
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

        bool cargar_menus(string menu_string, char letra_para_paginas_de_menu = 'p', int quitar_letras_iniciales_para_solo_tener_el_num_pagina = 1, char letra_para_menu_del_dia = 'd')
        {
            menu_string = menu_string.ToLower();

            string letra_para_paginas_string = "" + letra_para_paginas_de_menu;
            string letra_para_menu_del_dia_string = "" + letra_para_menu_del_dia;
            string primera_letra = "" + menu_string[0];
            

            int indice_productos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[2]));
            int indice_productos_del_dia = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[4]));

            string[] arr_todos_los_productos = null;
            if (primera_letra == letra_para_paginas_string)
            {

                string num_menu_sin_la_letra_de_pagina = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(menu_string, restar_cuantas_ultimas_o_primeras_celdas: quitar_letras_iniciales_para_solo_tener_el_num_pagina, restar_primera_celda: true);

                

                try
                {
                    if ((num_menu_sin_la_letra_de_pagina[0] + "") == letra_para_menu_del_dia_string)
                    {
                        num_menu_sin_la_letra_de_pagina = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(num_menu_sin_la_letra_de_pagina, restar_cuantas_ultimas_o_primeras_celdas: quitar_letras_iniciales_para_solo_tener_el_num_pagina, restar_primera_celda: true);
                        if (num_menu_sin_la_letra_de_pagina == "" || num_menu_sin_la_letra_de_pagina == null)
                        {
                            num_menu_sin_la_letra_de_pagina = "0";
                        }
                        arr_todos_los_productos = Tex_base.GG_base_arreglo_de_arreglos[indice_productos_del_dia];
                    }
                    else
                    {
                        arr_todos_los_productos = Tex_base.GG_base_arreglo_de_arreglos[indice_productos];
                    }

                    int num_m = Convert.ToInt32(num_menu_sin_la_letra_de_pagina);
                    G_productos = new string[10, 3];
                    int num_m_por_10 = (num_m * 10);
                    if (arr_todos_los_productos.Length >= (num_m_por_10))
                    {


                        int temp_donde_iniciar = 0;



                        if (num_m < 1)
                        {
                            temp_donde_iniciar = G_donde_inicia_la_tabla;
                        }


                        for (int k = temp_donde_iniciar; k < 10; k++)
                        {
                            if ((k + num_m_por_10) >= arr_todos_los_productos.Length)
                            {
                                break;
                            }
                            string[] producto_espliteado = arr_todos_los_productos[num_m_por_10 + k].Split(G_caracter_separacion[0][0]);
                            G_productos[k, 0] = producto_espliteado[0];
                            G_productos[k, 1] = producto_espliteado[1];
                            G_productos[k, 2] = "0";


                        }

                        return true;
                    }
                }
                catch { }

            }

            return false;


        }
        
        string[] productos_acumulados_strings = null;
        public string[] compra_solo_numeros_o_con_cantidades(string numeros_produc_a_comp = null, string menu = "p0", string operacion = "agregar")
        {
            if (operacion == "agregar")
            {
                for (int i = 0; i < numeros_produc_a_comp.Length; i++)
                {

                    int numero_producto = Convert.ToInt32("" + numeros_produc_a_comp[i]);
                    double precio = Convert.ToDouble(G_productos[numero_producto, 1]);
                    string nombre_produc = G_productos[numero_producto, 0];
                    string cadena_unida = numero_producto + menu + G_caracter_separacion[0] + precio + G_caracter_separacion[0] + nombre_produc + G_caracter_separacion[0] + precio + G_caracter_separacion[0] + "1";
                    productos_acumulados_strings = op_arr.si_existe_edita_o_incrementa_si_no_agrega_string(productos_acumulados_strings, "0", numero_producto + menu, cadena_unida, "4" + G_caracter_separacion_funciones_espesificas[0] + 1, "1" + G_caracter_separacion_funciones_espesificas[0] + precio, "1" + G_caracter_separacion_funciones_espesificas[0] + "1");


                }
                return productos_acumulados_strings;
            }
            else if (operacion == "retornar")
            {
                string[] tem_mensages = productos_acumulados_strings;
                productos_acumulados_strings = null;
                return tem_mensages;
            }
            return null;
        }

        
        public string[] mesas_compra_solo_numeros_o_con_cantidades(string mesa, string numeros_produc_a_comp = null, string menu = "p0", string operacion = "agregar")
        {
            
            string nuero_de_mesa_solo_numero = quitando_el_primeros_caracters_y_checa_si_es_int(mesa);
            if (cargar_menus(menu))
            {

                if (nuero_de_mesa_solo_numero != null)
                {
                    int numero_de_mesa_int = Convert.ToInt32(nuero_de_mesa_solo_numero);

                    if (operacion == "agregar")
                    {
                        string cantidad_de_productos_texto = "";
                        for (int i = 0; i < numeros_produc_a_comp.Length; i++)
                        {

                            int numero_producto = Convert.ToInt32("" + numeros_produc_a_comp[i]);
                            double precio = Convert.ToDouble(G_productos[numero_producto, 1]);
                            string nombre_produc = G_productos[numero_producto, 0];
                            string cadena_unida = numero_producto + menu + G_caracter_separacion[0] + precio + G_caracter_separacion[0] + nombre_produc + G_caracter_separacion[0] + precio + G_caracter_separacion[0] + "1";




                            G_mesas_productos_acumulados_strings[numero_de_mesa_int] = op_arr.agrega_textos_a_columna
                                (
                                G_mesas_productos_acumulados_strings[numero_de_mesa_int],//arreglo

                                mesa + G_caracter_separacion[0] + numero_producto + menu + G_caracter_separacion[2] + nombre_produc + G_caracter_separacion[2] + precio + G_caracter_separacion[0] + precio + G_caracter_separacion[0],//texto_a_agregar
                                numero_producto + menu + G_caracter_separacion[2] + nombre_produc + G_caracter_separacion[2] + precio,//texto_a_agregar_sino_lo_encuentra
                                "1"//columnas_a_agregar_si_no_lo_encuentra
                                );

                            string[] tem_mesa = G_mesas_productos_acumulados_strings[numero_de_mesa_int][0].Split(G_caracter_separacion[0][0]);
                            string[] tem_productos = tem_mesa[1].Split(G_caracter_separacion[1][0]);
                            cantidad_de_productos_texto = op_arr.suma_elementos_iguales_dentro_de_un_arreglo_retorna_un_string_al_final_de_cada_elemento(tem_productos, G_caracter_separacion[1] + G_caracter_separacion_funciones_espesificas[0] + G_caracter_separacion[2]);
                            string[] cantidad_de_productos = cantidad_de_productos_texto.Split(G_caracter_separacion[1][0]);
                            double acumulador = 0;
                            for (int m = 0; m < cantidad_de_productos.Length; m++)
                            {
                                string[] info_producto = cantidad_de_productos[m].Split(G_caracter_separacion[2][0]);
                                acumulador = acumulador + (Convert.ToDouble(info_producto[2]) * Convert.ToDouble(info_producto[3]));
                            }
                            tem_mesa[2] = "" + acumulador;
                            
                            if (i==numeros_produc_a_comp.Length-1)
                            {
                                G_variable_transferencia_grupos = cantidad_de_productos_texto;
                                G_variable_transferencia_grupos2 = ""+acumulador;
                            }
                            
                            G_mesas_productos_acumulados_strings[numero_de_mesa_int][0] = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(tem_mesa);
                            cantidad_de_productos = null;
                        }
                        
                        return G_mesas_productos_acumulados_strings[numero_de_mesa_int];
                    }

                    else if (operacion == "cerrar_cuenta")
                    {
                        
                        G_mesas_productos_acumulados_strings[numero_de_mesa_int] = null;
                        G_mesas_resumen_produc_acum_mesa[numero_de_mesa_int] = null;
                        return null;
                    }

                    else if (operacion == "cancelar")
                    {
                        
                        G_mesas_productos_acumulados_strings[numero_de_mesa_int] = null;
                        G_mesas_resumen_produc_acum_mesa[numero_de_mesa_int] = null;
                        return null;
                    }

                    else if (operacion == "cuanto_lleva")
                    {
                        string[] tem_mensages = G_mesas_resumen_produc_acum_mesa[Convert.ToInt32(nuero_de_mesa_solo_numero)];
                        return tem_mensages;
                    }

                }
            }
            return null;
        }



        public void registros_y_movimientos_a_confirmar(string nom_mensage_clickeado,string añomesdiahoraminseg,string folio,string total, string respuesta_de_mensaje_para_folio)
        {
            //registros y confirmaciones-----------------------------------------------------------------------------------

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
                string tem_info_si_no_es_vendedor = folio + G_caracter_separacion[0] + añomesdiahoraminseg + G_caracter_separacion[0] + total + G_caracter_separacion[0] + "venta" + G_caracter_separacion[0] + respuesta_de_mensaje_para_folio + G_caracter_separacion[0] + usuario_espliteado[0] + G_caracter_separacion[0] + nom_mensage_clickeado + G_caracter_separacion[0] + "repartidor" + G_caracter_separacion[0] + "datos_comprador" + G_caracter_separacion[0] + "datos_extras";
                bas.Agregar(G_dir_para_registros_y_configuraciones[0, 0], tem_info_si_no_es_vendedor);

            }

            else
            {

                string tem_info = folio + G_caracter_separacion[0] + añomesdiahoraminseg + G_caracter_separacion[0] + total + G_caracter_separacion[0] + "venta" + G_caracter_separacion[0] + respuesta_de_mensaje_para_folio + G_caracter_separacion[0] + "no_es_vendedor" + G_caracter_separacion[0] + nom_mensage_clickeado + G_caracter_separacion[0] + "repartidor" + G_caracter_separacion[0] + "datos_comprador" + G_caracter_separacion[0] + "datos_extras";
                bas.Agregar(G_dir_para_registros_y_configuraciones[0, 0], tem_info);
            }

            //fin registros y confirmaciones---------------------------------------------------------------------------------------------------------
        }

        public void mandar_mensages_acumulados(IWebDriver manejadores, WebDriverWait esperar)
        {
            //retornar mensages acumulados
            string[,] mensajes_para_y_mensaje = acumulador_de_mensajes(operacion: "retornar");
            //mandar mensages
            if (mensajes_para_y_mensaje != null)
            {
                //ordenar
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

                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    mandar_mensage_usuarios(manejadores, esperar, mensajes_para_y_mensaje[i, 0], mensajes_para_y_mensaje[i, 1]);
                }
            }
            

            
            
        }

        public void formato_para_mandar_mensajes_de_los_productos_pedidos(IWebDriver manejadores, WebDriverWait esperar, string nombre_Del_que_envio_el_mensage, string[] pedido)
        {
            double total = 0;
            string mensage_a_enviar_usuario = "";
            string mensage_a_enviar_contadores = "";
            string mensage_a_enviar_cocineros = "";
            string mensage_a_enviar_repartidores_supervisores = "";
            
            string texto_para_registro_foliado = "";
            for (int i = 0; i < pedido.Length; i++)
            {
                string[] producto_espliteado = pedido[i].Split(G_caracter_separacion[0][0]);
                string tem_cod = producto_espliteado[0];
                string tem_tot = producto_espliteado[1];
                string tem_nom = producto_espliteado[2];
                string tem_precio_unit = producto_espliteado[3];
                string tem_cant = producto_espliteado[4];

                total = total + Convert.ToDouble(tem_tot);
                mensage_a_enviar_usuario = op_tex.concatenacion_caracter_separacion(mensage_a_enviar_usuario, tem_nom + G_caracter_separacion[0] + tem_precio_unit + G_caracter_separacion[0] + tem_cant + G_caracter_separacion[0] + tem_tot, "\n");
                mensage_a_enviar_contadores = op_tex.concatenacion_caracter_separacion(mensage_a_enviar_contadores, "comida: " + G_caracter_separacion[0] + tem_precio_unit + G_caracter_separacion[0] + tem_cant + G_caracter_separacion[0] + tem_tot, "\n");
                mensage_a_enviar_cocineros = op_tex.concatenacion_caracter_separacion(mensage_a_enviar_cocineros, tem_nom + G_caracter_separacion[0] + tem_cant, "\n");
                mensage_a_enviar_repartidores_supervisores = op_tex.concatenacion_caracter_separacion(mensage_a_enviar_repartidores_supervisores, tem_cod + G_caracter_separacion[0] + tem_nom + G_caracter_separacion[0] + tem_precio_unit + G_caracter_separacion[0] + tem_cant + G_caracter_separacion[0] + tem_tot, "\n");
                
                texto_para_registro_foliado = op_tex.concatenacion_caracter_separacion(texto_para_registro_foliado, tem_cant + G_caracter_separacion[2] + tem_nom + G_caracter_separacion[2] + tem_precio_unit + G_caracter_separacion[2] + tem_tot, G_caracter_separacion[1]);

            }

            string añomesdiahoraminseg = DateTime.Now.ToString("yyMMddHHmmss");
            string folio = GenerarCadenaConFechaHoraAleatoria(4) + "" + añomesdiahoraminseg;
            folio = folio.ToLower();

            mensage_a_enviar_repartidores_supervisores = nombre_Del_que_envio_el_mensage + "\n" + mensage_a_enviar_repartidores_supervisores + "\n total: " + total + "\n" + folio + "\n--------------------------------------------------------------------";
            mensage_a_enviar_usuario = mensage_a_enviar_usuario + "\n total: " + total + "\n" + folio + "\n--------------------------------------------------------------------";
            mensage_a_enviar_contadores = mensage_a_enviar_contadores + "\n total: " + total + "\n" + folio + "\n--------------------------------------------------------------------";
            mensage_a_enviar_cocineros = mensage_a_enviar_cocineros + "\n" + folio + "\n--------------------------------------------------------------------";

            string mensage_a_enviar_confirmadores_y_tesoreros = "venta "+nombre_Del_que_envio_el_mensage +" "+ total + "\n" + folio+"\n---------------------------------------------------------------";


            acumulador_de_mensajes("usuario_actual", mensage_a_enviar_usuario);//usuario
            acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[0, 1], mensage_a_enviar_cocineros);//encargados
            acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[2, 1], mensage_a_enviar_contadores);//contadores
            acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[4, 1], mensage_a_enviar_repartidores_supervisores);//repartidores
            acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[1, 1], mensage_a_enviar_repartidores_supervisores);//supervisores

            acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[9, 1], mensage_a_enviar_confirmadores_y_tesoreros);//confirmadores
            acumulador_de_mensajes(G_contactos_lista_para_mandar_informacion[6, 1], mensage_a_enviar_confirmadores_y_tesoreros);//tesoreros


            mandar_mensages_acumulados(manejadores, esperar);

            registros_y_movimientos_a_confirmar(nombre_Del_que_envio_el_mensage, añomesdiahoraminseg, folio, "" + total, texto_para_registro_foliado);
        }

        public void enviar_mensage_inicial()
        {
            string mensaje_de_bienvenida_a_enviar = op_tex.concatenacion_filas_de_un_archivo(G_dir_arch_mensages[0], caracter_separacion_obj: '\n');
            string mensaje_de_productos_a_enviar = op_tex.concatenacion_filas_de_un_arreglo_bidimencional(G_productos,true);
            string mensaje_de_bienvenida_final_a_enviar = op_tex.concatenacion_filas_de_un_archivo(G_dir_arch_mensages[1], caracter_separacion_obj: '\n');
            mensaje_de_bienvenida_final_a_enviar = mensaje_de_bienvenida_final_a_enviar + "\n_________________________________________________________________";

            string mensage_bienvenida_total = mensaje_de_bienvenida_a_enviar + "\n" + mensaje_de_productos_a_enviar + "\n" + mensaje_de_bienvenida_final_a_enviar;

            acumulador_de_mensajes("usuario_actual", mensage_bienvenida_total);
        }

        public string horarios_menus()
        {
            string hora_minuto = DateTime.Now.ToString("HHmm");
            string menu_actual = "p0";
            if (Convert.ToInt32(hora_minuto) >= 1200)
            {
                menu_actual = "pd";
            }
            
            cargar_menus(menu_actual);
            return menu_actual;
        }

        public string quitando_el_primeros_caracters_y_checa_si_es_int(string dato_a_checar,int numero_de_caracteres_a_quitar=1)
        {
            string dato_sin_el_primer_caracter = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(dato_a_checar, restar_cuantas_ultimas_o_primeras_celdas: numero_de_caracteres_a_quitar, restar_primera_celda: true);
            try
            {
                int numero_a_retornar = Convert.ToInt32(dato_sin_el_primer_caracter);
                return "" + numero_a_retornar;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
