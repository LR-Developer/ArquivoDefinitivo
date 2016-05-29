using System;
using System.Windows.Forms;

namespace ArquivoDefinitivoScreens
{
    public partial class EditScreen : Form
    {
        public EditScreen()
        {
            InitializeComponent();
        }

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            InsertScreen form = new InsertScreen();
            form.Show();
            this.Close();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            UpdateScreen form = new UpdateScreen();
            form.Show();
            this.Close();
        }
    }
}
