using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine.SceneManagement;
using BepInEx;
using MaxLeaderboard.GUI;

namespace MaxLeaderboard
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Loader : BaseUnityPlugin
    {
        private const string GUID = "MaxLeaderboard";
        private const string NAME = "MaxLeaderboard";
        private const string VERSION = "1.0.0";

        private readonly Harmony harmony = new Harmony(GUID);
        private static Loader Instance;
        public static ManualLogSource mls;

        public static MaxRankGUI myGUI;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(GUID);
            mls.LogInfo($"[+] {NAME} {VERSION} loaded!");
            harmony.PatchAll();

            GameObject GUI_OBJECT = new GameObject("MaxRank GUI");
            DontDestroyOnLoad(GUI_OBJECT);
            GUI_OBJECT.hideFlags = HideFlags.HideAndDontSave;
            GUI_OBJECT.AddComponent<MaxRankGUI>();
            myGUI = (MaxRankGUI)GUI_OBJECT.GetComponent("MaxRank GUI");
        }
    }
}
