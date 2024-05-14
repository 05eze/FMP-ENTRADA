using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{


    public Text nameText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        
        
        if (unit == null)
        {
            Debug.LogError("Unit is null. Cannot set HUD.");
            return;
        }

        
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;


        
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
