using System;
using System.Drawing;
using System.Windows.Forms;
using chatbot_wathsapp.clases;

using System.Linq;
namespace chatbot_wathsapp.desinger
{
    public partial class Ventana_emergente : Form
    {


        string[] G_caracter_separacion = variables_glob_conf.GG_caracter_separacion;
        string G_datos_de_boton = "";

        operaciones_arreglos op_arr = new operaciones_arreglos();



        string G_devolver_informacion = "";


        public Ventana_emergente()
        {
            InitializeComponent();


        }

        public string Proceso_ventana_emergente(object arreglo_string_uni_y_bidimencional, string titulo_ventana = "ventana_emergente", string[] infoextra = null, string[] caracter_spliteo = null)
        {
            //1=textbox  1|titulo_texbox|contenido_text_box|restriccion_de_dato      ejemplo "1|precio venta|0|2" //el 2 es la restriccion que solo resivira numeros y punto decimal         
            //2=labels   2|titulo_label|abajo_pondra_otro_label_con_el_contenido    ejemplo "2|id|9999"
            //3=boton    3|titulo_del_boton|valor_del_boton|numero_de_Funcion            ejemplo "3|es_paquete|1|0" //cuando oprima el boton devolvera el valor 1 
            //4=combobox "4|
            //            titulo_combobox|
            //            valor_inicial_si anteriormente_no_se_a_modificado|
            //            restriccion_de_dato_con_aparte_opcion_4_que_es_proyecto_quetiene_otra_funcion|
            //            " + valor_inicial_si_se_modifico + '|'
            //            + todas_las_opciones_del_combobox_separadas_por_"°"
            //
            //            ejemplo "4|grupo|2|4|1|1|2|3|4"

            if (caracter_spliteo == null)
            {
                caracter_spliteo = G_caracter_separacion;
            }

            string[] nom_datos_recolectados;


            // Verificar si el objeto es un string o arreglo unidimensional o bidimensional de strings-----------------------------


            if (arreglo_string_uni_y_bidimencional is string[] arregloUnidimensional)
            {
                nom_datos_recolectados = arregloUnidimensional; // Ya es un arreglo de strings
            }

            else if (arreglo_string_uni_y_bidimencional is string[,] arregloBidimensional)
            {
                nom_datos_recolectados = new string[arregloBidimensional.GetLength(0)];

                for (int i = 0; i < arregloBidimensional.GetLength(0); i++)
                {

                    string[] resultadoArray = Enumerable.Range(0
                        , arregloBidimensional.GetLength(1))
                                    .Select(j => arregloBidimensional[i, j])
                                    .ToArray();


                    nom_datos_recolectados[i] = string.Join(caracter_spliteo[0], resultadoArray);
                }
            }

            else if (arreglo_string_uni_y_bidimencional is string)
            {
                // Aquí coloca el código que deseas ejecutar si el objeto es un string
                string texto = (string)arreglo_string_uni_y_bidimencional;
                // Por ejemplo, puedes hacer algo como:
                nom_datos_recolectados = new string[] { texto };
            }

            else
            {
                throw new ArgumentException("El objeto no es un arreglo unidimensional ni bidimensional de strings.");
            }

            //fin Verificar si el objeto es un string o arreglo unidimensional o bidimensional de strings-------------------------





            this.Text = titulo_ventana;
            this.AutoScroll = true;
            this.VerticalScroll.Enabled = true;

            //tamaño_ventana
            tamaño_ventana(nom_datos_recolectados.Length);

            //pocicion de los controles // no tiene return porque esta usando una variable global G_datos_de_boton que es el que se usara
            posicion_a_poner(nom_datos_recolectados, caracter_spliteo);

            this.ShowDialog();
            return G_devolver_informacion;//se uso la informacion de la variable global G_devolver_informacion que obtubo en funcion posicion a poner
        }

        public void posicion_a_poner(string[] controles, string[] caracter_spliteo = null)
        {
            if (caracter_spliteo == null)
            {
                caracter_spliteo = G_caracter_separacion;

            }

            string info = "";
            string bandera1 = "0", bandera2 = "0", bandera3 = "0", bandera4 = "0";

            string[] arraytextbox = new string[controles.Length];
            G_devolver_informacion = "";

            //para checar si solo se usan botones o tambien hay textbox o combobox---------------------------------------
            for (int i = 0; i < controles.Length; i++)
            {

                string[] tipo_de_datos = controles[i].Split(Convert.ToChar(caracter_spliteo[0]));

                if (tipo_de_datos[0] == "1")
                {
                    bandera1 = "1";
                }
                else if (tipo_de_datos[0] == "2")
                {
                    bandera2 = "1";
                }
                else if (tipo_de_datos[0] == "3")
                {
                    bandera3 = "1";
                }
                else if (tipo_de_datos[0] == "4")
                {
                    bandera4 = "1";
                }
            }
            if (bandera3 == "1" && bandera1 == "0" && bandera2 == "0" && bandera4 == "0")
            {
                info = "solo_botones";
            }
            //fin_para checar si solo se usan botones o tambien hay textbox o combobox---------------------------------------

            //posicion objeto---------------------------------------------------------------------------
            for (int numero_control = 0; numero_control < controles.Length; numero_control++)
            {
                if (numero_control == 13)
                {

                }
                int x = 120;
                int y__ = 40;

                int ancho = 100;
                int alto = 50;

                int numero_control_posicion = numero_control;
                int fila = numero_control_posicion / 5;
                int columna = numero_control_posicion % 5;

                int pos_col;
                int pos_fila;


                pos_col = (columna * x);
                pos_fila = fila * y__;



                //error_posicion_a_po = 0;

                string[] espliteado = controles[numero_control_posicion].Split(Convert.ToChar(caracter_spliteo[0]));

                int separacion_y = 15;


                //labels y textbox
                if (espliteado[0] == "1")
                {

                    Label lb = new Label();
                    TextBox Txt = new TextBox();


                    lb.Top = pos_fila;
                    lb.Left = pos_col;

                    Txt.Top = pos_fila + separacion_y;
                    Txt.Left = pos_col;

                    if (espliteado.Length >= 3)//este es para meter contenido al texbox
                    {
                        Txt.Text = espliteado[2];
                    }

                    mod_txt_cmd(Txt, espliteado, caracter_spliteo);


                    lb.Text = espliteado[1];
                    lb.AutoSize = true;
                    this.Controls.Add(lb);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                    this.Controls.Add(Txt);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                }

                //labels
                else if (espliteado[0] == "2")
                {
                    Label lb = new Label();
                    Label Lbl2 = new Label();
                    arraytextbox[numero_control] = espliteado[2];

                    lb.Top = pos_fila;
                    lb.Left = pos_col;

                    Lbl2.Top = pos_fila + separacion_y;
                    Lbl2.Left = pos_col;

                    if (espliteado.Length >= 3)//este es para meter contenido al texbox
                    {
                        Lbl2.Text = espliteado[2];
                    }
                    lb.Text = espliteado[1];
                    lb.AutoSize = true;
                    Lbl2.Width = ancho;
                    this.Controls.Add(lb);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                    this.Controls.Add(Lbl2);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                }

                //botones
                else if (espliteado[0] == "3")
                {
                    Button Btn_nuevoboton = new Button();

                    Btn_nuevoboton.Name = espliteado[2];
                    Btn_nuevoboton.Text = espliteado[1];


                    Btn_nuevoboton.Top = pos_fila + separacion_y;
                    Btn_nuevoboton.Left = pos_col;

                    Btn_nuevoboton.Width = ancho;
                    Btn_nuevoboton.Height = alto;
                    this.Controls.Add(Btn_nuevoboton);
                    string parametros = numero_control + "" + caracter_spliteo[1] + espliteado[2] + caracter_spliteo[1] + espliteado[3];

                    Btn_nuevoboton.Click += (sender1, e1) =>
                    {
                        G_devolver_informacion = NuevoBoton_Click(sender1, e1, parametros, info);
                        if (info == "solo_botones")
                        {
                            this.Close();
                        }


                    };


                }

                //combobox
                else if (espliteado[0] == "4")
                {
                    Label lb = new Label();
                    ComboBox cmb = new ComboBox();


                    lb.Top = pos_fila;
                    lb.Left = pos_col;

                    cmb.Top = pos_fila + separacion_y;
                    cmb.Left = pos_col;



                    cmb.Width = ancho;
                    cmb.Height = alto;

                    //error_falta caracter de espliteo
                    mod_txt_cmd(cmb, espliteado);

                    //cmb.KeyPress += new KeyPressEventHandler((sender1, e1) => restriccion_caracteres(sender1, e1, parametros));////llama funcion al precionar un carcter envia imformacion extra y parametros 
                    lb.Text = espliteado[1];
                    lb.AutoSize = true;
                    this.Controls.Add(lb);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                    this.Controls.Add(cmb);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                }

                //Txt.KeyPress += new KeyPressEventHandler((sender1, e1) => restriccion_caracteres2(sender1, e1, espliteado));////llama funcion al precionar un carcter envia imformacion extra y parametros 

            }

            //fin_posicion de objetos-----------------------------------------------------------------------

            //agrega el boton aceptar si hay un textbox o un combobox
            if (bandera1 == "1" || bandera4 == "1")
            {

                int x = 120;
                int y__ = 40;

                int ancho = 100;
                int alto = 50;

                int numero_control_posicion = controles.Length + 1;
                int fila = numero_control_posicion / 5;
                int columna = numero_control_posicion % 5;

                int pos_col = (columna * x) - x;
                int pos_fila = fila * y__;


                Button Btn_aceptar = new Button();

                Btn_aceptar.Width = ancho;
                Btn_aceptar.Height = alto;
                Btn_aceptar.Top = pos_fila + 60;
                Btn_aceptar.Left = 0;
                Btn_aceptar.Name = "Btn_aceptar_1";
                Btn_aceptar.Text = "aceptar";
                this.Controls.Add(Btn_aceptar);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string

                Btn_aceptar.DialogResult = DialogResult.OK;

                //----------------------------------------------------------------------------------------------------------------------------



                Btn_aceptar.Click += (sender, e) =>
                {
                    if (Btn_aceptar.DialogResult == DialogResult.OK)
                    {
                        G_devolver_informacion = Boton_aceptar(arraytextbox, null, Convert.ToChar(caracter_spliteo[0]));
                        // Cerrar la ventana emergente después de hacer clic en "aceptar"
                        this.Close();
                    }
                };
            }

            //fin agrega el boton aceptar si hay un textbox o un combobox

            //no tiene return por que se usa la varable global G_devolver_informacion
        }

        public void tamaño_ventana(int cantidad_elementos_para_la_ventana)
        {

            if (cantidad_elementos_para_la_ventana <= 1)
            {
                this.Size = new Size(150, 150);
            }

            else if (cantidad_elementos_para_la_ventana == 2)
            {
                this.Size = new Size(250, 150);
            }

            else if (cantidad_elementos_para_la_ventana == 3)
            {
                this.Size = new Size(350, 150);
            }

            else if (cantidad_elementos_para_la_ventana == 4)
            {
                this.Size = new Size(500, 150);
            }
            else if (cantidad_elementos_para_la_ventana == 5)
            {
                this.Size = new Size(650, 150);
            }

            else if (cantidad_elementos_para_la_ventana >= 6 && cantidad_elementos_para_la_ventana <= 10)
            {
                this.Size = new Size(650, 150);
            }

            else if (cantidad_elementos_para_la_ventana >= 11 && cantidad_elementos_para_la_ventana <= 15)
            {
                this.Size = new Size(650, 250);
            }

            else if (cantidad_elementos_para_la_ventana >= 16)
            {
                this.Size = new Size(650, 270);
            }


        }

        public void predicciones_txt(TextBox txt_a_agregar_predicciones, string[] espliteado, string[] caracter_spliteo = null)
        {
            if (caracter_spliteo == null)
            {
                caracter_spliteo = G_caracter_separacion;
            }

            if (espliteado.Length > 4)
            {
                txt_a_agregar_predicciones.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_a_agregar_predicciones.AutoCompleteSource = AutoCompleteSource.CustomSource;

                string[] elementros = espliteado[4].Split(Convert.ToChar(caracter_spliteo[1])); // Dividir el elemento espliteado[4] usando el carácter de separación

                for (int j = 0; j < elementros.Length; j++)
                {
                    txt_a_agregar_predicciones.AutoCompleteCustomSource.Add(elementros[j]);
                }
            }


        }

        public void predicciones_cmb(ComboBox combobox_a_agregar_predicciones, string[] espliteado, string[] caracter_spliteo = null)
        {
            if (caracter_spliteo == null)
            {
                caracter_spliteo = G_caracter_separacion;
            }
            if (espliteado.Length > 3)//para el predictor de palabras y agregar elementos combobox
            {

                combobox_a_agregar_predicciones.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combobox_a_agregar_predicciones.AutoCompleteSource = AutoCompleteSource.CustomSource;

                string[] elementros = espliteado[5].Split(Convert.ToChar(caracter_spliteo[1])); // Dividir el elemento espliteado[4] usando el carácter de separación

                for (int j = 0; j < elementros.Length; j++)
                {
                    combobox_a_agregar_predicciones.Items.Add(elementros[j]);
                    combobox_a_agregar_predicciones.AutoCompleteCustomSource.Add(elementros[j]);

                }

            }
            //error_predicciont_cmb = 0;

        }

        public string Boton_aceptar(string[] arraytextbox, string[] infoextra = null, char caracter_spliteo = '|')
        {
            Tex_base bas = new Tex_base();
            Operaciones_archivos op = new Operaciones_archivos();
            string temp2 = "";

            string[] info_detro_celda = G_datos_de_boton.Split(Convert.ToChar((G_caracter_separacion[0])));

            for (int i = 0; i < info_detro_celda.Length; i++)
            {
                string[] posicion_y_datos = info_detro_celda[i].Split(caracter_spliteo);
                if (posicion_y_datos.Length >= 2)
                {
                    arraytextbox[Convert.ToInt32(posicion_y_datos[0])] = posicion_y_datos[1];
                }
            }

            int k = 0;
            for (int j = 0; j < this.Controls.Count; j++) //aqui agrega al arreglo global "arraytextbox" la informacion
            {
                object obj = this.Controls[j];

                for (int i = k; i < arraytextbox.Length; i++)
                {

                    if (obj is TextBox && arraytextbox[i] == null)
                    {
                        TextBox temp = (TextBox)obj;
                        arraytextbox[i] = temp.Text;
                        k = i;
                        break;
                    }
                    else if (obj is ComboBox && arraytextbox[i] == null)
                    {
                        ComboBox temp = (ComboBox)obj;
                        arraytextbox[i] = temp.Text;
                        k = i;
                        break;
                    }
                }

            }




            for (int i = 0; i < arraytextbox.Length; i++)
            {
                temp2 = temp2 + arraytextbox[i] + G_caracter_separacion[0];
            }
            Operaciones_textos op_tex = new Operaciones_textos();
            temp2 = op_tex.Trimend_paresido(temp2, Convert.ToChar(G_caracter_separacion[0]));



            this.Close();
            return temp2;

        }

        public string NuevoBoton_Click(object sender, EventArgs e, string seccion, string info_extra = null)
        {
            Button botonClicado = sender as Button;
            return botonClicado.Name;
        }

        public void restriccion_txt_cmb(Control cont_txt_cmb, string[] esplieteo)
        {
            if (esplieteo.Length > 3)
            {
                string[] restricciones = esplieteo[3].Split(Convert.ToChar(G_caracter_separacion[2]));
                for (int i = 0; i < restricciones.Length; i++)
                {
                    string parametros = restricciones[i];

                    if (parametros == "solo_letras")//restriccion solo letras
                    {
                        cont_txt_cmb.KeyPress += (sender, e) =>
                        {
                            if (char.IsLetter(e.KeyChar))//checa si lo introducido fue letra o no chart.IsLetter devuelve true o falce
                            {

                            }
                            else
                            {
                                e.Handled = true;
                            }

                        };
                    }

                    else if (parametros == "solo_numeros")//restriccion solo numeros
                    {
                        cont_txt_cmb.KeyPress += (sender, e) =>
                        {
                            if (char.IsNumber(e.KeyChar) || '.' == e.KeyChar || '\b' == e.KeyChar)
                            {
                                // Permitir números, punto decimal y retroceso ('\b')
                                // Agrega aquí la lógica adicional si es necesario
                            }
                            else
                            {
                                // Cancelar la pulsación si no cumple las restricciones
                                e.Handled = true;
                            }
                        };
                    }

                    else if (parametros == "todas_mayusculas")
                    {
                        cont_txt_cmb.Leave += (sender, e) =>
                        {
                            cont_txt_cmb.Text = cont_txt_cmb.Text.ToUpper();
                        };
                    }

                    else if (parametros == "todas_minusculas")
                    {
                        cont_txt_cmb.Leave += (sender, e) =>
                        {
                            cont_txt_cmb.Text = cont_txt_cmb.Text.ToLower();
                        };
                    }
                }
            }

        }

        public void funciones_txt_cmb(Control cont_txt_cmb, string[] esplieteo)
        {

            if (esplieteo.Length > 6)
            {
                string[] funcion_a_realisar = esplieteo[6].Split(Convert.ToChar(G_caracter_separacion[1]));
                for (int i = 0; i < funcion_a_realisar.Length; i++)
                {
                    string parametros = funcion_a_realisar[i];
                    string[] detalle_parametro = parametros.Split(Convert.ToChar(G_caracter_separacion[2]));


                    //funciones y restricciones txt y cmb ventana_emergente cod:poison
                    if (detalle_parametro[0] == "ocultar_control")
                    {
                        cont_txt_cmb.TextChanged += new EventHandler((sender, e) =>
                        {
                            if (cont_txt_cmb.Text == detalle_parametro[2])
                            {
                                this.Controls[Convert.ToInt32(detalle_parametro[1])].Visible = true;
                            }

                            else
                            {
                                this.Controls[Convert.ToInt32(detalle_parametro[1])].Visible = false;
                            }

                        });
                    }

                    else if (detalle_parametro[0] == "reyeno_textbox_ventana_impu")
                    {
                        cont_txt_cmb.Enter += (sender, e) =>
                        {
                            MessageBox.Show("da doble click en este texbox si quieres volver abrir la ventana");
                            if (cont_txt_cmb.Text == "")
                            {

                                reyeno_textbox_ventana_y_comprobacion_array_id_archivo(cont_txt_cmb, esplieteo, 4, 0, mayusculas_o_minusculas: "mayusculas");
                            }


                        };
                        cont_txt_cmb.MouseDoubleClick += (sender, e) =>
                        {
                            reyeno_textbox_ventana_y_comprobacion_array_id_archivo(cont_txt_cmb, esplieteo, 4, 0, mayusculas_o_minusculas: "mayusculas");
                        };
                    }

                    else if (detalle_parametro[0] == "producto_elaborado")
                    {

                        cont_txt_cmb.Enter += (sender, e) =>
                        {
                            MessageBox.Show("da doble click en este texbox si quieres volver abrir la ventana");
                            if (cont_txt_cmb.Text == "")
                            {
                                producto_elaborado(cont_txt_cmb, esplieteo);
                            }


                        };
                        cont_txt_cmb.MouseDoubleClick += (sender, e) =>
                        {
                            producto_elaborado(cont_txt_cmb, esplieteo);
                        };
                    }

                    else if (detalle_parametro[0] == "no_visible")
                    {
                        cont_txt_cmb.Visible = false;
                    }

                    else if (detalle_parametro[0] == "parte_de_un_producto")
                    {

                        cont_txt_cmb.Enter += (sender, e) =>
                        {
                            MessageBox.Show("da doble click en este texbox si quieres volver abrir la ventana");
                            if (cont_txt_cmb.Text == "")
                            {

                                parte_de_un_producto(cont_txt_cmb, esplieteo);
                            }


                        };
                        cont_txt_cmb.MouseDoubleClick += (sender, e) =>
                        {
                            parte_de_un_producto(cont_txt_cmb, esplieteo);
                        };
                    }

                }
            }
        }

        private void producto_elaborado(Control cont_txt_cmb, string[] esplieteo, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            bool otro_producto = true;
            while (otro_producto)
            {


                string todos_los_codbar = "";
                for (int j = variables_glob_conf.GG_var_glob_int[0]; j < variables_glob_conf.GG_arrays_carga_de_archivos[0].Length; j++)
                {
                    string[] info_espliteado = variables_glob_conf.GG_arrays_carga_de_archivos[0][j].Split(Convert.ToChar(G_caracter_separacion[0]));
                    if (j < variables_glob_conf.GG_arrays_carga_de_archivos[0].Length - 1)
                    {
                        todos_los_codbar = todos_los_codbar + info_espliteado[5] + G_caracter_separacion[0];
                    }
                    else
                    {
                        todos_los_codbar = todos_los_codbar + info_espliteado[5];
                    }


                }


                string[] enviar = new string[] { "1" + caracter_separacion[0] + "codigo_producto" + caracter_separacion[0] + "" + caracter_separacion[0] + todos_los_codbar };
                Ventana_emergente cod_prod = new Ventana_emergente();

                string cod_bar = cod_prod.Proceso_ventana_emergente(enviar);
                if (cod_bar != "")
                {


                    string[] enviar_cant = new string[] { "1" + caracter_separacion[1] + "cantidad" + caracter_separacion[1] + "0" + caracter_separacion[1] + "2" };
                    Ventana_emergente cantidad_ingrediente = new Ventana_emergente();
                    string[] arr_car_separacion = new string[] { caracter_separacion[1] };
                    string cantidad = cantidad_ingrediente.Proceso_ventana_emergente(enviar_cant, caracter_spliteo: arr_car_separacion);
                    string[] productos_puestos = cont_txt_cmb.Text.Split(Convert.ToChar(caracter_separacion[1]));

                    bool esta_el_ingrediente_previo = false;
                    for (int j = 0; j < productos_puestos.Length; j++)
                    {
                        string[] detalles_ing_prim = productos_puestos[j].Split(Convert.ToChar(caracter_separacion[2]));
                        if (cod_bar == detalles_ing_prim[0])
                        {
                            esta_el_ingrediente_previo = true;
                            MessageBox.Show("ya pusiste este codigo previamente");
                            break;
                        }
                    }
                    if (esta_el_ingrediente_previo == false)
                    {
                        if (cont_txt_cmb.Text == "")
                        {
                            cont_txt_cmb.Text = cod_bar + caracter_separacion[2] + cantidad;
                        }

                        else
                        {
                            cont_txt_cmb.Text = cont_txt_cmb.Text + caracter_separacion[1] + cod_bar + caracter_separacion[2] + cantidad;
                        }

                    }




                    DialogResult result2 = MessageBox.Show("¿Deseas agregar otro producto?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result2 == DialogResult.No)
                    {
                        otro_producto = false;
                    }

                }
            }



        }

        private void parte_de_un_producto(Control cont_txt_cmb, string[] esplieteo, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }

            bool otro_producto = true;
            while (otro_producto)
            {

                string[] enviar = new string[] { "1" + caracter_separacion[1] + "codigo_producto" };
                Ventana_emergente cod_prod = new Ventana_emergente();
                string[] arr_car_separacion = new string[] { caracter_separacion[1] };
                string cod_bar = cod_prod.Proceso_ventana_emergente(enviar, caracter_spliteo: arr_car_separacion);
                if (cod_bar != "")
                {

                    string[] productos_puestos = cont_txt_cmb.Text.Split(Convert.ToChar(caracter_separacion[1]));

                    bool esta_el_ingrediente_previo = false;
                    for (int j = 0; j < productos_puestos.Length; j++)
                    {
                        string[] detalles_ing_prim = productos_puestos[j].Split(Convert.ToChar(caracter_separacion[2]));
                        if (cod_bar == detalles_ing_prim[0])
                        {
                            esta_el_ingrediente_previo = true;
                            MessageBox.Show("ya pusiste este codigo previamente");
                            break;
                        }
                    }
                    if (esta_el_ingrediente_previo == false)
                    {
                        if (cont_txt_cmb.Text == "")
                        {
                            cont_txt_cmb.Text = cod_bar + caracter_separacion[2] + "0";
                        }

                        else
                        {
                            cont_txt_cmb.Text = cont_txt_cmb.Text + caracter_separacion[1] + cod_bar + caracter_separacion[2] + "0";
                        }

                    }





                    DialogResult result2 = MessageBox.Show("¿Deseas agregar otro producto?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result2 == DialogResult.No)
                    {
                        otro_producto = false;
                    }

                }
            }

        }

        private void reyeno_textbox_ventana_y_comprobacion_array_id_archivo(Control cont_txt_cmb, string[] esplieteo, int id_array_archivo, int id_colum_comp, string id_extraer = null, string mayusculas_o_minusculas = null)
        {

            bool otro_producto = true;
            while (otro_producto)
            {
                string nom_imp = "";
                for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[id_array_archivo].Length; i++)
                {
                    string[] temp = variables_glob_conf.GG_arrays_carga_de_archivos[id_array_archivo][i].Split(Convert.ToChar(G_caracter_separacion[2]));
                    if (i < variables_glob_conf.GG_arrays_carga_de_archivos[id_array_archivo].Length - 1)
                    {
                        nom_imp = nom_imp + temp[0] + G_caracter_separacion[1];
                    }
                    else
                    {
                        nom_imp = nom_imp + temp[0];
                    }

                }

                string[] enviar = new string[] { "4" + G_caracter_separacion[0] + esplieteo[0] + G_caracter_separacion[0] + "NOSE" + G_caracter_separacion[0] + G_caracter_separacion[0] + "NOSE" + G_caracter_separacion[0] + nom_imp };
                Ventana_emergente cod_prod = new Ventana_emergente();

                string cod_bar = cod_prod.Proceso_ventana_emergente(enviar);
                if (mayusculas_o_minusculas == "mayusculas")
                {
                    cod_bar = cod_bar.ToUpper();
                }
                else if (mayusculas_o_minusculas == "minusculas")
                {
                    cod_bar = cod_bar.ToLower();
                }
                if (cod_bar != "")
                {

                    for (int i = variables_glob_conf.GG_var_glob_int[0]; i < variables_glob_conf.GG_arrays_carga_de_archivos[id_array_archivo].Length; i++)
                    {

                        string[] inf_produc = variables_glob_conf.GG_arrays_carga_de_archivos[id_array_archivo][i].Split(Convert.ToChar(G_caracter_separacion[0]));



                        string[] productos_puestos = cont_txt_cmb.Text.Split(Convert.ToChar(G_caracter_separacion[1]));

                        bool esta_el_ingrediente_previo = false;

                        for (int j = 0; j < productos_puestos.Length; j++)
                        {

                            if (cod_bar == productos_puestos[j])
                            {
                                esta_el_ingrediente_previo = true;
                                MessageBox.Show("ya pusiste este codigo previamente");
                                break;
                            }
                        }

                        if (esta_el_ingrediente_previo == false)
                        {
                            if (cont_txt_cmb.Text == "")
                            {
                                cont_txt_cmb.Text = cod_bar;
                            }

                            else
                            {
                                cont_txt_cmb.Text = cont_txt_cmb.Text + G_caracter_separacion[1] + cod_bar;
                            }

                            break;
                        }

                    }
                    DialogResult result = MessageBox.Show("deseas agregar otra informacion?", "Confirmación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        break;
                    }

                }
                if (cod_bar == "")
                {
                    break;
                }
            }



        }

        public void mod_txt_cmd(Control cont_txt_cmb, string[] espliteado, string[] caracter_spliteo = null)
        {
            if (caracter_spliteo == null)
            {
                caracter_spliteo = G_caracter_separacion;
            }

            if (espliteado.Length > 2)
            {


                cont_txt_cmb.Text = espliteado[2];

                if (cont_txt_cmb is TextBox)
                {
                    TextBox cont_a_pasar = cont_txt_cmb as TextBox;
                    predicciones_txt(cont_a_pasar, espliteado, caracter_spliteo);
                }
                else if (cont_txt_cmb is ComboBox)
                {
                    ComboBox cont_a_pasar = cont_txt_cmb as ComboBox;

                    predicciones_cmb(cont_a_pasar, espliteado, caracter_spliteo);

                }

                //funciones y restricciones txt y cmb ventana_emergente cod:poison
                restriccion_txt_cmb(cont_txt_cmb, espliteado);

                funciones_txt_cmb(cont_txt_cmb, espliteado);
            }


        }




        public void pasar_datos_impuestos_si_da_enter(Object sender, KeyEventArgs e, string parametros)
        {
            ComboBox contenido_contol = sender as ComboBox;
            if (e.KeyCode == Keys.Enter)
            {

                string[] dato_espliteado = contenido_contol.Text.Split(Convert.ToChar(G_caracter_separacion[1]));
                this.Controls[33].Text = dato_espliteado[0];
                //destino.Items.Add(origen.Text);

            }
        }

        private void reyeno_textbox_ventana(Control cont_txt_cmb, string[] esplieteo, string[] caracter_separacion = null)
        {
            if (caracter_separacion == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            bool otro_producto = true;
            while (otro_producto)
            {

                string[] enviar = new string[] { "1" + caracter_separacion[1] + "codigo_producto" };
                Ventana_emergente cod_prod = new Ventana_emergente();
                string[] arr_car_separacion = new string[] { caracter_separacion[1] };
                string cod_bar = cod_prod.Proceso_ventana_emergente(enviar, caracter_spliteo: arr_car_separacion);
                if (cod_bar != "")
                {
                    if (cont_txt_cmb.Text == "")
                    {
                        cont_txt_cmb.Text = cod_bar;
                    }

                    else
                    {
                        cont_txt_cmb.Text = cont_txt_cmb.Text + caracter_separacion[1] + cod_bar;
                    }

                    DialogResult result2 = MessageBox.Show("¿Deseas agregar otro producto?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result2 == DialogResult.No)
                    {
                        otro_producto = false;
                    }

                }
            }

        }

    }
}
