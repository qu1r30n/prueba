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


namespace chatbot_wathsapp.clases
{
    class chatbot_clase
    {
        operaciones_arreglos op_arr = new operaciones_arreglos();
        Tex_base bas = new Tex_base();
        string[] G_caracter_separacion = variables_glob_conf.GG_caracter_separacion;

        string[,] G_productos;
        string[] G_encargados;
        string[] G_supervisores;
        string[] G_contadores;
        string[] G_vendedores;
        string[] G_repartidores;

        string G_productos_string = "";
        string G_mensaje_bienvenida_inicio = "";
        string G_mensaje_bienvenida_final = "";
        string G_mensaje_informacion_extra_despues_de_la_venta = "";
        string[] G_reg_mensajes;

        string[] G_direcciones =
            {
                /*0*/"config\\productos.txt",
                /*1*/"config\\encargados.txt",
                /*2*/"config\\supervisores.txt",
                /*3*/"config\\contadores.txt",
                /*4*/"config\\vendedores.txt",
                /*5*/"config\\repartidores.txt",
                /*6*/"config\\mensaje_bienvenida_inicio.txt",
                /*7*/"config\\mensaje_bienvenida_final.txt",
                /*8*/"config\\mensaje_extra_despues_de_la_venta.txt",
                /*9*/"config\\poner_1_si_recargaras_los_archivos.txt",
                /*10*/"config\\reg_mensaje.txt",
            };

        public void configuracion_de_inicio()
        {

            crear_archivos_inicio();

            string pagina = "https://" + "web.whatsapp.com/";
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
            manejadores.Navigate().GoToUrl(pagina);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            Thread.Sleep(tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera

            //esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej =>
            {
                //IWebElement elemento_app = manej.FindElement(By.Id("app"));
                IWebElement elementoSide = manej.FindElement(By.Id("side"));
                return elementoSide;
            });
            

            

            procesos(manejadores, esperar);

        }

        public void procesos(IWebDriver manejadores, WebDriverWait esperar)
        {
            //estos son del no leido--------------------------------------------------------------------
            string elementos = "//span[contains(@aria-label, 'No leídos')" + " or contains(@aria-label, 'No leído')]";
            string elementos_clase = elementos + "//ancestor::div[@class='_8nE1Y']";
            //-----------------------------------------------------------------------------------------
            //estos son los de buscar el mensage que nos llego
            string elementos2 = "//div[contains(@class, 'message-in')]//span[contains(@class, '_11JPr')]";
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

                            // texto mensaje que recibio-----------------------------------------------------------------------

                            /*antes se puso haci
                             IWebElement elementoMensaje = esperar.Until(manej3 => manej3.FindElement(By.XPath(elementos2)));
                            string textoDelMensaje = elementoMensaje.Text;
                             */
                            //antes
                            //string textoDelMensaje = esperar.Until(manej3 => manej3.FindElement(By.XPath(elementos2))).Text;
                            //este esta mucho mejor
                            ReadOnlyCollection<IWebElement> elementos_ = esperar.Until(manej3 => manej3.FindElements(By.XPath(elementos2)));

                            // Inicializa un arreglo de strings para almacenar los textos de los elementos
                            string[] textosDelMensaje = new string[elementos_.Count];

                            // Itera a través de los elementos para obtener sus textos y guardarlos en el arreglo
                            for (int i = 0; i < elementos_.Count; i++)
                            {
                                textosDelMensaje[i] = elementos_[i].Text;
                            }
                            //fin mensaje que resibio--------------------------------------------------------------

                            Thread.Sleep(1000);
                            try
                            {
                                string[] separador = { ":" };
                                opciones_a_hacer_y_mandar_mensge(manejadores, esperar, textosDelMensaje[textosDelMensaje.Length - 1], separador);
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

        public void opciones_a_hacer_y_mandar_mensge(IWebDriver manejadores, WebDriverWait esperar, string texto_que_envio, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            
            
            var nombre_de_usuario = esperar.Until(manej2 => manej2.FindElement(By.XPath("//header[@class='AmmtE']//div[@class='Mk0Bp _30scZ']")).Text);
            
            recargar_informacion_de_un_archivos_si_un_archivo_contiene_1_en_su_primera_fila();

            string[] lineas_del_mensaje = texto_que_envio.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int j = 0; j < lineas_del_mensaje.Length; j++)
            {
                //en esta parte se asegura que no tenga espacios al principio ni al final y que todo este en minusculas
                string[] informacion_espliteada = lineas_del_mensaje[j].Split(Convert.ToChar(caracter_separacion[0]));
                string[] temp_informacion_tratada = new string[informacion_espliteada.Length];
                for (int i = 0; i < informacion_espliteada.Length; i++)
                {
                    temp_informacion_tratada[i] = informacion_espliteada[i].Trim();
                    informacion_espliteada[i] = temp_informacion_tratada[i].ToLower();
                }

                string[] mensaje_a_enviar;

                //aqui se chequea que opciones a hacer
                if (informacion_espliteada.Length > 1)
                {
                    switch (informacion_espliteada[0])
                    {
                        case "ext":
                            mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, informacion_espliteada, "todos-cont");
                            break;
                        case "ubi":
                            string[] info_mas_nom_usu = op_arr.agregar_registro_del_array(informacion_espliteada, nombre_de_usuario);
                            mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, info_mas_nom_usu, "todos-cont");
                            break;
                        case "can":
                            mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, informacion_espliteada, "todos");
                            break;
                        default:
                            try
                            {

                                Convert.ToInt32(informacion_espliteada[0]);
                                string numero_de_platillo = informacion_espliteada[0];
                                double total_a_pagar = 0;
                                int[] cantidad_de_platillos = new int[G_productos.GetLength(0)];
                                mensaje_a_enviar = new string[G_productos.GetLength(0)];


                                cantidad_de_platillos[Convert.ToInt32(numero_de_platillo)] = Convert.ToInt32(informacion_espliteada[1]);

                                int num_plat = Convert.ToInt32(numero_de_platillo);
                                total_a_pagar = total_a_pagar + Convert.ToDouble(G_productos[num_plat, 1]);
                            

                                for (int i = 0; i < mensaje_a_enviar.Length; i++)
                                {
                                    if (cantidad_de_platillos[i] > 0)
                                    {
                                        mensaje_a_enviar[i] = G_productos[i, 0] + G_caracter_separacion[0] + cantidad_de_platillos[i];
                                    }

                                }
                                //se le agrega el folio del pedido para buscarlo si hay una cancelacion
                                mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar,"folio\n"+GenerarCadenaConFechaHoraAleatoria());
                                
                                //este guarda el pedido si n el total a pagar por que no tiene que ver  el dinero los encargados de la fabricacion
                                string[] mensaje_encargados = mensaje_a_enviar;
                                
                                string[] mensaje_supervisores = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                                mensaje_supervisores = op_arr.agregar_registro_del_array(mensaje_supervisores, nombre_de_usuario);

                                string[] mensaje_contadoeres = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                                
                                string[] mensaje_repartidores = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                                mensaje_repartidores = op_arr.agregar_registro_del_array(mensaje_repartidores, nombre_de_usuario);

                                //le manda su pedido y el total a pagar al que lo pidio
                                mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                                // si es el vendedor
                                mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, si_es_el_vendedor(nombre_de_usuario, string.Join("\n", mensaje_a_enviar) ));
                                //informacion extra despues de enviarle la informacion
                                mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, G_mensaje_informacion_extra_despues_de_la_venta);
                                mandar_mensage(esperar, mensaje_a_enviar);

                                

                                //manda pedido a encargados
                                mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_encargados, "encargados");
                                //mandar mensaje a contadores
                                mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_contadoeres, "contadores");

                                //manda mensaje del pedido  a supervisores
                                mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_supervisores, "supervisores");

                                //mandar mensaje a repartidores
                                mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_repartidores, "repartidores");

                            }

                            catch (Exception ex)
                            {
                                mandar_menu(manejadores, esperar, texto_que_envio, nombre_de_usuario);
                            }
                            break;
                    }
                }
                
                //este es por si solo pone los numeros de los productos
                else
                {
                    
                    try
                    {

                        Convert.ToInt32(informacion_espliteada[0]);
                        string numero_de_platillo = informacion_espliteada[0];
                        double total_a_pagar = 0;
                        int[] cantidad_de_platillos = new int[G_productos.GetLength(0)];
                        mensaje_a_enviar = new string[G_productos.GetLength(0)];
                        for (int i = 0; i < numero_de_platillo.Length; i++)
                        {

                            cantidad_de_platillos[Convert.ToInt32("" + numero_de_platillo[i])] = Convert.ToInt32(cantidad_de_platillos[Convert.ToInt32("" + numero_de_platillo[i])]) + 1;

                            int num_plat = Convert.ToInt32("" + numero_de_platillo[i]);
                            total_a_pagar = total_a_pagar + Convert.ToDouble(G_productos[num_plat, 1]);
                        }

                        for (int i = 0; i < mensaje_a_enviar.Length; i++)
                        {
                            if (cantidad_de_platillos[i] > 0)
                            {
                                mensaje_a_enviar[i] = G_productos[i, 0] + G_caracter_separacion[0] + cantidad_de_platillos[i];
                            }

                        }

                        //se le agrega el folio del pedido para buscarlo si hay una cancelacion
                        mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, "folio\n" + GenerarCadenaConFechaHoraAleatoria());

                        //este guarda el pedido si n el total a pagar por que no tiene que ver  el dinero los encargados de la fabricacion
                        string[] mensaje_encargados = mensaje_a_enviar;

                        string[] mensaje_supervisores = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                        mensaje_supervisores = op_arr.agregar_registro_del_array(mensaje_supervisores, nombre_de_usuario);

                        string[] mensaje_contadoeres = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);

                        string[] mensaje_repartidores = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                        mensaje_repartidores = op_arr.agregar_registro_del_array(mensaje_repartidores, nombre_de_usuario);

                        //le manda su pedido y el total a pagar al que lo pidio
                        mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, "total a pagar: " + total_a_pagar);
                        // si es el vendedor
                        mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, si_es_el_vendedor(nombre_de_usuario, string.Join("\n", mensaje_a_enviar)));
                        //informacion extra despues de enviarle la informacion
                        mensaje_a_enviar = op_arr.agregar_registro_del_array(mensaje_a_enviar, G_mensaje_informacion_extra_despues_de_la_venta);
                        mandar_mensage(esperar, mensaje_a_enviar);



                        //manda pedido a encargados
                        mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_encargados, "encargados");
                        //mandar mensaje a contadores
                        mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_contadoeres, "contadores");

                        //manda mensaje del pedido  a supervisores
                        mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_supervisores, "supervisores");

                        //mandar mensaje a repartidores
                        mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, mensaje_repartidores, "repartidores");



                    }

                    catch (Exception ex)
                    {
                        mandar_menu(manejadores,esperar,texto_que_envio,nombre_de_usuario);
                    }

                }

            }
        }

        private void mandar_menu(IWebDriver manejadores, WebDriverWait esperar, string texto_que_envio, string nombre_de_usuario)
        {
            string[] mensaje_a_enviar;
            mensaje_a_enviar = new string[] { $"Bienvenido {nombre_de_usuario}",
                                        G_mensaje_bienvenida_inicio,
                                        G_productos_string,
                                        G_mensaje_bienvenida_final};

            mandar_mensage(esperar, mensaje_a_enviar);

            string[] nombre_y_mensaje_que_envio = { nombre_de_usuario, texto_que_envio };
            mandar_mensajes_a_supervisores_y_encargados(manejadores, esperar, nombre_y_mensaje_que_envio, "reg_mensaje");
        }
        public void crear_archivos_inicio()
        {
            
            for (int i = 0; i < G_direcciones.Length; i++)
            {
                bas.Crear_archivo_y_directorio(G_direcciones[i]);
            }

            carga_de_informacion_a_variables_globales();

        }

        
        private void mandar_mensajes_a_supervisores_y_encargados(IWebDriver manejadores, WebDriverWait esperar,string[] mensaje,string NotificarSupEnc="todos")
        {
            if (NotificarSupEnc == "todos")
            {
                for (int i = 0; i < G_supervisores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_supervisores[i]);

                    mandar_mensage(esperar, mensaje);
                }

                for (int i = 0; i < G_encargados.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_encargados[i]);

                    mandar_mensage(esperar, mensaje);

                }

                for (int i = 0; i < G_contadores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_contadores[i]);

                    mandar_mensage(esperar, mensaje);

                }

                for (int i = 0; i < G_repartidores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_repartidores[i]);

                    mandar_mensage(esperar, mensaje);
                }


            }

            else if (NotificarSupEnc == "todos-cont")
            {
                for (int i = 0; i < G_supervisores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_supervisores[i]);

                    mandar_mensage(esperar, mensaje);
                }

                for (int i = 0; i < G_encargados.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_encargados[i]);

                    mandar_mensage(esperar, mensaje);

                }

                for (int i = 0; i < G_repartidores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_repartidores[i]);

                    mandar_mensage(esperar, mensaje);
                }

            }

            else if (NotificarSupEnc == "supervisores")
            {
                for (int i = 0; i < G_supervisores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_supervisores[i]);

                    mandar_mensage(esperar, mensaje);
                }
            }

            else if (NotificarSupEnc == "encargados")
            {
                for (int i = 0; i < G_encargados.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_encargados[i]);

                    mandar_mensage(esperar, mensaje);

                }
            }

            else if (NotificarSupEnc == "contadores")
            {
                for (int i = 0; i < G_contadores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_contadores[i]);

                    mandar_mensage(esperar, mensaje);

                }
            }

            else if (NotificarSupEnc == "repartidores")
            {
                for (int i = 0; i < G_repartidores.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_repartidores[i]);

                    mandar_mensage(esperar, mensaje);
                }
            }

            else if (NotificarSupEnc == "reg_mensaje")
            {
                for (int i = 0; i < G_reg_mensajes.Length; i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, G_reg_mensajes[i]);

                    mandar_mensage(esperar, mensaje);
                }
            }


        }

        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {
            
            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath("//span[contains(@title, '" + nombre_o_numero + "')]"));
            string a = elemento.Text;
            elemento.Click();

        }
        WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, string[] texto_enviar_arreglo)
        {
            G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba
            //html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]

            var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath("html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]")));
            string texto_enviar = string.Join("\n", texto_enviar_arreglo);
            escribir_msg.SendKeys(texto_enviar);
            Thread.Sleep(3000); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Enter);
            Thread.Sleep(100); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Escape);
            
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

        private string si_es_el_vendedor(string nombre_de_usuario,string info_a_guardar=null)
        {
            if (info_a_guardar!=null)
            {
                bas.Agregar("config\\registros.txt", nombre_de_usuario + " " + info_a_guardar);
            }

            string texto_a_retornar = "";
            for (int i = 0; i < G_vendedores.Length; i++)
            {
                if (G_vendedores[i]==nombre_de_usuario)
                {
                    texto_a_retornar = "ext:si quieres mandar informacion extra\nubi:di masomenos por donde esta o entre que calles\ncan:escribe el numero de folio y el motivo\n EJEMPLO \"can: 1234 me equivoque\"";
                }
            }
            return texto_a_retornar;
        }

        private void carga_de_informacion_a_variables_globales()
        {
            string[] produc = bas.Leer(G_direcciones[0]);
            G_encargados = bas.Leer(G_direcciones[1]);
            G_supervisores = bas.Leer(G_direcciones[2]);
            G_contadores = bas.Leer(G_direcciones[3]);
            G_vendedores = bas.Leer(G_direcciones[4]);
            G_repartidores = bas.Leer(G_direcciones[5]);
            G_mensaje_bienvenida_inicio = string.Join("\n", bas.Leer(G_direcciones[6]));
            G_mensaje_bienvenida_final = string.Join("\n", bas.Leer(G_direcciones[7]));
            G_mensaje_informacion_extra_despues_de_la_venta = string.Join("\n", bas.Leer(G_direcciones[8]));
            G_productos = new string[produc.Length, 2];
            for (int i = 0; i < produc.Length; i++)
            {
                string[] datosProducto = produc[i].Split(Convert.ToChar(G_caracter_separacion[0]));
                G_productos[i, 0] = datosProducto[0].Trim(); // Nombre del producto
                G_productos[i, 1] = datosProducto[1].Trim(); // Precio del producto
                if (i < produc.Length - 1)
                {
                    G_productos_string = G_productos_string + i + ")" + G_productos[i, 0] + " $" + G_productos[i, 1] + "\n";
                }
                else
                {
                    G_productos_string = G_productos_string + i + ")" + G_productos[i, 0] + " $" + G_productos[i, 1];
                }
            }
            //G_direcciones[9] el archivo que verificaras si se recargara  los datos de los archivos esta en la funcion recargar_informacion
            G_reg_mensajes = bas.Leer(G_direcciones[10]);
        }
        private void recargar_informacion_de_un_archivos_si_un_archivo_contiene_1_en_su_primera_fila()
        {
            bas.Crear_archivo_y_directorio(G_direcciones[9]);
            string[] contenido_del_archivo = bas.Leer(G_direcciones[9]);
            if (contenido_del_archivo.Length != 0)
            {
                if (contenido_del_archivo[0] == "1")
                {
                    G_productos_string = "";
                    carga_de_informacion_a_variables_globales();
                }
            }
            
        }

    }
}
