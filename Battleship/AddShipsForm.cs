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
        private int xStart;
        private int xEnd;
        private int yStart;
        private int yEnd;
        private bool clicked = false;
        private int sSize;

        public AddShipsForm()
        {
            InitializeComponent();
        }

        public Ship GetNewShip(int size)
        {
            sSize = size;
            titleLabel.Text = size + "-Place Ship";
            this.ShowDialog();
            return ship;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ship = new Ship(0, int.Parse(txtXVal.Text), int.Parse(txtXVal2.Text), int.Parse(txtYVal.Text), int.Parse(txtYVal2.Text));
            this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (!clicked)
            {
                xStart = int.Parse(button.Name[3].ToString());
                yStart = int.Parse(button.Name[4].ToString());
                clicked = true;
                button.BackColor = Color.Blue;
                button.Enabled = false;
                //set buttons to prevent errors
                foreach (Button s in this.Controls.OfType<Button>())
                {
                    if (!(int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()) + sSize - 1 
                     && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString())
                     || int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()) + sSize - 1
                     && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString())
                     || int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()) - sSize + 1
                     && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString())
                     || int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()) - sSize + 1
                     && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString())))
                    { s.Enabled = false; }
                }
            }
            else if (clicked)
            {
                xEnd = int.Parse(button.Name[3].ToString());
                yEnd = int.Parse(button.Name[4].ToString());
                ship = new Ship(0, xStart, xEnd, yStart, yEnd);

                if (xStart == xEnd)
                {
                    for (int top = yStart; top <= yEnd; top++)
                    {
                        foreach (Button s in this.Controls.OfType<Button>())
                        {
                            if (int.Parse(s.Name[3].ToString()) == xStart
                             && int.Parse(s.Name[4].ToString()) == top)
                            {
                                s.BackColor = Color.Gray;
                            }
                        }
                    }
                }
                else if (yStart == yEnd)
                {
                    for (int top = xStart; top <= xEnd; top++) //same goes
                    {
                        foreach (Button s in this.Controls.OfType<Button>())
                        {
                            if (int.Parse(s.Name[4].ToString()) == yStart
                             && int.Parse(s.Name[3].ToString()) == top)
                            {
                                s.BackColor = Color.Gray;
                            }
                        }
                    }
                }


                foreach (Button s in this.Controls.OfType<Button>())
                {
                    if(s.BackColor != Color.Gray)
                    {
                        s.Enabled = true;
                    }
                }
                clicked = false;
                this.Close();
            }
        }
    }
}
