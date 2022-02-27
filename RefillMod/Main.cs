using HarmonyLib;
using ModLoader;
using SFS;
using SFS.Parts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RefillMod
{
    public class Main : SFSMod
    {
        public static GameObject menuObject;

        public static Harmony patcher;
        public string getModAuthor()
        {
            return "Dani0105";
        }

        public string getModName()
        {
            return "ReFill";
        }

        public void load()
        {
            Main.patcher = new Harmony("website.danielrojas.RefillMod");
            Main.patcher.PatchAll();

            Loader.modLoader.suscribeOnChangeScene(this.OnSceneLoaded);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.name == "World_PC")
            {
                GameObject menu = new GameObject("RefillMod");
                menu.AddComponent<Menu>();
                UnityEngine.Object.DontDestroyOnLoad(menu);
                menu.SetActive(true);
                Main.menuObject = menu;
            }
            else
            {
                UnityEngine.Object.Destroy(menuObject);
            }
        }

        public void unload()
        {
            throw new System.NotImplementedException();
        }
    }
}
