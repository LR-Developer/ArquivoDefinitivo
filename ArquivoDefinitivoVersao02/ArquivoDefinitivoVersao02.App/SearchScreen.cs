using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArquivoDefinitivoVersao02.App
{
    public partial class SearchScreen : Form
    {
        public SearchScreen()
        {
            InitializeComponent();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_pesquisar.Text))
            {
                MessageBox.Show("Preenha o Nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SqlConnection sqlcon = new SqlConnection("Data Source=LUIS-NOTE\\SQL2014;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            //SqlConnection sqlcon = new SqlConnection("Data Source=PCARY4\\ARYGOMES;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_AD", sqlcon);
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NM_ALUNO", txt_pesquisar.Text);
                    txt_pesquisar.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg_select.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Registro Encontrado", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            SearchScreen form = new SearchScreen();
                            form.Show();
                            return;
                        }
                    }
                }
            }
        }

        private void SearchScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
