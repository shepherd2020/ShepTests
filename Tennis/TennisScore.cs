using static Tennis.Enumerations;

namespace Tennis
{
//bb
    internal class TennisScore
    {
        private PointEnum FirstPlayerScore;
        private PointEnum SecondPlayerScore;

        public TennisScore()
        {
            FirstPlayerScore = 0;
            SecondPlayerScore = 0;
        }

        public TennisScore(PointEnum firstPlayerScore, PointEnum secondPlayerScore)
        {
            FirstPlayerScore = firstPlayerScore;
            SecondPlayerScore = secondPlayerScore;

            //1 3
        }

        internal string PrintResult()
        {
            return GetWinResult() ?? GetDeuceResult() ?? GetAdvantageOfPlayer() ?? $"{GetPlayerScoreAsString(FirstPlayerScore)} - {GetPlayerScoreAsString(SecondPlayerScore)}";
        }

        private string GetWinResult()
        {
            if (FirstPlayerScore == PointEnum.Win)
            {
                return "player one wins";
            }
            else if (SecondPlayerScore == PointEnum.Win)
            {
                return "player two wins";
            }

            return null;
        }

        private string GetDeuceResult()
        {
            return FirstPlayerScore == PointEnum.Fourty && SecondPlayerScore == PointEnum.Fourty ? "deuce" : null;
        }

        private string GetAdvantageOfPlayer()
        {
            if (FirstPlayerScore == PointEnum.Advantage)
                return "player one advantage";
            else if (SecondPlayerScore == PointEnum.Advantage)
                return "player two advantage";
            return null;
        }

        internal void FirstPlayerScorePoint()
        {
            FirstPlayerScore++;
        }

        internal void SecondPlayerScorePoint()
        {
            SecondPlayerScore++;
        }

        private string GetPlayerScoreAsString(PointEnum points)
        {
            switch (points)
            {
                case PointEnum.Love:
                    return "love";
                case PointEnum.Fifteen:
                    return "15";
                case PointEnum.Thirty:
                    return "30";
                case PointEnum.Fourty:
                    return "40";
                default: return "0";
            }
        }
    }
}