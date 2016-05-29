using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArquivoDefinitivoScreens
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void lnklbl_NovoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUserScreen form = new NewUserScreen();
            txt_usuario.Focus();
            form.Show();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                MessageBox.Show("Digite um Usuário!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txt_senha.Text))
            {
                MessageBox.Show("Digite uma Senha!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
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
                    this.Close();
                    EditScreen form = new EditScreen();
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
    }
}