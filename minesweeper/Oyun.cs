using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public class Oyun
    {
        private byte[,] Positions;
        private Button[,] ButtonList;
        private int gridSize;
        private int mineCount;
        private int flagCount;
        private int moves;
        private int correctFlags;
        private int points;
        private Stopwatch timer;
        private string playerName;
        private Form1 mainForm;
        public string PlayerName { get; set; } // oyuncu adı
        public int Points { get; set; }        // skor puanı

        public Oyun(Form1 form)
        {
            mainForm = form;

        }

        public void InitializeGame(int gridSize, int mineCount, string playerName)
        {  
            if (mineCount <= 10)
            {
                MessageBox.Show("En az 10 mayın olması gerekmektedir. Bu yüzden oyun, alt sınır olan 10 mayın ile başlayacak. Haberiniz olsun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mineCount = 10; // minimum mayın sayısı 10 a ayarlandı
            }


            this.gridSize = gridSize;
            this.mineCount = mineCount;
            this.playerName = playerName;
            flagCount = mineCount;
            moves = 0;
            points = 0;
            correctFlags = 0;

            Positions = new byte[gridSize, gridSize];
            ButtonList = new Button[gridSize, gridSize];
            timer = new Stopwatch();

            GenerateBombs();
            GeneratePositionValues();
            GenerateButtons();

            timer.Start();
            mainForm.UpdateMoves(moves);
            mainForm.UpdatePlayerName(playerName);
            mainForm.UpdateFlagCount(flagCount);
            mainForm.UpdateElapsedTime(0);
        }

       
        

        private void GenerateBombs()
        {
            Random rnd = new Random();
            int bombs = 0;
            while (bombs < mineCount)
            {
                int x = rnd.Next(0, gridSize);
                int y = rnd.Next(0, gridSize);
                if (Positions[x, y] == 0)
                {
                    Positions[x, y] = 10;
                    bombs++;
                }
            }
        }

        private void GeneratePositionValues()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (Positions[x, y] == 10) continue;
                    byte bombCount = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nx = x + i, ny = y + j;
                            if (nx >= 0 && ny >= 0 && nx < gridSize && ny < gridSize && Positions[nx, ny] == 10)
                                bombCount++;
                        }
                    }
                    Positions[x, y] = bombCount;
                }
            }
        }

        private void GenerateButtons()
        {
            int buttonSize = 25;
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(x * buttonSize, y * buttonSize),
                        Tag = new Point(x, y)
                    };
                    btn.Click += Button_Click;
                    btn.MouseUp += Button_MouseUp;
                    mainForm.Controls.Add(btn);
                    ButtonList[x, y] = btn;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point pt = (Point)btn.Tag;
            int x = pt.X, y = pt.Y;

            if (btn.BackgroundImage != null) // bayrakların olduğu yere tıklanmaz
                return;

            if (Positions[x, y] == 10)
            {
                ShowAllMines();
                timer.Stop();
                MessageBox.Show("Game Over! Tüm mayınlar açıldı.");
                mainForm.Update();
            }
            else
            {
                OpenCell(x, y);
                moves++;
                mainForm.UpdateMoves(moves);

                if (CheckWinCondition())
                {
                    timer.Stop();
                    MarkRemainingMines();
                    int elapsedSeconds = (int)timer.Elapsed.TotalSeconds;
                    points = (int)((double)correctFlags / elapsedSeconds * 1000);
                    mainForm.UpdateScore(points);
                    MessageBox.Show("Tebrikler! Oyunu Kazandınız!");
                    MessageBox.Show("EN İYİ 10 SKOR\n1- Oyuncu: Adınız\n");
                }

            }
        
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Point pt = (Point)btn.Tag;
            int x = pt.X, y = pt.Y;

            if (e.Button == MouseButtons.Right)
            {
                if (btn.BackgroundImage == null && flagCount > 0)
                {
                    btn.BackgroundImage = Properties.Resources.flag;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    flagCount--;

                    if (Positions[x, y] == 10)
                        correctFlags++;

                    mainForm.UpdateFlagCount(flagCount);
                }
                else if (btn.BackgroundImage != null)
                {
                    btn.BackgroundImage = null;
                    flagCount++;

                    if (Positions[x, y] == 10)
                        correctFlags--;

                    mainForm.UpdateFlagCount(flagCount);
                }
            }
        }

        private void ShowAllMines()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (Positions[x, y] == 10)
                    {
                        ButtonList[x, y].BackgroundImage = Properties.Resources.bomb;
                        ButtonList[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }

        private void OpenCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= gridSize || y >= gridSize || ButtonList[x, y].Enabled == false)
                return;

            ButtonList[x, y].Text = Positions[x, y] == 0 ? "" : Positions[x, y].ToString();
            ButtonList[x, y].Enabled = false;

            if (Positions[x, y] == 0)
            {
                OpenCell(x - 1, y);
                OpenCell(x + 1, y);
                OpenCell(x, y - 1);
                OpenCell(x, y + 1);
            }
        }

        private bool CheckWinCondition()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (Positions[x, y] != 10 && ButtonList[x, y].Enabled)
                        return false;
                }
            }

            //oyun kazanıldı skoru kaydet
            mainForm.GetSkorboard().AddScore(playerName, points);

            return true;
        }
        public void EndGame(bool won)
        {
            timer.Stop();
            timer.Stop();

            // skoru hesapla ve formu göster
            int elapsedSeconds = (int)timer.Elapsed.TotalSeconds;
            int playerScore = (int)((double)correctFlags / elapsedSeconds * 1000);

            // form1 den skorboardı göster
            mainForm.ShowScoreboard(playerName, playerScore);  
        }

        private void MarkRemainingMines()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (Positions[x, y] == 10 && ButtonList[x, y].BackgroundImage == null)
                    {
                        ButtonList[x, y].BackgroundImage = Properties.Resources.flag;
                        ButtonList[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                        correctFlags++;
                    }
                }
            }


        }
        
       

    }

}
