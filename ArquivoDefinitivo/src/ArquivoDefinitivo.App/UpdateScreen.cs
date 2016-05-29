using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArquivoDefinitivoScreens
{
    public partial class UpdateScreen : Form
    {
        public UpdateScreen()
        {
            InitializeComponent();
        }

        private void UpdateScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_alterar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_aluno.Text))
            {
                MessageBox.Show("Insira um Nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txt_ra.Text))
            {
                MessageBox.Show("Insira um RA!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SqlConnection sqlcon = new SqlConnection("Data Source=LUIS-NOTE\\SQL2014;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            //SqlConnection sqlcon = new SqlConnection("Data Source=PCARY4\\ARYGOMES;Initial Catalog=DB_ESCOLA;Integrated Security=true");
            {
                SqlCommand cmd1 = new SqlCommand("PR_SEL_UPD", sqlcon);
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@NM_ALUNO", txt_aluno.Text);
                    cmd1.Parameters.AddWithValue("@NR_RA", txt_ra.Text);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Registro Encontrado. Verifique os Dados Digitados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("Existem dois ou mais nomes iguais. Chame o Luís!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                        SqlCommand cmd2 = new SqlCommand("PR_UPD_AD", sqlcon);
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@NM_ALUNO", txt_aluno.Text);
                            cmd2.Parameters.AddWithValue("@NR_RA", txt_ra.Text);

                            sqlcon.Open();
                            cmd2.ExecuteNonQuery();
                            sqlcon.Close();

                            MessageBox.Show("Alteração Realizada com Sucesso!", "Concluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_aluno.Clear();
                            txt_ra.Clear();
                            txt_aluno.Focus();
                        }
                     
                    }


                }
            }
        }
    }
