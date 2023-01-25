using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Game : Form
    {
        // Declare variables for the game
        private int ROWS;
        private int COLS;
        private int MINES;
        private bool[,] mines;
        private Button[,] buttons;

        public Game()
        {
        }

        public void StartButtonClick(object sender, TextBox rowsTextBox, TextBox colsTextBox, TextBox minesTextBox)
        {
            // Get the input values from the input form
            ROWS = int.Parse(rowsTextBox.Text);
            COLS = int.Parse(colsTextBox.Text);
            MINES = int.Parse(minesTextBox.Text);

            // Initiale the form
            Text = "test";
            Size = new System.Drawing.Size(30 * COLS, 30 * ROWS);
            // Initialize the minefield
            mines = new bool[ROWS, COLS];
            for (int i = 0; i < MINES; i++)
            {
                int row = new Random().Next(ROWS);
                int col = new Random().Next(COLS);
                mines[row, col] = true;
            }

            // Initialize the buttons
            buttons = new Button[ROWS, COLS];
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row, col].Size = new System.Drawing.Size(30, 30);
                    buttons[row, col].Location = new System.Drawing.Point(30 * col, 30 * row);
                    buttons[row, col].Click += new EventHandler(ButtonClick);
                    Controls.Add(buttons[row, col]);
                }
            }
        }


        private void ButtonClick(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Button button = (Button)sender;

            // Get the row and column of the button
            int row = button.Location.Y / 30;
            int col = button.Location.X / 30;

            // Check if the button is a mine
            if (mines[row, col])
            {
                // Game over
                MessageBox.Show("You hit a mine! Game over.");
                Application.Exit();
            }
            else
            {
                // Reveal the number of surrounding mines
                int count = GetSurroundingMines(row, col);
                button.Text = count.ToString();
            }
        }

        /** Return the number of mines surrounding the given cell */
        private int GetSurroundingMines(int row, int col)
        {
            // Count the number of surrounding mines
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < ROWS && j >= 0 && j < COLS && mines[i, j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
    
