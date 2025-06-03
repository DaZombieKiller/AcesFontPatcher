using BepInEx;
using BepInEx.Unity.Mono;
using HarmonyLib;
using FallenAces.HUD;
using UnityEngine;
using TMPro;
using System.IO;
using BepInEx.Configuration;

namespace AcesFontPatcher;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public sealed class AcesFontPatch : BaseUnityPlugin
{
    private ConfigEntry<string> _subtitleFontName;

    private static TMP_FontAsset _subtitleFont;

    private void Awake()
    {
        BindConfigEntries();
        var bundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "fonts"));

        if (!string.IsNullOrEmpty(_subtitleFontName.Value) && _subtitleFontName.Value != "None")
            _subtitleFont = TMP_FontAsset.CreateFontAsset(bundle.LoadAsset<Font>(_subtitleFontName.Value));

        Harmony.CreateAndPatchAll(typeof(AcesFontPatch));
    }

    private void BindConfigEntries()
    {
        _subtitleFontName = Config.Bind("Fonts", "Subtitles", "None", "Subtitle font replacement");
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(SubtitleController), "Awake")]
    private static void PostAwake(SubtitleController __instance)
    {
        if (_subtitleFont == null)
            return;

        foreach (SubtitleController.Subtitle subtitle in __instance._subtitles)
        {
            subtitle.TextMesh.font = _subtitleFont;
            subtitle.TextMesh.UpdateFontAsset();
        }
    }
}
