using HarmonyLib;
using ModLoader;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RefillMod
{
    public class Main : SFSMod
    {
        public static GameObject menuObject;

        public Main() : base(
            "refillmod", // mod id
            "RefillMod", // Mod name
            "Dani0105",  // author
            "v1.1.x", // mod loader verison
            "v1.1.0", // mod version
            "This mod add a refill button in wold map", // description
            null, // assets file name
            null //dependecies
            ) 
        {
        }


        private void OnWorldSceneLoaded(object sender, EventArgs e)
        {
            Debug.Log("WorldSceneLoaded");
            GameObject menu = new GameObject("RefillMod");
            menu.AddComponent<Menu>();
            UnityEngine.Object.DontDestroyOnLoad(menu);
            menu.SetActive(true);
            Main.menuObject = menu;
        }

        private void OnHomeSceneLoaded(object sender, EventArgs e)
        {
            Debug.Log("HomeLoaded");
            if (menuObject != null)
            {
                UnityEngine.Object.Destroy(menuObject);
                menuObject = null;
            }
        }

        private void OnBuildSceneLoaded(object sender, EventArgs e)
        {
            Debug.Log("BuildSceneLoaded");
            if (menuObject != null)
            {
                UnityEngine.Object.Destroy(menuObject);
                menuObject = null;
            }
        }

        public override void load()
        {
            Harmony patcher = new Harmony("website.danielrojas.RefillMod");
            patcher.PatchAll();

            Helper.OnWorldSceneLoaded += this.OnWorldSceneLoaded;
            Helper.OnHomeSceneLoaded += this.OnHomeSceneLoaded;
            Helper.OnBuildSceneLoaded += this.OnBuildSceneLoaded;
        }

        public override void unload()
        {
            throw new System.NotImplementedException();
        }
    }
}
