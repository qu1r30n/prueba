using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_wathsapp.clases
{
    class operaciones_arreglos
    {
        public string[] extraer_ultimo_arreglo_dentro_de_arreglo(string[] arreglo_de_arreglos, int colum_comp_string, string comparacion, string columna_donde_esta_arreglo_string, char[] caracteres_separacion)
        {
            string[] temp = columna_donde_esta_arreglo_string.Split(caracteres_separacion);

            int[] columna_donde_esta_arreglo = new int[temp.Length];
            for (int i = 0; i < columna_donde_esta_arreglo.Length; i++)
            {
                columna_donde_esta_arreglo[i] = Convert.ToInt32(temp[i]);
            }

            //la_estructura_que_puse---------------------------------------------
            //arreglos_co1mpuestos arr_comp = new arreglos_compuestos();
            //string[] arreglo_de_arreglos = new string[] { "1|2|3|4|5|6|7°8°9°10|11|12|13", "2|2|3|4|5|6|7°8°9°10|11|12|13", "3|2|3|4|5|6|7°8°9°10|11|12|13", "4|2|3|4|5|6|7°8°9°10|11|12|13", "5|2|3|4|5|6|7°8°9°10|11|12|13" };
            //int[] columna_donde_esta_arreglo = new int[] { 2, 4 };
            //char[] caracteres_separacion = new char[] { '|', '|', '°' };
            //string[] arreglo_extraido = arr_comp.extraer_ultimo_arreglo_dentro_de_arreglo(arreglo_de_arreglos, "0", "3", columna_donde_esta_arreglo, caracteres_separacion);
            //--------------------------------------------------------------------

            int columna_comparar = Convert.ToInt32(colum_comp_string);
            bool bandera = false;
            for (int i = 0; i < arreglo_de_arreglos.Length; i++)
            {
                string[] arreglo_de_arreglos_esplit = arreglo_de_arreglos[i].Split(caracteres_separacion[0]);
                if (arreglo_de_arreglos_esplit[columna_comparar] == comparacion)
                {
                    bandera = true;
                    string[] arreglo_recursivo = arreglo_de_arreglos_esplit;
                    for (int j = 1; j < caracteres_separacion.Length; j++)
                    {
                        string temp2 = "" + arreglo_recursivo[columna_donde_esta_arreglo[j - 1]];
                        arreglo_recursivo = temp2.Split(caracteres_separacion[j]);
                    }
                    return arreglo_recursivo;
                }
            }
            if (bandera == false)
            {
                return new string[] { "error" + caracteres_separacion[0] + " no encontro codigo" };
            }

            return new string[] { "error" + caracteres_separacion[0] + "no se" };
        }

        public string[] ordenar_arreglo_simple(string[] arreglo, int columna, string orden = "menor_mayor", char caracter_separacion = '|')
        {
            if (orden == "menor_mayor")
            {
                for (int i = 0; i < arreglo.Length; i++)
                {
                    for (int j = i + 1; j < arreglo.Length; j++)
                    {

                        string[] arreglo_espliteado = arreglo[i].Split(caracter_separacion);
                        double arriba = Convert.ToDouble(arreglo_espliteado[columna]);
                        string[] arreglo_espliteado2 = arreglo[j].Split(caracter_separacion);
                        double abajo = Convert.ToDouble(arreglo_espliteado2[columna]);
                        string temp;
                        if (arriba > abajo)
                        {
                            temp = arreglo[i];
                            arreglo[i] = arreglo[j];
                            arreglo[j] = temp;
                        }
                    }
                }
            }


            else if (orden == "mayor_menor")
            {
                for (int i = 0; i < arreglo.Length; i++)
                {
                    for (int j = i + 1; j < arreglo.Length; j++)
                    {

                        string[] arreglo_espliteado = arreglo[i].Split(caracter_separacion);
                        double arriba = Convert.ToDouble(arreglo_espliteado[columna]);
                        string[] arreglo_espliteado2 = arreglo[j].Split(caracter_separacion);
                        double abajo = Convert.ToDouble(arreglo_espliteado2[columna]);
                        string temp;
                        if (arriba < abajo)
                        {
                            temp = arreglo[i];
                            arreglo[i] = arreglo[j];
                            arreglo[j] = temp;
                        }
                    }
                }
            }



            return arreglo;
        }

        public string[] agregar_registro_del_array(string[] arreglo, string registro)
        {
            string[] temp = new string[arreglo.Length + 1];

            for (int i = 0; i < arreglo.Length; i++)
            {
                temp[i] = arreglo[i];
            }

            temp[arreglo.Length] = registro;

            return temp;
        }

        public string[] eliminar_registro_del_array(string[] arreglo, int num_registro)
        {
            string[] temp = new string[arreglo.Length - 1];
            int j = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (i != num_registro)
                {
                    temp[j] = arreglo[i];
                    j++;
                }
            }

            return temp;
        }


    }
}
