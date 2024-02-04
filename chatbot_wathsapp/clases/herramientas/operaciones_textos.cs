using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using chatbot_wathsapp.clases.herramientas;

namespace chatbot_wathsapp.clases.herramientas
{
    class operaciones_textos
    {
        Tex_base bas = new Tex_base();
        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;
        var_fun_GG var_GG = new var_fun_GG();

        public string joineada_paraesida_y_quitador_de_extremos_del_string(object arreglo_objeto, object caracter_separacion_objeto = null, int restar_cuantas_ultimas_o_primeras_celdas = 0, bool restar_primera_celda = false)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            string[] arreglo = null;

            if (arreglo_objeto is string)
            {
                arreglo = arreglo_objeto.ToString().Split(caracter_separacion[0][0]);
            }
            else if (arreglo_objeto is string[])
            {
                arreglo = (string[])arreglo_objeto;
            }


            string a_retornar = "";

            if (restar_primera_celda)
            {
                for (int i = restar_cuantas_ultimas_o_primeras_celdas; i < arreglo.Length; i++)
                {
                    if (i < arreglo.Length - 1)
                    {
                        a_retornar = a_retornar + arreglo[i] + caracter_separacion[0];
                    }
                    else
                    {
                        a_retornar = a_retornar + arreglo[i];
                    }
                }

            }
            else
            {
                int cantidad_celdas_a_retornar_del_arreglo = arreglo.Length - restar_cuantas_ultimas_o_primeras_celdas;
                for (int i = 0; i < cantidad_celdas_a_retornar_del_arreglo; i++)
                {
                    if (i < cantidad_celdas_a_retornar_del_arreglo - 1)
                    {
                        a_retornar = a_retornar + arreglo[i] + caracter_separacion[0];
                    }
                    else
                    {
                        a_retornar = a_retornar + arreglo[i];
                    }
                }
            }

            return a_retornar;
        }

        public string Trimend_paresido(string texto, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string texto_editado = "";
            string[] texto_spliteado = texto.Split(caracter_separacion[0][0]);

            if (texto_spliteado[texto_spliteado.Length - 1] == "")
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 2)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion[0];
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
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion[0];
                    }

                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }


            return texto_editado;
        }

        public string concatenacion_caracter_separacion_dentro_de_un_for_1(string direccion_archivo,bool poner_num_fila=false)
        {
            

            int indice_mensage_bienvenida = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo));
            string mensaje_de_bienvenida_a_enviar = "";
            for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice_mensage_bienvenida].Length; i++)
            {
                string num_fil = "";
                if (poner_num_fila)
                {
                    num_fil = i + ") ";
                }
                mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion_dentro_de_un_for_2(mensaje_de_bienvenida_a_enviar, num_fil + Tex_base.GG_base_arreglo_de_arreglos[indice_mensage_bienvenida][i], i, Tex_base.GG_base_arreglo_de_arreglos[indice_mensage_bienvenida].Length, '\n');

            }
            return mensaje_de_bienvenida_a_enviar;
        }
        public string concatenacion_caracter_separacion_dentro_de_un_for_2(string tex_a_cambiar, string tex_a_agregar, int ciclo_en_el_que_esta, int ultimo_ciclo_Length, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (ciclo_en_el_que_esta < ultimo_ciclo_Length) 
            {
                tex_a_cambiar = tex_a_cambiar + tex_a_agregar + caracter_separacion[0];
            }
            else
            {
                tex_a_cambiar = tex_a_cambiar + tex_a_agregar;
            }
            return tex_a_cambiar;
        }

    }
}
