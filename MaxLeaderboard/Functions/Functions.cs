using Steamworks.Data;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using MaxLeaderboard.GUI;

namespace MaxLeaderboard.Functions
{
    public class Functions : MonoBehaviour
    {
        /*
         * Creds to various people
         * I found this way of doing it as many others did
         * For idea creds: everyone on UC threads asking for this
         */
        public static async void setLeaderboard()
        {
            Leaderboard? leaderboardAsync = await SteamUserStats.FindOrCreateLeaderboardAsync(string.Format("challenge{0}",
                GameNetworkManager.Instance.GetWeekNumber()),
                LeaderboardSort.Descending, LeaderboardDisplay.Numeric);

            try
            {
                LeaderboardUpdate? replace = await leaderboardAsync.Value.ReplaceScore(int.Parse(MaxRankGUI.rankText));
            }
            catch(OverflowException)
            {
                MaxRankGUI.rankText = int.MaxValue.ToString();
            }
        }
    }
}
