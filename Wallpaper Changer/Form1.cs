using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Wallpaper_Changer
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]

        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        UInt32 SPI_SETWALL = 0x14;
        UInt32 SPIF_UPDATE = 0x01;
        UInt32 SPIF_SWEDWINI = 0x2;

        OpenFileDialog op = new OpenFileDialog();
        string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (op.ShowDialog() == DialogResult.OK)
            {
                filePath = op.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SystemParametersInfo(SPI_SETWALL, 0, filePath, SPIF_UPDATE | SPIF_SWEDWINI);
        }
    }
}
