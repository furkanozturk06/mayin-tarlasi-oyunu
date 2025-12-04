namespace WindowsFormsApp1
{
    partial class SkorboardForm
    {
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label lblScores;

        private void InitializeComponent()
        {
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Location = new System.Drawing.Point(20, 20);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(0, 13);
            this.lblPlayerScore.TabIndex = 0;
            this.Controls.Add(this.lblPlayerScore);

            this.lblScores.AutoSize = true;
            this.lblScores.Location = new System.Drawing.Point(20, 50);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(0, 13);
            this.lblScores.TabIndex = 1;
            this.Controls.Add(this.lblScores);

   
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Name = "SkorboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
