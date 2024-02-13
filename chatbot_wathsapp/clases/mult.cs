using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chatbot_wathsapp.clases.herramientas;

namespace chatbot_wathsapp.clases
{
    class mult
    {
        Tex_base bas = new Tex_base();
        operaciones_arreglos op_arreglos = new operaciones_arreglos();
        operaciones_textos op_textos = new operaciones_textos();
        var_fun_GG var_GG = new var_fun_GG();
        /*
        
        
        
        */
        //string G_direccion_negocio = "config\\sismul2\\negocio.txt";
        string G_direccion_negocio = Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0];
        //string G_direccion_patrocinadores_complejos = "config\\sismul2\\patrocinadores_complejos.txt";
        string G_direccion_patrocinadores_complejos = Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[3, 0];
        //string G_direccion_porcentages = "config\\sismul2\\porcentajes\\porcentajes.txt";
        string G_direccion_porcentages = Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[4, 0];



        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;


        public void registro_simple(string direccion, string id_encargado_simple, string tabla_simple, string[] datos, double dinero_registro = 0, object caracter_separacion_objeto = null, bool regis = true)
        {

            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string datos_usuario = "";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i > datos.Length - 1)
                {
                    datos_usuario = datos_usuario + datos[i] + caracter_separacion[1];
                }
                else
                {
                    datos_usuario = datos_usuario + datos[i];
                }
            }

            int indice_de_la_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            int cantidad_de_registros = Tex_base.GG_base_arreglo_de_arreglos[indice_de_la_base].Length;
            //                      0_id_usuario                  |       1_id_patrocinador_complejo|                 2_tabla_patrocinador_complejo           |               3_id_encargado_simple           |       4_tabla_encargado_simple    |                       5_diner                 |                 6_pago_directo    |            7_pago_indirecto     |                      8_datos                  |        9_encargados     |
            string info_a_agregar = cantidad_de_registros + caracter_separacion[0] + "0" + caracter_separacion[0] + "patrocinadores_complejos" + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0] + tabla_simple + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + "0" + caracter_separacion[0] + "0" + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + "" + caracter_separacion[0];
            bas.Agregar(direccion, info_a_agregar);

            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_textos.joineada_paraesida_y_quitador_de_extremos_del_string(direccion_espliteada, "\\", 2);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + "\\reg\\" + año_mes_dia + "registro_simple_mov.txt";
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir, "registro_simple|dir_tabla|id_usuario|datos_usuario|dinero_registro|id_encargado_simple|", leer_y_agrega_al_arreglo: false);
                string info_movimiento = "registro_simple" + caracter_separacion[0] + direccion + caracter_separacion[0] + cantidad_de_registros + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0];
                bas.Agregar_a_archivo_sin_arreglo(dir, info_movimiento);
            }
        }

        public void registro_complejo(string direccion, string id_encargado_simple, string tabla_simple, string id_encargado_complejo, string tabla_complejo, string[] datos, double dinero_registro = 0, object caracter_separacion_objeto = null, bool regis = true)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            string datos_usuario = "";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i > datos.Length - 1)
                {
                    datos_usuario = datos_usuario + datos[i] + caracter_separacion[1];
                }
                else
                {
                    datos_usuario = datos_usuario + datos[i];
                }
            }

            int indice_de_la_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            int cantidad_de_registros = Tex_base.GG_base_arreglo_de_arreglos[indice_de_la_base].Length;
            //                      0_id_usuario                  |       1_id_patrocinador_complejo|                 2_tabla_patrocinador_complejo           |               3_id_encargado_simple           |       4_tabla_encargado_simple    |                       5_diner                 |                 6_pago_directo    |            7_pago_indirecto     |                      8_datos                  |        9_encargados     |
            string info_a_agregar = cantidad_de_registros + caracter_separacion[0] + id_encargado_complejo + caracter_separacion[0] + tabla_complejo + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0] + tabla_simple + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + "0" + caracter_separacion[0] + "0" + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + "" + caracter_separacion[0];



            bas.Agregar(direccion, info_a_agregar);




            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_textos.joineada_paraesida_y_quitador_de_extremos_del_string(direccion_espliteada, "\\", 2);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + "\\reg\\" + año_mes_dia + "registro_simple_mov.txt";
                bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(dir, "registro_simple|dir_tabla|id_usuario|datos_usuario|dinero_registro|id_encargado_simple|", leer_y_agrega_al_arreglo: false);
                string info_movimiento = "registro_complejo" + caracter_separacion[0] + direccion + caracter_separacion[0] + cantidad_de_registros + caracter_separacion[0] + datos_usuario + caracter_separacion[0] + dinero_registro + caracter_separacion[0] + id_encargado_simple + caracter_separacion[0] + id_encargado_complejo + caracter_separacion[0];
                bas.Agregar_a_archivo_sin_arreglo(dir, info_movimiento);
            }
        }



        public void entrada_dinero_simple_y_complejo(string direccion_enc_simple, string id_usuario_simple, string cantidad_dinero_string, string direccion_enc_complejo = null, string porsentage_comision_por_venta = null, string porsentajes_de_comision_encargados_simp = null, string porsentajes_de_comision_encargados_complejo = null, object caracter_separacion_objeto = null, bool regis = true)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            string[] fila_espliteada = bas.seleccionar(direccion_enc_simple, 0, id_usuario_simple).Split(caracter_separacion[0][0]);
            string textos_a_repetir = "0" + caracter_separacion[0] + "7" + caracter_separacion[0] + "1";
            string[,] a_pagar = null;

            string[] res_comp = null;
            //simple-----------------------------------------------------------------------------------------------------------------------

            int indice_de_porcentages = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direccion_porcentages));
            //string[] porcentage_simple_esp = Tex_base.GG_base_arreglo_de_arreglos[4][2].Split(caracter_separacion[0][0]);
            string[] porcentage_simple_esp = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][2].Split(caracter_separacion[0][0]);
            string enc_simples = extraer_patrosinadores_funcion_recursiva(direccion_enc_simple, 0, id_usuario_simple, 3, porcentage_simple_esp.Length, G_separador_para_funciones_espesificas_[0]);
            string[] acum_simple = acumulador_de_strings(textos_a_repetir, porcentage_simple_esp.Length, caracter_separacion_devolvera_2: G_separador_para_funciones_espesificas_[0]);


            //complejo---------------------------------------------------------------------------------------------------------------------------

            if (direccion_enc_complejo != null)
            {
                string[] porcentaje_complejo_esp = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][3].Split(caracter_separacion[0][0]);
                string enc_complejos = extraer_patrosinadores_funcion_recursiva(direccion_enc_complejo, 0, fila_espliteada[3], 3, porcentaje_complejo_esp.Length, G_separador_para_funciones_espesificas_[0]);
                string[] acum_complejo = acumulador_de_strings(textos_a_repetir, porcentaje_complejo_esp.Length, caracter_separacion_devolvera_2: G_separador_para_funciones_espesificas_[0]);

                a_pagar = calc_din_por_enc_y_total(enc_simples, cantidad_dinero_string, enc_complejos, car_sep_para_retornar: G_separador_para_funciones_espesificas_[0]);
                int indice_arch_pat_comp = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direccion_patrocinadores_complejos));
                res_comp = op_arreglos.busqueda_multiple_edicion_multiple_arreglo_profunda(Tex_base.GG_base_arreglo_de_arreglos[indice_arch_pat_comp], acum_complejo[0], enc_complejos, acum_complejo[1], a_pagar[0, 1], acum_complejo[2], caracter_separacion_para_busqueda_multiple_profuda: G_separador_para_funciones_espesificas_[0]);
                bas.cambiar_archivo_con_arreglo(direccion_enc_complejo, res_comp);
            }
            else
            {
                a_pagar = calc_din_por_enc_y_total(enc_simples, cantidad_dinero_string, null, car_sep_para_retornar: G_separador_para_funciones_espesificas_[0]);

            }

            int indice_negocio = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direccion_negocio));
            string[] res_simp = op_arreglos.busqueda_multiple_edicion_multiple_arreglo_profunda(Tex_base.GG_base_arreglo_de_arreglos[indice_negocio], acum_simple[0], enc_simples, acum_simple[1], a_pagar[0, 0], acum_simple[2], caracter_separacion_para_busqueda_multiple_profuda: G_separador_para_funciones_espesificas_[0]);
            bas.cambiar_archivo_con_arreglo(direccion_enc_simple, res_simp);

            if (porsentage_comision_por_venta != null)
            {
                string cant_incr = "" + (Convert.ToDouble(porsentage_comision_por_venta) / 100) * Convert.ToDouble(cantidad_dinero_string);
                bas.Editar_o_incr_espesifico_si_no_esta_agrega_linea(direccion_enc_simple, 0, id_usuario_simple, "7", cant_incr, "1");
            }

            if (regis == true)
            {


                //string datos = "entrada_de_dinero_simple" + G_sep_fun_esp + " id_usuario:" + id_usuario_simple + caracter_separacion[0] + "dinero_introducido:" + cantidad_dinero_string + caracter_separacion[0] + "encargados_simples: " + encargados_simples + cantidad_dinero_string + caracter_separacion[0] + "encargados complejos: " + encargados_complejos;
                //var_GG.GG_registros(direccion_enc_simple, datos);


            }
        }

        public string extraer_patrosinadores_funcion_recursiva(string direccion, int columna_a_comparar_usuario, string id_comparar_usuario, int columna_patrocinadores, int cantidad_patrocinadores_a_extraer, string car_sep_para_retornar = null, object caracter_separacion_objeto = null, bool no_cambiar = true)
        {

            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);

            int indice_de_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));

            string ids_pat_a_retornar = null;
            for (int j = 0; j < cantidad_patrocinadores_a_extraer; j++)
            {
                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[indice_de_base].Length; i++)
                {
                    string[] fila_espliteada = Tex_base.GG_base_arreglo_de_arreglos[indice_de_base][i].Split(caracter_separacion[0][0]);
                    if (fila_espliteada[columna_a_comparar_usuario] == id_comparar_usuario)
                    {
                        if (cantidad_patrocinadores_a_extraer > 0)
                        {
                            //que caracter se usara para separar los patrocinadores
                            if (car_sep_para_retornar == null)
                            {
                                string temp = extraer_patrosinadores_funcion_recursiva(direccion, columna_a_comparar_usuario, fila_espliteada[columna_patrocinadores], columna_patrocinadores, cantidad_patrocinadores_a_extraer - 1, car_sep_para_retornar, no_cambiar: false);
                                if (temp == null)
                                {
                                    ids_pat_a_retornar = fila_espliteada[columna_patrocinadores] + temp;
                                }
                                else
                                {
                                    ids_pat_a_retornar = fila_espliteada[columna_patrocinadores] + caracter_separacion[0] + temp;
                                }


                            }
                            else
                            {
                                string temp = extraer_patrosinadores_funcion_recursiva(direccion, columna_a_comparar_usuario, fila_espliteada[columna_patrocinadores], columna_patrocinadores, cantidad_patrocinadores_a_extraer - 1, car_sep_para_retornar, no_cambiar: false);
                                if (temp == null)
                                {
                                    ids_pat_a_retornar = fila_espliteada[columna_patrocinadores] + temp;
                                }
                                else
                                {
                                    ids_pat_a_retornar = fila_espliteada[columna_patrocinadores] + car_sep_para_retornar + temp;
                                }

                            }
                            return ids_pat_a_retornar;
                        }
                    }
                }
            }
            return ids_pat_a_retornar;
        }

        public string[,] calc_din_por_enc_y_total(string encargados_simple, string dinero, string encargados_complejo = null, string porsentajes_de_comision_encargados_simp = null, string porsentajes_de_comision_encargados_complejo = null, string comision_venta_dir_compleja = null, string car_sep_para_retornar = null, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            int indice_de_porcentages = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_direccion_porcentages));
            if (comision_venta_dir_compleja == null)
            {
                comision_venta_dir_compleja = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][4];
            }

            if (porsentajes_de_comision_encargados_simp == null)
            {
                porsentajes_de_comision_encargados_simp = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][2];
            }
            if (porsentajes_de_comision_encargados_complejo == null)
            {
                porsentajes_de_comision_encargados_complejo = Tex_base.GG_base_arreglo_de_arreglos[indice_de_porcentages][3];
            }


            string[] porsentajes_de_comision_encargados_simp_ESPLITEADO = porsentajes_de_comision_encargados_simp.Split(caracter_separacion[0][0]);
            string[] porsentajes_de_comision_encargados_complejo_ESPLITEADO = porsentajes_de_comision_encargados_complejo.Split(caracter_separacion[0][0]);



            string info_a_devolver = null;
            double total_acumulado = 0;

            string[,] arreglo_bidimencional = null;
            double dinero_a_devolver_a_enc_complejos;
            for (int i = 0; i < porsentajes_de_comision_encargados_simp_ESPLITEADO.Length; i++)
            {

                double dinero_a_devolver = (Convert.ToDouble(porsentajes_de_comision_encargados_simp_ESPLITEADO[i]) / 100) * Convert.ToDouble(dinero);

                if (i < porsentajes_de_comision_encargados_simp_ESPLITEADO.Length - 1)
                {

                    info_a_devolver = info_a_devolver + dinero_a_devolver + car_sep_para_retornar;
                }
                else
                {
                    info_a_devolver = info_a_devolver + dinero_a_devolver + "";
                }
                total_acumulado = total_acumulado + dinero_a_devolver;
            }



            if (encargados_complejo != null && comision_venta_dir_compleja != null)
            {
                info_a_devolver = info_a_devolver + G_separador_para_funciones_espesificas_[1];

                for (int i = 0; i < porsentajes_de_comision_encargados_complejo_ESPLITEADO.Length; i++)
                {
                    double dinero_a_devolver = (Convert.ToDouble(porsentajes_de_comision_encargados_complejo_ESPLITEADO[i]) / 100) * (Convert.ToDouble(dinero) * (Convert.ToDouble(comision_venta_dir_compleja) / 100));
                    if (i < porsentajes_de_comision_encargados_complejo_ESPLITEADO.Length - 1)
                    {
                        info_a_devolver = info_a_devolver + dinero_a_devolver + car_sep_para_retornar;
                    }
                    else
                    {

                        info_a_devolver = info_a_devolver + dinero_a_devolver + "";
                    }
                    total_acumulado = total_acumulado + dinero_a_devolver;
                }
            }
            else
            {
                info_a_devolver = info_a_devolver + G_separador_para_funciones_espesificas_[1] + "falto_encargados_complejo_O_comision_venta_dir_compleja";
            }
            info_a_devolver = info_a_devolver + G_separador_para_funciones_espesificas_[1] + total_acumulado;
            arreglo_bidimencional = op_arreglos.agregar_registro_del_array_bidimensional(arreglo_bidimencional, info_a_devolver, G_separador_para_funciones_espesificas_[1]);


            return arreglo_bidimencional;
        }


        public string[] acumulador_de_strings(string texto, int veces, object caracter_separacion_objeto = null, object caracter_separacion_devolvera_2 = null)
        {
            string[] caracter_separacion = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto);
            string[] caracter_separacion_devolvera = var_GG.GG_funcion_caracter_separacion(caracter_separacion_devolvera_2);
            string[] texto_espliteado = texto.Split(caracter_separacion[0][0]);

            string[] tex_a_retornar = new string[texto_espliteado.Length];

            for (int j = 0; j < texto_espliteado.Length; j++)
            {
                string acumulador = "";
                for (int i = 0; i < veces; i++)
                {
                    if (i < veces - 1)
                    {
                        acumulador = acumulador + texto_espliteado[j] + caracter_separacion_devolvera[0];
                    }
                    else
                    {
                        acumulador = acumulador + texto_espliteado[j];
                    }

                }
                tex_a_retornar[j] = acumulador;

            }
            return tex_a_retornar;
        }


    }
}
