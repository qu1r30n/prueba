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


namespace chatbot_wathsapp.clases
{
    class chatbot_clase
    {
        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        var_fun_GG var_GG = new var_fun_GG();
        Tex_base bas = new Tex_base();
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
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[13, 0],//"config\\chatbot\\01_mensaje_bienvenida_inicio.txt,"
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[14, 0],//"config\\chatbot\\02_mensaje_bienvenida_final.txt"
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[15, 0],//"config\\chatbot\\03_productos.txt"
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[16, 0]//"config\\chatbot\\04_mensaje_extra_despues_de_la_venta.txt"
        };
        string[,] G_contactos_lista_para_mandar_informacion =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[17, 0],"encargados" },//"config\\chatbot\\05_encargados.txt"
            /*1*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18, 0],"supervisores" },//"config\\chatbot\\06_supervisores.txt"
            /*2*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[19, 0],"contadores" },//"config\\chatbot\\07_contadores.txt"
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[20, 0],"vendedores" },//"config\\chatbot\\08_vendedores.txt"
            /*4*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[21, 0],"repartidores" },//"config\\chatbot\\09_repartidores.txt"
            /*5*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[22, 0],"reg_mensage" }//"config\\chatbot\\10_reg_mensaje.txt"
        };

        string[] G_dir_arch_listas_de_contactos_para_recepcion_de_informacion_para_funciones_espesificas =
        {
            /**/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[23, 0],//"config\\chatbot\\configuracion_programador.txt"
            
        };

        string si_es_1_recarga_todos_los_arreglos = Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[24, 0];


        string[] G_info_de_configuracion_chatbot = null;

        public void configuracion_de_inicio()
        {

            G_info_de_configuracion_chatbot=extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);
            
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
            manejadores.Navigate().GoToUrl(G_info_de_configuracion_chatbot[0]);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            Thread.Sleep(tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera

            //esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej =>
            {
                //IWebElement elemento_app = manej.FindElement(By.Id("app"));
                IWebElement elementoSide = manej.FindElement(By.Id(G_info_de_configuracion_chatbot[1]));
                return elementoSide;
            });
            
            procesos(manejadores, esperar);

        }

        public void procesos(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son del no leido--------------------------------------------------------------------
            string elementos = G_info_de_configuracion_chatbot[2];
            string elementos_clase = elementos + G_info_de_configuracion_chatbot[3]; ;
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

            string[] textos_recibidos_srting_arr= op_arr.funcion_convert_objeto_a_arreglo(texto_recibidos_arreglo_objeto);


            string ultimo_mensaje = textos_recibidos_srting_arr[textos_recibidos_srting_arr.Length-1];
            ultimo_mensaje = ultimo_mensaje.ToLower();
            string[] lineas_del_mensaje = ultimo_mensaje.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int indice_productos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[2]));

            string responder_mensage = "";
            string mensajes_para_ = "";

            

            string[] nombre_de_productos = new string[Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length];
            double[] precio_a_pagar_por_producto = new double[Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length];
            double[] cantidad_de_productos = new double[Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length];

            

            string mensaje_de_bienvenida_a_enviar = op_tex.concatenacion_caracter_separacion_dentro_de_un_for_1(G_dir_arch_mensages[0]);
            string mensaje_de_productos_a_enviar = op_tex.concatenacion_caracter_separacion_dentro_de_un_for_1(G_dir_arch_mensages[2],true);
            string mensaje_de_bienvenida_final_a_enviar = op_tex.concatenacion_caracter_separacion_dentro_de_un_for_1(G_dir_arch_mensages[1]);
            string mensage_bienvenida_total = mensaje_de_bienvenida_a_enviar + "\n" + mensaje_de_productos_a_enviar + "\n" + mensaje_de_bienvenida_final_a_enviar;

            
            double total_a_pagar_de_todo = 0;
            for (int j = 0; j < lineas_del_mensaje.Length; j++)
            {

                string[] ultimo_mensaje_espliteado = lineas_del_mensaje[j].Split(':');
                for (int k = 0; k < ultimo_mensaje_espliteado.Length; k++)
                {
                    ultimo_mensaje_espliteado[k] = ultimo_mensaje_espliteado[k].Trim();
                }


                if (ultimo_mensaje_espliteado.Length > 1)
                {
                    
                    

                    switch (ultimo_mensaje_espliteado[0])
                    {
                        case "ubi":
                            responder_mensage = responder_mensage + "ubicacion recibida: " + G_caracter_separacion_funciones_espesificas[0];
                            mandar_mensage(esperar, responder_mensage);
                            mensajes_para_ = mensajes_para_ + lineas_del_mensaje[j] + G_caracter_separacion_funciones_espesificas[0];

                            /*reg*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");

                            /*sup*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[1, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*repa*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[4, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            return;
                            break;
                        case "ext":
                            responder_mensage = responder_mensage + "informacion extra recibida: " + G_caracter_separacion_funciones_espesificas[0];
                            mandar_mensage(esperar, responder_mensage);
                            mensajes_para_ = mensajes_para_ + lineas_del_mensaje[j] + G_caracter_separacion_funciones_espesificas[0];

                            /*reg*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*enc*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[0, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*sup*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[1, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*repa*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[4, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            return;
                            break;
                        case "can":
                            responder_mensage = responder_mensage + "cancelacion recibida: " + G_caracter_separacion_funciones_espesificas[0];
                            mandar_mensage(esperar, responder_mensage);

                            mensajes_para_ = mensajes_para_ + lineas_del_mensaje[j] + G_caracter_separacion_funciones_espesificas[0];

                            /*reg*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*enc*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[0, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*sup*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[1, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            /*repa*/mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[4, 1], nombre_Del_que_envio_el_mensage + "\n" + mensajes_para_ + "\n" + "------------------------------------------------------------------------");
                            return;
                            break;
                        default:
                            try
                            {
                                int numero_de_platillo = Convert.ToInt32(ultimo_mensaje_espliteado[0]);
                                Double cantidad_de_platillos = Convert.ToDouble(ultimo_mensaje_espliteado[1]);
                                for (int k = G_donde_inicia_la_tabla; k < Tex_base.GG_base_arreglo_de_arreglos[indice_productos].Length; k++)
                                {
                                    string[] productos = Tex_base.GG_base_arreglo_de_arreglos[indice_productos][k].Split(G_caracter_separacion[0][0]);

                                    if (numero_de_platillo==k)
                                    {
                                        
                                        double total = Convert.ToDouble(productos[1]) * cantidad_de_platillos;
                                        total_a_pagar_de_todo = total_a_pagar_de_todo + total;
                                        precio_a_pagar_por_producto[numero_de_platillo] = precio_a_pagar_por_producto[numero_de_platillo] + total;
                                        cantidad_de_productos[numero_de_platillo] = cantidad_de_productos[numero_de_platillo] + cantidad_de_platillos;
                                    }

                                    nombre_de_productos[k] = productos[0];
                                }
                            }
                            catch (Exception)
                            {

                                mandar_mensage(esperar, mensage_bienvenida_total);
                                mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n" + "------------------------------------------------------------------------");
                                return;
                                
                            }
                            break;
                    }
                }


                else
                {
                    try
                    {
                        int solo_numeros_para_el_pedido = Convert.ToInt32(ultimo_mensaje_espliteado[0]);
                        for (int i = 0; i < ultimo_mensaje_espliteado[0].Length; i++)
                        {

                            int numero_de_platillo = Convert.ToInt32((""+ultimo_mensaje_espliteado[0][i]));
                            string[] productos = Tex_base.GG_base_arreglo_de_arreglos[indice_productos][numero_de_platillo].Split(G_caracter_separacion[0][0]);
                            nombre_de_productos[numero_de_platillo] = productos[0];
                            double precio = Convert.ToDouble(productos[1]);
                            precio_a_pagar_por_producto[numero_de_platillo] = precio_a_pagar_por_producto[numero_de_platillo] + precio;
                            total_a_pagar_de_todo = total_a_pagar_de_todo + precio;
                            cantidad_de_productos[numero_de_platillo] = cantidad_de_productos[numero_de_platillo] + 1;
                        }
                    }
                    catch (Exception)
                    {
                        mandar_mensage(esperar, mensage_bienvenida_total);
                        mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n" + "------------------------------------------------------------------------");
                        return;
                    }

                }
            }

            string encargado_cantidades_nom_producto = "";
            string contador_ventas = "";
            string respuesta_de_mensaje = "";
            
            for (int i = G_donde_inicia_la_tabla; i < nombre_de_productos.Length; i++)
            {
                if (precio_a_pagar_por_producto[i]>0)
                {
                    encargado_cantidades_nom_producto = op_tex.concatenacion_caracter_separacion_dentro_de_un_for_2(encargado_cantidades_nom_producto, cantidad_de_productos[i] + G_caracter_separacion[0] + nombre_de_productos[i], i, nombre_de_productos.Length, '\n');
                    contador_ventas= op_tex.concatenacion_caracter_separacion_dentro_de_un_for_2(contador_ventas, "comida" + G_caracter_separacion[0] + precio_a_pagar_por_producto[i], i, nombre_de_productos.Length, '\n');
                    string todos_juntos = cantidad_de_productos[i] + G_caracter_separacion[0] + nombre_de_productos[i] + G_caracter_separacion[0] + precio_a_pagar_por_producto[i];
                    respuesta_de_mensaje = op_tex.concatenacion_caracter_separacion_dentro_de_un_for_2(respuesta_de_mensaje,todos_juntos, i, nombre_de_productos.Length, '\n');
                    
                }
                
            }
            
            respuesta_de_mensaje = respuesta_de_mensaje + "\n" + "total a pagar " + total_a_pagar_de_todo;
            contador_ventas = contador_ventas + "\n" + "total a pagar " + total_a_pagar_de_todo;
            string mensaje_despues_de_la_venta_a_enviar = op_tex.concatenacion_caracter_separacion_dentro_de_un_for_1(G_dir_arch_mensages[3]);
            for (int i = 0; i < G_contactos_lista_para_mandar_informacion.GetLength(0); i++)
            {
                int indice_lista_contactos=Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[i,0]));
                for (int k = 0; k < Tex_base.GG_base_arreglo_de_arreglos[indice_lista_contactos].Length; k++)
                {

                    mandar_mensage_supervisores(manejadores,esperar,Tex_base.GG_base_arreglo_de_arreglos[indice_lista_contactos][k], G_contactos_lista_para_mandar_informacion[k, 1]);
                    
                }
            }


            

            mandar_mensage(esperar, respuesta_de_mensaje);
            //aqui se mandara el mensage
            mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n" + "------------------------------------------------------------------------");

            mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[0, 1], encargado_cantidades_nom_producto);
            mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[1, 1], nombre_Del_que_envio_el_mensage + "\n" + respuesta_de_mensaje);
            mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[2, 1], contador_ventas);
            mandar_mensage_supervisores(manejadores, esperar, G_contactos_lista_para_mandar_informacion[4, 1], nombre_Del_que_envio_el_mensage + "\n" + respuesta_de_mensaje);


        }

        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {
            
            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath(G_info_de_configuracion_chatbot[6] + nombre_o_numero + "')]"));
            string a = elemento.Text;
            elemento.Click();

        }

        private void mandar_mensage_supervisores(IWebDriver manejadores, WebDriverWait esperar, string nombre_contacto, object mensage = null)
        {
            for (int i = 0; i < G_contactos_lista_para_mandar_informacion.GetLength(0); i++)
            {
                if (nombre_contacto== G_contactos_lista_para_mandar_informacion[i,1])
                {
                    int indice_contactos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[i, 0]));
                    for (int j = G_donde_inicia_la_tabla; j < Tex_base.GG_base_arreglo_de_arreglos[indice_contactos].Length; j++)
                    {
                        buscar_nombre_y_dar_click(manejadores, esperar, Tex_base.GG_base_arreglo_de_arreglos[indice_contactos][j]);
                        mandar_mensage(esperar, mensage);

                    }
                    break;
                }
            }
        }
        
        WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, object texto_enviar_arreglo_objeto)
        {
            string[] texto_enviar_arreglo_string = op_arr.funcion_convert_objeto_a_arreglo(texto_enviar_arreglo_objeto, "\n");


            G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba
            
            string lugar_a_escribir = G_info_de_configuracion_chatbot[5];
            var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            string texto_enviar = string.Join("\n", texto_enviar_arreglo_string);

            escribir_msg.SendKeys(texto_enviar);
            Thread.Sleep(3000); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Enter);
            Thread.Sleep(100); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Escape);
        }

        private string[] leer_mensages_recibidos_del_mensage_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son los de buscar el mensage que nos llego
            string elementos2 = G_info_de_configuracion_chatbot[4];

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
            string nombre_a_devolver = esperar.Until(manej2 => manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7])).Text);
            return nombre_a_devolver;
        }

        private string GenerarCadenaConFechaHoraAleatoria(int cant_caracteres=4)
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

        private string[] extraer_info_de_archivos_de_configuracion_chatbot(string[] direcciones)
        {

            string[] info_a_retornar = null;
            for (int i = 0; i < direcciones.Length; i++)
            {
                int indice_configuracion_archivos_chatbot = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direcciones[i]));
                info_a_retornar = op_arr.agregar_registro_del_array(info_a_retornar, Tex_base.GG_base_arreglo_de_arreglos[indice_configuracion_archivos_chatbot][1]);
            }

            return info_a_retornar;
        }

        public void recargar_arreglos()
        {
            string[] chequeo = bas.Leer_inicial(si_es_1_recarga_todos_los_arreglos);
            if (chequeo.Length > G_donde_inicia_la_tabla)
            {
                if (chequeo[G_donde_inicia_la_tabla] == "1")
                {
                    for (int i = G_donde_inicia_la_tabla; i < G_dir_arch_mensages.Length; i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[i]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_dir_arch_mensages[i]);
                    }

                    for (int i = G_donde_inicia_la_tabla; i < G_contactos_lista_para_mandar_informacion.GetLength(0); i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[i, 0]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_contactos_lista_para_mandar_informacion[i, 0]);
                    }

                    for (int i = G_donde_inicia_la_tabla; i < G_dir_arch_listas_de_contactos_para_recepcion_de_informacion_para_funciones_espesificas.Length; i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_listas_de_contactos_para_recepcion_de_informacion_para_funciones_espesificas[i]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_dir_arch_listas_de_contactos_para_recepcion_de_informacion_para_funciones_espesificas[i]);
                    }

                }
            }
            

        }


    }
}
