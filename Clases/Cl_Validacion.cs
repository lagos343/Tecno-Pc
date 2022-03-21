using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Tecno_Pc.Clases
{


    class Cl_Validacion
    {
        private static TextBox [] text;
        private static ErrorProvider[] error;
        private static string[] regular;
        private static int[] minimo;
        private static string[] msj;
        private static int control = 0;

        #region encapsulaimetno
        public TextBox[] Text { get => text; set => text = value; }
        public ErrorProvider[] Error { get => error; set => error = value; }
        public string[] Regular { get => regular; set => regular = value; }
        public int[] Minimo { get => minimo; set => minimo = value; }
        public string[] Msj { get => msj; set => msj = value; }
        public int Control { get => control; set => control = value; }
        #endregion

        public bool comprobartxt()
        {
            for (int i = 0; i < text.Length; i++)
            {
                bool conteo;
                Error[i].Clear();


                if (Text[i].Text == "")
                {
                    Error[i].SetError(Text[i], "Campo Vacio");
                    conteo= false;
                }
                else if (Text[i].Text.Length < Minimo[i])
                {
                    Error[i].SetError(Text[i], "El minimo de caracteres es " + Minimo[i]);
                    conteo= false;
                }
                else if (Regex.Replace(Text[i].Text, Regular[i], String.Empty).Length != 0)
                {
                    Error[i].SetError(Text[i], Msj[i]);
                    conteo = false;                    
                }
                else
                {
                    conteo= true;
                }

                if (conteo == false)
                {
                    control += 1;
                }
            }
                       

            if (control > 0)
            {
                control = 0;
                return false;
            }
            else
            {
                control = 0;
                return true;                
            }          
        }  
    }
}
