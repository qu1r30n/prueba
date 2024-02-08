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
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;

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





        public string[] quitar_registro_del_array(string[] arreglo)
        {
            if (arreglo.Length <= 1)
            {
                // No hay elementos para quitar, devolver un array vacío o el mismo array
                return null;
            }

            string[] temp = new string[arreglo.Length - 1];

            for (int i = 1; i < arreglo.Length; i++)
            {
                temp[i - 1] = arreglo[i];
            }


            return temp;
        }

        public string busqueda_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparar, string columnas_a_retornar = null, object caracter_separacion_objeto = null,int donde_iniciar=0)
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
                //comparacion--------------------------------------------------------------------------
                if (tem_linea == comparar)
                {
                    areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], columnas_a_recorrer_editar, info_a_sustituir);
                    return areglo;
                }

            }
            return null;
        }


        public string editar_inc_busqueda_multiple_edicion_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparar, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1", "5", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (caracter_separacion_para_busqueda_multiple_profuda == null)
            {
                caracter_separacion_para_busqueda_multiple_profuda = G_separador_para_funciones_espesificas_[0];
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
                if (tem_linea == comparar)
                {


                    string[] indices_espliteado = indices_a_editar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                    string[] info_editar_espliteado = info_editar.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                    string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracter_separacion_para_busqueda_multiple_profuda[0]);
                    for (int k = 0; k < indices_espliteado.Length; k++)
                    {
                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_dif_a_texto: caracter_separacion_para_busqueda_multiple_profuda);
                    }

                    return areglo[i];
                }

            }


            return null;

        }

        public string si_no_existe_agrega_string(string[] areglo, string columnas_a_recorrer, string comparar, string texto_a_agregar)
        {
            string info_encontrada = busqueda_profunda_arreglo(areglo, columnas_a_recorrer, comparar);
            if (info_encontrada != null)
            {
                return info_encontrada;
            }
            else
            {
                agregar_registro_del_array(areglo, texto_a_agregar);
                return null;
            }

        }

        public string si_existe_edita_o_incrementa_si_no_agrega_string(string[] arreglo, string columnas_a_recorrer, string comparar, string texto_a_agregar, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda = null)
        {
            string encontrado = si_no_existe_agrega_string(arreglo,columnas_a_recorrer,comparar,texto_a_agregar);
            if (encontrado != null) 
            {
                encontrado=editar_inc_busqueda_multiple_edicion_profunda_arreglo(arreglo, columnas_a_recorrer, comparar,indices_a_editar,info_editar,edit_0_o_increm_1,caracter_separacion_objeto,caracter_separacion_para_busqueda_multiple_profuda);

            }
            return encontrado;

        }


        public string[] busqueda_multiple_edicion_multiple_arreglo_profunda(string[] areglo, string columnas_a_recorrer, string comparar, string indices_a_editar, string info_editar, string edit_0_o_increm_1 = null, object caracter_separacion_objeto = null, string caracter_separacion_para_busqueda_multiple_profuda = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1~2|1|1~2|1|1", "5~5~5", "2|1|1~1~2|1|0", "10~10~10","1~1~0");
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            if (caracter_separacion_para_busqueda_multiple_profuda == null)
            {
                caracter_separacion_para_busqueda_multiple_profuda = G_separador_para_funciones_espesificas_[0];
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

        public string[] funcion_convert_objeto_a_arreglo(object texto_enviar_arreglo_objeto, string caracter_de_separacion_si_es_string = null)
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
                        texto_enviar_arreglo_string = texto_enviar_arreglo_objeto.ToString().Split(G_separador_para_funciones_espesificas_[2][0]);
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

    }
}
