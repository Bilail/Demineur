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
        private int restant;

        public Game()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public void StartButtonClick(object sender, TextBox rowsTextBox, TextBox colsTextBox, TextBox minesTextBox)
        {
            // Get the input values from the input form
            ROWS = int.Parse(rowsTextBox.Text);
            COLS = int.Parse(colsTextBox.Text);
            MINES = int.Parse(minesTextBox.Text);
            restant = ROWS * COLS - MINES;

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
                revealAllMines();
                if(MessageBox.Show("You hit a mine! Game over. \n Do you want to play again?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
                //Game game = new Game();
                //game.Show();
                //Application.Exit();
            }
            else 
            {
                restant--;
                // Reveal the number of surrounding mines
                int count = GetSurroundingMines(row, col);
                if(count != 0)
                {
                    button.Text = count.ToString();
                }
                if (button.Text == "1")
                {
                    button.ForeColor = Color.Blue;
                }
                if (button.Text == "2")
                {
                    button.ForeColor = Color.Green;
                }
                if (button.Text == "3")
                {
                    button.ForeColor = Color.Red;
                }
                button.BackColor = Color.LightGray;
                win();
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
                        visited[i,j] = true;
                        
                        int count = GetSurroundingMines(i, j);
                        if (count == 0)
                        {
                            RevealSurroundingCells(i, j,visited);
                            if(buttons[i,j].Text == "" && buttons[i,j].BackColor != Color.LightGray)
                            {
                                restant--;
                                
                            }
                            buttons[i, j].BackColor = Color.LightGray;
                            win();
                        }
                        else
                        {
                            if(buttons[i,j].Text == "" && buttons[i,j].BackColor != Color.LightGray)
                            {
                                restant--;
                            }
                            buttons[i, j].Text = count.ToString();
                            if (buttons[i, j].Text == "1")
                            {
                                buttons[i, j].ForeColor = Color.Blue;
                            }
                            if (buttons[i, j].Text == "2")
                            {
                                buttons[i, j].ForeColor = Color.Green;
                            }
                            if (buttons[i, j].Text == "3")
                            {
                                buttons[i, j].ForeColor = Color.Red;
                            }
                            buttons[i, j].BackColor = Color.LightGray;
                            
                            win();
                        }
                    }
                }
            }
        }

        public void revealAllMines()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (mines[row, col])
                    {
                        buttons[row, col].BackgroundImage = Image.FromFile("../../bomb.png");
                        buttons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }
        
        public void win()
        {
            if(restant == 0)
            {
                revealAllMines();
                if (MessageBox.Show("You won! \n Do you want to play again?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        


    }
    
    
}
    
