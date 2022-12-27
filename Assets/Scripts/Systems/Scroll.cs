using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public ScrollText[] scrollTexts;

    public TMP_Text scrollText;

    private Dictionary<ItemID, string> scrollTextsDict;
    [System.Serializable]
    public class ScrollText
    {
        public ItemID LoreID;
        [TextArea(4, 15)]
        public string Lore;
    }

    private void Awake()
    {
        Inventory.ItemAdded += OnItemPickedUp;
        InitDict();
    }

    private void OnDestroy()
    {
        Inventory.ItemAdded -= OnItemPickedUp;
    }

    private void InitDict()
    {
        scrollTextsDict = new Dictionary<ItemID, string>();
        foreach(var e in scrollTexts)
        {
            scrollTextsDict.Add(e.LoreID, e.Lore);
        }
    }

    private void OnItemPickedUp(ItemID item)
    {
        if (item <= ItemID.EndOfKeys)
            return;

        var text = scrollTextsDict[item];
        if (text == null)
            return;

        scrollText.text = text;
    }
}
