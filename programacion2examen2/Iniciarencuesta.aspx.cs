using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Security.Cryptography;
using System.Reflection.Emit;
using Label1 = System.Web.UI.ITextControl;
using System.Linq.Expressions;

namespace programacion2examen2
{
    public partial class Iniciarencuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexionexam"].ConnectionString;
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(constr);
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM encuesta", con))
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();//refrescar la tabla
                    }
                }
            }
            catch (Exception ex)
            {
                // Generar un mensaje de JavaScript para mostrar el error
                string errorMessage = "alert('Error al conectar con la base de datos: " + ex.Message.Replace("'", "\\'") + "');";
                // Registra el script para que se ejecute en el cliente
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorScript", errorMessage, true);
            }
            finally
            {
                // Cerrar la conexión en el bloque finally para asegurarse de que se ejecute incluso si hay una excepción.
                if (con != null)
                {
                    con.Close();
                }
            }
        }




        protected void Bingresar_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionexam"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Extraer la fecha de nacimiento del TextBox Tfecha
                DateTime fechaNacimiento;
                if (!DateTime.TryParse(Tfecha.Text, out fechaNacimiento))
                {
                    // Manejar el caso en que la fecha ingresada no sea válida
                    // Puedes mostrar un mensaje al usuario indicando que la fecha de nacimiento es inválida
                    return;
                }

                // Calcular la edad
                int edad = CalcularEdad(fechaNacimiento);

                // Validar si la edad está en el rango especificado
                if (edad < 18 || edad > 50)
                {
                    string errorMessage = "alert('Lo sentimos, la edad debe estar entre 18 y 50 años para ingresar la encuesta.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorScript", errorMessage, true);
                    return;
                }

                // Consulta SQL para insertar en la tabla encuesta
                string query = "INSERT INTO encuesta (nombre, apellido, fechanacimiento, edad, correo, carropropio) VALUES (@nombre, @apellido, @fechanacimiento, @edad, @correo, @carropropio)";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", Tnom.Text);
                comando.Parameters.AddWithValue("@apellido", Tapellido.Text);
                comando.Parameters.AddWithValue("@fechanacimiento", fechaNacimiento); // Insertar la fecha de nacimiento
                comando.Parameters.AddWithValue("@edad", edad); // Insertar la edad calculada
                comando.Parameters.AddWithValue("@correo", Tcorreo.Text);

                // Insertar el valor del carro propio basado en la selección de Sitiene
                if (Sitiene.Checked)
                {
                    comando.Parameters.AddWithValue("@carropropio", Sitiene.Checked ? "Si" : "Si");
                }
                else if (Notiene.Checked)
                {
                    comando.Parameters.AddWithValue("@carropropio", Notiene.Checked ? "No" : "No");
                }

                comando.ExecuteNonQuery();
                string errorMessages = "alert('Encuesta ingresada satisfactoriamente!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorScript", errorMessages, true);
            }
        }

        // Método para calcular la edad
        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }
    }

}
