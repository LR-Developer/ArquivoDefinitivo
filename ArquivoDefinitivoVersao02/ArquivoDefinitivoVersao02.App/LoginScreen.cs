using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArquivoDefinitivoVersao02.App
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                lbl_usuario.Text = "Digite um Usuário!";
                txt_usuario.Focus();
                return;
            }
            else
            {
                lbl_usuario.Text = "";
            }

            if (string.IsNullOrWhiteSpace(txt_senha.Text))
            {
                lbl_senha.Text = "Digite uma Senha";
                txt_senha.Focus();
                return;
            }
            else
            {
                lbl_senha.Text = "";
            }

            SqlConnection sqlcon = new SqlConnection("Data Source=LUIS-NOTE\\SQL2014;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            //SqlConnection sqlcon = new SqlConnection("Data Source=PCARY4\\ARYGOMES;Initial Catalog=DB_ESCOLA;Integrated Security=true");

            {
                SqlCommand cmd = new SqlCommand("PR_VALIDA_LOGIN", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID_LOGIN", txt_usuario.Text);
                cmd.Parameters.AddWithValue("ID_SENHA", txt_senha.Text);

                sqlcon.Open();
                bool exists = (bool)cmd.ExecuteScalar();

                if (exists)
                {
                    MessageBox.Show("Bem Vindo! Não faça cagada.", "Olá " + txt_usuario.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                    MainScreen form = new MainScreen(txt_usuario.Text);
                    this.Hide();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Usuário e Senha Inválidos. Tente Novamente.", "Acesso Negado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_usuario.Clear();
                    txt_senha.Clear();
                    txt_usuario.Focus();
                }
            }
        }

        private void LoginScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

