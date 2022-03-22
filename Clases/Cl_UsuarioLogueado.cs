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
    class Cl_UsuarioLogueado: Cl_SqlMaestra
    {
        DataTable datos;
        private ErrorProvider erp_usu;
        private ErrorProvider erp_contra;
        Guna.UI.WinForms.GunaLineTextBox txt_usu;
        Guna.UI.WinForms.GunaLineTextBox txt_contra;
        private static int idUsuario_;
        private static int idRol_;
        private static int idEmpleado_;
        private static string usuario_;
        private static string contraseña_;
        private static string propietario_;        
        private static string correo_;
        private static string telefono_;
        private static string rol_;


        #region Encapsulado de Variables

        public ErrorProvider Erp_usu { get => erp_usu; set => erp_usu = value; }
        public ErrorProvider Erp_contra { get => erp_contra; set => erp_contra = value; }
        public GunaLineTextBox Txt_usu { get => txt_usu; set => txt_usu = value; }
        public GunaLineTextBox Txt_contra { get => txt_contra; set => txt_contra = value; }
        public int IdUsuario_ { get => idUsuario_; set => idUsuario_ = value; }
        public int IdRol_ { get => idRol_; set => idRol_ = value; }
        public int IdEmpleado_ { get => idEmpleado_; set => idEmpleado_ = value; }
        public string Usuario_ { get => usuario_; set => usuario_ = value; }
        public string Contraseña_ { get => contraseña_; set => contraseña_ = value; }
        public string Propietario_ { get => propietario_; set => propietario_ = value; }
        public string Correo_ { get => correo_; set => correo_ = value; }
        public string Telefono_ { get => telefono_; set => telefono_ = value; }
        public string Rol_ { get => rol_; set => rol_ = value; }

        #endregion

        public bool ObtenerDatos(Guna.UI.WinForms.GunaLinkLabel lbl_recu)
        {
            bool ingresar = false;
            datos = new DataTable();
            string cadena;
            cadena = "Select u.[ID Usuario], u.[ID Rol], u.[ID Empleado], u.[Nombre Usuario], convert(nvarchar, DECRYPTBYPASSPHRASE('TecnoPc', u.Clave)), (e.Nombre + ' ' + e.Apellido) Propietario, e.[Correo Electronico], e.Telefono, " +
                "r.[Nombre Rol], u.Estado from Usuarios u inner join Roles r on u.[ID Rol] = r.IDRol inner join Empleados e on u.[ID Empleado] = e.[ID Empleado] where " +
                "[Nombre Usuario] = '" + usuario_+ "' and u.Estado = 1";
            datos = Consulta(cadena);

            try
            {
                idUsuario_ = int.Parse(datos.Rows[0][0].ToString());
                idRol_ = int.Parse(datos.Rows[0][1].ToString());
                idEmpleado_ = int.Parse(datos.Rows[0][2].ToString());
                usuario_ = datos.Rows[0][3].ToString();
                contraseña_ = datos.Rows[0][4].ToString();
                propietario_ = datos.Rows[0][5].ToString();
                correo_ = datos.Rows[0][6].ToString();
                telefono_ = datos.Rows[0][7].ToString();
                rol_ = datos.Rows[0][8].ToString();

                if (txt_usu.Text == usuario_)
                {
                    if (Txt_contra.Text == contraseña_)
                    {
                        ingresar = true;
                    }
                    else
                    {
                        erp_contra.SetError(txt_contra, "La contraseña es incorrecta");
                        lbl_recu.Visible = true;
                    }
                }
                else
                {
                    erp_usu.SetError(txt_usu, "El usuario ingresado no existe");
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
