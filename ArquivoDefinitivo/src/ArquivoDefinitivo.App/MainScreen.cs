using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace ArquivoDefinitivoScreens
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            //Valida o nome preenchido
            if (string.IsNullOrWhiteSpace(txt_pesquisar.Text))
            {
                //Exibe uma mensagem de tela
                MessageBox.Show ("Preenha o Nome!","Atenção!", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);

                //aborta a execucao do metodo
                return;
            }

            SqlConnection sqlcon = new SqlConnection("Data Source=LUIS-NOTE\\SQL2014;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            //SqlConnection sqlcon = new SqlConnection("Data Source=PCARY4\\ARYGOMES;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_AD", sqlcon);
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //recupera a variavel _nome q foi preenchida no construtor
                    cmd.Parameters.AddWithValue("@NM_ALUNO", txt_pesquisar.Text);
                    txt_pesquisar.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //preenche os dados no grid
                        dtg_select.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Registro Encontrado", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }  
        }

        private void lnklbl_alteracoes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txt_pesquisar.Focus();
            LoginScreen form = new LoginScreen();
            form.Show();
        }
    }
}
