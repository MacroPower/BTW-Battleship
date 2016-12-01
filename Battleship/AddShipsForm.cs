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
        private int nsSize;

        public AddShipsForm()
        {
            InitializeComponent();
        }

        public Ship GetNewShip(int size)
        {
            nsSize = size;

            if (size == 1 || size == 2)
                sSize = size + 1;
            else
                sSize = size;

            titleLabel.Text = sSize + "-Place Ship";
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

                btnControlUndo.Enabled = true;

                bool markYDown = false;
                bool markXRight = false;
                bool markYUp = false;
                bool markXLeft = false;

                // Disable impossible buttons and find potential collisions.
                foreach (Button s in this.Controls.OfType<Button>())
                {
                    if (s.Name[3].ToString() == "C") continue;
                    if (!(int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()) + sSize - 1 
                     && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString())
                     || int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()) + sSize - 1
                     && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString())
                     || int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()) - sSize + 1
                     && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString())
                     || int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()) - sSize + 1
                     && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString())))
                    {
                        s.Enabled = false;
                    }
                    
                    for (int x = xStart; x < sSize+xStart; x++)
                    {
                        if (int.Parse(s.Name[3].ToString()) == x
                         && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()))
                        {
                            if (s.BackColor == Color.Gray)
                                markYDown = true;
                        }
                    }
                    for (int y = yStart; y < sSize+yStart; y++)
                    {
                        if (int.Parse(s.Name[4].ToString()) == y
                         && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()))
                        {
                            if (s.BackColor == Color.Gray)
                                markXRight = true;
                        }
                    }

                    for (int x = xStart; x > xStart-sSize; x--)
                    {
                        if (int.Parse(s.Name[3].ToString()) == x
                         && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()))
                        {
                            if (s.BackColor == Color.Gray)
                                markYUp = true;
                        }
                    }
                    for (int y = yStart; y > yStart-sSize; y--)
                    {
                        if (int.Parse(s.Name[4].ToString()) == y
                         && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()))
                        {
                            if (s.BackColor == Color.Gray)
                                markXLeft = true;
                        }
                    }
                }

                // If there is a collision, prevent it from happening.
                foreach (Button s in this.Controls.OfType<Button>())
                {
                    if (s.Name[3].ToString() == "C") continue;
                    if (markYDown)
                    {
                        for (int x = xStart; x < sSize + xStart; x++)
                        {
                            if (int.Parse(s.Name[3].ToString()) == x
                             && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()))
                            {
                                s.Enabled = false;
                            }
                        }
                    }
                    if (markXRight)
                    {
                        for (int y = yStart; y < sSize + yStart; y++)
                        {
                            if (int.Parse(s.Name[4].ToString()) == y
                             && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()))
                            {
                                s.Enabled = false;
                            }
                        }
                    }
                    if (markYUp)
                    {
                        for (int x = xStart; x > xStart-sSize; x--)
                        {
                            if (int.Parse(s.Name[3].ToString()) == x
                             && int.Parse(s.Name[4].ToString()) == int.Parse(button.Name[4].ToString()))
                            {
                                s.Enabled = false;
                            }
                        }
                    }
                    if (markXLeft)
                    {
                        for (int y = yStart; y > yStart-sSize; y--)
                        {
                            if (int.Parse(s.Name[4].ToString()) == y
                             && int.Parse(s.Name[3].ToString()) == int.Parse(button.Name[3].ToString()))
                            {
                                s.Enabled = false;
                            }
                        }
                    }
                }
            }
            else if (clicked)
            {
                xEnd = int.Parse(button.Name[3].ToString());
                yEnd = int.Parse(button.Name[4].ToString());
                clicked = false;

                if (xStart > xEnd)
                {
                    int start = xStart;
                    xStart = xEnd;
                    xEnd = start;
                }

                if (yStart > yEnd)
                {
                    int start = yStart;
                    yStart = yEnd;
                    yEnd = start;
                }

                if (xStart == xEnd)
                {
                    for (int top = yStart; top <= yEnd; top++)
                    {
                        foreach (Button s in this.Controls.OfType<Button>())
                        {
                            if (s.Name[3].ToString() == "C") continue;
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
                            if (s.Name[3].ToString() == "C") continue;
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

                ship = new Ship(nsSize, xStart, xEnd, yStart, yEnd);
                
                this.Close();
            }
        }

        private void btnControlUndo_Click(object sender, EventArgs e)
        {
            clicked = false;
            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.BackColor != Color.Gray)
                {
                    s.Enabled = true;
                }

                if (s.BackColor == Color.Blue)
                {
                    s.Enabled = true;
                    s.UseVisualStyleBackColor = true;
                }
            }
            btnControlUndo.Enabled = false;
        }
    }
}
