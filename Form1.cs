using ProyectoBanco;
using System.Data.SqlClient;

namespace ChequesRepo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContrase�a.Text;

            // Validar el usuario y la contrase�a en la base de datos
            bool usuarioValido = ValidarUser(username, password);

            // Si los datos de inicio de sesi�n son v�lidos, mostrar mensaje de �xito
            // De lo contrario, mostrar un mensaje de error
            if (usuarioValido)
            {
                MessageBox.Show("Inicio de sesi�n exitoso.");
                //miChequera miChequera = new miChequera();
               // miChequera.Show();
               // this.Close();
            }
            else
            {
                MessageBox.Show("El usuario o la contrase�a son incorrectos. Int�ntalo de nuevo.");
            }
        }

        private bool ValidarUser(string username, string password)
        {
            // Conectar a la base de datos y validar el usuario y la contrase�a
            // Devuelva true si el usuario y la contrase�a son v�lidos, de lo contrario, false
            bool valido = false;

            {
                SqlParameter paruser = new("@user", username);
                SqlParameter parword = new("@pass", password);

                using SqlCommand comando = new("SELECT * FROM usuarios WHERE usuario = @user AND contrasena = @pass", Conexion.Conectar());

                comando.Parameters.Add(paruser);
                comando.Parameters.Add(parword);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        valido = true;
                    }
                }
            }
            return valido;
        }
    }
}