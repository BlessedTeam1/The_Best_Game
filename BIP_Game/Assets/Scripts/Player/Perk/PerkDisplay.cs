using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkDisplay : MonoBehaviour
{
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;

    public List<Perk> perksPlayer;

    public void ShowAvailablePerks(List<Perk> perks)
    {
        perksPlayer = perks;
        if(perks[0] == null ){ Text1.text = "NO PERKS for u" ; }
        Text1.text = perks[0].perkName;
         if(perks[1] == null ){ Text2.text = "NO PERKS for u" ; }
        Text2.text = perks[1].perkName;
         if(perks[2] == null ){ Text2.text = "NO PERKS for u" ; }
        Text3.text = perks[2].perkName;

        gameObject.SetActive(true);

        // СТАВИМ ПАУЗУ при показе окна
        Time.timeScale = 0f;
    }

    public void OnButtonClick(int index)
    {
        var selected = perksPlayer[index];
        Expirience.playersPerks.Add(selected);

        GameObject player = GameObject.FindWithTag("Player");
        selected.Apply(player);

        // СНЯТЬ ПАУЗУ после выбора перка
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }
}
