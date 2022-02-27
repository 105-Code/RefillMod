
using SFS.Parts.Modules;
using SFS.World;
using UnityEngine;

namespace RefillMod
{
    class Menu : MonoBehaviour
    {
        public static Rocket playerRocket;

        public Rect windowRect = new Rect((float)Screen.width * 0.05f, (float)Screen.height * 0.05f, 200f, 200f);

        public void OnGUI()
        {
            windowRect = GUI.Window(0, windowRect, new GUI.WindowFunction(this.windowFunc), "Menu");
        }

        public void windowFunc(int windowID)
        {
            if (GUI.Button(new Rect(10f, 20f, 190f, 20f), " Refill tanks"))
            {

                foreach (ResourceModule tank in Menu.playerRocket.partHolder.GetModules<ResourceModule>())
                {
                    tank.AddResource(1000f);
                }
               
            }
        }

    }

}
