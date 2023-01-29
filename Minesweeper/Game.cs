using System;
using System.Drawing;
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
            Text = "Minesweeper";
            Size = new System.Drawing.Size(30 * COLS, 30 * ROWS);
            // Initialize the minefield
            mines = new bool[ROWS, COLS];

            for (int i = 0; i < MINES; i++)
            {
                int row = new Random().Next(ROWS);
                int col = new Random().Next(COLS);
                while (mines[row, col])
                {
                    row = new Random().Next(ROWS);
                    col = new Random().Next(COLS);
                }
                mines[row, col] = true;
                
            }
            //afficher dans la console le tableau mines 
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Console.Write(mines[row, col] + " ");
                }
                Console.WriteLine();
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
                button.BackgroundImage = Image.FromFile("../../bomb.png");
                //MessageBox.Show("You hit a mine! Game over.");
                //Game game = new Game();
                //game.Show();
                //Application.Exit();
            }
            else 
            {
                // Reveal the number of surrounding mines
                int count = GetSurroundingMines(row, col);
                button.Text = count.ToString();
                button.BackColor = Color.LightGray;
                if(count == 0)
                {
                    bool[,] visited = new bool[ROWS, COLS];
                    RevealSurroundingCells(row, col, visited);
                    
                }
                
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
        /** Reveal the surrounding cells */
        private void RevealSurroundingCells(int row, int col,bool[,] visited)
        {
            visited[row,col] = true;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < ROWS && j >= 0 && j < COLS && !mines[i, j] && !visited[i,j])
                    {
                        int count = GetSurroundingMines(i, j);
                        if (count == 0)
                        {
                            RevealSurroundingCells(i, j,visited);
                            buttons[i, j].BackColor = Color.LightGray;
                        }
                        if (!(count == 0))
                        {
                            buttons[i, j].Text = count.ToString();
                            buttons[i, j].BackColor = Color.LightGray;
                        }
                    }
                }
            }
        }


    }
    
    
}
    
