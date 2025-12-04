using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1
{
    public class Skorboard
    {
        private List<(string playerName, int score)> scores = new List<(string playerName, int score)>();

        // skor ekler ve en yüksek 10 skoru saklar
        public void AddScore(string playerName, int score)
        {
            scores.Add((playerName, score));
            scores = scores.OrderByDescending(s => s.score).Take(10).ToList();
        }

        // en iyi 10 skoru döndürür
        public List<(string playerName, int score)> GetTopScores()
        {
            return scores;
        }
    }
}
