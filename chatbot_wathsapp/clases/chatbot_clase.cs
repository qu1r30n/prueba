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
        

        public void inicio()
        {
            string G_pagina = "https://web.whatsapp.com/";
            //<span class="l7jjieqr cfzgl7ar ei5e7seu h0viaqh7 tpmajp1w c0uhu3dl riy2oczp dsh4tgtl sy6s5v3r gz7w46tb lyutrhe2 qfejxiq4 fewfhwl7 ovhn1urg ap18qm3b ikwl5qvt j90th5db aumms1qt"
            //aria-label="No leídos">1</span>
            string G_elementos = "//span[contains(@aria-label, 'No leídos') or contains(@aria-label, 'No leído')]";
            string G_elementos_clase = G_elementos + "//ancestor::div[@class='_8nE1Y']";
            int G_tiempo_en_segunds_espera = 40;
            int G_tiempo_en_minutos = 0;


            //damos algunas opciones para iniciar el chomer
            var opciones = new ChromeOptions();
            opciones.AddArguments("--start-maximized");
            opciones.AddExcludedArgument("enable-automation");

            //declaramos el elemento manejadores
            var manejadores = new ChromeDriver(opciones);
            manejadores.Navigate().GoToUrl(G_pagina);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(G_tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            Thread.Sleep(G_tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera
            esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej => manej.FindElement(By.XPath(G_elementos)));

            manejadores.FindElement(By.XPath(G_elementos_clase)).Click();

            //aqui hacemos que reconosca la barra de texto y escriba
            //html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]

            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath("html/body/div[1]/div/div/div[5]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]")));
            escribir_msg.SendKeys("que onda" + Keys.Enter);
        }
    }
}
