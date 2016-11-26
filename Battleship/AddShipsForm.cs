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
                     && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()))) //need to add conditions to prevent overlap.
                    { s.Enabled = false; }
                }
            }
            else if (clicked)
            {
                xEnd = int.Parse(button.Name[3].ToString());
                yEnd = int.Parse(button.Name[4].ToString());
                clicked = false;

                if (xStart > xEnd)
                {
                    int s = xStart;
                    xStart = xEnd;
                    xEnd = s;
                }

                if (yStart > yEnd)
                {
                    int s = yStart;
                    yStart = yEnd;
                    yEnd = s;
                }

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
                else
                {
                    throw new NotImplementedException();
                }

                foreach (Button s in this.Controls.OfType<Button>())
                {
                    if(s.BackColor != Color.Gray)
                    {
                        s.Enabled = true;
                    }
                }

                //change this to conform to 1,2,3,4,5 standard.

                ship = new Ship(sSize, xStart, xEnd, yStart, yEnd);
                this.Close();
            }
        }
    }
}
