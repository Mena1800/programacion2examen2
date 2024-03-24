using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace programacion2examen2
{
    public partial class Consultarencuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btotalencue_Click(object sender, EventArgs e)
        {
            LlenarGrid();
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

        protected void Bconcarro_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["conexionexam"].ConnectionString;
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(constr);
                using (SqlCommand cmd = new SqlCommand("SELECT numeroencuesta, nombre, apellido, fechanacimiento, edad, correo,carropropio  FROM encuesta WHERE carropropio = 'no'", con))
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

        protected void Bsincarro_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["conexionexam"].ConnectionString;
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(constr);
                using (SqlCommand cmd = new SqlCommand("SELECT numeroencuesta, nombre, apellido, fechanacimiento, edad, correo,carropropio  FROM encuesta WHERE carropropio = 'si'", con))
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
    }
}