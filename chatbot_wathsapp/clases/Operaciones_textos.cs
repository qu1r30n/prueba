using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_wathsapp.clases
{
    class Operaciones_textos
    {

        public string ordenar_string_con_caractere_separacion(string texto_a_ordenar, string orden, string caracter_separacion)
        {
            string[] orden_spliteado = orden.Split(Convert.ToChar(caracter_separacion));
            string[] texto_spliteado = texto_a_ordenar.Split(Convert.ToChar(caracter_separacion));
            string texto_a_devolver = "";
            for (int i = 0; i < orden_spliteado.Length; i++)
            {
                if (i < (orden_spliteado.Length - 1))
                {
                    texto_a_devolver = texto_a_devolver + texto_spliteado[Convert.ToInt32(orden_spliteado[i])] + caracter_separacion;
                }
                else
                {
                    texto_a_devolver = texto_a_devolver + texto_spliteado[Convert.ToInt32(orden_spliteado[i])];
                }

            }

            return texto_a_devolver;
        }

        public string cambiar_caracter(string texto, char caracter_a_buscar, char caracter_a_cambiar)
        {
            string[] texto_espliteado = texto.Split(caracter_a_buscar);
            string texto_joineado = string.Join("" + caracter_a_cambiar, texto_espliteado);
            return texto_joineado;
        }

        public string Trimend_paresido(string texto, char caracter_separacion = '|')
        {

            string texto_editado = "";
            string[] texto_spliteado = texto.Split(caracter_separacion);

            if (texto_spliteado[texto_spliteado.Length - 1] == "")
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 2)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion;
                    }
                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 1)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion;
                    }

                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }


            return texto_editado;
        }

        public string join_paresido(char caracter_union_filas, string[] texto, string columna_extraer = null, string caracter_union_columnas = null)
        {
            string resultado = "";
            if (columna_extraer != null)
            {
                char caracter_union_columnas_caracter = Convert.ToChar(caracter_union_columnas);
                for (int i = 0; i < texto.Length; i++)
                {
                    string[] columnas_extraer_arreglo = columna_extraer.Split(caracter_union_columnas_caracter);
                    for (int j = 0; j < columnas_extraer_arreglo.Length; j++)
                    {
                        string[] temp;
                        temp = texto[i].Split(caracter_union_columnas_caracter);
                        resultado = resultado + temp[Convert.ToInt32(columnas_extraer_arreglo[j])] + caracter_union_columnas;

                    }
                    resultado = Trimend_paresido(resultado, caracter_union_columnas_caracter);
                    resultado = resultado + caracter_union_filas;

                }
            }
            else
            {

                for (int i = 0; i < texto.Length; i++)
                {
                    resultado = resultado + texto[i] + caracter_union_filas;
                }
            }
            resultado = Trimend_paresido(resultado, caracter_union_filas);

            return resultado;
        }

        public double cantidad_decimales(double value, int decimales)
        {
            double aux_value = Math.Pow(10, decimales);
            return (Math.Truncate(value * aux_value) / aux_value);
        }

    }
}
