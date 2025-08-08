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
        perksPlayer = perks;
        if(perks[0] == null ){ Text1.text = "NO PERKS for u" ; }
        Text1.text = perks[0].perkName;
        Description1.text = perks[0].description;
         if (perks[1] == null ){ Text2.text = "NO PERKS for u" ; }
        Text2.text = perks[1].perkName;
        Description2.text = perks[1].description;
        if (perks[2] == null ){ Text2.text = "NO PERKS for u" ; }
        Text3.text = perks[2].perkName;
        Description3.text = perks[2].description;


        gameObject.SetActive(true);

        // pause on perk choice
        Time.timeScale = 0f;
    }

    public void OnButtonClick(int index)
    {
        var selected = perksPlayer[index];
        Expirience.playersPerks.Add(selected);

        GameObject player = GameObject.FindWithTag("Player");
        selected.Apply(player);

        // unpause
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }
}
