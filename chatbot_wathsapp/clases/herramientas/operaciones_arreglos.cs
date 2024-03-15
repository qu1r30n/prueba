using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace chatbot_wathsapp.clases.herramientas
{
    class operaciones_arreglos
    {

        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_caracter_separacion_para_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;



        var_fun_GG var_GG = new var_fun_GG();
        public string[] agregar_registro_del_array(string[] arreglo, string registro, string al_inicio = null)
        {
            if (arreglo == null)
            {
                // Si el arreglo es null, se crea un nuevo arreglo con un solo elemento que es el registro proporcionado.
                return new string[] { registro };
            }
            else
            {
                string[] temp = new string[arreglo.Length + 1];
                if (al_inicio == null)
                {
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        temp[i] = arreglo[i];
                    }

                    temp[arreglo.Length] = registro;

                }
                else
                {
                    temp[0] = registro;
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        temp[i + 1] = arreglo[i];
                    }

                }

                return temp;
            }


        }

        public string[,] agregar_registro_del_array_bidimensional(string[,] arreglo, string registro, object caracter_separacion_objeto = null, string al_inicio = null)
        {

            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            if (arreglo == null)
            {
                // Si el arreglo es null, crear un nuevo arreglo bidimensional con un solo elemento que es el registro proporcionado.

                // Dividir el registro usando el carácter de separación
                string[] partes = registro.Split(caracter_separacion[0][0]);

                // Crear un nuevo arreglo bidimensional con una fila y la longitud de partes
                string[,] temp = new string[1, partes.Length];

                // Copiar los elementos del arreglo unidimensional al arreglo bidimensional
                for (int i = 0; i < partes.Length; i++)
                {
                    temp[0, i] = partes[i];
                }

                return temp;
            }

            else
            {
                int filas = arreglo.GetLength(0);
                int columnas = arreglo.GetLength(1);

                string[,] temp = new string[filas + 1, columnas];

                if (al_inicio == null)
                {
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            temp[i, j] = arreglo[i, j];
                        }
                    }

                    // Dividir el nuevo registro usando el carácter de separación
                    string[] partes = registro.Split(caracter_separacion[0][0]);

                    // Agregar el nuevo registro en la última fila
                    for (int j = 0; j < partes.Length; j++)
                    {
                        temp[filas, j] = partes[j];
                    }
                }
                else
                {
                    // Agregar el nuevo registro en la primera fila
                    temp[0, 0] = registro;

                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            // Desplazar los elementos existentes hacia abajo
                            temp[i + 1, j] = arreglo[i, j];
                        }
                    }
                }

                return temp;
            }
        }



        /*
        public string[][] agregar_arreglo_a_arreglo_de_arreglos(string[][] arreglo_de_arreglos, string[] nuevo_arreglo)
        {
            string[][] temp = new string[arreglo_de_arreglos.Length + 1][];

            for (int i = 0; i < arreglo_de_arreglos.Length; i++)
            {
                temp[i] = arreglo_de_arreglos[i];
            }

            temp[arreglo_de_arreglos.Length] = nuevo_arreglo;

            return temp;
        }
        */
        public string[][] agregar_arreglo_a_arreglo_de_arreglos(string[][] arreglo_de_arreglos, string[] nuevo_arreglo)
        {
            if (arreglo_de_arreglos == null)
            {
                // Si el arreglo de arreglos es null, se crea un nuevo arreglo de arreglos con un solo elemento.
                return new string[][] { nuevo_arreglo };
            }

            string[][] temp = new string[arreglo_de_arreglos.Length + 1][];
            Array.Copy(arreglo_de_arreglos, temp, arreglo_de_arreglos.Length);
            temp[arreglo_de_arreglos.Length] = nuevo_arreglo;
            return temp;
        }





        public string[] quitar_registro_del_array(string[] arreglo, int cantidad_a_quitar = 1, bool quitar_del_inicio = false)
        {
            if (arreglo.Length <= 1)
            {
                // No hay elementos para quitar, devolver un array vacío o el mismo array
                return null;
            }
            string[] temp = new string[arreglo.Length - cantidad_a_quitar];
            if (quitar_del_inicio)
            {


                for (int i = cantidad_a_quitar; i < arreglo.Length; i++)
                {
                    temp[i - 1] = arreglo[i];
                }
            }
            else
            {

                for (int i = 0; i < arreglo.Length - cantidad_a_quitar; i++)
                {
                    temp[i - 1] = arreglo[i];
                }
            }



            return temp;
        }

        public string busqueda_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparar, string columnas_a_retornar = null, object caracter_separacion_objeto = null, int donde_iniciar = 0)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);



            string[] arr_col_rec = null;
            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(caracter_separacion[0][0]);

            for (int i = donde_iniciar; i < areglo.Length; i++)
            {

                string tem_linea = areglo[i];
                string[][] niveles_de_profundidad = null;
                int j = 0;
                do
                {

                    //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                    niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[j][0]));
                    tem_linea = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                    j++;
                } while (j < arr_col_rec.Length);

                string tem_linea_2 = "";
                //comparacion--------------------------------------------------------------------------
                if (tem_linea == comparar)
                {
                    if (columnas_a_retornar == null)
                    {
                        return areglo[i];
                    }
                    else
                    {

                        string[] info_a_recorrer = columnas_a_retornar.Split(caracter_separacion[0][0]);
                        for (int l = 0; l < info_a_recorrer.Length; l++)
                        {
                            tem_linea_2 = info_a_recorrer[l];
                            string[][] niveles_de_profundidad_2 = null;
                            int k = 1;
                            do
                            {

                                //caracter_separacion[k][0] el primer [k] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                                niveles_de_profundidad_2 = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad_2, tem_linea_2.Split(caracter_separacion[k][0]));
                                tem_linea_2 = niveles_de_profundidad_2[k][Convert.ToInt32(arr_col_rec[k])];

                                k++;
                            } while (k < arr_col_rec.Length);

                        }

                        return tem_linea_2;
                    }

                }

            }
            return null;
        }


        //se le pone yy en referencia a &&
        public string busqueda_con_YY_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparaciones, object caracter_separacion_objeto = null, object caracter_separacion_para_busqueda_multiple_profuda_obj = null)
        {
            operaciones_textos op_tex = new operaciones_textos();
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1~2|1|0", "5~9", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string[] caracter_separacion_para_busqueda_multiple_profuda = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_para_busqueda_multiple_profuda_obj);

            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            string[] arr_comparaciones_a_rec = columnas_a_recorrer.Split(caracter_separacion_para_busqueda_multiple_profuda[0][0]);
            string[] arr_comparaciones = comparaciones.Split(caracter_separacion_para_busqueda_multiple_profuda[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {


                bool[] chequeo_todas_las_comparaciones = new bool[arr_comparaciones_a_rec.Length];

                string[][] niveles_de_profundidad = null;
                for (int l = 0; l < arr_comparaciones_a_rec.Length; l++)
                {
                    string tem_linea = areglo[i];
                    string[] arr_col_rec = arr_comparaciones_a_rec[l].Split(caracter_separacion[0][0]);



                    if (arr_col_rec.Length > 1)
                    {

                        string temp_opciones_comp = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(arr_comparaciones_a_rec[l], restar_cuantas_ultimas_o_primeras_celdas: 1);
                        string[] arr_info = extraer_arreglo_dentro_de_un_string(tem_linea, temp_opciones_comp);
                        for (int m = 0; m < arr_info.Length; m++)
                        {
                            string[] elemento_espliteado = arr_info[m].Split(caracter_separacion[arr_col_rec.Length][0]);
                            tem_linea = elemento_espliteado[Convert.ToInt32(arr_col_rec[arr_col_rec.Length - 1])];
                        }

                    }
                    else
                    {
                        niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[0][0]));
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


                    return areglo[i];
                }
            }


            return null;

        }

        //se le pone OO en referencia a ||
        public string busqueda_con_OO_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparaciones, object caracter_separacion_objeto = null, object caracter_separacion_para_busqueda_multiple_profuda_obj = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1~2|1|0", "5~9", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string[] caracter_separacion_para_busqueda_multiple_profuda = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_para_busqueda_multiple_profuda_obj);

            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            string[] arr_comparaciones_a_rec = columnas_a_recorrer.Split(caracter_separacion_para_busqueda_multiple_profuda[0][0]);
            string[] arr_comparaciones = comparaciones.Split(caracter_separacion_para_busqueda_multiple_profuda[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {
                string tem_linea = areglo[i];

                bool[] chequeo_todas_las_comparaciones = new bool[arr_comparaciones_a_rec.Length];

                for (int l = 0; l < arr_comparaciones_a_rec.Length; l++)
                {

                    string[] arr_col_rec = arr_comparaciones_a_rec[l].Split(caracter_separacion[0][0]);

                    string[][] niveles_de_profundidad = null;
                    int j = 0;
                    do
                    {

                        //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                        niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[j][0]));
                        tem_linea = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                        j++;
                    } while (j < arr_col_rec.Length);

                    string tem_linea_2 = "";
                    //comparacion--------------------------------------------------------------------------
                    chequeo_todas_las_comparaciones[l] = false;
                    if (tem_linea == arr_comparaciones[l])
                    {
                        chequeo_todas_las_comparaciones[l] = true;


                    }

                }
                bool estan_una_comparacion = false;
                for (int m = 0; m < chequeo_todas_las_comparaciones.Length; m++)
                {
                    if (chequeo_todas_las_comparaciones[m] == true)
                    {
                        estan_una_comparacion = true;
                        break;
                    }
                }
                if (estan_una_comparacion)
                {

                    return areglo[i];
                }
            }


            return null;

        }


        public string editar_incr_string_funcion_recursiva(string texto, object columnas_a_recorrer, string info_a_sustituir, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_dif_a_texto = null)
        {
            //string texto="0|1|2¬3°4¬5|6", object columnas_a_recorrer="2°1°1", string info_a_sustituir="10", string edit_0_o_increm_1 = "1",  string[] caracter_separacion = null, string caracter_separacion_dif_a_texto = "°"

            /*ejemplo puesto
                    string[] indices_espliteado = indices_a_editar.Split(caracter_separacion[0][0]);
                    string[] info_editar_espliteado = info_editar.Split(caracter_separacion[0][0]);
                    string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracter_separacion[0][0]);
                    for (int k = 0; k < indices_espliteado.Length; k++)
                    {
                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_dif_a_texto:"°");
                    }
            
            */
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string[] espliteado_columnas_recorrer = { };

            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                if (caracter_separacion_dif_a_texto == null)
                {
                    espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(caracter_separacion[0][0]);

                }
                else
                {
                    espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(caracter_separacion_dif_a_texto[0]);
                }

            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }

            string[] espliteado_texto = texto.Split(caracter_separacion[0][0]);

            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            string texto_a_retornar = "";

            string[] tem_array_caracter_separacion = caracter_separacion;
            if (espliteado_columnas_recorrer.Length > 0)
            {
                string[] tem_array_col_recorrer = espliteado_columnas_recorrer;
                //espliteado_texto = texto.Split(Convert.ToChar(tem_array_caracter_separacion[0]));
                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                tem_array_caracter_separacion = new string[caracter_separacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {

                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];

                }
                for (int i = 1; i < caracter_separacion.Length; i++)
                {
                    tem_array_caracter_separacion[i - 1] = caracter_separacion[i];
                }


                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[0])] = editar_incr_string_funcion_recursiva(texto_a_retornar, tem_array_col_recorrer, info_a_sustituir, edit_0_o_increm_1, tem_array_caracter_separacion); // Llamada recursiva


            }
            else
            {
                if (edit_0_o_increm_1 == "1")
                {
                    espliteado_texto[0] = "" + (Convert.ToDouble(espliteado_texto[0]) + Convert.ToDouble(info_a_sustituir));
                }
                else
                {
                    espliteado_texto[0] = info_a_sustituir;
                }

            }

            string retornar = string.Join(caracter_separacion[0], espliteado_texto);
            return retornar;
        }



        public string[] editar_busqueda_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparar, object columnas_a_recorrer_editar, string info_a_sustituir, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);


            string[] arr_col_rec = null;
            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(caracter_separacion[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {

                string tem_linea = areglo[i];
                string[][] niveles_de_profundidad = null;
                int j = 0;
                do
                {

                    //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                    niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[j][0]));
                    tem_linea = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                    j++;
                } while (j < arr_col_rec.Length);

                string tem_linea_2 = "";
                //compa
                //racion--------------------------------------------------------------------------
                if (tem_linea == comparar)
                {
                    areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], columnas_a_recorrer_editar, info_a_sustituir);
                    return areglo;
                }

            }
            return null;
        }


        public string[] editar_inc_busqueda_multiple_edicion_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparaciones, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1", "5", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (caracter_separacion_para_busqueda_multiple_profuda == null)
            {
                caracter_separacion_para_busqueda_multiple_profuda = G_caracter_separacion_para_funciones_espesificas[0];
            }



            //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            string[] arr_col_rec = columnas_a_recorrer.Split(caracter_separacion[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {

                string tem_linea = areglo[i];
                string[][] niveles_de_profundidad = null;
                int j = 0;
                do
                {

                    //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                    niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[j][0]));
                    tem_linea = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                    j++;
                } while (j < arr_col_rec.Length);

                string tem_linea_2 = "";
                //comparacion--------------------------------------------------------------------------
                if (tem_linea == comparaciones)
                {


                    string[] indices_espliteado = indices_a_editar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                    string[] info_editar_espliteado = info_editar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                    string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                    for (int k = 0; k < indices_espliteado.Length; k++)
                    {
                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_dif_a_texto: caracter_separacion_para_busqueda_multiple_profuda);
                    }

                    return areglo;
                }

            }


            return null;

        }



        public object si_no_existe_agrega_string(string[] areglo, string columnas_a_recorrer, string comparar, string texto_a_agregar)
        {
            //retorna objet porque retoran un string del buscado y si no lo encuentra retorna un arreglo del agregado
            if (areglo != null)
            {


                string info_encontrada = busqueda_profunda_arreglo(areglo, columnas_a_recorrer, comparar);
                if (info_encontrada != null)
                {
                    return info_encontrada;
                }
                else
                {
                    areglo = agregar_registro_del_array(areglo, texto_a_agregar);
                    return areglo;
                }
            }
            else
            {
                areglo = agregar_registro_del_array(areglo, texto_a_agregar);
                return areglo;
            }
        }

        public object si_arreglo_es_null_agrega_texto_si_no_agrega_texto_a_columna_seleccionada(string[] arreglo, string texto_a_agregar_si_arreglo_es_nulo, string texto_a_agregar, string columnas_agregar, object caracter_separacion_obj = null)
        {
            operaciones_textos op_tex = new operaciones_textos();
            operaciones_arreglos op_arr = new operaciones_arreglos();
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            //retorna objet porque retoran un string del buscado y si no lo encuentra retorna un arreglo del agregado
            if (arreglo != null)
            {



                for (int i = 0; i < arreglo.Length; i++)
                {
                    string[] elemento_espliteado = arreglo[i].Split(caracter_separacion[0][0]);



                    elemento_espliteado[Convert.ToInt32(columnas_agregar)] = op_tex.concatenacion_caracter_separacion(elemento_espliteado[Convert.ToInt32(columnas_agregar)], texto_a_agregar, caracter_separacion[1]);





                    arreglo[i] = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(elemento_espliteado, caracter_separacion[0]);
                    return arreglo;
                }

            }

            else
            {
                arreglo = agregar_registro_del_array(arreglo, texto_a_agregar_si_arreglo_es_nulo);
                return arreglo;
            }
            return null;
        }

        public string[] si_existe_edita_o_incrementa_si_no_agrega_string(string[] arreglo, string columnas_a_recorrer, string comparar, string texto_a_agregar, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda = null)
        {


            object encontrado = si_no_existe_agrega_string(arreglo, columnas_a_recorrer, comparar, texto_a_agregar);
            string[] arreglo_a_retornar = null;
            if (encontrado is string)
            {
                arreglo_a_retornar = editar_inc_busqueda_multiple_edicion_profunda_arreglo(arreglo, columnas_a_recorrer, comparar, indices_a_editar, info_editar, edit_0_o_increm_1, caracter_separacion_objeto, caracter_separacion_para_busqueda_multiple_profuda);

            }
            else if (encontrado is string[])
            {
                arreglo_a_retornar = (string[])encontrado;
            }

            return arreglo_a_retornar;

        }


        public string[] agrega_textos_a_columna(string[] arreglo, string texto_a_agregar_si_es_nulo_el_arreglo, string texto_a_agregar, string columnas_agregar, object caracter_separacion_objeto = null)
        {

            string[] arreglo_a_retornar = null;
            object encontrado = si_arreglo_es_null_agrega_texto_si_no_agrega_texto_a_columna_seleccionada(arreglo, texto_a_agregar_si_es_nulo_el_arreglo, texto_a_agregar, columnas_agregar, caracter_separacion_objeto);


            arreglo_a_retornar = (string[])encontrado;

            return arreglo_a_retornar;

        }



        public string[] busqueda_multiple_edicion_multiple_arreglo_profunda(string[] areglo, string columnas_a_recorrer, string comparar, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1~2|1|1~2|1|1", "5~5~5", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (caracter_separacion_para_busqueda_multiple_profuda == null)
            {
                caracter_separacion_para_busqueda_multiple_profuda = G_caracter_separacion_para_funciones_espesificas[0];
            }
            string[] comparar_espliteado = comparar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);

            string[] arr_column_a_recorrer = columnas_a_recorrer.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
            for (int j = 0; j < arr_column_a_recorrer.Length; j++)
            {
                //caracter_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                string[] col_rec_espliteado = arr_column_a_recorrer[j].Split(caracter_separacion[0][0]);

                for (int i = 0; i < areglo.Length; i++)
                {

                    string tem_linea = areglo[i];
                    string[][] niveles_de_profundidad = null;
                    int h = 0;
                    do
                    {

                        //caracter_separacion[h][0] el primer [h] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                        niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracter_separacion[h][0]));
                        tem_linea = niveles_de_profundidad[h][Convert.ToInt32(col_rec_espliteado[h])];

                        h++;
                    } while (h < col_rec_espliteado.Length);

                    string tem_linea_2 = "";
                    //comparacion--------------------------------------------------------------------------

                    if (tem_linea == comparar_espliteado[j])
                    {

                        string[] indices_espliteado = indices_a_editar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                        string[] info_editar_espliteado = info_editar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                        string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);

                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[j], info_editar_espliteado[j], edit_0_o_increm_1_espliteado[j]);



                    }

                }

            }

            return areglo;
        }

        public string[] convierte_objeto_a_arreglo(object texto_enviar_arreglo_objeto, string caracter_de_separacion_si_es_string = null)
        {
            string[] texto_enviar_arreglo_string = null;
            if (texto_enviar_arreglo_objeto == null)
            {
                texto_enviar_arreglo_string = new[] { "" };
            }
            else
            {
                if (texto_enviar_arreglo_objeto is char)
                {
                    texto_enviar_arreglo_string = new string[] { texto_enviar_arreglo_objeto + "" };
                }
                if (texto_enviar_arreglo_objeto is string)
                {
                    if (caracter_de_separacion_si_es_string == null)
                    {
                        texto_enviar_arreglo_string = texto_enviar_arreglo_objeto.ToString().Split(G_caracter_separacion_para_funciones_espesificas[2][0]);
                    }
                    else
                    {
                        texto_enviar_arreglo_string = texto_enviar_arreglo_objeto.ToString().Split(caracter_de_separacion_si_es_string[0]);
                    }

                }
                if (texto_enviar_arreglo_objeto is string[])
                {
                    texto_enviar_arreglo_string = (string[])texto_enviar_arreglo_objeto;
                }
            }

            return texto_enviar_arreglo_string;
        }

        public string[] que_elementos_se_encuentra_dentro_de_un_arreglo(string[] arreglo_en_el_que_se_buscara, object elememntos_buscar, string caracter_de_separacion_si_es_string = null)
        {
            string[] elementoas_a_buscar_arreglo = convierte_objeto_a_arreglo(elememntos_buscar, caracter_de_separacion_si_es_string);
            string[] arreglo_a_devolver = null;
            for (int i = 0; i < elementoas_a_buscar_arreglo.Length; i++)
            {
                for (int j = 0; j < arreglo_en_el_que_se_buscara.Length; j++)
                {
                    if (arreglo_en_el_que_se_buscara[i] == arreglo_en_el_que_se_buscara[j])
                    {
                        arreglo_a_devolver = agregar_registro_del_array(arreglo_a_devolver, arreglo_en_el_que_se_buscara[i]);
                    }
                }
            }


            return arreglo_a_devolver;
        }


        public string join_para_bidimensional(string[,] arregloBidimensional, string separador = null, string separador2 = null)
        {
            operaciones_textos op_tex = new operaciones_textos();
            if (separador == null)
            {
                separador = G_caracter_separacion[1];
            }
            if (separador2 == null)
            {
                separador2 = G_caracter_separacion[2];
            }
            int filas = arregloBidimensional.GetLength(0);
            int columnas = arregloBidimensional.GetLength(1);

            string[] filasUnidimensionales = null;

            for (int i = 0; i < filas; i++)
            {
                string[] filaActual = new string[columnas];
                bool estan_sin_nulo = true;
                for (int j = 0; j < columnas; j++)
                {
                    filaActual[j] = arregloBidimensional[i, j];
                    if (arregloBidimensional[i, j] == null)
                    {
                        estan_sin_nulo = false;
                        break;
                    }
                }
                if (estan_sin_nulo)
                {
                    filasUnidimensionales = agregar_registro_del_array(filasUnidimensionales, string.Join(separador, filaActual));

                }

            }
            return op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(filasUnidimensionales, separador2);

        }

        public string[][] si_el_multiarreglo_no_tiene_la_cantidad_de_arreglos_se_le_agrega(string[][] arreglo, int cantidad_arreglos_de_arreglos)
        {
            if (arreglo == null) { arreglo = new string[1][]; }

            if (cantidad_arreglos_de_arreglos > arreglo.Length)
            {
                string[][] arreglo_a_retornar = new string[cantidad_arreglos_de_arreglos][];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo_a_retornar[i] = arreglo[i];

                }
                return arreglo_a_retornar;
            }
            return arreglo;
        }

        public string[] extraer_arreglo_dentro_de_un_string(string linea_con_arreglo_dentro, string columnas_a_recorrer = null, object caracteres_separacion_obj = null)
        {
            string[] caracteres_separacion = var_GG.GG_funcion_caracter_separacion(caracteres_separacion_obj);

            string[] arr_col_rec = columnas_a_recorrer.Split(caracteres_separacion[0][0]);

            int j = 0;
            string[][] niveles_de_profundidad = null;
            do
            {

                //caracter_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, linea_con_arreglo_dentro.Split(caracteres_separacion[j][0]));
                linea_con_arreglo_dentro = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                j++;

            } while (j < arr_col_rec.Length);
            string[] arreglo_a_retoranar = linea_con_arreglo_dentro.Split(caracteres_separacion[j][0]);
            return arreglo_a_retoranar;
        }


        public string[,] suma_elementos_iguales_dentro_de_un_arreglo_retorna_un_bidimencional(string[] arreglo_entrada, object caracter_separacion_func_esp_obj = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_func_esp_obj);
            string[] arreglo = new string[arreglo_entrada.Length];
            Array.Copy(arreglo_entrada, arreglo, arreglo_entrada.Length);

            string[,] arreglo_a_retornar = null;
            string[,] cantidad_de_elementos = new string[arreglo.Length, 2];
            if (arreglo.Length > 1)
            {


                for (int i = 0; i < arreglo.Length; i++)
                {
                    int cont = 0;
                    for (int j = i + 1; j < arreglo.Length; j++)
                    {
                        if (arreglo[i] != null && arreglo[j] != null)
                        {
                            if (arreglo[i] == arreglo[j])
                            {
                                cantidad_de_elementos[i, 0] = arreglo[i];
                                cantidad_de_elementos[i, 1] = "" + (Convert.ToInt32(cantidad_de_elementos[i, 1]) + 1);
                                arreglo[j] = null;
                                if (cont == 0)
                                {
                                    cantidad_de_elementos[i, 1] = "" + (Convert.ToInt32(cantidad_de_elementos[i, 1]) + 1);
                                    cont++;
                                }


                            }
                        }

                    }

                }
                string sin_nulos = join_para_bidimensional(cantidad_de_elementos, G_caracter_separacion_para_funciones_espesificas[1], G_caracter_separacion_para_funciones_espesificas[0]);
                string[] arr1 = sin_nulos.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
                string[] arr2 = arr1[0].Split(G_caracter_separacion_para_funciones_espesificas[1][0]);
                arreglo_a_retornar = new string[arr1.Length, arr2.Length];
                for (int i = 0; i < arr1.Length; i++)
                {
                    arr2 = arr1[i].Split(G_caracter_separacion_para_funciones_espesificas[1][0]);
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        arreglo_a_retornar[i, j] = arr2[j];

                    }
                }
            }
            else
            {
                cantidad_de_elementos[0, 0] = arreglo[0];
                cantidad_de_elementos[0, 1] = "1";
                arreglo_a_retornar = new string[,] { { cantidad_de_elementos[0, 0], cantidad_de_elementos[0, 1] } };
            }
            return arreglo_a_retornar;
        }

        public string suma_elementos_iguales_dentro_de_un_arreglo_retorna_un_string_al_final_de_cada_elemento(string[] arreglo_entrada, object caracter_separacion_obj = null, object caracter_separacion_func_esp_obj = null)
        {

            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string[] caracter_separacion_funciones_esp = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_func_esp_obj);
            string[] arreglo = new string[arreglo_entrada.Length];
            Array.Copy(arreglo_entrada, arreglo, arreglo_entrada.Length);

            string[,] arreglo_a_retornar = null;
            string[,] cantidad_de_elementos = new string[arreglo.Length, 2];
            if (arreglo.Length > 1)
            {


                for (int i = 0; i < arreglo.Length; i++)
                {
                    int cont = 0;
                    for (int j = i + 1; j < arreglo.Length; j++)
                    {
                        if (arreglo[i] != null && arreglo[j] != null)
                        {
                            if (arreglo[i] == arreglo[j])
                            {
                                cantidad_de_elementos[i, 0] = arreglo[i];
                                cantidad_de_elementos[i, 1] = "" + (Convert.ToInt32(cantidad_de_elementos[i, 1]) + 1);
                                arreglo[j] = null;
                                if (cont == 0)
                                {
                                    cantidad_de_elementos[i, 1] = "1";
                                    cont = 1;
                                }


                            }
                            if (cont == 0 && arreglo[i] != null)
                            {
                                cantidad_de_elementos[i, 0] = arreglo[i];
                                cantidad_de_elementos[i, 1] = "1";
                                cont = 1;
                            }
                        }

                    }

                    if (cont == 0 && arreglo[i] != null)
                    {
                        cantidad_de_elementos[i, 0] = arreglo[i];
                        cantidad_de_elementos[i, 1] = "1";
                        cont = 1;
                    }

                }
                string sin_nulos = join_para_bidimensional(cantidad_de_elementos, caracter_separacion_funciones_esp[1], caracter_separacion_funciones_esp[0]);
                string[] arr1 = sin_nulos.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
                string[] arr2 = arr1[0].Split(G_caracter_separacion_para_funciones_espesificas[1][0]);
                arreglo_a_retornar = new string[arr1.Length, arr2.Length];
                for (int i = 0; i < arr1.Length; i++)
                {
                    arr2 = arr1[i].Split(G_caracter_separacion_para_funciones_espesificas[1][0]);
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        arreglo_a_retornar[i, j] = arr2[j];

                    }
                }
            }
            else
            {
                cantidad_de_elementos[0, 0] = arreglo[0];
                cantidad_de_elementos[0, 1] = "1";
                arreglo_a_retornar = new string[,] { { cantidad_de_elementos[0, 0], cantidad_de_elementos[0, 1] } };
            }
            string info_a_devolver = join_para_bidimensional(arreglo_a_retornar, caracter_separacion[1], caracter_separacion[0]);
            return info_a_devolver;
        }

        public string[] suma_elementos_iguales_dentro_de_un_arreglo_retorna_un_arreglo_y_al_final_de_cada_elemento_el_elmento_sumado(string[] arreglo_entrada, object caracter_separacion_obj = null, object caracter_separacion_func_esp_obj = null)
        {

            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_obj);
            string[] caracter_separacion_funciones_esp = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_func_esp_obj);
            string[] arreglo = new string[arreglo_entrada.Length];
            Array.Copy(arreglo_entrada, arreglo, arreglo_entrada.Length);

            string[,] arreglo_bidimencional_a_retornar = null;
            string[,] cantidad_de_elementos = new string[arreglo.Length, 2];
            if (arreglo.Length > 1)
            {


                for (int i = 0; i < arreglo.Length; i++)
                {
                    int cont = 0;
                    for (int j = i + 1; j < arreglo.Length; j++)
                    {
                        if (arreglo[i] != null && arreglo[j] != null)
                        {
                            if (arreglo[i] == arreglo[j])
                            {
                                cantidad_de_elementos[i, 0] = arreglo[i];
                                cantidad_de_elementos[i, 1] = "" + (Convert.ToInt32(cantidad_de_elementos[i, 1]) + 1);
                                arreglo[j] = null;
                                if (cont == 0)
                                {
                                    cantidad_de_elementos[i, 1] = "1";
                                    cont++;
                                }


                            }
                            else
                            {
                                cantidad_de_elementos[i, 0] = arreglo[i];
                                cantidad_de_elementos[i, 1] = "1";
                                if (cont == 0)
                                {
                                    cont = 1; 
                                }
                            }
                        }

                    }

                    if (cont == 0 && arreglo[i] != null)
                    {
                        cantidad_de_elementos[i, 0] = arreglo[i];
                        cantidad_de_elementos[i, 1] = "1";
                        if (cont == 0)
                        {
                            cont = 1;
                        }
                    }

                }
                string sin_nulos = join_para_bidimensional(cantidad_de_elementos, caracter_separacion_funciones_esp[1], caracter_separacion_funciones_esp[0]);
                string[] arr1 = sin_nulos.Split(G_caracter_separacion_para_funciones_espesificas[0][0]);
                string[] arr2 = arr1[0].Split(G_caracter_separacion_para_funciones_espesificas[1][0]);
                arreglo_bidimencional_a_retornar = new string[arr1.Length, arr2.Length];
                for (int i = 0; i < arr1.Length; i++)
                {
                    arr2 = arr1[i].Split(G_caracter_separacion_para_funciones_espesificas[1][0]);
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        arreglo_bidimencional_a_retornar[i, j] = arr2[j];

                    }
                }
            }
            else
            {
                cantidad_de_elementos[0, 0] = arreglo[0];
                cantidad_de_elementos[0, 1] = "1";
                arreglo_bidimencional_a_retornar = new string[,] { { cantidad_de_elementos[0, 0], cantidad_de_elementos[0, 1] } };
            }
            string info_a_devolver = join_para_bidimensional(arreglo_bidimencional_a_retornar, caracter_separacion[1], caracter_separacion[0]);
            string[] arrelgo_a_devolver = info_a_devolver.Split(caracter_separacion[0][0]);
            return arrelgo_a_devolver;
        }
    }
}
