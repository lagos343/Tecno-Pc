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
    class Cl_Validacion //se encarga de las validaciones de los datos de entrada en los formularios 
    {
        // propiedades que permiten validar todos los formualarios
        private static TextBox [] text_validacion;
        private static ErrorProvider[] error_validacion;
        private static string[] regular_validacion;
        private static int[] minimo_validacion;
        private static string[] msj_validacion;
        private static int control_validacion = 0;
        private static int [] ctrl_user;
                
        #region encapsulaimetno
        public TextBox[] Text { get => text_validacion; set => text_validacion = value; }
        public ErrorProvider[] Error { get => error_validacion; set => error_validacion = value; }
        public string[] Regular { get => regular_validacion; set => regular_validacion = value; }
        public int[] Minimo { get => minimo_validacion; set => minimo_validacion = value; }
        public string[] Msj { get => msj_validacion; set => msj_validacion = value; }
        public int Control { get => control_validacion; set => control_validacion = value; }
        public int[] Ctrl_user { get => ctrl_user; set => ctrl_user = value; }
        #endregion

        public bool Comprobar_Txt() //este procedimiento valida los textbox
        {
            for (int i = 0; i < text_validacion.Length; i++)
            {
                bool conteo; 
                Error[i].Clear();


                if (Text[i].Text == "") //valida que no este vacio
                {
                    Error[i].SetError(Text[i], "Campo Vacio");
                    conteo= false;
                }
                else if (Text[i].Text.Length < Minimo[i]) //valida el minimo de carcateres o digitos
                {
                    Error[i].SetError(Text[i], "El minimo de caracteres es " + Minimo[i]);
                    conteo= false;
                }
                else if (Regex.Replace(Text[i].Text, Regular[i], String.Empty).Length != 0) //valida la expresion regular
                {
                    Error[i].SetError(Text[i], Msj[i]);
                    conteo = false;                    
                }
                else
                {
                    conteo= true;
                }

                if (conteo == false) //de hallarce un error aumenta el conteo de errores
                {
                    control_validacion += 1;
                }
            }
                       

            if (control_validacion > 0) //si hay errores rretorna falso, sino verdadero
            {
                control_validacion = 0;
                return false;
            }
            else
            {
                control_validacion = 0;
                return true;                
            }         
        }  

        public void Validar_Carpetas(string Carpeta) //validamos que no se hayan borado las carpetas de los reportes
        {
            string ruta = Properties.Settings.Default.RutaReportes.ToString(); //extraemos la ruta definida por el user

            if (!Directory.Exists(ruta + @"\Reportes Tecno Pc") || !Directory.Exists(ruta + @"\Reportes Tecno Pc\" + Carpeta)) //de no encontrar la carpeta, la creamos de nuevo 
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

        public bool Validar_Letrascorreos(TextBox txt, ErrorProvider erp)
        {
            int parte = 0; //variable que indica en que sector del correo estamos
            int conteo1 = 0, conteo2 = 0, conteo3 = 0;//cuentan los errores dependiendo del sector de email, conteo1@conteo2.conteo3

            for (int i = 0; i < txt.Text.Length; i++)
            {
                //condicional para contar las letras de las tes partes
                if (Char.IsLetter(txt.Text, i) && parte == 0)
                {
                    conteo1 += 1;

                }else if(Char.IsLetter(txt.Text, i) && parte == 1)
                {
                    conteo2 += 1;
                }
                else
                {
                    if (Char.IsLetter(txt.Text, i) && parte == 2)
                    {
                        conteo3 += 1;
                    }
                }
                
                if (txt.Text.Substring(i, 1) == "@")//saltamos a la parte despues de @
                {
                    parte = 1;
                }

                if (txt.Text.Substring(i, 1) == ".")//saltamos a la parte despues de '.'
                {
                    parte = 2;
                }
            }

            if (conteo1 > 0 && conteo2 > 0 && conteo3 > 0) //si se hayoo minimo una letra en las tres partes, el correo esta bien, si no se notiffica el error
            {
                return true;
            }
            else
            {
                if (erp.GetError(txt) == "")
                {
                    erp.Clear();
                    erp.SetError(txt, "El correo debe contener letras\nantes y despues de @ y despues\ndel .");
                }                
                return false;
            }
        }

        public bool Validar_Letras(TextBox txt, ErrorProvider erp) //valida que las marcas tengas minimo una letra y no solo numeros
        {
            int conteo = 0;
            for (int i = 0; i < txt.Text.Length; i++)
            {
                if (Char.IsLetter(txt.Text, i))
                {
                    conteo += 1;
                }
            }

            if (conteo > 0)
            {
                return true;
            }
            else
            {
                if (erp.GetError(txt) == "")
                {
                    erp.Clear();
                    erp.SetError(txt, "Debe llevar letras o\nnumeros acompañados de letras");
                }                
                return false;
            }                      
        }

        public bool Validar_Usuario() //validaciones de usuario y contraseña 
        {        
            for (int i = 0; i < text_validacion.Length ; i++) //recoremos todos los textbox
            {
                bool conteo;
                error_validacion[i].Clear(); //accedemos a su error provider para mostrar alertas en caso de error

                if (ctrl_user[i] == 1) //esta variable verifica si validamos usuario o contraseña
                {

                    //USUARIO
                    if (text_validacion[i].Text == "")
                    {
                        error_validacion[i].SetError(text_validacion[i], "Campo Vacio");
                        conteo = false;

                    }
                    else if (text_validacion[i].Text.Length < 8)
                    {
                        error_validacion[i].SetError(text_validacion[i], "El minimo de caracteres es 8");
                        conteo = false;

                    }
                    else if (Regex.Replace(text_validacion[i].Text, "[A-Z, a-z]", String.Empty).Length != 0)
                    {
                        error_validacion[i].SetError(text_validacion[i], "Solo caracteres tipo letra");
                        conteo = false ;

                    }
                    else if (Regex.IsMatch(text_validacion[i].Text, "[A-Z]") == false)
                    {
                        error_validacion[i].SetError(text_validacion[i], "Debe contener por lo menos una Mayus");
                        conteo = false;
                    }
                    else
                    {
                        conteo = true;

                    }
                }
                else
                {
                    //CONTRASEÑA
                    bool mayuscula = false, minuscula = false, numero = false, carespecial = false;

                    if (text_validacion[i].Text == "")
                    {
                        error_validacion[i].SetError(text_validacion[i], "Campo Vacio");
                        conteo = false;

                    }
                    else if (text_validacion[i].Text.Length < 8)
                    {
                        error_validacion[i].SetError(text_validacion[i], "El minimo de caracteres es 8");
                        conteo = false;

                    }
                    else
                    {
                        for (int j = 0; j < text_validacion[i].Text.Length; j++)
                        {
                            if (Char.IsUpper(text_validacion[i].Text, j))
                            {
                                mayuscula = true;
                            }
                            else if (Char.IsLower(text_validacion[i].Text, j))
                            {
                                minuscula = true;
                            }
                            else if (Char.IsDigit(text_validacion[i].Text, j))
                            {
                                numero = true;
                            }
                            else
                            {
                                carespecial = true;
                            }
                        }
                        if (mayuscula && minuscula && numero && carespecial && text_validacion[i].Text.Length >= 8)
                        {
                            conteo = true;
                        }
                        else
                        {
                            error_validacion[i].SetError(text_validacion[i], "Debe contener por lo menos una Mayus, un numero y un caracter especial");
                            conteo = false;
                        }
                    }
                }
                if (conteo == false)
                {
                    control_validacion += 1;
                }
            }

            if (control_validacion > 0)
            {
                control_validacion = 0;
                return false;
            }
            else
            {
                control_validacion = 0;
                return true;
            }
        }

        public bool Buscar_Repetidos(TextBox txt, ErrorProvider erp)//valida que un telefono no tenga 8 digitos repetidos
        {
            if (txt.Text != "") //validamos que no este vacio
            {
                string letraInicial = ""; 

                for (int i = 0; i < txt.Text.Length; i++)//recorremos todos los digitos
                {
                    if (i == 0) //capturamos el primer caracter
                    {
                        letraInicial = txt.Text.Substring(i, 1);
                    }

                    if (i > 0) //comparamos el piemer caracter con el caracter actual, de haber minimo uno distinto retornamos true
                    {
                        if (letraInicial != txt.Text.Substring(i, 1))
                            return true;
                    }
                }

                if (erp.GetError(txt) == "") //vemos si no hay un erorr ya notificado para no soobreescribir
                {
                    erp.Clear();
                    erp.SetError(txt, "No se puede repetir el mismo\ndigito 8 veces"); //si no mostramos el error
                }

                return false; //si todos son iguales retorrnamos falso
            }

            return true; //si esta vacio retornamos true
        }
    }
}
