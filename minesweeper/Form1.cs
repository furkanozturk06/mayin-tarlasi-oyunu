using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Oyun oyun;
        private Skorboard skorboard;
        private Button restartButton;
        private Label lblMoves;
        private Label lblScore;
        private Label lblTime;
        private Label lblPlayerName;
        private Label lblDeveloperInfo;
        private Timer gameTimer;
        private int elapsedTime; //süre

        public Form1()
        {
            InitializeComponent();

            // form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // restart butonu
            restartButton = new Button();
            restartButton.Text = "Restart";
            restartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            restartButton.Click += RestartButton_Click;
            this.Controls.Add(restartButton);

            // etiketler
            lblMoves = new Label();
            lblMoves.Text = "Hamle: 0";
            this.Controls.Add(lblMoves);

            lblScore = new Label();
            lblScore.Text = "Skor: 0";
            this.Controls.Add(lblScore);

            lblTime = new Label();
            lblTime.Text = "Geçen Süre: 0s";
            this.Controls.Add(lblTime);

            lblPlayerName = new Label();
            lblPlayerName.Text = "Oyuncu: -";
            this.Controls.Add(lblPlayerName);

            lblDeveloperInfo = new Label();
            lblDeveloperInfo.Text = "Yapımcı: Furkan Öztürk\n230229083";
            this.Controls.Add(lblDeveloperInfo);

            oyun = new Oyun(this);
            skorboard = new Skorboard();
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 saniye
            gameTimer.Tick += GameTimer_Tick;
            ShowPlayerInfo();

        }

        private void ShowPlayerInfo()
        {
            // oyuncu bilgisi al
            string playerName = Interaction.InputBox("Oyuncu Adı:", "Oyuna Başla", "Adınız");
            int gridSize = Convert.ToInt32(Interaction.InputBox("Grid Boyutu (en fazla 30):", "Grid Boyutu", "15"));
            gridSize = Math.Min(gridSize, 30); // max boyut sınırlaması
            int mineCount = Convert.ToInt32(Interaction.InputBox("Mayın Sayısı (en az 10):", "Mayın Sayısı", "30"));
            mineCount = Math.Max(mineCount, 10); // min mayın sayısı kontrolü


            // oyunu başlat
            oyun.InitializeGame(gridSize, mineCount, playerName);

           
            

            
            AdjustFormSize(gridSize);
            elapsedTime = 0; // süreyi sıfırla
            gameTimer.Start(); // zamanlayıcıyı başlat
        }


        private void AdjustFormSize(int gridSize)
        {
            // elle yazılan form boyutu
            this.Size = new Size(gridSize * 30 + 200, gridSize * 30 + 150); 
            restartButton.Location = new Point(gridSize * 30 + 110, 10);

            // etiketleri sağ tarafa konumlandır
            lblMoves.Location = new Point(gridSize * 30 + 110, 50);
            lblScore.Location = new Point(gridSize * 30 + 110, 80);
            lblTime.Location = new Point(gridSize * 30 + 110, 110);
            lblPlayerName.Location = new Point(gridSize * 30 + 110, 140);
            lblDeveloperInfo.Location = new Point(gridSize * 30 + 110, 170);
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            gameTimer.Stop(); // süreyi durdur
            
            ShowPlayerInfo();
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime++; // süreyi bir artır
            UpdateElapsedTime(elapsedTime); // süreyi güncelle
        }

        public void UpdateMoves(int moves)
        {
            lblMoves.Text = "Hamle: " + moves;
        }

        public void UpdateScore(int score)
        {
            lblScore.Text = "Skor: " + score;
        }

        public void UpdateFlagCount(int flagCount)
        {
          
        }

        public void UpdateElapsedTime(int seconds)
        {
            lblTime.Text = "Geçen Süre: " + seconds + "s";
        }

        public void UpdatePlayerName(string playerName)
        {
            lblPlayerName.Text = "Oyuncu: " + playerName;
        }

        public Skorboard GetSkorboard()
        {
            return skorboard;
        }
        

        public void Update_Moves(int moves) => lblMoves.Text = "Hamle: " + moves;

        public void Update_Score(int score) => lblScore.Text = "Skor: " + score;

        public void ShowScoreboard(string playerName, int score)
        {
            skorboard.AddScore(playerName, score);
            SkorboardForm scoreboardForm = new SkorboardForm(playerName, score, skorboard);
            scoreboardForm.ShowDialog();
        }

        private void RestartButtonClick(object sender, EventArgs e)
        {
            gameTimer.Stop();
            ShowPlayerInfo();
        }

        private void GameTimerTick(object sender, EventArgs e)
        {
            elapsedTime++;
        }

    }


}
