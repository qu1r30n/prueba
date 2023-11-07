using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using chatbot_wathsapp.clases;

namespace chatbot_wathsapp.formularios
{
    public partial class chatbot : Form
    {
        public chatbot()
        {
            InitializeComponent();

            chatbot_clase ch_bot_clase = new chatbot_clase();
            ch_bot_clase.configuracion_de_inicio();
        }
    }
}
