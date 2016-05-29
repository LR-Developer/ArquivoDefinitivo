using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArquivoDefinitivoScreens
{
    public partial class NewUserScreen : Form
    {
        public NewUserScreen()
        {
            InitializeComponent();
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NovoUsuario.Text))
            {
                MessageBox.Show("Preencha o Usuário a ser criado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txt_NovaSenha.Text))
            {
                MessageBox.Show("Preencha a Senha a ser criada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SqlConnection sqlcon = new SqlConnection("Data Source=LUIS-NOTE\\SQL2014;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            //SqlConnection sqlcon = new SqlConnection("Data Source=PCARY4\\ARYGOMES;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            {
                SqlCommand cmd1 = new SqlCommand("PR_SEL_LOGIN", sqlcon);
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@NOVO_USUARIO", txt_NovoUsuario.Text);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Usuário já existente, tente novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_NovoUsuario.Clear();
                        txt_NovaSenha.Clear();
                        txt_NovoUsuario.Focus();
                        return;
                    }
                }

                SqlCommand cmd2 = new SqlCommand("PR_INS_LOGIN", sqlcon);
                {
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@NOVO_USUARIO", txt_NovoUsuario.Text);
                    cmd2.Parameters.AddWithValue("@NOVA_SENHA", txt_NovaSenha.Text);

                    sqlcon.Open();
                    cmd2.ExecuteNonQuery();
                    sqlcon.Close();

                    MessageBox.Show("Usuário Criado com Sucesso! Utilize este Usuário e Senha na tela de login!", "Concluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}