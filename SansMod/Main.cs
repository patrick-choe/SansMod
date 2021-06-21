using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace SansMod
{
    internal static class Main
    {
        private static Harmony _harmony;

        private static bool Load(UnityModManager.ModEntry entry)
        {
            entry.OnToggle = (modEntry, value) =>
            {
                if (value)
                {
                    _harmony = new Harmony(modEntry.Info.Id);
                    _harmony.PatchAll(Assembly.GetExecutingAssembly());
                }
                else
                {
                    AccessTools.Field(typeof(Sans), "Speed").SetValue(Object.FindObjectOfType<Sans>(), 25);
                    _harmony.UnpatchAll(_harmony.Id);
                    _harmony = null;
                }

                return true;
            };

            return true;
        }

        [HarmonyPatch(typeof(Sans), "Update")]
        private static class SansUpdatePatch
        {
            private static void Prefix(ref int ___Speed)
            {
                if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
                {
                    ___Speed = Mathf.Clamp(___Speed + 5, 0, 100);
                }

                if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
                {
                    ___Speed = Mathf.Clamp(___Speed - 5, 0, 100);
                }
            }
        }
    }
}