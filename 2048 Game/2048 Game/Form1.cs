using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_Game
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        int n = 4;
        public Form1()
        {
            InitializeComponent();

            game_board = new Label[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    game_board[i, j] = new Label();
                    
                    game_board[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    game_board[i, j].Font = new Font("Tahoma", 32);
                    game_board[i, j].BackColor = Color.LightGray;
                    var margin = game_board[i, j].Margin;
                    margin.All = 4;
                    game_board[i, j].Margin= margin; 
                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;


                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);
                }
            }
            Random r = new Random();
            int r1_x, r1_y, r2_x, r2_y, r1, r2;

            int[] init_numbers = { 2, 2, 2, 2, 4 };

            int random_index = r.Next(0, init_numbers.Length);
            r1 = init_numbers[random_index];
            if (init_numbers[random_index] != 4)
            {
                r2 = init_numbers[random_index];

                r1_x = r.Next(0, 3);
                r1_y = r.Next(0, 3);


                do
                {
                    r2_x = r.Next(0, 3);
                    r2_y = r.Next(0, 3);
                }

                while (r1_x == r2_x && r1_y == r2_y);

                game_board[r1_x, r1_y].Text = Convert.ToString(r1);
                game_board[r2_x, r2_y].Text = Convert.ToString(r2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Up)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j > 0 && game_board[i, j - 1].Text == "")
                            {
                                game_board[i, j - 1].Text = game_board[i, j].Text;
                                game_board[i, j].Text = "";
                            }
                        }
                    }
                }
            }
            else if (e.KeyData == Keys.Down)
            {

            }
        }
    }
}
