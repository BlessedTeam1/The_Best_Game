using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkDisplay : MonoBehaviour
{
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;

    public TextMeshProUGUI Description1;
    public TextMeshProUGUI Description2;
    public TextMeshProUGUI Description3;

    public List<Perk> perksPlayer;

    public void ShowAvailablePerks(List<Perk> perks)
    {
        // every perk is already taken: nothing to choose, so don't open (and pause) the menu
        if (perks.Count == 0)
            return;

        perksPlayer = perks;
        ShowSlot(0, Text1, Description1);
        ShowSlot(1, Text2, Description2);
        ShowSlot(2, Text3, Description3);

        gameObject.SetActive(true);

        // pause on perk choice
        Time.timeScale = 0f;
    }

    // fewer than 3 perks can be left near the end of a run
    private void ShowSlot(int index, TextMeshProUGUI title, TextMeshProUGUI description)
    {
        if (index < perksPlayer.Count)
        {
            title.text = perksPlayer[index].perkName;
            description.text = perksPlayer[index].description;
        }
        else
        {
            title.text = "NO PERKS for u";
            description.text = "";
        }
    }

    public void OnButtonClick(int index)
    {
        // empty slot: ignore the click, the player picks one of the real perks
        if (index >= perksPlayer.Count)
            return;

        var selected = perksPlayer[index];
        Expirience.playersPerks.Add(selected);

        GameObject player = GameObject.FindWithTag("Player");
        selected.Apply(player);

        // unpause
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }
}
