using System;
using System.Linq;

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
                if (arreglo.Length <= 1)
                {
                    char[] arreglo_letras = arreglo_objeto.ToString().ToCharArray();
                    arreglo = new string[arreglo_letras.Length];
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        arreglo[i] = "" + arreglo_letras[i];
                    };
                    
                    
                }
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

        public string concatenacion_filas_de_un_archivo(string direccion_archivo,bool poner_num_fila=false)
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
                mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + Tex_base.GG_base_arreglo_de_arreglos[indice_mensage_bienvenida][i], '\n');

            }
            return mensaje_de_bienvenida_a_enviar;
        }

        public string concatenacion_filas_de_un_arreglo(string[] arreglo, bool poner_num_fila = false)
        {



            string mensaje_de_bienvenida_a_enviar = "";
            for (int i = G_donde_inicia_la_tabla; i < arreglo.Length; i++)
            {
                string num_fil = "";
                if (poner_num_fila)
                {
                    num_fil = i + ") ";
                }
                mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + arreglo[i], '\n');

            }
            return mensaje_de_bienvenida_a_enviar;
        }

        public string concatenacion_filas_de_un_arreglo_bidimencional(string[,] arreglo, bool poner_num_fila = false, object caracter_separacion_obj = null)
        {
            


            string mensaje_de_bienvenida_a_enviar = "";
            
            for (int i = 0; i < arreglo.GetLength(0); i++)
            {
                string tiene_informacion = arreglo[i, 0];
                if (tiene_informacion != null)
                {
                    string concatenado = "";
                    for (int j = 0; j < arreglo.GetLength(1); j++)
                    {
                        
                            concatenado = concatenacion_caracter_separacion(concatenado, arreglo[i, j], caracter_separacion_obj);

                    }


                    string num_fil = "";
                    if (poner_num_fila)
                    {
                        num_fil = i + ") ";
                    }
                    mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + concatenado, '\n');
                }

            }
            return mensaje_de_bienvenida_a_enviar;
        }

        public string concatenacion_caracter_separacion(string tex_a_cambiar, string tex_a_agregar,  object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            
                if (tex_a_cambiar!="")
                {
                    tex_a_cambiar = tex_a_cambiar + caracter_separacion[0] + tex_a_agregar;
                }
                else
                {
                    tex_a_cambiar = tex_a_cambiar + tex_a_agregar;
                }
            
            

            return tex_a_cambiar;
        }


    }
}
