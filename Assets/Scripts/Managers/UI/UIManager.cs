using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Dictionary<UIScreenID, UIScreen> UIScreensDict;
    [SerializeField]
    List<UIScreen> UiScreens;
    UIScreenID currentScreen;

    private void Awake()
    {
        InitDict();
        currentScreen = UIScreenID.Lore;
        OpenScreen(UIScreenID.MainMenu);
    }

    private void InitDict()
    {
        UIScreensDict = new();
        foreach (var e in UiScreens)
        {
            UIScreensDict.Add(e.id, e); 
        }
    }


    public void OpenScreen(UIScreenID ID)
    {
        var newScreen = UIScreensDict[ID];
        if (newScreen == null)
        {
            return;
        }
        UIScreensDict[currentScreen].gameObject.SetActive(false);
        currentScreen = ID;
        newScreen.gameObject.SetActive(true);
    }



}


public enum UIScreenID
{
    None,
    Lore,
    InGame,
    MainMenu,
    Settings,
    Lost,
    Won

}
