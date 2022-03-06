using HarmonyLib;
using ModLoader;
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


        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.name == "World_PC")
            {
                GameObject menu = new GameObject("RefillMod");
                menu.AddComponent<Menu>();
                UnityEngine.Object.DontDestroyOnLoad(menu);
                menu.SetActive(true);
                Main.menuObject = menu;
                return;
            }

            if(scene.name == "Home_PC")
            {
                Debug.Log("Create Arm prefab");
                GameObject arm = this.Assets.LoadAsset<GameObject>("Arm");
                Object.Instantiate(arm, new Vector3(1f, 2f, 3f), Quaternion.identity);
                arm.SetActive(true);
            }

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

            Loader.main.suscribeOnChangeScene(this.OnSceneLoaded);
        }

        public override void unload()
        {
            throw new System.NotImplementedException();
        }
    }
}
