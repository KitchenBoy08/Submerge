using Submerge.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Logger = Submerge.Utilities.Logger;

namespace Submerge.GameTweaks;

public class MainMenuTweak : GameTweak
{
    public override void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene loadedScene, LoadSceneMode sceneMode)
    {
        if (loadedScene.name != "XMenu")
            return;
        
        // Change play button text
        GameObject.Destroy(UICreator.PlayButton.GetComponentInChildren<TranslationLiveUpdate>());
        TextMeshProUGUI playText = UICreator.PlayButton.GetComponentInChildren<TextMeshProUGUI>();
        playText.text = "Singleplayer";

        // Add multiplayer menu
        MainMenuGroup group = UICreator.CreateMenuGroup("Multiplayer");
        group.CreateGroupButton("Host a New Game", () => Logger.Log("TEST"), 0);
        group.CreateGroupButton("Host an Existing Save", () => Logger.Log("TEST"), 1);
        group.CreateGroupButton("Join Server", () => Logger.Log("TEST"), 2);;
        
        UICreator.CreatePrimaryButton("Multiplayer", () => MainMenuRightSide.main.OpenGroup("Multiplayer"), 1);
    }
}