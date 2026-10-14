using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Buzzer.Properties;

namespace Buzzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(Resources.mixkit_basketball_buzzer_1647);
            sp.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(Resources.mixkit_basketball_buzzer_1647);
            sp.Play();
        }
    }
}
