using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace Tecno_Pc.Clases
{
    class Cl_UsuarioLogueado: Cl_SqlMaestra //esta clase sirve de cache para tene informacion de quien se logueo en el sistema
    {
        //propiedades de la informacion guardada en cache
        DataTable datos;
        private ErrorProvider erp_usu;
        private ErrorProvider erp_contra;
        Guna.UI.WinForms.GunaLineTextBox Txt_Usuario;
        Guna.UI.WinForms.GunaLineTextBox Txt_Contraseña;
        private static int id_usuario;
        private static int id_rol;
        private static int id_empleado;
        private static string usuario;
        private static string contraseña_usuario;
        private static string propietario_usuario;        
        private static string correo_usuario;
        private static string telefono_usuario;
        private static string rol_usuario;


        #region Encapsulado de Variables

        public ErrorProvider Erp_Usu { get => erp_usu; set => erp_usu = value; }
        public ErrorProvider Erp_Contra { get => erp_contra; set => erp_contra = value; }
        public GunaLineTextBox Txt_Usu { get => Txt_Usuario; set => Txt_Usuario = value; }
        public GunaLineTextBox Txt_Contra { get => Txt_Contraseña; set => Txt_Contraseña = value; }
        public int Id_Usuario { get => id_usuario; set => id_usuario = value; }
        public int Id_Rol { get => id_rol; set => id_rol = value; }
        public int Id_Empleado { get => id_empleado; set => id_empleado = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña_Usuario { get => contraseña_usuario; set => contraseña_usuario = value; }
        public string Propietario_Usuario { get => propietario_usuario; set => propietario_usuario = value; }
        public string Correo_Usuario { get => correo_usuario; set => correo_usuario = value; }
        public string Telefono_Usuario { get => telefono_usuario; set => telefono_usuario = value; }
        public string Rol_Usuario { get => rol_usuario; set => rol_usuario = value; }

        #endregion

        public bool Obtener_Datos(Guna.UI.WinForms.GunaLinkLabel lbl_recu) //prod para oobtener ls datos del usuario logueado
        {
            bool ingresar = false; //indicara si ingresamos o no al sistema
            datos = new DataTable();
            string cadena;
            cadena = "Select u.[id_usuario], u.[id_rol], u.[id_empleado], u.[nombre_usuario], convert(nvarchar, DECRYPTBYPASSPHRASE('TecnoPc', u.clave_usuario)), " +
                "(e.nombre_empleado + ' ' + e.apellido_empleado) Propietario, e.[correo_electronico], e.telefono_empleado, " +
                "r.[nombre_rol], u.estado_usuario from Usuarios u inner join Roles r on u.[id_rol] = r.id_rol inner join Empleados e on u.[id_empleado] = e.[id_empleado] where " +
                "[nombre_usuario] = '" + usuario+ "' and u.estado_usuario = 1";
            datos = Consulta_Registro(cadena);

            try//intentamos extraer la informacion si ha devuelto algun registro la consulta sql 
            {
                //llenamos las variables
                id_usuario = int.Parse(datos.Rows[0][0].ToString());
                id_rol = int.Parse(datos.Rows[0][1].ToString());
                id_empleado = int.Parse(datos.Rows[0][2].ToString());
                usuario = datos.Rows[0][3].ToString();
                contraseña_usuario = datos.Rows[0][4].ToString();
                propietario_usuario = datos.Rows[0][5].ToString();
                correo_usuario = datos.Rows[0][6].ToString();
                telefono_usuario = datos.Rows[0][7].ToString();
                rol_usuario = datos.Rows[0][8].ToString();

                //comparamos si usuario y coontraseña son excatamente iguales a los del registro devuelto
                if (Txt_Usuario.Text == usuario)
                {
                    if (Txt_Contra.Text == contraseña_usuario)
                    {
                        ingresar = true;//si todo esta bien no perrmitira entra al sistema
                    }
                    else
                    {
                        erp_contra.SetError(Txt_Contraseña, "La contraseña es incorrecta");
                        lbl_recu.Visible = true;
                    }
                }
                else
                {
                    erp_usu.SetError(Txt_Usuario, "El usuario ingresado no existe");
                }              
            }
            catch (Exception ex)
            {
                erp_usu.SetError(Txt_Usuario, "El usuario ingresado no existe");
            }

            return ingresar; 
        }
    }
}
