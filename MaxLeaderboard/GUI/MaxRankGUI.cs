using Steamworks;
using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using MaxLeaderboard.Functions;

namespace MaxLeaderboard.GUI
{
    public class MaxRankGUI : MonoBehaviour
    {
        public static bool showMenu = false;
        public static bool lockedCursor = false;

        private const int GUI_WIDTH = 250;
        private const int GUI_HEIGHT = 150;
        private static float GUI_X_POS = (Screen.width / 2) - (GUI_WIDTH / 2);
        private static float GUI_T_POS = (Screen.height / 2) - (GUI_HEIGHT / 2);

        private Rect MAIN_WINDOW = new Rect(Screen.width / 2, Screen.height / 2, GUI_WIDTH, GUI_HEIGHT - 75);

        private float scrollPos = 0f;
        private UnityEngine.Vector2 scrollPosition = UnityEngine.Vector2.zero;
        private Rect scrollViewRect = new Rect(5, 45, GUI_WIDTH - 20, GUI_HEIGHT - 145);

        public static string rankText = "0";

        private void Awake()
        {
            Loader.mls.LogInfo("[+] GUI Loaded!");
        }

        private void Update()
        {
            if (Keyboard.current[Key.Insert].wasPressedThisFrame)
            {
                showMenu = !showMenu;
                Cursor.visible = showMenu;
                Cursor.lockState = (CursorLockMode)2;

                QuickMenuManager menuManager = GameObject.FindObjectOfType<QuickMenuManager>();

                if (menuManager == null) return;
                menuManager.isMenuOpen = showMenu;
            }
        }

        private void OnGUI()
        {
            if (showMenu)
            {
                MAIN_WINDOW = UnityEngine.GUI.Window(0, MAIN_WINDOW, doWindow, "Challenge Rank Selector");
            }
        }

        private async void doWindow(int windowID)
        {
            rankText = UnityEngine.GUI.TextField(new Rect(5, GUI_HEIGHT - 130, GUI_WIDTH - 10, GUI_HEIGHT - 120), rankText, 10);

            if (UnityEngine.GUI.Button(new Rect(5, GUI_HEIGHT - 100, GUI_WIDTH - 10, 20), "Set"))
            {
                if (rankText.Equals("max"))
                {
                    rankText = int.MaxValue.ToString();
                }

                Functions.Functions.setLeaderboard();
            }

            UnityEngine.GUI.DragWindow();
        }
    }
}
