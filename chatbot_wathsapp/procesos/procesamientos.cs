using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using chatbot_wathsapp.clases;

namespace chatbot_wathsapp.procesos
{
    class procesamientos
    {
        //string direccion_inventario = G_dir_base + variables_glob_conf.GG_nom_archivos[0,0];//direccion_inventario


        Tex_base bas = new Tex_base();

        string[] G_caracter_separacion = variables_glob_conf.GG_caracter_separacion;

        //----------------------------------------------------------------------------------------------
        // funcion para crear archivos al inicio del programa
        public void crear_archivos_inicio_programa()
        {


            // Crear archivos del programa
            for (int i = 0; i < variables_glob_conf.GG_dir_nom_archivos.GetLength(0); i++)
            {
                bas.Crear_archivo_y_directorio(variables_glob_conf.GG_dir_nom_archivos[i, 0], variables_glob_conf.GG_dir_nom_archivos[i, 1]);
            }

            // Crear archivos de registro
            for (int i = 0; i < variables_glob_conf.GG_dir_reg.GetLength(0); i++)
            {
                bas.Crear_archivo_y_directorio(variables_glob_conf.GG_dir_reg[i, 0], variables_glob_conf.GG_dir_reg[i, 1]);
            }
            // Recargar información de arreglos desde archivos
            for (int i = 0; i < variables_glob_conf.GG_dir_nom_archivos.GetLength(0); i++)
            {
                variables_glob_conf.GG_arrays_carga_de_archivos[i] = bas.Leer(variables_glob_conf.GG_dir_nom_archivos[i, 0]);
            }

            // Recargar información de arreglos desde registros
            for (int i = 0; i < variables_glob_conf.GG_dir_reg.GetLength(0); i++)
            {
                variables_glob_conf.GG_arrays_carga_de_registros[i] = bas.Leer(variables_glob_conf.GG_dir_reg[i, 0]);
            }

            variables_glob_conf var_glob = new variables_glob_conf();

            // orden que el text box venta deve tener por codigo y por nombre
            string orden_venta = bas.arr_str_conv_nom_a_indice(var_glob.GG_orden_codbar_venta, variables_glob_conf.GG_arrays_carga_de_archivos[0][0], Convert.ToChar(G_caracter_separacion[0]));
            string orden_venta_2 = bas.arr_str_conv_nom_a_indice(var_glob.GG_orden_nom_produc_venta, variables_glob_conf.GG_arrays_carga_de_archivos[0][0], Convert.ToChar(G_caracter_separacion[0]));

            // orden que el text box venta deve tener por codigo y por nombre
            string orden_compra = bas.arr_str_conv_nom_a_indice(var_glob.GG_orden_codbar_compra, variables_glob_conf.GG_arrays_carga_de_archivos[0][0], Convert.ToChar(G_caracter_separacion[0]));
            string orden_compra_2 = bas.arr_str_conv_nom_a_indice(var_glob.GG_orden_nom_produc_compra, variables_glob_conf.GG_arrays_carga_de_archivos[0][0], Convert.ToChar(G_caracter_separacion[0]));

            // Cargar predicciones en las variables globales GG_autoCompleteCollection (para predictor de código de barras y nombre de producto)
            for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[0].Length; i++)
            {
                Operaciones_textos op_tex = new Operaciones_textos();

                // Obtener texto ordenado para ventas y compras
                string texto_a_agregar_venta = op_tex.ordenar_string_con_caractere_separacion(variables_glob_conf.GG_arrays_carga_de_archivos[0][i], orden_venta, G_caracter_separacion[0]);
                string texto_a_agregar_nom_produc_venta = op_tex.ordenar_string_con_caractere_separacion(variables_glob_conf.GG_arrays_carga_de_archivos[0][i], orden_venta_2, G_caracter_separacion[0]);

                string texto_a_agregar_compra = op_tex.ordenar_string_con_caractere_separacion(variables_glob_conf.GG_arrays_carga_de_archivos[0][i], orden_compra, G_caracter_separacion[0]);
                string texto_a_agregar_nom_produc_compra = op_tex.ordenar_string_con_caractere_separacion(variables_glob_conf.GG_arrays_carga_de_archivos[0][i], orden_compra_2, G_caracter_separacion[0]);

                // Agregar a las variables globales GG_autoCompleteCollection
                variables_glob_conf.GG_autoCompleteCollection_codbar_venta.Add(texto_a_agregar_venta);
                variables_glob_conf.GG_autoCompleteCollection_nom_produc_venta.Add(texto_a_agregar_nom_produc_venta);

                variables_glob_conf.GG_autoCompleteCollection_codbar_compra.Add(texto_a_agregar_venta);
                variables_glob_conf.GG_autoCompleteCollection_nom_produc_compra.Add(texto_a_agregar_nom_produc_venta);
            }

        }

        //-----------------------------------------------------------------------------------------------

        public int[] extraer_ids_arreglo_fila_columna_comparar_columna_editar_REGISTROS(object dir_arch_o_id, int id_fila = -1, object id_o_nom_columna_comparar = null, string comparacion = null, string[] caracter_separacion = null, object id_o_nom_columna_editar = null)
        {
            // Variables para almacenar los índices de los arreglos y columnas
            // no esta el de fila por que es parametro
            int[] ids_0arreglo_1fila_2columnaComparar_3columnaEditar = { -1, id_fila, -1, -1 };





            // Si el arreglo de separación de caracteres no está definido, usar el valor predeterminado
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            //sacamos id_del_arreglo------------------------------------------------------------
            bool se_encontro_arreglo = false;

            if (dir_arch_o_id is string)
            {
                string temp = dir_arch_o_id.ToString();
                for (int i = 0; i < variables_glob_conf.GG_dir_reg.GetLength(0); i++)
                {

                    if (temp == variables_glob_conf.GG_dir_reg[i, 0])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0] = i;
                        se_encontro_arreglo = true;
                        break;
                    }
                }
            }

            else if (dir_arch_o_id is int)
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0] = Convert.ToInt32(dir_arch_o_id);
                string tem = variables_glob_conf.GG_dir_reg[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0], 0];//esto solo es para checar que exista el arreglo
                se_encontro_arreglo = true;

            }
            //sacamos id_fila--------------------------------------------------------------------------

            bool se_encontro_fila = false;
            if (ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] > -1)
            {
                se_encontro_fila = true;
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = id_fila;
            }
            //sacar id_fila con columna_comparar ------------------------------------------------------------------------------------

            bool se_encontro_columna_comparar = false;
            if (id_o_nom_columna_comparar is string)
            {
                string[] nom_columnas = variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][0].Split(Convert.ToChar(caracter_separacion[0]));
                for (int i = 0; i < nom_columnas.Length; i++)
                {

                    if ((string)id_o_nom_columna_comparar == nom_columnas[i])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] = i;
                        se_encontro_columna_comparar = true;
                        break;
                    }
                }

                if (se_encontro_fila == false)
                {
                    string[] columnas_a_recorrer;

                    if (se_encontro_columna_comparar == true)
                    {
                        columnas_a_recorrer = new string[] { "0", "" + ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] };
                    }
                    else
                    {
                        columnas_a_recorrer = id_o_nom_columna_comparar.ToString().Split(Convert.ToChar(caracter_separacion[0]));
                    }


                    for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]].Length; i++)
                    {
                        string[] columnas_de_la_fila_comp = variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][i].Split(Convert.ToChar(caracter_separacion[0]));
                        for (int j = 1; j < columnas_a_recorrer.Length; j++)
                        {
                            columnas_de_la_fila_comp = columnas_de_la_fila_comp[Convert.ToInt32(columnas_a_recorrer[j])].Split(Convert.ToChar(caracter_separacion[j]));
                            if (j == columnas_a_recorrer.Length - 1)
                            {
                                if (comparacion == columnas_de_la_fila_comp[0])
                                {
                                    ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = i;
                                    se_encontro_fila = true;
                                    break;
                                }
                            }

                        }
                        if (se_encontro_fila)
                        {
                            break;
                        }
                    }

                }



            }


            else if (id_o_nom_columna_comparar is int)
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] = (int)id_o_nom_columna_comparar;

                for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]].Length; i++)
                {
                    string[] info_columnas = variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][i].Split(Convert.ToChar(caracter_separacion[0]));
                    if (comparacion == info_columnas[(int)id_o_nom_columna_comparar])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = i;
                        se_encontro_fila = true;
                        break;
                    }
                }

                if (se_encontro_fila == false)
                {
                    string[] columnas_a_recorrer;

                    if (se_encontro_columna_comparar == true)
                    {
                        columnas_a_recorrer = new string[] { "0", "" + ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] };
                    }
                    else
                    {
                        columnas_a_recorrer = id_o_nom_columna_comparar.ToString().Split(Convert.ToChar(caracter_separacion[0]));
                    }


                    for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]].Length; i++)
                    {
                        string[] columnas_de_la_fila_comp = variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][i].Split(Convert.ToChar(caracter_separacion[0]));
                        for (int j = 1; j < columnas_a_recorrer.Length; j++)
                        {
                            columnas_de_la_fila_comp = columnas_de_la_fila_comp[Convert.ToInt32(columnas_a_recorrer[j])].Split(Convert.ToChar(caracter_separacion[j]));
                            if (j == columnas_a_recorrer.Length - 1)
                            {
                                if (comparacion == columnas_de_la_fila_comp[0])
                                {
                                    ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = i;
                                    se_encontro_fila = true;
                                    break;
                                }
                            }

                        }
                        if (se_encontro_fila)
                        {
                            break;
                        }
                    }

                }
            }

            //sacar columna a editar-------------------------------------------------------------------------------------------------------------------------
            bool se_encontro_columna_editar = false;
            if (id_o_nom_columna_editar is string)
            {
                string[] nom_columnas = variables_glob_conf.GG_arrays_carga_de_registros[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][0].Split(Convert.ToChar(caracter_separacion[0]));
                for (int i = 0; i < nom_columnas.Length; i++)
                {

                    if ((string)id_o_nom_columna_editar == nom_columnas[i])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3] = i;
                        se_encontro_columna_editar = true;
                        break;
                    }
                }


                // mod__ talves falte columnas a recorrer  para checar y como se hace en la funcion incrementar_decrementar_stringElementoEnMultiArregloRecursivo
                //por que si hay que cambiar de lugar el de editar tendremos que hacerlo desde la llamada a la funcion
                //incrementar_decrementar_stringElementoEnMultiArregloRecursivo
                //y
                //EditarstringElementoEnMultiArregloRecursivo
                string[] columnas_a_recorrer;

                if (se_encontro_columna_editar == true)
                {
                    columnas_a_recorrer = new string[] { "0", "" + ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3] };
                }

            }

            else if (id_o_nom_columna_editar is int)
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3] = (int)id_o_nom_columna_editar;

            }

            //-------------------------------------------------------------------------------------------------------------------------

            return ids_0arreglo_1fila_2columnaComparar_3columnaEditar;
        }

        public int[] extraer_ids_arreglo_fila_columna_comparar_columna_editar_ARCHIVOS(object dir_arch_o_id, int id_fila = -1, object id_o_nom_columna_comparar = null, string comparacion = null, string[] caracter_separacion = null, object id_o_nom_columna_editar = null)
        {
            // Variables para almacenar los índices de los arreglos y columnas
            // no esta el de fila por que es parametro

            int[] ids_0arreglo_1fila_2columnaComparar_3columnaEditar = { -1, id_fila, -1, -1, };




            // Si el arreglo de separación de caracteres no está definido, usar el valor predeterminado
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            //sacamos id_del_arreglo------------------------------------------------------------
            bool se_encontro_arreglo = false;

            if (dir_arch_o_id is string)
            {
                string temp = dir_arch_o_id.ToString();
                for (int i = 0; i < variables_glob_conf.GG_dir_nom_archivos.GetLength(0); i++)
                {
                    if (temp == variables_glob_conf.GG_dir_nom_archivos[i, 0])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0] = i;
                        se_encontro_arreglo = true;
                        break;
                    }
                }
            }

            else if (dir_arch_o_id is int)
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0] = Convert.ToInt32(dir_arch_o_id);
                string tem = variables_glob_conf.GG_dir_nom_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0], 0];//esto solo es para checar que exista el arreglo
                se_encontro_arreglo = true;

            }
            //sacamos id_fila--------------------------------------------------------------------------

            bool se_encontro_fila = false;
            if (ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] > -1)
            {
                se_encontro_fila = true;
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = id_fila;
            }
            //sacar id_fila con columna_comparar ------------------------------------------------------------------------------------

            bool se_encontro_columna_comparar = false;
            if (id_o_nom_columna_comparar is string)
            {
                string[] nom_columnas = variables_glob_conf.GG_arrays_carga_de_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][0].Split(Convert.ToChar(caracter_separacion[0]));
                for (int i = 0; i < nom_columnas.Length; i++)
                {

                    if ((string)id_o_nom_columna_comparar == nom_columnas[i])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] = i;
                        se_encontro_columna_comparar = true;
                        break;
                    }
                }

                if (se_encontro_fila == false)
                {
                    string[] columnas_a_recorrer;

                    if (se_encontro_columna_comparar == true)
                    {
                        columnas_a_recorrer = new string[] { "0", "" + ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] };
                    }
                    else
                    {
                        columnas_a_recorrer = id_o_nom_columna_comparar.ToString().Split(Convert.ToChar(G_caracter_separacion[0]));
                    }


                    for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]].Length; i++)
                    {
                        string[] columnas_de_la_fila_comp = variables_glob_conf.GG_arrays_carga_de_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][i].Split(Convert.ToChar(caracter_separacion[0]));
                        for (int j = 1; j < columnas_a_recorrer.Length; j++)
                        {
                            columnas_de_la_fila_comp = columnas_de_la_fila_comp[Convert.ToInt32(columnas_a_recorrer[j])].Split(Convert.ToChar(G_caracter_separacion[j]));
                            if (j == columnas_a_recorrer.Length - 1)
                            {
                                if (comparacion == columnas_de_la_fila_comp[0])
                                {
                                    ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = i;
                                    se_encontro_fila = true;
                                    break;
                                }
                            }

                        }
                        if (se_encontro_fila)
                        {
                            break;
                        }
                    }

                }

            }

            else if (id_o_nom_columna_comparar is int)
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2] = (int)id_o_nom_columna_comparar;

                for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]].Length; i++)
                {
                    string[] info_columnas = variables_glob_conf.GG_arrays_carga_de_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][i].Split(Convert.ToChar(G_caracter_separacion[0]));
                    if (comparacion == info_columnas[(int)id_o_nom_columna_comparar])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1] = i;
                        se_encontro_fila = true;
                    }
                }


            }

            //sacar columna a editar-------------------------------------------------------------------------------------------------------------------------
            bool se_encontro_columna_editar = false;
            if (id_o_nom_columna_editar is string)
            {
                string[] nom_columnas = variables_glob_conf.GG_arrays_carga_de_archivos[ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0]][0].Split(Convert.ToChar(caracter_separacion[0]));
                for (int i = 0; i < nom_columnas.Length; i++)
                {

                    if ((string)id_o_nom_columna_editar == nom_columnas[i])
                    {
                        ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3] = i;
                        se_encontro_columna_editar = true;
                        break;
                    }
                }


                // mod__ talves falte columnas a recorrer  para checar y como se hace en la funcion incrementar_decrementar_stringElementoEnMultiArregloRecursivo
                //por que si hay que cambiar de lugar el de editar tendremos que hacerlo desde la llamada a la funcion
                //incrementar_decrementar_stringElementoEnMultiArregloRecursivo
                //y
                //EditarstringElementoEnMultiArregloRecursivo
                string[] columnas_a_recorrer;

                if (se_encontro_columna_editar == true)
                {
                    columnas_a_recorrer = new string[] { "0", "" + ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3] };
                }

            }

            else if (id_o_nom_columna_editar is int)
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3] = (int)id_o_nom_columna_editar;

            }

            //-------------------------------------------------------------------------------------------------------------------------
            return ids_0arreglo_1fila_2columnaComparar_3columnaEditar;
        }

        public string[] extraer_info_de_un_arreglo_de_un_elemento_de_otro_arreglo_RETORNA_ARREGLO(string string_a_extraer_informacion, string columnas_recorrer_extraer, int id_a_extaer_del_arreglo_final, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            string[] arreglo_a_retornar = null;
            string[] ids_columnas_a_recorrer = columnas_recorrer_extraer.Split(Convert.ToChar(caracter_separacion[0]));
            string[] arreglo_a_extraer_informacion = string_a_extraer_informacion.Split(Convert.ToChar(caracter_separacion[0]));


            string info_columna = "";
            for (int j = 1; j < ids_columnas_a_recorrer.Length; j++)
            {


                if (j < ids_columnas_a_recorrer.Length - 1)
                {
                    arreglo_a_extraer_informacion = arreglo_a_extraer_informacion[Convert.ToInt32(ids_columnas_a_recorrer[j])].Split(Convert.ToChar(caracter_separacion[j]));


                }
                else
                {



                    for (int k = 0; k < arreglo_a_extraer_informacion.Length; k++)
                    {
                        string[] arreglo_de_el_espliteo = arreglo_a_extraer_informacion[k].Split(Convert.ToChar(caracter_separacion[ids_columnas_a_recorrer.Length - 1]));



                        arreglo_a_retornar = agregar_registro_del_array(arreglo_a_retornar, arreglo_de_el_espliteo[id_a_extaer_del_arreglo_final]);
                    }

                }
            }

            return arreglo_a_retornar;
        }

        public string[] extraer_arreglo_de_string(string texto, string columnas_a_recorrer, string ids_comparacion = null, string comparacion = null, string[] caracter_separacion = null)
        {
            string texto_a_recorrer = texto;
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            //------------------------------------------------------------------------------------

            int i = 0;
            String[] columnas_recorrer_espliteadas = columnas_a_recorrer.Split(Convert.ToChar(caracter_separacion[i]));
            string[] texto_a_retornar;
            string[] texto_espliteado;
            string[] ids_comp_espliteado;
            string[] comparaciones_espliteado;
            do
            {
                //aqui se hace todas las operaciones-----------------------------------------------------------------------
                texto_espliteado = texto_a_recorrer.Split(Convert.ToChar(caracter_separacion[i]));
                texto_a_recorrer = texto_espliteado[Convert.ToInt32(columnas_a_recorrer)];
                //fin aqui se terminan_las_operaciones-------------------------------------------------------------------------
                i++;
            } while (i < columnas_recorrer_espliteadas.Length);


            if (ids_comparacion == null)
            {
                texto_a_retornar = texto_a_recorrer.Split(Convert.ToChar(caracter_separacion[i]));

            }
            else
            {
                if (comparacion == null)
                {
                    texto_espliteado = texto_a_recorrer.Split(Convert.ToChar(caracter_separacion[i]));
                    ids_comp_espliteado = ids_comparacion.Split(Convert.ToChar(caracter_separacion[0]));
                    texto_a_retornar = new string[ids_comp_espliteado.Length];
                    for (int j = 0; j < ids_comp_espliteado.Length; j++)
                    {

                        texto_a_retornar[j] = texto_espliteado[Convert.ToInt32(ids_comp_espliteado[j])];
                    }
                }

                else
                {
                    comparaciones_espliteado = comparacion.Split(Convert.ToChar(caracter_separacion[0]));

                    texto_espliteado = texto_a_recorrer.Split(Convert.ToChar(caracter_separacion[i]));
                    ids_comp_espliteado = ids_comparacion.Split(Convert.ToChar(caracter_separacion[0]));
                    texto_a_retornar = new string[ids_comp_espliteado.Length];
                    for (int j = 0; j < ids_comp_espliteado.Length; j++)
                    {

                        texto_a_retornar[j] = texto_espliteado[Convert.ToInt32(ids_comp_espliteado[j])];
                    }

                }

            }
            //-----------------------------------------------------------------------------------

            return texto_a_retornar;
        }



        public void modelo_de_registros_venta(string informacion_venta, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            string[] informacion_venta_espliteada = informacion_venta.Split(Convert.ToChar(caracter_separacion[0]));


            //producto_0|cant_produc_1|tipo_medida_2|precio_venta_3|cod_barras_4|cantidad_5|costo_comp_6|provedor_7|grupo_8|no poner nada_9|cant_produc_x_paquet_10|tipo_de_producto_11|ligar_produc_sab_12|impuestos_13|parte_de_que_producto_14
            string[] info_sin_producto_y_fecha_vacia = { "", informacion_venta_espliteada[1], informacion_venta_espliteada[2], informacion_venta_espliteada[3] };
            //solo hay que concatenar la_fecha
            string info_fecha_vacia_y_sin_producto = string.Join(caracter_separacion[0], info_sin_producto_y_fecha_vacia);


            string[] nom_impuestos = extraer_info_de_un_arreglo_de_un_elemento_de_otro_arreglo_RETORNA_ARREGLO(informacion_venta, "0|3|0", 0);
            string nom_impuestos_joineado = string.Join(caracter_separacion[1], nom_impuestos);
            string[] dinero_impuestos = extraer_info_de_un_arreglo_de_un_elemento_de_otro_arreglo_RETORNA_ARREGLO(informacion_venta, "0|3|0", 1);
            string dinero_impuestos_joineado = string.Join(caracter_separacion[1], dinero_impuestos);

            string[] espliteado_info_venta = informacion_venta.Split(Convert.ToChar(caracter_separacion[0]));
            string venta_comp = espliteado_info_venta[1] + caracter_separacion[0] + espliteado_info_venta[2];

            string[] codigos = extraer_info_de_un_arreglo_de_un_elemento_de_otro_arreglo_RETORNA_ARREGLO(informacion_venta, "0|4|0", 0);
            string[] nombres = extraer_info_de_un_arreglo_de_un_elemento_de_otro_arreglo_RETORNA_ARREGLO(informacion_venta, "0|4|0", 1);
            string[] cantidades = extraer_info_de_un_arreglo_de_un_elemento_de_otro_arreglo_RETORNA_ARREGLO(informacion_venta, "0|4|0", 2);
            string codigos_joineados = string.Join(caracter_separacion[0], codigos);
            string cantidades_joineados = string.Join(caracter_separacion[0], cantidades);

            string si_no_esta_reg_producto = "";
            for (int i = 0; i < codigos.Length; i++)
            {
                if (i < codigos.Length - 1)
                {
                    si_no_esta_reg_producto = si_no_esta_reg_producto + codigos[i] + caracter_separacion[0] + cantidades[i] + caracter_separacion[0] + nombres[i] + caracter_separacion[1];
                }
                else
                {
                    si_no_esta_reg_producto = si_no_esta_reg_producto + codigos[i] + caracter_separacion[0] + cantidades[i] + caracter_separacion[0] + nombres[i];
                }

            }
            int a = 1 + 1;

            //¡IMPORTANTE! los caracteres de separacion de 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO,
            //tienen que ser los mismos que los de 9_comparar, 10_dato_editar_o_incrementar O CREO QUE de los ultimos caracteres que se van a comparar
            string[,] info_lugar_a_buscar = new string[,]
            {
                //impuestos//{0_sera_en_archivos_o_en_registros,                        1_dir_arch_o_id, 2_id_fila, 3_columnas_a_recorrer_COMPARAR_para_sacar_FILA, 4_id_o_nom_columna_COMPARAR_para_sacar_FILA,                 5_comparacion_FILA, 6_columna_a_RECORRER_ARCHIVO, 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO,             9_comparar, 10_dato_editar_o_incrementar, 11_proceso_incrementar_o_editar,                                                     12_si_no_esta,13_caracteres_separacion
                {/*0*/                              "registros",  variables_glob_conf.GG_dir_reg[3,0],      "-1",                                            "3",                                         "0",  DateTime.Now.ToString("yyyyMMdd"),                        "0|3",                       "0",                     "1", nom_impuestos_joineado,    dinero_impuestos_joineado,                   "incrementar", DateTime.Now.ToString("yyyyMMdd")+info_fecha_vacia_y_sin_producto, ""},
                {/*1*/                              "registros",  variables_glob_conf.GG_dir_reg[6,0],      "-1",                                            "3",                                         "0",    DateTime.Now.ToString("yyyyMM"),                        "0|3",                     "0°0",                   "1°1", nom_impuestos_joineado,    dinero_impuestos_joineado,                   "incrementar", DateTime.Now.ToString("yyyyMM")+info_fecha_vacia_y_sin_producto  , ""},
                {/*2*/                              "registros",  variables_glob_conf.GG_dir_reg[9,0],      "-1",                                            "3",                                         "0",      DateTime.Now.ToString("yyyy"),                        "0|3",                       "0",                   "1°1", nom_impuestos_joineado,    dinero_impuestos_joineado,                   "incrementar", DateTime.Now.ToString("yyyy")+info_fecha_vacia_y_sin_producto    , ""},
                {/*3*/                              "registros", variables_glob_conf.GG_dir_reg[12,0],      "-1",                                            "3",                                         "0",      DateTime.Now.ToString("yyyy"),                        "0|3",                       "0",                     "1", nom_impuestos_joineado,    dinero_impuestos_joineado,                   "incrementar", DateTime.Now.ToString("yyyy")+info_fecha_vacia_y_sin_producto    , ""},
                //total_venta  //{0_sera_en_archivos_o_en_registros,                      1_dir_arch_o_id, 2_id_fila, 3_columnas_a_recorrer_COMPARAR_para_sacar_FILA, 4_id_o_nom_columna_COMPARAR_para_sacar_FILA,                 5_comparacion_FILA, 6_columna_a_RECORRER_ARCHIVO, 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO,                        9_comparar, 10_dato_editar_o_incrementar, 11_proceso_incrementar_o_editar, 12_si_no_esta, 13_caracteres_separacion_de_sino_esta
                {/*4*/                                "registros",  variables_glob_conf.GG_dir_reg[3,0],      "-1",                                            "0",                                         "0",  DateTime.Now.ToString("yyyyMMdd"),                          "0",                       "0",                   "1|2", DateTime.Now.ToString("yyyyMMdd"),                   venta_comp,                   "incrementar",            "", ""},
                {/*5*/                                "registros",  variables_glob_conf.GG_dir_reg[6,0],      "-1",                                            "0",                                         "0",    DateTime.Now.ToString("yyyyMM"),                          "0",                       "0",                   "1|2",   DateTime.Now.ToString("yyyyMM"),                   venta_comp,                   "incrementar",            "", ""},
                {/*6*/                                "registros",  variables_glob_conf.GG_dir_reg[9,0],      "-1",                                            "0",                                         "0",      DateTime.Now.ToString("yyyy"),                          "0",                       "0",                   "1|2",     DateTime.Now.ToString("yyyy"),                   venta_comp,                   "incrementar",            "", ""},
                {/*7*/                                "registros", variables_glob_conf.GG_dir_reg[12,0],      "-1",                                            "0",                                         "0",      DateTime.Now.ToString("yyyy"),                          "0",                       "0",                   "1|2",     DateTime.Now.ToString("yyyy"),                   venta_comp,                   "incrementar",            "", ""},
                //productoscantidades//{0_sera_en_archivos_o_en_registros,                      1_dir_arch_o_id, 2_id_fila, 3_columnas_a_recorrer_COMPARAR_para_sacar_FILA, 4_id_o_nom_columna_COMPARAR_para_sacar_FILA, 5_comparacion_FILA, 6_columna_a_RECORRER_ARCHIVO, 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO, 9_comparar, 10_dato_editar_o_incrementar, 11_proceso_incrementar_o_editar,           12_si_no_esta, 13_caracteres_separacion
                {/*8*/                                       "registros",  variables_glob_conf.GG_dir_reg[2,0],      "-1",                                            "0",                                         "0",   codigos_joineados,                          "0",                      null,                     "1",       null,         cantidades_joineados,                   "incrementar", si_no_esta_reg_producto, "°"},
                {/*9*/                                       "registros",  variables_glob_conf.GG_dir_reg[5,0],      "-1",                                            "0",                                         "0",   codigos_joineados,                          "0",                      null,                     "1",       null,         cantidades_joineados,                   "incrementar", si_no_esta_reg_producto, "°"},
                {/*10*/                                      "registros",  variables_glob_conf.GG_dir_reg[8,0],      "-1",                                            "0",                                         "0",   codigos_joineados,                          "0",                      null,                     "1",       null,         cantidades_joineados,                   "incrementar", si_no_esta_reg_producto, "°"},
                {/*11*/                                      "registros", variables_glob_conf.GG_dir_reg[11,0],      "-1",                                            "0",                                         "0",   codigos_joineados,                          "0",                      null,                     "1",       null,         cantidades_joineados,                   "incrementar", si_no_esta_reg_producto, "°"},
                {/*12*/                                      "registros", variables_glob_conf.GG_dir_reg[14,0],      "-1",                                            "0",                                         "0",   codigos_joineados,                          "0",                      null,                     "1",       null,         cantidades_joineados,                   "incrementar", si_no_esta_reg_producto, "°"}
            };

            modificadores_de_arreglo_y_archivo(info_lugar_a_buscar, caracter_separacion);
        }

        public void modificadores_de_arreglo_y_archivo(string[,] info_lugar_a_buscar, string[] caracter_separacion = null)
        {
            //nombres columna y ejemplos
            //impuestos//{0_sera_en_archivos_o_en_registros,                        1_dir_arch_o_id, 2_id_fila, 3_columnas_a_recorrer_COMPARAR_para_sacar_FILA, 4_id_o_nom_columna_COMPARAR_para_sacar_FILA,                 5_comparacion_FILA, 6_columna_a_RECORRER_ARCHIVO, 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO,             9_comparar, 10_dato_editar_o_incrementar, 11_proceso_incrementar_o_editar,                                                     12_si_no_esta,13_caracteres_separacion
            //{/*0*/                              "registros",  variables_glob_conf.GG_dir_reg[3,0],      "-1",                                            "3",                                         "0",  DateTime.Now.ToString("yyyyMMdd"),                        "0|3",                       "0",                     "1", nom_impuestos_joineado,    dinero_impuestos_joineado,                   "incrementar", DateTime.Now.ToString("yyyyMMdd")+info_fecha_vacia_y_sin_producto, ""},
            //total_venta  //{0_sera_en_archivos_o_en_registros,                      1_dir_arch_o_id, 2_id_fila, 3_columnas_a_recorrer_COMPARAR_para_sacar_FILA, 4_id_o_nom_columna_COMPARAR_para_sacar_FILA,                 5_comparacion_FILA, 6_columna_a_RECORRER_ARCHIVO, 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO,                        9_comparar, 10_dato_editar_o_incrementar, 11_proceso_incrementar_o_editar, 12_si_no_esta, 13_caracteres_separacion_de_sino_esta
            //{/*4*/                                "registros",  variables_glob_conf.GG_dir_reg[3,0],      "-1",                                            "0",                                         "0",  DateTime.Now.ToString("yyyyMMdd"),                          "0",                       "0",                   "1|2", DateTime.Now.ToString("yyyyMMdd"),                   venta_comp,                   "incrementar",            "", ""},
            //productoscantidades//{0_sera_en_archivos_o_en_registros,                      1_dir_arch_o_id, 2_id_fila, 3_columnas_a_recorrer_COMPARAR_para_sacar_FILA, 4_id_o_nom_columna_COMPARAR_para_sacar_FILA, 5_comparacion_FILA, 6_columna_a_RECORRER_ARCHIVO, 7_id_col_COMPARAR_ARCHIVO, 8_id_col_EDITAR_ARCHIVO, 9_comparar, 10_dato_editar_o_incrementar, 11_proceso_incrementar_o_editar,           12_si_no_esta, 13_caracteres_separacion
            //{/*8*/                                       "registros",  variables_glob_conf.GG_dir_reg[2,0],      "-1",                                            "0",                                         "0",   codigos_joineados,                          "0",                      null,                     "1",       null,         cantidades_joineados,                   "incrementar", si_no_esta_reg_producto, "°"},


            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            //id_archivo
            string[] esta_direccion_fue_agregado = null;
            for (int i = 0; i < info_lugar_a_buscar.GetLength(0); i++)
            {
                string[] espliteado_comparacion_fila = info_lugar_a_buscar[i, 5].Split(Convert.ToChar(G_caracter_separacion[0]));
                for (int j = 0; j < espliteado_comparacion_fila.Length; j++)
                {


                    int id_archivo_o_registro = sacar_id_arreglo_archivo_o_registro(info_lugar_a_buscar[i, 0], info_lugar_a_buscar[i, 1]);

                    string sera_en_archivos_o_en_registros = info_lugar_a_buscar[i, 0];
                    string id_o_nom_columna_COMPARAR = info_lugar_a_buscar[i, 4];
                    string comparacion = espliteado_comparacion_fila[j];

                    string[] id_o_fila_a_trabajar = sacar_fila_comparando_simple(sera_en_archivos_o_en_registros, id_archivo_o_registro, Convert.ToInt32(id_o_nom_columna_COMPARAR), comparacion);

                    bool agrego_informacion_al_archivo = false;
                    string direccion = info_lugar_a_buscar[i, 1];
                    if (id_o_fila_a_trabajar == null)
                    {


                        string si_no_esta = info_lugar_a_buscar[i, 12];
                        string[] espliteado_si_no_esta = null;
                        if (info_lugar_a_buscar[i, 13] != "" && info_lugar_a_buscar[i, 13] != null)
                        {
                            espliteado_si_no_esta = si_no_esta.Split(Convert.ToChar(info_lugar_a_buscar[i, 13]));
                        }
                        else
                        {
                            espliteado_si_no_esta = new string[] { si_no_esta };
                        }

                        for (int m = 0; m < espliteado_si_no_esta.Length; m++)
                        {
                            agregar_string_ARCHIVOS_o_REGISTROS(sera_en_archivos_o_en_registros, direccion, espliteado_si_no_esta[m]);
                        }

                        esta_direccion_fue_agregado = agregar_registro_del_array(esta_direccion_fue_agregado, direccion);


                        break;
                    }


                    bool modificar = true;
                    if (esta_direccion_fue_agregado != null)
                    {
                        //checa que las direcciones no alla sido agregado la informacion anterior mente
                        //por que si incrementa cuando previamente fue agregado estaria duplicando la venta
                        for (int k = 0; k < esta_direccion_fue_agregado.Length; k++)
                        {
                            if (direccion == esta_direccion_fue_agregado[k])
                            {
                                modificar = false;
                            }
                        }
                    }


                    if (modificar == true)
                    {
                        if (agrego_informacion_al_archivo == false)
                        {


                            //extraer_arreglo_de_string(fila_a_trabajar,);

                            string columna_a_RECORRER_ARCHIVO_ = info_lugar_a_buscar[i, 6];
                            string id_col_COMPARAR_ARCHIVO_ = info_lugar_a_buscar[i, 7];
                            string comparar = info_lugar_a_buscar[i, 9];
                            string id_col_EDITAR_ARCHIVO_ = info_lugar_a_buscar[i, 8];
                            string dato_editar = info_lugar_a_buscar[i, 10];
                            string proceso = info_lugar_a_buscar[i, 11];

                            string texto_modificado = null;

                            if (id_col_COMPARAR_ARCHIVO_ != null && comparar != null && id_col_COMPARAR_ARCHIVO_ != "" && comparar != "")
                            {

                                texto_modificado = incrementar_editar_MultiArregloRecursivo(proceso, id_o_fila_a_trabajar[1], columna_a_RECORRER_ARCHIVO_, id_col_COMPARAR_ARCHIVO_, comparar, id_col_EDITAR_ARCHIVO_, dato_editar);

                                editar_fila_string_ARCHIVOS_o_REGISTROS(sera_en_archivos_o_en_registros, id_archivo_o_registro, Convert.ToInt32(id_o_fila_a_trabajar[0]), texto_modificado);

                            }
                            else
                            {
                                string[] espliteado_dato_editar = dato_editar.Split(Convert.ToChar(caracter_separacion[0]));
                                texto_modificado = incrementar_editar_MultiArregloRecursivo(proceso, id_o_fila_a_trabajar[1], columna_a_RECORRER_ARCHIVO_, id_col_COMPARAR_ARCHIVO_, comparar, id_col_EDITAR_ARCHIVO_, espliteado_dato_editar[j]);

                                editar_fila_string_ARCHIVOS_o_REGISTROS(sera_en_archivos_o_en_registros, id_archivo_o_registro, Convert.ToInt32(id_o_fila_a_trabajar[0]), texto_modificado);
                            }

                        }
                    }



                }
            }
        }


        public int sacar_id_arreglo_archivo_o_registro(string arch_o_registro, string direccion_para_sacar_id_arreglo)
        {
            int j = -1;
            if (arch_o_registro == "archivos")
            {
                for (j = 0; j < variables_glob_conf.GG_dir_nom_archivos.Length; j++)
                {
                    if (direccion_para_sacar_id_arreglo == variables_glob_conf.GG_dir_nom_archivos[j, 0])
                    {
                        break;
                    }
                }

            }

            else if (arch_o_registro == "registros")
            {
                for (j = 0; j < variables_glob_conf.GG_dir_reg.Length; j++)
                {
                    if (direccion_para_sacar_id_arreglo == variables_glob_conf.GG_dir_reg[j, 0])
                    {
                        break;
                    }
                }

            }

            return j;


        }

        public string[] sacar_fila_comparando_simple(string arch_o_registro, int id_arreglo, int id_columna_comparar, string comparar, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracter_separacion;
            }
            string fila = null;
            string[] info_id_fila_e_informacion_a_retornar = null;
            int i = variables_glob_conf.GG_var_glob_int[0];
            if (arch_o_registro == "archivos")
            {
                for (; i < variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo].Length; i++)
                {
                    string[] datos_espliteado = variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo][i].Split(Convert.ToChar(caracteres_separacion[0]));
                    if (datos_espliteado[id_columna_comparar] == comparar)
                    {
                        fila = variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo][i];
                        info_id_fila_e_informacion_a_retornar = new string[] { "" + i, fila };
                        break;
                    }
                }

            }
            else if (arch_o_registro == "registros")
            {
                for (; i < variables_glob_conf.GG_arrays_carga_de_registros[id_arreglo].Length; i++)
                {
                    string[] datos_espliteado = variables_glob_conf.GG_arrays_carga_de_registros[id_arreglo][i].Split(Convert.ToChar(caracteres_separacion[0]));
                    if (datos_espliteado[id_columna_comparar] == comparar)
                    {
                        fila = variables_glob_conf.GG_arrays_carga_de_registros[id_arreglo][i];
                        info_id_fila_e_informacion_a_retornar = new string[] { "" + i, fila };
                        break;
                    }
                }

            }

            return info_id_fila_e_informacion_a_retornar;
        }



        public string mod_proc_extraxion_informacion_archivos_o_registros(string archivos_o_registros, object dir_arch_o_id, int id_fila = -1, object id_o_nom_columna_comparar = null, string comparacion = null, string[] caracter_separacion = null, object id_o_nom_columna_editar = null)
        {
            int[] ids_0arreglo_1fila_2columnaComparar_3columnaEditar = { 0, 0, 0, 0 };
            if (archivos_o_registros == "archivos")
            {
                ids_0arreglo_1fila_2columnaComparar_3columnaEditar = extraer_ids_arreglo_fila_columna_comparar_columna_editar_ARCHIVOS(dir_arch_o_id, id_fila, id_o_nom_columna_comparar, comparacion, caracter_separacion, id_o_nom_columna_editar);
                int id_arreglo = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0];
                id_fila = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1];
                int id_columna_comparar = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2];
                int id_columna_editar = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3];

                return variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo][id_fila];

            }
            else if (archivos_o_registros == "registros")
            {

                ids_0arreglo_1fila_2columnaComparar_3columnaEditar = extraer_ids_arreglo_fila_columna_comparar_columna_editar_REGISTROS(dir_arch_o_id, id_fila, id_o_nom_columna_comparar, comparacion, caracter_separacion, id_o_nom_columna_editar);
                int id_arreglo = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[0];
                id_fila = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[1];
                int id_columna_comparar = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[2];
                int id_columna_editar = ids_0arreglo_1fila_2columnaComparar_3columnaEditar[3];

                return variables_glob_conf.GG_arrays_carga_de_registros[id_arreglo][id_fila];

            }

            return null;
        }

        public int[] mod_proc_extraer_ids_arreglo_fila_columna_comparar_columna_editar_archivos_o_registros(string archivos_o_registros, object dir_arch_o_id, int id_fila = -1, object id_o_nom_columna_comparar = null, string comparacion = null, string[] caracter_separacion = null, object id_o_nom_columna_editar = null)
        {

            if (archivos_o_registros == "archivos")
            {
                int[] ids_0arreglo_1fila_2columnaComparar_3columnaEditar = ids_0arreglo_1fila_2columnaComparar_3columnaEditar = extraer_ids_arreglo_fila_columna_comparar_columna_editar_ARCHIVOS(dir_arch_o_id, id_fila, id_o_nom_columna_comparar, comparacion, caracter_separacion, id_o_nom_columna_editar);

                return ids_0arreglo_1fila_2columnaComparar_3columnaEditar;

            }
            else if (archivos_o_registros == "registros")
            {

                int[] ids_0arreglo_1fila_2columnaComparar_3columnaEditar = extraer_ids_arreglo_fila_columna_comparar_columna_editar_REGISTROS(dir_arch_o_id, id_fila, id_o_nom_columna_comparar, comparacion, caracter_separacion, id_o_nom_columna_editar);

                return ids_0arreglo_1fila_2columnaComparar_3columnaEditar;

            }

            return null;
        }

        // Método para agregar un texto a un archivo y actualizar un arreglo
        public void agregar_string_ARCHIVOS_o_REGISTROS(string archivo_o_registro, string direccion, string texto)
        {
            if (archivo_o_registro == "archivos")
            {
                agregar_string_ARCHIVOS(direccion, texto);
            }
            else if (archivo_o_registro == "registros")
            {
                agregar_string_REGISTROS(direccion, texto);
            }
        }

        public void editar_fila_string_ARCHIVOS_o_REGISTROS(string archivo_o_registro, int id_direccion_archivo_o_registro, int fila, string texto)
        {
            if (archivo_o_registro == "archivos")
            {
                editar_fila_string_ARCHIVOS(id_direccion_archivo_o_registro, fila, texto);
            }
            else if (archivo_o_registro == "registros")
            {
                editar_fila_string_REGISTROS(id_direccion_archivo_o_registro, fila, texto);
            }
        }

        public void agregar_string_ARCHIVOS(string direccion, string texto)
        {
            // Crear el archivo si no existe crea directorios
            bas.Crear_archivo_y_directorio(direccion);


            // Recorrer los nombres de archivos en el arreglo global GG_dir_nom_archivos
            //  si coincide el nombre el agrega nuevo registro
            for (int i = 0; i < variables_glob_conf.GG_dir_nom_archivos.GetLength(0); i++)
            {
                if (direccion == variables_glob_conf.GG_dir_nom_archivos[i, 0])
                {
                    // Agregar el nuevo registro al arreglo correspondiente
                    variables_glob_conf.GG_arrays_carga_de_archivos[i] = agregar_registro_del_array(variables_glob_conf.GG_arrays_carga_de_archivos[i], texto);
                    break;
                }

            }

            bas.Agregar(direccion, texto);
        }

        public void agregar_string_REGISTROS(string direccion, string texto)
        {
            // Crear el archivo si no existe crea directorios
            bas.Crear_archivo_y_directorio(direccion);


            // Recorrer los nombres de archivos en el arreglo global GG_dir_nom_archivos
            //  si coincide el nombre el agrega nuevo registro
            for (int i = 0; i < variables_glob_conf.GG_dir_reg.GetLength(0); i++)
            {
                if (direccion == variables_glob_conf.GG_dir_reg[i, 0])
                {
                    // Agregar el nuevo registro al arreglo correspondiente
                    variables_glob_conf.GG_arrays_carga_de_registros[i] = agregar_registro_del_array(variables_glob_conf.GG_arrays_carga_de_registros[i], texto);
                    break;
                }

            }
            bas.Agregar(direccion, texto);
        }

        public void editar_fila_string_ARCHIVOS(int id_archivo_ARCHIVO, int fila, string texto)
        {
            variables_glob_conf.GG_arrays_carga_de_archivos[id_archivo_ARCHIVO][fila] = texto;

            bas.cambiar_archivo_con_arreglo(variables_glob_conf.GG_dir_nom_archivos[id_archivo_ARCHIVO, 0], variables_glob_conf.GG_arrays_carga_de_archivos[id_archivo_ARCHIVO]);
        }

        public void editar_fila_string_REGISTROS(int id_archivo_REGISTRO, int fila, string texto)
        {

            variables_glob_conf.GG_arrays_carga_de_registros[id_archivo_REGISTRO][fila] = texto;

            bas.cambiar_archivo_con_arreglo(variables_glob_conf.GG_dir_reg[id_archivo_REGISTRO, 0], variables_glob_conf.GG_arrays_carga_de_registros[id_archivo_REGISTRO]);


        }







        // Método para editar un elemento en un string de formato arreglo multiple, recursivo
        public string EditarstringElementoEnMultiArregloRecursivo(string texto, object columnas_a_recorrer, string texto_a_sustituir, string[] caracterSeparacion = null)
        {
            //ejemplo_de_entrada
            //EditarstringElementoEnMultiArregloRecursivo(variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo][id_fila], "0|" + id_columna_editar, texto);


            //si no introdujo caracteres de separacion se usara predeterminado
            if (caracterSeparacion == null)
            {
                caracterSeparacion = G_caracter_separacion;
            }

            string[] espliteado_columnas_recorrer = { };

            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(Convert.ToChar(caracterSeparacion[0]));
            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }

            string[] espliteado_texto = texto.Split(Convert.ToChar(caracterSeparacion[0]));

            string texto_a_retornar = "";
            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            if (espliteado_columnas_recorrer.Length > 1)
            {
                string[] tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                string[] tem_array_caracter_separacion = new string[caracterSeparacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {
                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];
                    tem_array_caracter_separacion[i - 1] = caracterSeparacion[i];
                }


                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[1])] = EditarstringElementoEnMultiArregloRecursivo(texto_a_retornar, tem_array_col_recorrer, texto_a_sustituir, tem_array_caracter_separacion); // Llamada recursiva
            }
            else
            {
                //Sí es el último elemento del arreglo múltiple modifica el texto
                //para finalmente concatenarlos Con Los otros textos a retornar de la función recursiva 
                texto_a_retornar = texto_a_sustituir;
                espliteado_texto[0] = texto_a_retornar;
            }
            //Este concatena todos los resultados para el final ya tener toda la fila recuerda que es un proceso recursivo 
            texto_a_retornar = string.Join(caracterSeparacion[0], espliteado_texto);
            return texto_a_retornar;
        }

        // Método para incrementar un elemento en un string de formato arreglo multiple, recursivo
        public string incrementar_decrementar_stringElementoEnMultiArregloRecursivo(string texto, object columnas_a_recorrer, string cantidad_a_incrementar_decrementar, string[] caracterSeparacion = null)
        {
            //ejemplo_de_entrada
            //incrementar_decrementar_stringElementoEnMultiArregloRecursivo("COCA COLA|4896|°|°||||||calificacion_preventa¬0°calificacion_entrega¬0|", 0|1, "156"); // Llamada recursiva

            //si no introdujo caracteres de separacion se usara predeterminado
            if (caracterSeparacion == null)
            {
                caracterSeparacion = G_caracter_separacion;
            }

            string[] espliteado_columnas_recorrer = { };
            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(Convert.ToChar(caracterSeparacion[0]));
            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }
            string[] espliteado_texto = texto.Split(Convert.ToChar(caracterSeparacion[0]));

            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            string texto_a_retornar = "";
            if (espliteado_columnas_recorrer.Length > 1)
            {
                string[] tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                string[] tem_array_caracter_separacion = new string[caracterSeparacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {
                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];
                    tem_array_caracter_separacion[i - 1] = caracterSeparacion[i];
                }

                //espliteado_texto = texto.Split(Convert.ToChar(tem_array_caracter_separacion[0]));
                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[1])] = incrementar_decrementar_stringElementoEnMultiArregloRecursivo(texto_a_retornar, tem_array_col_recorrer, cantidad_a_incrementar_decrementar, tem_array_caracter_separacion); // Llamada recursiva


            }

            else
            {
                //Sí es el último elemento del arreglo múltiple modifica el texto
                //para finalmente concatenarlos Con Los otros textos a retornar de la función recursiva 
                texto_a_retornar = "" + (Convert.ToDouble(espliteado_texto[0]) + Convert.ToDouble(cantidad_a_incrementar_decrementar));
                espliteado_texto[0] = texto_a_retornar;
            }

            //Este concatena todos los resultados para el final ya tener toda la fila recuerda que es un proceso recursivo 
            texto_a_retornar = string.Join(caracterSeparacion[0], espliteado_texto);
            return texto_a_retornar;
        }




        //Metodo para incrementar comparando un dato igual en un arreglo multiple

        public string incrementar_decrementar_comparando_datos_stringElementoEnMultiArregloRecursivo(string texto, object columnas_a_recorrer, string id_string_al_esplitear_comparar, string comparar, string id_string_al_esplitear_editar, string cantidad_a_incrementar_decrementar, string[] caracterSeparacion = null)
        {
            //ejemplo_de_entrada
            //incrementar_decrementar_stringElementoEnMultiArregloRecursivo("COCA COLA|4896|°|°||||||calificacion_preventa¬0°calificacion_entrega¬0|", 0|1, "156"); // Llamada recursiva

            //si no introdujo caracteres de separacion se usara predeterminado
            if (caracterSeparacion == null)
            {
                caracterSeparacion = G_caracter_separacion;
            }

            string[] espliteado_columnas_recorrer = { };
            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(Convert.ToChar(caracterSeparacion[0]));
            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }
            string[] espliteado_texto = texto.Split(Convert.ToChar(caracterSeparacion[0]));

            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            string texto_a_retornar = "";
            if (espliteado_columnas_recorrer.Length > 1)
            {
                string[] tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                string[] tem_array_caracter_separacion = new string[caracterSeparacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {
                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];
                    tem_array_caracter_separacion[i - 1] = caracterSeparacion[i];
                }

                //espliteado_texto = texto.Split(Convert.ToChar(tem_array_caracter_separacion[0]));
                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[1])] = incrementar_decrementar_comparando_datos_stringElementoEnMultiArregloRecursivo(texto_a_retornar, tem_array_col_recorrer, id_string_al_esplitear_comparar, comparar, id_string_al_esplitear_editar, cantidad_a_incrementar_decrementar, tem_array_caracter_separacion); // Llamada recursiva


            }

            else
            {

                //Sí es el último elemento del arreglo múltiple modifica el texto
                //para finalmente concatenarlos Con Los otros textos a retornar de la función recursiva 

                //err__ = 1;
                //texto_a_retornar = "" + (Convert.ToDouble(espliteado_texto[id_string_al_esplitear_editar]) + Convert.ToDouble(cantidad_a_incrementar_decrementar));
                //espliteado_texto[id_string_al_esplitear_editar] = texto_a_retornar;
            }

            //Este concatena todos los resultados para el final ya tener toda la fila recuerda que es un proceso recursivo 
            texto_a_retornar = string.Join(caracterSeparacion[0], espliteado_texto);
            return texto_a_retornar;
        }

        public string incrementar_editar_MultiArregloRecursivo(string operacion, string texto, object columnas_a_recorrer, string id_string_al_esplitear_comparar, string comparar_info_del_STRING, string ids_archivo_a_editar, string cantidad_a_incrementar_decrementar, string[] caracterSeparacion = null)
        {
            //ejemplo_de_entrada
            //incrementar_decrementar_stringElementoEnMultiArregloRecursivo("COCA COLA|4896|°|°||||||calificacion_preventa¬0°calificacion_entrega¬0|", 0|1, "156"); // Llamada recursiva

            //si no introdujo caracteres de separacion se usara predeterminado
            if (caracterSeparacion == null)
            {
                caracterSeparacion = G_caracter_separacion;
            }

            string[] espliteado_columnas_recorrer = { };
            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(Convert.ToChar(caracterSeparacion[0]));
            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }
            string[] espliteado_texto = texto.Split(Convert.ToChar(caracterSeparacion[0]));

            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            string texto_a_retornar = "";


            string[] tem_array_caracter_separacion = caracterSeparacion;
            if (espliteado_columnas_recorrer.Length > 1)
            {
                string[] tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                tem_array_caracter_separacion = new string[caracterSeparacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {

                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];

                }
                for (int i = 1; i < caracterSeparacion.Length; i++)
                {
                    tem_array_caracter_separacion[i - 1] = caracterSeparacion[i];
                }

                //espliteado_texto = texto.Split(Convert.ToChar(tem_array_caracter_separacion[0]));
                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[1])] = incrementar_editar_MultiArregloRecursivo(operacion, texto_a_retornar, tem_array_col_recorrer, id_string_al_esplitear_comparar, comparar_info_del_STRING, ids_archivo_a_editar, cantidad_a_incrementar_decrementar, tem_array_caracter_separacion); // Llamada recursiva


            }

            else
            {
                //si no profundiso en el arreglo 
                if (columnas_a_recorrer is string)
                {
                    string[] id_editar = ids_archivo_a_editar.Split(Convert.ToChar(caracterSeparacion[0]));
                    string[] cant_inc_edit = cantidad_a_incrementar_decrementar.Split(Convert.ToChar(caracterSeparacion[0]));
                    if (operacion == "incrementar")
                    {
                        for (int i = 0; i < cant_inc_edit.Length; i++)
                        {
                            if (id_editar.Length == cant_inc_edit.Length)
                            {
                                espliteado_texto[Convert.ToInt32(id_editar[i])] = "" + (Convert.ToDouble(espliteado_texto[Convert.ToInt32(id_editar[i])]) + Convert.ToDouble(cant_inc_edit[i]));
                            }
                            else if (id_editar.Length == 1)
                            {
                                espliteado_texto[Convert.ToInt32(id_editar[0])] = "" + (Convert.ToDouble(espliteado_texto[Convert.ToInt32(id_editar[0])]) + Convert.ToDouble(cant_inc_edit[i]));
                            }


                        }
                    }
                    else if (operacion == "editar")
                    {
                        for (int i = 0; i < cant_inc_edit.Length; i++)
                        {
                            if (id_editar.Length == cant_inc_edit.Length)
                            {
                                espliteado_texto[Convert.ToInt32(id_editar[i])] = cant_inc_edit[i];
                            }
                            else if (id_editar.Length == 1)
                            {
                                espliteado_texto[Convert.ToInt32(id_editar[0])] = cant_inc_edit[i];
                            }


                        }
                    }

                }

                //si profundiso en  el arreglo entonses es un multiarregl y se introdujo
                else if (columnas_a_recorrer is string[] temp)
                {

                    espliteado_texto = modificacion_informacion(operacion, texto, id_string_al_esplitear_comparar, comparar_info_del_STRING, ids_archivo_a_editar, cantidad_a_incrementar_decrementar, tem_array_caracter_separacion);

                }


            }

            //Este concatena todos los resultados para el final ya tener toda la fila recuerda que es un proceso recursivo 
            texto_a_retornar = string.Join(caracterSeparacion[0], espliteado_texto);
            return texto_a_retornar;
        }


        public string[] modificacion_informacion(string operacion, string texto, string id_comp, string comparacion, string id_editar, string incremetar_editar, string[] caracterSeparacion = null)
        {
            string[] espliteado_texto = texto.Split(Convert.ToChar(caracterSeparacion[0]));
            for (int i = 0; i < espliteado_texto.Length; i++)
            {

                string[] info_del_espliteado = espliteado_texto[i].Split(Convert.ToChar(caracterSeparacion[1]));

                //modificar
                //string operacion,string texto, object columnas_a_recorrer, string id_string_al_esplitear_comparar, string comparar_info_del_STRING, string ids_archivo_a_editar, string cantidad_a_incrementar_decrementar, string[] caracterSeparacion = null
                if (id_comp != null && comparacion != null)
                {
                    string[] espliteado_id_string_al_esplitear_comparar = id_comp.Split(Convert.ToChar(caracterSeparacion[0]));
                    string[] espliteado_comparar_info_del_STRING = comparacion.Split(Convert.ToChar(caracterSeparacion[0]));

                    //si tienen la misma cantidad espliteada id_string_al_esplitear_comparar que comparar_info_del_STRING
                    if (espliteado_id_string_al_esplitear_comparar.Length == espliteado_comparar_info_del_STRING.Length)
                    {
                        for (int j = 0; j < espliteado_id_string_al_esplitear_comparar.Length; j++)
                        {
                            //mod__ aqui creo que debo comparar el que eta em eñ archivo con el de el string para que si son iguales se procede
                            //porque estoy pensando que solo se estan auto comparandose la misma variable com a==a 
                            //este es de los id_de_comparar //creo?
                            if (info_del_espliteado[Convert.ToInt32(espliteado_id_string_al_esplitear_comparar[j])] == espliteado_comparar_info_del_STRING[j])
                            {
                                string[] espliteado_ids_archivo_a_editar = id_editar.Split(Convert.ToChar(caracterSeparacion[0]));
                                string[] espliteado_cantidad_a_incrementar_decrementar = incremetar_editar.Split(Convert.ToChar(caracterSeparacion[0]));

                                //mod__ aqui creo que deberia comparar 
                                //este es de los id_de_editar
                                if (espliteado_ids_archivo_a_editar.Length == espliteado_cantidad_a_incrementar_decrementar.Length)
                                {
                                    for (int k = 0; k < espliteado_ids_archivo_a_editar.Length; k++)
                                    {
                                        //ve la funcion que esta dentro del if 

                                        if (info_del_espliteado[Convert.ToInt32(espliteado_id_string_al_esplitear_comparar[j])] == espliteado_comparar_info_del_STRING[k])
                                        {
                                            info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[k])] = funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(operacion, info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[k])], espliteado_cantidad_a_incrementar_decrementar[k]);
                                        }


                                    }
                                }

                                else if (espliteado_ids_archivo_a_editar.Length == 1)
                                {
                                    for (int k = 0; k < espliteado_cantidad_a_incrementar_decrementar.Length; k++)
                                    {
                                        if (info_del_espliteado[Convert.ToInt32(espliteado_id_string_al_esplitear_comparar[0])] == espliteado_comparar_info_del_STRING[k])
                                        {
                                            info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[0])] = funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(operacion, info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[0])], espliteado_cantidad_a_incrementar_decrementar[k]);
                                        }
                                    }
                                }

                                else
                                {
                                    string error = "espliteado_ids_archivo_a_editar debe tener solo 1 elemento o espliteado_ids_archivo_a_editar y espliteado_cantidad_a_incrementar_decrementar deben tener la misma cantidad de espliteado o ";
                                    int error_a_proposito = Convert.ToInt32(error);
                                }

                            }


                        }
                    }

                    else if (espliteado_id_string_al_esplitear_comparar.Length == 1)
                    {
                        for (int j = 0; j < espliteado_comparar_info_del_STRING.Length; j++)
                        {
                            if (info_del_espliteado[Convert.ToInt32(id_comp)] == espliteado_comparar_info_del_STRING[j])
                            {
                                string[] espliteado_ids_archivo_a_editar = id_editar.Split(Convert.ToChar(caracterSeparacion[0]));
                                string[] espliteado_cantidad_a_incrementar_decrementar = incremetar_editar.Split(Convert.ToChar(caracterSeparacion[0]));

                                //este es de los id_de_editar
                                if (espliteado_ids_archivo_a_editar.Length == espliteado_cantidad_a_incrementar_decrementar.Length)
                                {
                                    for (int k = 0; k < espliteado_cantidad_a_incrementar_decrementar.Length; k++)
                                    {
                                        //ve la funcion que esta dentro del if 

                                        if (info_del_espliteado[Convert.ToInt32(espliteado_id_string_al_esplitear_comparar[0])] == espliteado_comparar_info_del_STRING[k])
                                        {
                                            info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[k])] = funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(operacion, info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[k])], espliteado_cantidad_a_incrementar_decrementar[k]);
                                        }


                                    }
                                }

                                else if (espliteado_ids_archivo_a_editar.Length == 1)
                                {
                                    for (int k = 0; k < espliteado_cantidad_a_incrementar_decrementar.Length; k++)
                                    {
                                        if (info_del_espliteado[Convert.ToInt32(espliteado_id_string_al_esplitear_comparar[0])] == espliteado_comparar_info_del_STRING[k])
                                        {
                                            info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[0])] = funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(operacion, info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[0])], espliteado_cantidad_a_incrementar_decrementar[k]);
                                        }
                                    }
                                }

                                else
                                {
                                    string error = "espliteado_ids_archivo_a_editar debe tener solo 1 elemento o espliteado_ids_archivo_a_editar y espliteado_cantidad_a_incrementar_decrementar deben tener la misma cantidad de espliteado o ";
                                    int error_a_proposito = Convert.ToInt32(error);
                                }

                            }
                        }
                    }
                }

                else
                {
                    string[] espliteado_ids_archivo_a_editar = id_editar.Split(Convert.ToChar(caracterSeparacion[0]));
                    string[] espliteado_cantidad_a_incrementar_decrementar = incremetar_editar.Split(Convert.ToChar(caracterSeparacion[0]));

                    //mod__ aqui creo que deberia comparar 
                    //este es de los id_de_editar
                    if (espliteado_ids_archivo_a_editar.Length == espliteado_cantidad_a_incrementar_decrementar.Length)
                    {
                        for (int k = 0; k < espliteado_ids_archivo_a_editar.Length; k++)
                        {
                            //ve la funcion que esta dentro del if 


                            info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[k])] = funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(operacion, info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[k])], espliteado_cantidad_a_incrementar_decrementar[k]);



                        }
                    }

                    else if (espliteado_ids_archivo_a_editar.Length == 1)
                    {
                        for (int k = 0; k < espliteado_cantidad_a_incrementar_decrementar.Length; k++)
                        {
                            info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[0])] = funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(operacion, info_del_espliteado[Convert.ToInt32(espliteado_ids_archivo_a_editar[0])], espliteado_cantidad_a_incrementar_decrementar[k]);
                        }
                    }

                    else
                    {
                        string error = "espliteado_ids_archivo_a_editar debe tener solo 1 elemento o espliteado_ids_archivo_a_editar y espliteado_cantidad_a_incrementar_decrementar deben tener la misma cantidad de espliteado o ";
                        int error_a_proposito = Convert.ToInt32(error);
                    }
                }






                //joinear
                string ya_modificado = string.Join(caracterSeparacion[1], info_del_espliteado);
                //pasar la informacion modificada a espliteado texto para retornar
                espliteado_texto[i] = ya_modificado;
            }
            return espliteado_texto;
        }
        public string funcion_solo_utilisa_la_modificacion_informacion_editar_o_incrementar(string operacion, string info_original, string incremento_o_edicion)
        {
            if (operacion == "incrementar")
            {
                info_original = "" + (Convert.ToDouble(info_original) + Convert.ToDouble(incremento_o_edicion));
            }
            else if (operacion == "editar")
            {
                info_original = incremento_o_edicion;
            }

            return info_original;
        }
        //-----------------------------------------------------------------------------------------------

        public void cambiar_archivo_por_arreglo(string direccion, string[] arreglo)
        {
            bas.cambiar_archivo_con_arreglo(direccion, arreglo);
        }


        //-----------------------------------------------------------------------------------------------

        // Método para procesar una venta utilizando información de la lista de venta
        public void procesar_venta(string[] info_lista_venta, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            double total_venta = 0;
            double total_costo_compra = 0;

            //crea un arreglo con todos los impuestos que hay el porcentage y le agrega otra columna para poner hay lo que se va a pagar en dinero
            // La primera columna contiene el nombre del impuesto, y la segunda columna contiene el porcentaje de impuesto.
            string[] impuestos_columnas = variables_glob_conf.GG_arrays_carga_de_archivos[4][0].Split(Convert.ToChar(caracter_separacion[2]));
            // La matriz tiene un tamaño basado en la longitud de la matriz de archivos y el número de columnas de impuestos más una columna adicional para el monto de impuestos pagado.
            string[,] impuestos = new string[variables_glob_conf.GG_arrays_carga_de_archivos[4].Length, impuestos_columnas.Length + 1];
            for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[4].Length; i++)
            {
                string[] info_imp_esplit = variables_glob_conf.GG_arrays_carga_de_archivos[4][i].Split(Convert.ToChar(caracter_separacion[2]));
                impuestos[i, 0] = info_imp_esplit[0];
                impuestos[i, 1] = info_imp_esplit[1];
            }

            //aqui se encarga de dividir la informacion de cada producto de la lista para poner el texto a agregar a incremetar o a editar 

            string texto_info_producto_agregar = "";

            for (int i = 0; i < info_lista_venta.Length; i++)
            {
                // Dividir los detalles del producto en la lista de venta utilizando el caracter de separación
                string[] detalles_del_producto_lista = info_lista_venta[i].Split(Convert.ToChar(caracter_separacion[0]));

                // Obtener el índice del producto en el arreglo de carga
                int indice_producto = Convert.ToInt32(detalles_del_producto_lista[detalles_del_producto_lista.Length - 1]);

                // Dividir la información del producto en el inventario utilizando el caracter de separación global
                string[] produ_invent = variables_glob_conf.GG_arrays_carga_de_archivos[0][indice_producto].Split(Convert.ToChar(caracter_separacion[0]));



                // Construir una cadena con los detalles del producto para despues agregarla al registro de venta
                if (i < info_lista_venta.Length - 1)
                {
                    //codigo¬nombre¬cantidad¬precio_venta¬precio_compra¬provedor°codigo_2¬nombre_2¬cantidad_2¬precio_venta_2¬precio_compra_2¬provedor_2
                    texto_info_producto_agregar = texto_info_producto_agregar + produ_invent[4] + caracter_separacion[2] + produ_invent[0] + " " + produ_invent[1] + " " + produ_invent[2] + caracter_separacion[2] + detalles_del_producto_lista[5] + caracter_separacion[2] + produ_invent[3] + caracter_separacion[2] + produ_invent[6] + caracter_separacion[2] + produ_invent[7] + caracter_separacion[1];
                }
                else
                {
                    //codigo¬nombre¬cantidad¬precio_venta¬precio_compra¬provedor°codigo_2¬nombre_2¬cantidad_2¬precio_venta_2¬precio_compra_2¬provedor_2
                    texto_info_producto_agregar = texto_info_producto_agregar + produ_invent[4] + caracter_separacion[2] + produ_invent[0] + " " + produ_invent[1] + " " + produ_invent[2] + caracter_separacion[2] + detalles_del_producto_lista[5] + caracter_separacion[2] + produ_invent[3] + caracter_separacion[2] + produ_invent[6] + caracter_separacion[2] + produ_invent[7];
                }

                // Llamar al método para incrementar una celda en el archivo y arreglo
                //decrementa cantidad del producto en el inventario
                //editar_string_ARCHIVOS_y_arreglo_todo_conjunto("incrementar_decrementar_celda", variables_glob_conf.GG_dir_nom_archivos[0, 0], "-" + detalles_del_producto_lista[5], -1, "cod_barras", detalles_del_producto_lista[0], null, "cantidad", info_lista_venta[i]);

                string dinero_venta_provedor = "" + (Convert.ToDouble(detalles_del_producto_lista[5]) * Convert.ToDouble(detalles_del_producto_lista[4]));
                //editar_string_ARCHIVOS_y_arreglo_todo_conjunto("incrementar_decrementar_celda", variables_glob_conf.GG_dir_nom_archivos[1, 0], dinero_venta_provedor, -1, "provedor", produ_invent[7], null, "dinero");

                double precio_venta_multiplicado_con_cantidad_producto = (Convert.ToDouble(produ_invent[3]) * Convert.ToDouble(detalles_del_producto_lista[5]));
                total_venta = total_venta + precio_venta_multiplicado_con_cantidad_producto;

                double precio_compra_multiplicado_con_cantidad_producto = (Convert.ToDouble(produ_invent[6]) * Convert.ToDouble(detalles_del_producto_lista[5]));
                total_costo_compra = total_costo_compra + precio_compra_multiplicado_con_cantidad_producto;

                //IMPUESTOS aqui se ACUMULAN en dinero por cada tipo de impuesto 
                string[] info_impuestos_del_string = produ_invent[13].Split(Convert.ToChar(caracter_separacion[1]));
                for (int j = variables_glob_conf.GG_var_glob_int[0]; j < variables_glob_conf.GG_arrays_carga_de_archivos[4].Length; j++)
                {
                    bool esta_el_impuesto = false;
                    for (int k = 0; k < info_impuestos_del_string.Length; k++)
                    {
                        if (impuestos[j, 0] == info_impuestos_del_string[k])
                        {
                            esta_el_impuesto = true;
                            impuestos[j, impuestos_columnas.Length] = "" + (Convert.ToDouble(impuestos[j, impuestos_columnas.Length]) + ((Convert.ToDouble(impuestos[j, 1]) / 100) * precio_venta_multiplicado_con_cantidad_producto));
                            break;
                        }
                    }
                }


            }

            //aqui se crea un texto con todos los impuestos que se deven poner en el archivo de REGISTRO que contiene hora minuto segundo del registro
            string impuestos_agregar_registros = "";
            for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[4].Length; i++)
            {
                if (impuestos[i, impuestos_columnas.Length] != null)
                {
                    // impuesto_1¬cantidad_a_pagar_impuesto_1¬porcentage_de_impuesto_1°impuesto_2¬cantidad_a_pagar_impuesto_2¬porcentage_de_impuesto_2
                    impuestos_agregar_registros = impuestos_agregar_registros + impuestos[i, 0] + caracter_separacion[2] + impuestos[i, 2] + caracter_separacion[2] + impuestos[i, 1] + caracter_separacion[1];
                }
            }
            //aqui se quita el ultimo caracter de separacion para que no alla seldas de mas
            Operaciones_textos op = new Operaciones_textos();
            impuestos_agregar_registros = op.Trimend_paresido(impuestos_agregar_registros, Convert.ToChar(caracter_separacion[1]));

            //aqui se junta toda la informacion del registro para ser agregada o tratada
            //hora_min_seg | total_transaccion_vendida | costo_compra | impuesto_1¬cantidad_a_pagar_impuesto_1¬porcentage_de_impuesto_1°impuesto_2¬cantidad_a_pagar_impuesto_2¬porcentage_de_impuesto_2 | codigo¬nombre¬cantidad¬precio_venta¬precio_compra°codigo_2¬nombre_2¬cantidad_2¬precio_venta_2¬precio_compra_2 | total_venta | total_compra|alguna_informacion
            string text_agregar = DateTime.Now.ToString("HH:mm:ss") + caracter_separacion[0] + total_venta + caracter_separacion[0] + total_costo_compra + caracter_separacion[0] + impuestos_agregar_registros + caracter_separacion[0] + texto_info_producto_agregar + caracter_separacion[0] + "";

            modelo_de_registros_venta(text_agregar);

        }


        public void procesar_compra(string[] info_lista_venta, string caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion[0];
            }
            for (int i = 0; i < info_lista_venta.Length; i++)
            {
                string[] detalles_del_producto_lista = info_lista_venta[i].Split(Convert.ToChar(caracter_separacion));
                int indice_producto = Convert.ToInt32(detalles_del_producto_lista[detalles_del_producto_lista.Length - 1]);
                string[] produ_invent = variables_glob_conf.GG_arrays_carga_de_archivos[0][indice_producto].Split(Convert.ToChar(caracter_separacion[0]));

                if (produ_invent[5] != detalles_del_producto_lista[0])
                {
                    produ_invent = extraer_info_e_indise(detalles_del_producto_lista[0]);

                    if (produ_invent[0] == null)
                    {
                        return;
                    }
                    //producto|cant_produc|tipo_medida|precio_venta|cod_barras|cantidad|costo_comp|provedor|grupo|no poner nada|cant_produc_x_paquet|tipo_de_producto|ligar_produc_sab|impuestos|parte_de_que_producto
                    produ_invent = produ_invent[0].Split(Convert.ToChar(caracter_separacion[0]));


                }



                //producto|cant_produc|tipo_medida|precio_venta|cod_barras|cantidad|costo_comp|provedor|grupo|no poner nada|cant_produc_x_paquet|tipo_de_producto|ligar_produc_sab|impuestos|parte_de_que_producto


            }

        }

        // Método para agregar un registro a un arreglo de strings
        public string[] agregar_registro_del_array(string[] arreglo, string registro)
        {
            string[] temp = { "" };

            //Este if es por si no tienen nada el arreglo Agrega el registro inicial 
            if (arreglo == null)
            {
                arreglo = new string[] { "" };// Crear un nuevo arreglo con un elemento vacío
                temp = new string[arreglo.Length];

                // Copiar los elementos del arreglo original al arreglo temporal
                for (int i = 0; i < arreglo.Length; i++)
                {
                    temp[i] = arreglo[i];
                }

                // Agregar el nuevo registro al último elemento del arreglo temporal
                temp[arreglo.Length - 1] = registro;

            }
            //Este si tiene datos el arreglo le agrega otro registro más 
            else
            {
                temp = new string[arreglo.Length + 1];

                for (int i = 0; i < arreglo.Length; i++)
                {
                    temp[i] = arreglo[i];
                }

                temp[arreglo.Length] = registro;
            }

            return temp;
        }

        public string[] chequeo_datos_esten_en_archivo_retorna_toda_la_fila(string info_texto, string columna_a_recorer_del_string, int id_arreglo_archivo, string columna_a_recorer_del_archivo, string[] caracter_separacion_del_string = null, string[] caracter_separacion_del_archivo = null)
        {

            if (caracter_separacion_del_string == null)
            {
                caracter_separacion_del_string = G_caracter_separacion;
            }
            if (caracter_separacion_del_archivo == null)
            {
                caracter_separacion_del_archivo = G_caracter_separacion;
            }

            string[] info_spliteado_del_string = info_texto.Split(Convert.ToChar(caracter_separacion_del_string[0]));
            //aqui se extrae el arreglo de la info del las columnas recorridas
            string[] columnas_del_string = columna_a_recorer_del_string.Split(Convert.ToChar(caracter_separacion_del_string[0]));

            int id_columna_recorrida_string = 1; //esta es la inicialisasion del for se hace arriba para poder usar la variable despues 
            for (; id_columna_recorrida_string < columnas_del_string.Length; id_columna_recorrida_string++)
            {
                info_spliteado_del_string = info_spliteado_del_string[Convert.ToInt32(columnas_del_string[id_columna_recorrida_string])].Split(Convert.ToChar(caracter_separacion_del_string[id_columna_recorrida_string]));

            }



            //este es el de extraccion informacion del archivo
            string[] retornar_fila = null;
            for (int id_resul_del_string = 0; id_resul_del_string < info_spliteado_del_string.Length; id_resul_del_string++)
            {




                for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo].Length; i++)
                {
                    string[] info_spliteado_del_archivo = variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo][i].Split(Convert.ToChar(caracter_separacion_del_archivo[0]));

                    //aqui se extrae el arreglo de la info del las columnas recorridas
                    string[] columnas_del_archivo = columna_a_recorer_del_archivo.Split(Convert.ToChar(caracter_separacion_del_archivo[0]));




                    //aqui la comparacion para ver si existe o no
                    if (info_spliteado_del_archivo[0] == info_spliteado_del_string[id_resul_del_string])
                    {

                        return retornar_fila = new string[] { variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo][i], "" + i };

                    }

                }

            }

            return retornar_fila;
        }

        public string[] chequeo_datos_esten_en_archivo_retorna_todo_el_texto_que_ingresaste_faltante(string info_texto, string columna_a_recorer_del_string, int id_arreglo_archivo, string columna_a_recorer_del_archivo, string[] caracter_separacion_del_string = null, string[] caracter_separacion_del_archivo = null)
        {

            if (caracter_separacion_del_string == null)
            {
                caracter_separacion_del_string = G_caracter_separacion;
            }
            if (caracter_separacion_del_archivo == null)
            {
                caracter_separacion_del_archivo = G_caracter_separacion;
            }

            string[] info_spliteado_del_string = info_texto.Split(Convert.ToChar(caracter_separacion_del_string[0]));
            //aqui se extrae el arreglo de la info del las columnas recorridas
            string[] columnas_del_string = columna_a_recorer_del_string.Split(Convert.ToChar(caracter_separacion_del_string[0]));

            int id_columna_recorrida_string = 1; //esta es la inicialisasion del for se hace arriba para poder usar la variable despues 
            for (; id_columna_recorrida_string < columnas_del_string.Length; id_columna_recorrida_string++)
            {
                info_spliteado_del_string = info_spliteado_del_string[Convert.ToInt32(columnas_del_string[id_columna_recorrida_string])].Split(Convert.ToChar(caracter_separacion_del_string[id_columna_recorrida_string]));

            }



            //este es el de extraccion informacion del archivo
            string[] faltantes_a_retornar = null;
            for (int id_resul_del_string = 0; id_resul_del_string < info_spliteado_del_string.Length; id_resul_del_string++)
            {


                bool se_encontro_el_producto = false;

                for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo].Length; i++)
                {
                    string[] info_spliteado_del_archivo = variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo][i].Split(Convert.ToChar(caracter_separacion_del_archivo[0]));

                    //aqui se extrae el arreglo de la info del las columnas recorridas
                    string[] columnas_del_archivo = columna_a_recorer_del_archivo.Split(Convert.ToChar(caracter_separacion_del_archivo[0]));

                    int id_columna_recorrida_archivo = 1; //esta es la inicialisasion del for se hace arriba para poder usar la variable despues 
                    for (; id_columna_recorrida_archivo < columnas_del_archivo.Length; id_columna_recorrida_archivo++)
                    {
                        info_spliteado_del_archivo = info_spliteado_del_archivo[Convert.ToInt32(columnas_del_archivo[id_columna_recorrida_archivo])].Split(Convert.ToChar(caracter_separacion_del_archivo[id_columna_recorrida_archivo]));

                    }


                    //aqui la comparacion para ver si existe o no
                    if (info_spliteado_del_archivo[0] == info_spliteado_del_string[0])
                    {
                        se_encontro_el_producto = true;
                        break;
                    }

                }


                if (se_encontro_el_producto == false)
                {
                    faltantes_a_retornar = agregar_registro_del_array(faltantes_a_retornar, info_texto);
                }

            }

            return faltantes_a_retornar;
        }

        public string[] chequeo_datos_esten_en_archivo_retorna_solo_el_elemento_buscado_faltantes(string info_texto, string columna_a_recorer_del_string, int id_arreglo_archivo, string columna_a_recorer_del_archivo, string[] caracter_separacion_del_string = null, string[] caracter_separacion_del_archivo = null)
        {

            if (caracter_separacion_del_string == null)
            {
                caracter_separacion_del_string = G_caracter_separacion;
            }
            if (caracter_separacion_del_archivo == null)
            {
                caracter_separacion_del_archivo = G_caracter_separacion;
            }

            string[] info_spliteado_del_string = info_texto.Split(Convert.ToChar(caracter_separacion_del_string[0]));
            //aqui se extrae el arreglo de la info del las columnas recorridas
            string[] columnas_del_string = columna_a_recorer_del_string.Split(Convert.ToChar(caracter_separacion_del_string[0]));

            int id_columna_recorrida_string = 1; //esta es la inicialisasion del for se hace arriba para poder usar la variable despues 
            for (; id_columna_recorrida_string < columnas_del_string.Length; id_columna_recorrida_string++)
            {
                info_spliteado_del_string = info_spliteado_del_string[Convert.ToInt32(columnas_del_string[id_columna_recorrida_string])].Split(Convert.ToChar(caracter_separacion_del_string[id_columna_recorrida_string]));

            }



            //este es el de extraccion informacion del archivo
            string[] faltantes_a_retornar = null;
            for (int id_resul_del_string = 0; id_resul_del_string < info_spliteado_del_string.Length; id_resul_del_string++)
            {


                bool se_encontro_el_producto = false;

                for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo].Length; i++)
                {
                    string[] info_spliteado_del_archivo = variables_glob_conf.GG_arrays_carga_de_archivos[id_arreglo_archivo][i].Split(Convert.ToChar(caracter_separacion_del_archivo[0]));

                    //aqui se extrae el arreglo de la info del las columnas recorridas
                    string[] columnas_del_archivo = columna_a_recorer_del_archivo.Split(Convert.ToChar(caracter_separacion_del_archivo[0]));




                    //aqui la comparacion para ver si existe o no
                    if (info_spliteado_del_archivo[0] == info_spliteado_del_string[id_resul_del_string])
                    {
                        se_encontro_el_producto = true;
                        break;
                    }

                }


                if (se_encontro_el_producto == false)
                {
                    faltantes_a_retornar = agregar_registro_del_array(faltantes_a_retornar, info_spliteado_del_string[id_resul_del_string]);
                }

            }

            return faltantes_a_retornar;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public string[] extraer_info_e_indise(string cod_bar, string caracter_separacion = null)
        {

            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion[0];
            }

            string[] informacionProducto = { null, null };

            bool encontrado = false;
            for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[0].Length; i++)
            {
                string[] producto_espliteado = variables_glob_conf.GG_arrays_carga_de_archivos[0][i].Split(Convert.ToChar(caracter_separacion));
                if (producto_espliteado[5] == cod_bar)
                {
                    informacionProducto[0] = variables_glob_conf.GG_arrays_carga_de_archivos[0][i];
                    informacionProducto[1] = "" + i;
                    encontrado = true;
                    break;
                }
            }

            if (encontrado == false) {/*hacer algo si no lo encuentra*/}

            return informacionProducto;
        }

    }
}
