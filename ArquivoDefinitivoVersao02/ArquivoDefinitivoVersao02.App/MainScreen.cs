using System;
using System.Windows.Forms;

namespace ArquivoDefinitivoVersao02.App
{
    public partial class MainScreen : Form
    {
        private string _label;

        public MainScreen(string label)
        {
            _label = label;
            InitializeComponent();
            lbl_login.Text = "Logado(a): " + label;
        }

        private void menu_pesquisar_Click_1(object sender, EventArgs e)
        {
            SearchScreen form = new SearchScreen();
            form.Show();
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
