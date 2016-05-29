using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArquivoDefinitivoScreens
{
    public partial class InsertScreen : Form
    {
        public InsertScreen()
        {
            InitializeComponent();
        }

        private void InsertScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_aluno.Text))
            {
                MessageBox.Show("Preencha o Nome a ser Inserido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txt_ra.Text))
            {
                MessageBox.Show("Preencha o RA a ser Inserido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SqlConnection sqlcon = new SqlConnection("Data Source=LUIS-NOTE\\SQL2014;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            //SqlConnection sqlcon = new SqlConnection("Data Source=PCARY4\\ARYGOMES;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            {
                SqlCommand cmd1 = new SqlCommand("PR_INS_AD", sqlcon);
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@NM_ALUNO", txt_aluno.Text);
                    cmd1.Parameters.AddWithValue("@NR_RA", txt_ra.Text);

                    sqlcon.Open();

                    SqlCommand cmd2 = new SqlCommand("PR_SEL_RA", sqlcon);
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@NR_RA", txt_ra.Text);

                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count == 1)
                            {
                                MessageBox.Show("Já existe este número de RA! Verifique se está correto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }

                    cmd1.ExecuteNonQuery();
                    sqlcon.Close();

                    MessageBox.Show("Aluno Inserido com Sucesso!", "Concluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_aluno.Clear();
                    txt_ra.Clear();
                    txt_aluno.Focus();
                }
            }
        }

    }
}
