using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Threading;


namespace chatbot_wathsapp.clases
{
    class chatbot_clase
    {
        string[] G_caracter_separacion = variables_globales.GG_caracter_separacion;
        public void configuracion_de_inicio()
        {
            string pagina = "https://" + "web.whatsapp.com/";
            //<span class="l7jjieqr cfzgl7ar ei5e7seu h0viaqh7 tpmajp1w c0uhu3dl riy2oczp dsh4tgtl sy6s5v3r gz7w46tb lyutrhe2 qfejxiq4 fewfhwl7 ovhn1urg ap18qm3b ikwl5qvt j90th5db aumms1qt"
            //aria-label="No leídos">1</span>

            int tiempo_en_segunds_espera = 60;
            int tiempo_en_minutos = 0;


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
            
            esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            procesos(manejadores, esperar);

        }
        //tabindex="0"
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

                            manejadores.FindElement(By.XPath(elementos_clase)).Click();//clikea el elemento del no leido

                            // texto mensaje que recibio-----------------------------------------------------------------------

                            /*antes se puso haci
                             IWebElement elementoMensaje = esperar.Until(manej3 => manej3.FindElement(By.XPath(elementos2)));
                            string textoDelMensaje = elementoMensaje.Text;
                             */
                            //mejorado
                            string textoDelMensaje = esperar.Until(manej3 => manej3.FindElement(By.XPath(elementos2))).Text;

                            //fin mensaje que resibio--------------------------------------------------------------


                            opciones_a_hacer_y_mandar_mensge(esperar, textoDelMensaje);
                            
                            

                            return true;
                        }
                        else
                        {
                            // Si el elemento no está presente, espera y luego vuelve a intentar
                            Thread.Sleep(2000); // Puedes ajustar el tiempo de espera según tu escenario
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

        public void opciones_a_hacer_y_mandar_mensge(WebDriverWait esperar, string texto, string[] caracter_separacion = null)
        {
            if (caracter_separacion==null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            string[] informacion_espliteada = texto.Split(Convert.ToChar(caracter_separacion[0]));
            string mensaje = "";
            switch (informacion_espliteada[0])
            {
                case "1":
                    mensaje = "prueba 1";
                break;

                default:
                    mensaje = $"Bienvenido {texto} en que puedo ayudarlo?";
                    
                    break;
            }

            mandar_mensage(esperar, mensaje);
        }

        private void mandar_mensage(WebDriverWait esperar,string texto_enviar)
        {
            
            //aqui hacemos que reconosca la barra de texto y escriba
            //html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]

            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath("html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]")));

            escribir_msg.SendKeys(texto_enviar + Keys.Enter);
            escribir_msg.SendKeys(Keys.Escape);
            
        }

        
    }
}
