using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Text EnergyText;
    public static int Energy;
    public int EnergyMax;

    private Image Energybar;

    // Start is called before the first frame update
    void Start()
    {
        Energybar = GetComponent<Image>();
        Energy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Energybar.fillAmount = (float)Energy / (float)EnergyMax;
        EnergyText.text = Energy.ToString();
    }
}
