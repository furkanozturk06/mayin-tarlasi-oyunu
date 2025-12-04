using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SkorboardForm : Form
    {
        public SkorboardForm(string playerName, int playerScore, Skorboard skorboard)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(300, 400);
            // oyuncunun adı ve skoru 
            lblPlayerScore.Text = $"Oyuncu: {playerName} - Skor: {playerScore}";

            // en iyi 10 skor
            var topScores = skorboard.GetTopScores();
            lblScores.Text = "En İyi 10 Skor:\n" +
                             string.Join("\n", topScores.Select(s => $"{s.playerName} - {s.score}"));
        }
    }
}
