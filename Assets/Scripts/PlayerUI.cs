using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider rifleChargeSlider;
    [SerializeField] private TMP_Text rifleText;
    [SerializeField] private Slider shotgunChargeSlider;
    [SerializeField] private TMP_Text shotgunText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShotgunChargeBar();
        UpdateRifleChargeBar();
        HighlightSelectedWeapon();
    }


    void UpdateRifleChargeBar()
    {
        float rifleCharge = player.GetComponent<PlayerFireController>().GetRifle().GetCharge();
        float rifleMaxCharge = player.GetComponent<PlayerFireController>().GetRifle().GetMaxCharge();
        rifleChargeSlider.value = rifleCharge / rifleMaxCharge; //Normalize (0-1)
    }

    void UpdateShotgunChargeBar()
    {
        float shotgunCharge = player.GetComponent<PlayerFireController>().GetShotgun().GetCharge();
        float shotgunMaxCharge = player.GetComponent<PlayerFireController>().GetShotgun().GetMaxCharge();
        shotgunChargeSlider.value = shotgunCharge / shotgunMaxCharge; //Normalize (0-1)
    }
    
    void HighlightSelectedWeapon()
    {
        if (0 == player.GetComponent<PlayerFireController>().GetSelectedWeapon())
        {
            rifleText.fontStyle = FontStyles.Bold;
            shotgunText.fontStyle = FontStyles.Normal;
        }
        if (1 == player.GetComponent<PlayerFireController>().GetSelectedWeapon())
        {
            rifleText.fontStyle = FontStyles.Normal;
            shotgunText.fontStyle = FontStyles.Bold;
            
        }

    }

}
