using Submerge.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Submerge.Utilities;

public static class UICreator
{
    private static GameObject _playButton;
    private static GameObject _newGameButton;
    private static GameObject _savedGames;
    private static GameObject _inputBox;
    private static GameObject _newGame;
    
    public static GameObject PlayButton
    {
        get
        {
            if (_playButton == null)
            {
                _playButton = GameObject.Find(GamePaths.PLAY_BUTTON);
            }

            return _playButton;
        }
    }

    public static GameObject NewGameButton
    {
        get
        {
            if (_newGameButton == null)
            {
                _newGameButton = GameObject.Find(GamePaths.NEWGAME_BUTTON);
            }
            
            return _newGameButton;
        }
    }
        
    public static GameObject SavedGames
    {
        get
        {
            if (_savedGames == null)
            {
                _savedGames = MainMenuRightSide.main.gameObject.transform.Find("SavedGames").gameObject;
            }

            return _savedGames;
        }
    }

    public static GameObject NewGame
    {
        get
        {
            if (_newGame == null)
            {
                _newGame = MainMenuRightSide.main.gameObject.transform.Find("NewGame").gameObject;
            }

            return _newGame;
        }
    }

    public static GameObject InputBox
    {
        get
        {
            if (_inputBox == null)
            {
                _inputBox = GameObject.Find(GamePaths.INPUT_MENU);
            }

            return _inputBox;
        }
    }

    public static GameObject CreatePrimaryButton(string text, Action onClick, int index = 0)
    {
        // Instantiate new button
        var buttonObject = Object.Instantiate(PlayButton, PlayButton.transform.parent);
        buttonObject.name = $"Button {text}";
        buttonObject.transform.SetSiblingIndex(index);
        
        // Change button action
        var button = buttonObject.GetComponent<Button>();
        button.onClick = new();
        button.onClick.AddListener(new UnityAction(onClick));
        
        // Change button text
        var buttonText = buttonObject.transform.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = text;
        Object.Destroy(buttonText.GetComponent<TranslationLiveUpdate>());
        
        return buttonObject;
    }

    public static MainMenuGroup CreateMenuGroup(string name)
    {
        var menuObject = Object.Instantiate(SavedGames, SavedGames.transform.parent);
        menuObject.name = name;
        
        // Strip componenets
        foreach (var translation in menuObject.transform.GetComponentsInChildren<TranslationLiveUpdate>())
            Object.Destroy(translation);
        Object.Destroy(menuObject.GetComponent<MainMenuLoadPanel>());
        
        // Rename header
        var headerObject = menuObject.transform.Find("Header");
        var headerText = headerObject.GetComponent<TextMeshProUGUI>();
        headerText.text = name;
        
        // Strip buttons
        GameObject saveGameAreaObject = menuObject.transform.Find("Scroll View/Viewport/SavedGameAreaContent").gameObject;
        for (var i = 0; i < saveGameAreaObject.transform.childCount; i++)
        {
            var child = saveGameAreaObject.transform.GetChild(i);
            Object.Destroy(child.gameObject);
        }
        
        // Add and return group
        MainMenuGroup group = menuObject.GetComponent<MainMenuGroup>();
        MainMenuRightSide.main.groups.Add(group);
        return group;
    }

    public static void CreateGroupButton(this MainMenuGroup menuGroup, string text, Action onClick, int index = 0)
    {
        // Instantiate and transform
        var areaContentObject = menuGroup.transform.Find("Scroll View/Viewport/SavedGameAreaContent");
        var buttonObject = Object.Instantiate(NewGameButton, areaContentObject.transform);
        buttonObject.name = $"Button {text}";
        buttonObject.transform.SetSiblingIndex(index);
        
        // Set text
        var buttonText = buttonObject.transform.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = text;
        
        // Add custom action
        var button = buttonObject.transform.GetComponentInChildren<Button>();;
        button.onClick = new();
        button.onClick.AddListener(new UnityAction(onClick));
    }
}