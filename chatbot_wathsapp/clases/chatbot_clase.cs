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

        public void crear_archivos_inicio()
        {
            bas.Crear_archivo_y_directorio("productos.txt");
            bas.Crear_archivo_y_directorio("encargados.txt");
            string[] produc = bas.Leer("productos.txt");
            G_encargados = bas.Leer("encargados.txt");

            G_productos = new string[produc.Length, 2];
            for (int i = 0; i < produc.Length; i++)
            {
                string[] datosProducto = produc[i].Split(Convert.ToChar(G_caracter_separacion[0]));
                G_productos[i, 0] = datosProducto[0].Trim(); // Nombre del producto
                G_productos[i, 1] = datosProducto[1].Trim(); // Precio del producto
            }

        }

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

                            
                            opciones_a_hacer_y_mandar_mensge(manejadores,esperar, textosDelMensaje[textosDelMensaje.Length-1]);

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

        public void opciones_a_hacer_y_mandar_mensge(IWebDriver manejadores, WebDriverWait esperar, string texto, string[] caracter_separacion = null)
        {
            if (caracter_separacion==null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            
            string[] informacion_espliteada = texto.Split(Convert.ToChar(caracter_separacion[0]));
            string[] mensaje;

            
            try
            {
                var nombre_de_usuario = esperar.Until(manej2 => manej2.FindElement(By.XPath("//header[@class='AmmtE']//div[@class='Mk0Bp _30scZ']")).Text);
                
                Convert.ToInt32(informacion_espliteada[0]);
                string numero_de_platillo = informacion_espliteada[0];
                double total_a_pagar = 0;
                int[] cantidad_de_platillos = new int[G_productos.GetLength(0)];
                mensaje = new string[G_productos.GetLength(0)];
                for (int i = 0; i < numero_de_platillo.Length; i++)
                {

                    cantidad_de_platillos[Convert.ToInt32("" + numero_de_platillo[i])] = Convert.ToInt32(cantidad_de_platillos[Convert.ToInt32("" + numero_de_platillo[i])]) + 1;

                    int num_plat = Convert.ToInt32(""+numero_de_platillo[i]);
                    total_a_pagar = total_a_pagar + Convert.ToDouble(G_productos[num_plat, 1]);
                }

                for (int i = 0; i < mensaje.Length; i++)
                {
                    if (cantidad_de_platillos[i]>0)
                    {
                        mensaje[i] = G_productos[i, 0] + G_caracter_separacion[0] + cantidad_de_platillos[i];
                    }
                    
                }
                
                mensaje = op_arr.agregar_registro_del_array(mensaje, "total a pagar: " + total_a_pagar+"\n"+nombre_de_usuario);
                mandar_mensage(esperar, mensaje);
                
                for (int i = 0; i < G_encargados.Length; i++)
                {

                    buscar_nombre_y_dar_click(manejadores, esperar, G_encargados[i]);
                    
                    mandar_mensage(esperar, mensaje);

                }
                



            }
            catch(Exception ex)
            {

                var nombre_de_usuario = esperar.Until(manej2 => manej2.FindElement(By.XPath("//header[@class='AmmtE']//div[@class='Mk0Bp _30scZ']")).Text);
                mensaje = new string[] { $"Bienvenido {nombre_de_usuario} a nuestra encantadora fondita! ",
                                        "Estamos emocionados de tenerte aquí y compartir",
                                        "contigo una experiencia culinaria inolvidable. ",
                                        "A continuación, te presentamos ",
                                        "tres opciones deliciosas para que elijas:",
                                        "",
                                        $"0) {G_productos[0, 0]} ${G_productos[0, 1]}",
                                        $"1) {G_productos[1, 0]} ${G_productos[1, 1]}",
                                        $"2) {G_productos[2, 0]} ${G_productos[2, 1]}",
                                        "",
                                        "Cuando estés listo/a para realizar tu pedido, ",
                                        "simplemente indícanos el número correspondiente sin espacios ni otro caracter ",
                                        "al platillo que has elegido. ",
                                        "¡Estamos aquí para hacer de tu experiencia gastronómica algo excepcional! ",
                                        "¡Buen provecho!"};



                mandar_mensage(esperar, mensaje);
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

        
    }
}
