using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using chatbot_wathsapp.desinger;

using chatbot_wathsapp.procesos;


namespace chatbot_wathsapp.modelos
{
    class model
    {
        string[] G_caracter_separacion = variables_glob_conf.GG_caracter_separacion;

        procesamientos pr = new procesamientos();

        //----------------------------  ---------------------------------------------------

        public object modelo_unico(string operacion, string[] descripcion_arreglo_opcional = null, string[][] arreglos_de_entrada = null, string[] informacion_de_variables = null, string ubicacion_rapida = null, string texto_rapido = null)
        {
            object objeto_a_retornar = null;
            //funciones a hacer
            //--------------------------------------------------------------------------------------------------------------
            //"crear_archivos_inicio"
            //----------------------------------------------------------------------------------------------------------------

            //-----------------------------------------------------------------------------------------------------------
            //"pasar_arreglo_a_archivo"
            //direccion_rapido
            //informacion_de_variables//este es arreglo pero se pasa todo el arreglo
            //------------------------------------------------------------------------------------------------------------
            //agregar_string_al_archivo
            //direccion_rapido = string direccion
            //texto_rapido = string texto
            //-----------------------------------------------------------------------------------------------------------
            //agregar_string_al_inventario
            //texto_rapido = string texto

            if (operacion == "crear_archivos_inicio")
            {
                pr.crear_archivos_inicio_programa();
            }

            else if (operacion == "pasar_arreglo_a_archivo")
            {
                if (ubicacion_rapida != null && informacion_de_variables != null)
                {
                    pr.cambiar_archivo_por_arreglo(ubicacion_rapida, informacion_de_variables);
                }
                else
                {
                    // Manejar el caso cuando faltan parámetros requeridos para la operación "pasar_arreglo_a_archivo"
                }
            }

            else if (operacion == "agregar_string_al_archivo")
            {
                if (ubicacion_rapida != null && texto_rapido != null)
                {
                    pr.agregar_string_ARCHIVOS(ubicacion_rapida, texto_rapido);
                }
                else
                {
                    // Manejar el caso cuando faltan parámetros requeridos para la operación "agregar_string_al_archivo"
                }
            }

            else if (operacion == "agregar_string_al_inventario")
            {
                if (texto_rapido != null)
                {
                    pr.agregar_string_ARCHIVOS(variables_glob_conf.GG_dir_nom_archivos[0, 0], texto_rapido);
                }
                else
                {
                    // Manejar el caso cuando falta el parámetro requerido para la operación "agregar_string_al_inventario"
                }
            }

            else if (operacion == "mod_form_chequeo_info_producto_nuevo")
            {
                mod_form_chequeo_dat_nuevo_produc(texto_rapido);
            }

            else if (operacion == "mod_chequeo_info_arch")
            {

                if (texto_rapido != null)
                {
                    objeto_a_retornar = mod_chequeo_info_arch(ubicacion_rapida, texto_rapido);
                }
                else
                {
                    // Manejar el caso cuando falta el parámetro requerido para la operación "agregar_string_al_inventario"
                }
            }

            else if (operacion == "cantidad_venta_compra_resultado")
            {

                int cantidad = variables_glob_conf.GG_arrays_carga_de_archivos[3].Length - 1;
                string[] inf_espliteado = variables_glob_conf.GG_arrays_carga_de_archivos[3][cantidad].Split(Convert.ToChar(G_caracter_separacion[1]));
                if (inf_espliteado[0] == DateTime.Now.ToString("yyyyMMdd"))
                {
                    objeto_a_retornar = variables_glob_conf.GG_arrays_carga_de_archivos[3][cantidad];
                }
                else
                {
                    string datos = DateTime.Now.ToString("yyyyMMdd") + G_caracter_separacion[1] + "0" + G_caracter_separacion[1] + "0";
                    pr.agregar_string_ARCHIVOS(variables_glob_conf.GG_dir_nom_archivos[3, 0], datos);
                    objeto_a_retornar = datos;

                }

            }
            //mod_comp_vent------------------------------------------------------------------------------------------

            else if (operacion == "mod_venta")
            {
                if (informacion_de_variables != null)
                {
                    pr.procesar_venta(informacion_de_variables);
                }
                else
                {
                    // Manejar el caso cuando falta el parámetro requerido para la operación "agregar_string_al_inventario"
                }

            }

            else if (operacion == "mod_compra")
            {
                if (informacion_de_variables != null)
                {
                    pr.procesar_compra(informacion_de_variables);
                }
                else
                {
                    // Manejar el caso cuando falta el parámetro requerido para la operación "agregar_string_al_inventario"
                }

            }

            //fin mod_comp_vent--------------------------------------------------------------------------------------


            else
            {
                // Manejar el caso cuando se proporciona una operación no válida
            }


            return objeto_a_retornar;

        }


        public void mod_form_chequeo_dat_nuevo_produc(string datos_introducidos)
        {
            modelo_unico("mod_chequeo_info_arch", ubicacion_rapida: "chequeo_provedor_sino_agrega", texto_rapido: datos_introducidos);
            modelo_unico("mod_chequeo_info_arch", ubicacion_rapida: "chequeo_tipo_medida_sino_agrega", texto_rapido: datos_introducidos);
            modelo_unico("mod_chequeo_info_arch", ubicacion_rapida: "form_chequeo_impuesto_sino_agrega", texto_rapido: datos_introducidos);
        }

        private string[] mod_chequeo_info_arch(string operacion, string texto, string[] info_extra = null, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            string[] arreglo_a_retornar = null;
            //pr.chequeo_datos_esten_en_archivo("1|1|2|3|4|5|6|7|8|venta_ingrediente||11|12¬0°0_5¬1|13|14°14|15", "0|12", 0, 0, "0",5);
            if (operacion == "chequeo_info_en_archivo")
            {
                arreglo_a_retornar = pr.chequeo_datos_esten_en_archivo_retorna_todo_el_texto_que_ingresaste_faltante(texto, "0|12", 0, "0");
            }


            else if (operacion == "chequeo_provedor_sino_agrega")
            {
                arreglo_a_retornar = pr.chequeo_datos_esten_en_archivo_retorna_solo_el_elemento_buscado_faltantes(texto, "0|7", 1, "0");
                if (arreglo_a_retornar != null)
                {
                    string[] texto_espliteado = texto.Split(Convert.ToChar(caracter_separacion[0]));
                    //provedor|dinero|dias_de_preventa_0°dias_de_preventa_1|dias_de_entrega_0°dias_de_entrega_1|id_de_empleado|nombre_y_apellidos|numero_celular_de_provedor|numero_de_telefono_para_reporte|direccion_empresa|calificacion_preventa¬0°calificacion_entrega¬0|comentarios_preventa_entrega
                    string info_a_agregar = arreglo_a_retornar[0] + caracter_separacion[0] + "0" + caracter_separacion[0] + "" + caracter_separacion[1] + "" + caracter_separacion[0] + "" + caracter_separacion[1] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "" + caracter_separacion[0] + "calificacion_preventa¬0" + caracter_separacion[1] + "calificacion_entrega¬0" + caracter_separacion[0] + "";
                    modelo_unico("agregar_string_al_archivo", ubicacion_rapida: variables_glob_conf.GG_dir_nom_archivos[1, 0], texto_rapido: info_a_agregar);

                }
            }

            else if (operacion == "chequeo_tipo_medida_sino_agrega")
            {
                arreglo_a_retornar = pr.chequeo_datos_esten_en_archivo_retorna_solo_el_elemento_buscado_faltantes(texto, "0|2", 5, "0|0");
                if (arreglo_a_retornar != null)
                {
                    modelo_unico("agregar_string_al_archivo", ubicacion_rapida: variables_glob_conf.GG_dir_nom_archivos[5, 0], texto_rapido: arreglo_a_retornar[0]);

                }
            }



            else if (operacion == "form_chequeo_y_agregar_codbar_si_no_esta")
            {

                arreglo_a_retornar = pr.chequeo_datos_esten_en_archivo_retorna_todo_el_texto_que_ingresaste_faltante(texto, "0|5", 0, "0|5");
                variables_glob_conf.GG_variables_string[0] = arreglo_a_retornar[0];


                if (arreglo_a_retornar[0] != "" && arreglo_a_retornar.Length < 1)
                {
                    Ventana_emergente emergent_ventana = new Ventana_emergente();

                    string info_a_agregar = emergent_ventana.Proceso_ventana_emergente(variables_glob_conf.GG_ventana_emergente_productos);
                    modelo_unico("agregar_string_al_inventario", texto_rapido: info_a_agregar);
                }

            }

            else if (operacion == "form_chequeo_impuesto_sino_agrega")
            {
                string[] caracter_sep_impuestos = { "¬" };
                arreglo_a_retornar = pr.chequeo_datos_esten_en_archivo_retorna_solo_el_elemento_buscado_faltantes(texto, "0|13", 4, "0|0", caracter_separacion_del_archivo: caracter_sep_impuestos);
                if (arreglo_a_retornar != null)
                {
                    for (int j = 0; j < arreglo_a_retornar.Length; j++)
                    {

                        Ventana_emergente vent_emer = new Ventana_emergente();
                        string[] enviar = { "1" + G_caracter_separacion[0] + "porsentaje_impuesto" + G_caracter_separacion[0] + "0" };
                        string porcentaje = vent_emer.Proceso_ventana_emergente(enviar, "impuesto: " + arreglo_a_retornar[j]);
                        string impuesto_y_porcentaje = arreglo_a_retornar[j] + G_caracter_separacion[2] + porcentaje;


                        modelo_unico("agregar_string_al_archivo", ubicacion_rapida: variables_glob_conf.GG_dir_nom_archivos[4, 0], texto_rapido: impuesto_y_porcentaje);


                    }
                }


            }



            return arreglo_a_retornar;
        }





        //-------------------------------------------------------------------------------



    }
}
