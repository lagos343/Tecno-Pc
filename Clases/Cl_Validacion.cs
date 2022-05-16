using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

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
        private static int [] ctrl_user;
                

        #region encapsulaimetno
        public TextBox[] Text { get => text; set => text = value; }
        public ErrorProvider[] Error { get => error; set => error = value; }
        public string[] Regular { get => regular; set => regular = value; }
        public int[] Minimo { get => minimo; set => minimo = value; }
        public string[] Msj { get => msj; set => msj = value; }
        public int Control { get => control; set => control = value; }
        public int[] Ctrl_user { get => ctrl_user; set => ctrl_user = value; }
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

        public void ValidarCarpetas(string Carpeta)
        {
            string ruta = Properties.Settings.Default.RutaReportes.ToString();

            if (!Directory.Exists(ruta + @"\Reportes Tecno Pc") || !Directory.Exists(ruta + @"\Reportes Tecno Pc\" + Carpeta))
            {
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Clientes");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Contactos");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Empleados");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Proveedores");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Productos");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Usuarios");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Facturas");
                Directory.CreateDirectory(ruta + @"\Reportes Tecno Pc\Ventas");
            }            
        }


        public bool validarusuario()
        {
            

            for (int i = 0; i < text.Length ; i++)
            {
                bool conteo;
                error[i].Clear();

                if (ctrl_user[i] == 1)
                {

                    if (text[i].Text == "")
                    {
                        error[i].SetError(text[i], "Campo Vacio");
                        conteo = false;

                    }
                    else if (text[i].Text.Length < 8)
                    {
                        error[i].SetError(text[i], "El minimo de caracteres es 8");
                        conteo = false;

                    }
                    else if (Regex.Replace(text[i].Text, "[A-Z, a-z]", String.Empty).Length != 0)
                    {
                        error[i].SetError(text[i], "Solo caracteres tipo letra");
                        conteo = false ;

                    }
                    else if (Regex.IsMatch(text[i].Text, "[A-Z]") == false)
                    {
                        error[i].SetError(text[i], "Debe contener por lo menos una Mayus");
                        conteo = false;
                    }
                    else
                    {
                        conteo = true;

                    }
                }
                else
                {
                    bool mayuscula = false, minuscula = false, numero = false, carespecial = false;

                    if (text[i].Text == "")
                    {
                        error[i].SetError(text[i], "Campo Vacio");
                        conteo = false;

                    }
                    else if (text[i].Text.Length < 8)
                    {
                        error[i].SetError(text[i], "El minimo de caracteres es 8");
                        conteo = false;

                    }
                    else
                    {
                        for (int j = 0; j < text[i].Text.Length; j++)
                        {
                            if (Char.IsUpper(text[i].Text, j))
                            {
                                mayuscula = true;
                            }
                            else if (Char.IsLower(text[i].Text, j))
                            {
                                minuscula = true;
                            }
                            else if (Char.IsDigit(text[i].Text, j))
                            {
                                numero = true;
                            }
                            else
                            {
                                carespecial = true;
                            }
                        }
                        if (mayuscula && minuscula && numero && carespecial && text[i].Text.Length >= 8)
                        {
                            conteo = true;
                        }
                        else
                        {
                            error[i].SetError(text[i], "Debe contener por lo menos una Mayus, un numero y un caracter especial");
                            conteo = false;
                        }
                    }
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
