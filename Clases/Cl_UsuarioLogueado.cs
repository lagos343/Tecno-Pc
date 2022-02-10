using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace Repuestos_Arias.Clases
{
    class Cl_UsuarioLogueado
    {
        Cl_SqlManaggement sql = new Cl_SqlManaggement();
        DataTable datos;
        private ErrorProvider erp_usu;
        private ErrorProvider erp_contra;
        Guna.UI.WinForms.GunaLineTextBox txt_usu;
        Guna.UI.WinForms.GunaLineTextBox txt_contra;
        private static int id_usuario;
        private static string nombre_usuario;
        private static string contraseña_usuario;
        private static string nombres_propietario;
        private static string apellidos_propietarios;
        private static string correo_usuario;
        private static string telefono;
        private static string tipo_usuario;

        #region Encapsulado de Variables
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public string Contraseña_usuario { get => contraseña_usuario; set => contraseña_usuario = value; }
        public string Nombres_propietario { get => nombres_propietario; set => nombres_propietario = value; }
        public string Apellidos_propietarios { get => apellidos_propietarios; set => apellidos_propietarios = value; }
        public string Correo_usuario { get => correo_usuario; set => correo_usuario = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }
        public ErrorProvider Erp_usu { get => erp_usu; set => erp_usu = value; }
        public ErrorProvider Erp_contra { get => erp_contra; set => erp_contra = value; }
        public GunaLineTextBox Txt_usu { get => txt_usu; set => txt_usu = value; }
        public GunaLineTextBox Txt_contra { get => txt_contra; set => txt_contra = value; }

        #endregion

        public bool ObtenerDatos(Guna.UI.WinForms.GunaLinkLabel lbl_recu)
        {
            bool ingresar = false;
            datos = new DataTable();
            string cadena;
            cadena = "Select us.Id_Usuario, us.Nombre_Usuario, us.Contraseña_Usuario, us.Nombres_Propietario, us.Apellidos_Propietario, us.Correo_Usuario, " +
                "us.Telefono, tu.Descripcion_TipoUsuario from Usuarios us inner join TipoUsuario tu on tu.Id_TipoUsuario = us.Id_TipoUsuario " +
                "Where us.Nombre_Usuario = '" + nombre_usuario + "'";
            datos = sql.Consulta(cadena);

            try
            {
                id_usuario = int.Parse(datos.Rows[0][0].ToString());
                nombre_usuario = datos.Rows[0][1].ToString();
                contraseña_usuario = datos.Rows[0][2].ToString();
                nombres_propietario = datos.Rows[0][3].ToString();
                apellidos_propietarios = datos.Rows[0][4].ToString();
                correo_usuario = datos.Rows[0][5].ToString();
                telefono = datos.Rows[0][6].ToString();
                tipo_usuario = datos.Rows[0][7].ToString();

                if (Txt_contra.Text == Contraseña_usuario)
                {
                    ingresar = true;                    
                }
                else
                {
                    erp_contra.SetError(txt_contra, "La contraseña es incorrecta");
                    lbl_recu.Visible = true;
                }
            }
            catch (Exception ex)
            {
                erp_usu.SetError(txt_usu, "El usuario ingresado no existe");
            }

            return ingresar;
        }
    }
}
