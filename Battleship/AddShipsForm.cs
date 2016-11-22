using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class AddShipsForm : Form
    {
        private Ship ship;

        public AddShipsForm()
        {
            InitializeComponent();
        }

        public Ship GetNewShip(int size)
        {
            titleLabel.Text = size + "-Place Ship";
            this.ShowDialog();
            return ship;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ship = new Ship(0, int.Parse(txtXVal.Text), int.Parse(txtXVal2.Text), int.Parse(txtYVal.Text), int.Parse(txtYVal2.Text));
            this.Close();
        }
    }
}
