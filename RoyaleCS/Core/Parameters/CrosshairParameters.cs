namespace RoyaleCS.Core.Other
{
    internal class CrosshairParameters
    {
        internal int TriggeredEnemy { get; }

        internal int TriggeredEnemyTeam { get; }

        internal int TriggeredValue { get; }



        public CrosshairParameters(int triggeredEnemy, int triggeredEnemyTeam, int triggeredValue)
        {
            TriggeredEnemy = triggeredEnemy;
            TriggeredEnemyTeam = triggeredEnemyTeam;
            TriggeredValue = triggeredValue;
        }



        internal bool TriggerIsTeammate()
        {
            return Player.TeamNum == TriggeredEnemyTeam;
        }
    }
}
