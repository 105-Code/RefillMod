using HarmonyLib;
using ModLoader;
using SFS.Input;
using SFS.Parts.Modules;
using SFS.World;
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

        private void onWorld(object sender, EventArgs e)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Rocket rocket = PlayerController.main.player.Value as Rocket;
                if (rocket)
                {
                    ResourceModule[] tanks = rocket.partHolder.GetModules<ResourceModule>();

                    foreach (ResourceModule tank in tanks)
                    {
                        tank.AddResource(1000f);
                    }
                }
            }
        }

        public override void load()
        {
            Helper.OnUpdateWorldScene += this.onWorld;
        }

        public override void unload()
        {
            throw new System.NotImplementedException();
        }
    }
}
