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
            string password = txtContraseña.Text;

            // Validar el usuario y la contraseña en la base de datos
            bool usuarioValido = ValidarUser(username, password);

            // Si los datos de inicio de sesión son válidos, mostrar mensaje de éxito
            // De lo contrario, mostrar un mensaje de error
            if (usuarioValido)
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                //miChequera miChequera = new miChequera();
               // miChequera.Show();
               // this.Close();
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña son incorrectos. Inténtalo de nuevo.");
            }
        }

        private bool ValidarUser(string username, string password)
        {
            // Conectar a la base de datos y validar el usuario y la contraseña
            // Devuelva true si el usuario y la contraseña son válidos, de lo contrario, false
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