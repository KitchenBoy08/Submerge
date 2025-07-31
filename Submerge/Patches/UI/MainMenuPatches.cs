using HarmonyLib;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static UnityEngine.Object;

namespace Submerge.Patches;

[HarmonyPatch(typeof(uGUI_MainMenu))]
public class MainMenuPatches
{
    [HarmonyPatch("Awake")]
    [HarmonyPostfix]
    private static void AwakePatch(uGUI_MainMenu __instance)
    {
        SetupMultiplayerMenu(__instance);
    }

    private static void SetupMultiplayerMenu(uGUI_MainMenu __instance)
    {
        SetupMultiplayerTab(__instance);
        SetupMultiplayerButton(__instance);
    }
    
    private static void SetupMultiplayerTab(uGUI_MainMenu __instance)
    {
        var playTab = __instance.primaryOptions.transform.Find("RightSide/SavedGames").gameObject;
        var homeTab = __instance.primaryOptions.transform.Find("RightSide/Home").gameObject;
        
        var joinServerTab = Instantiate(homeTab, homeTab.transform.parent);
        joinServerTab.name = "JoinServer";
        var joinServerHeaderText = joinServerTab.GetComponentInChildren<TextMeshProUGUI>();
        joinServerHeaderText.text = "Join Server";
        __instance.rightSide.groups.Add(joinServerTab.GetComponentInChildren<MainMenuGroup>());
        
        // Strip unnecessary menu items
        Destroy(joinServerTab.transform.GetChild(0).gameObject);
        Destroy(joinServerTab.transform.GetChild(1).gameObject);
        Destroy(joinServerTab.transform.GetChild(2).GetChild(3).gameObject);
        Destroy(joinServerTab.transform.GetChild(2).GetChild(4).gameObject);
        Destroy(joinServerTab.transform.GetChild(2).GetChild(5).gameObject);
        Destroy(joinServerTab.transform.GetChild(2).GetChild(6).gameObject);
        
        // Change text of certain elements
        try
        {
            joinServerTab.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text =
                "Join Server";
            joinServerTab.transform.GetChild(2).GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>().text =
                "Enter the Steam ID of the host you want to join";
        }
        catch (Exception e)
        {
            MelonLogger.Error(e);
        }
        
        var multiplayerTab = Instantiate(playTab, playTab.transform.parent);
        multiplayerTab.name = "Multiplayer";
        var multiplayerHeaderText = multiplayerTab.GetComponentInChildren<TextMeshProUGUI>();
        multiplayerHeaderText.text = "Multiplayer";
        __instance.rightSide.groups.Add(multiplayerTab.GetComponentInChildren<MainMenuGroup>());

        var joinServerButton = multiplayerTab.transform.Find("Scroll View/Viewport/SavedGameAreaContent/NewGame").gameObject;
        var joinServerButtonText = joinServerButton.GetComponentInChildren<TextMeshProUGUI>();
        joinServerButtonText.text = "Join Server";
        
        var multiplayerButtonMethod = joinServerButton.GetComponentInChildren<Button>();
        multiplayerButtonMethod.onClick = new Button.ButtonClickedEvent();
        multiplayerButtonMethod.onClick.AddListener(() => __instance.rightSide.OpenGroup("JoinServer"));
    }
    
    private static void SetupMultiplayerButton(uGUI_MainMenu __instance)
    {
        var playButton = __instance.primaryOptions.transform.Find("PrimaryOptions/MenuButtons/ButtonPlay").gameObject;
        
        var multiplayerButton = Instantiate(playButton, playButton.transform.parent);
        multiplayerButton.name = "ButtonMultiplayer";
        var multiplayerButtonText = multiplayerButton.GetComponentInChildren<TextMeshProUGUI>();
        multiplayerButtonText.text = "Multiplayer";
        multiplayerButton.transform.SetSiblingIndex(1);
        
        var multiplayerButtonMethod = multiplayerButton.GetComponent<Button>();
        multiplayerButtonMethod.onClick = new Button.ButtonClickedEvent();
        multiplayerButtonMethod.onClick.AddListener(() => __instance.rightSide.OpenGroup("Multiplayer"));
        
        var singleplayerButtonText = playButton.GetComponentInChildren<TextMeshProUGUI>();
        singleplayerButtonText.text = "Singleplayer";
    }
}