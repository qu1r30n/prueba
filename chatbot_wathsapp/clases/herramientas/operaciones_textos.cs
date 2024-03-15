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

        public string joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(object arreglo_objeto, object caracter_separacion_objeto = null, int restar_cuantas_ultimas_o_primeras_celdas = 0, bool restar_primera_celda = false)
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
                    if (i == 0)
                    {
                        if (arreglo[i] != null)
                        {
                            a_retornar = a_retornar + arreglo[i];
                        }

                    }
                    else
                    {
                        if (arreglo[i] != null)
                        {
                            a_retornar = a_retornar + caracter_separacion[0] + arreglo[i];

                        }

                    }
                }

            }

            else
            {
                if (arreglo != null)
                {
                    int cantidad_celdas_a_retornar_del_arreglo = arreglo.Length - restar_cuantas_ultimas_o_primeras_celdas;
                    for (int i = 0; i < cantidad_celdas_a_retornar_del_arreglo; i++)
                    {
                        if (i == 0)
                        {
                            if (arreglo[i] != null)
                            {
                                a_retornar = a_retornar + arreglo[i];
                            }
                        }
                        else
                        {
                            if (arreglo[i] != null)
                            {
                                a_retornar = a_retornar + caracter_separacion[0] + arreglo[i];
                            }
                        }
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

        public string concatenacion_filas_de_un_archivo(string direccion_archivo, bool poner_num_fila = false, object caracter_separacion_obj = null)
        {

            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);

            int indice_mensage_bienvenida = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion_archivo));
            string mensaje_de_bienvenida_a_enviar = "";
            for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice_mensage_bienvenida].Length; i++)
            {
                string num_fil = "";
                if (poner_num_fila)
                {
                    num_fil = i + ") ";
                }
                mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + Tex_base.GG_base_arreglo_de_arreglos[indice_mensage_bienvenida][i], caracter_separacion[0]);

            }
            return mensaje_de_bienvenida_a_enviar;
        }

        public string concatenacion_filas_de_un_arreglo(string[] arreglo, bool poner_num_fila = false,object caracter_separacion_obj=null)
        {

            string[] caracter_separacion=var_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);

            string mensaje_de_bienvenida_a_enviar = "";
            for (int i = G_donde_inicia_la_tabla; i < arreglo.Length; i++)
            {
                string num_fil = "";
                if (poner_num_fila)
                {
                    num_fil = i + ") ";
                }
                mensaje_de_bienvenida_a_enviar = concatenacion_caracter_separacion(mensaje_de_bienvenida_a_enviar, num_fil + arreglo[i], caracter_separacion[0]);

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

        public string concatenacion_caracter_separacion(string tex_a_cambiar, string tex_a_agregar, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (tex_a_cambiar != "" && tex_a_cambiar != null)
            {
                tex_a_cambiar = tex_a_cambiar + caracter_separacion[0] + tex_a_agregar;
            }
            else
            {
                if (tex_a_cambiar == null)
                {
                    tex_a_cambiar = "";
                }
                tex_a_cambiar = tex_a_cambiar + tex_a_agregar;
            }



            return tex_a_cambiar;



        }


        public string busqueda_con_YY_profunda_texto(string texto, string columnas_a_recorrer, string comparaciones, object caracter_separacion_objeto = null, object caracter_separacion_para_busqueda_multiple_profuda_obj = null)
        {
            operaciones_arreglos op_arr = new operaciones_arreglos();
            //editar_busqueda_multiple_edicion_profunda_arreglo(texto, "2|1|1~2|1|0", "5~9", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string[] caracter_separacion_para_busqueda_multiple_profuda = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_para_busqueda_multiple_profuda_obj);

            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            string[] arr_comparaciones_a_rec = columnas_a_recorrer.Split(caracter_separacion_para_busqueda_multiple_profuda[0][0]);
            string[] arr_comparaciones = comparaciones.Split(caracter_separacion_para_busqueda_multiple_profuda[0][0]);

            


                bool[] chequeo_todas_las_comparaciones = new bool[arr_comparaciones_a_rec.Length];

                string[][] niveles_de_profundidad = null;
                for (int l = 0; l < arr_comparaciones_a_rec.Length; l++)
                {
                    string tem_linea = texto;
                    string[] arr_col_rec = arr_comparaciones_a_rec[l].Split(caracter_separacion[0][0]);



                    if (arr_col_rec.Length > 1)
                    {

                        string temp_opciones_comp = joineada_paraesida_y_quitador_de_extremos_del_string(arr_comparaciones_a_rec[l], restar_cuantas_ultimas_o_primeras_celdas: 1);
                        string[] arr_info = op_arr.extraer_arreglo_dentro_de_un_string(tem_linea, temp_opciones_comp);
                        for (int m = 0; m < arr_info.Length; m++)
                        {
                            string[] elemento_espliteado = arr_info[m].Split(caracter_separacion[arr_col_rec.Length][0]);
                            tem_linea = elemento_espliteado[Convert.ToInt32(arr_col_rec[arr_col_rec.Length - 1])];
                        }

                    }
                    else
                    {
                        niveles_de_profundidad = op_arr.agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[0][0]));
                        tem_linea = niveles_de_profundidad[0][Convert.ToInt32(arr_col_rec[0])];
                    }
                    string tem_linea_2 = "";
                    //comparacion--------------------------------------------------------------------------
                    chequeo_todas_las_comparaciones[l] = false;
                    if (tem_linea == arr_comparaciones[l])
                    {
                        chequeo_todas_las_comparaciones[l] = true;


                    }

                }
                bool estan_todas_las_comparaciones = true;
                for (int m = 0; m < chequeo_todas_las_comparaciones.Length; m++)
                {
                    if (chequeo_todas_las_comparaciones[m] == false)
                    {
                        estan_todas_las_comparaciones = false;
                        break;
                    }
                }
                if (estan_todas_las_comparaciones)
                {


                    return texto;
                }
            


            return null;

        }

        

    }
}