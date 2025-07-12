using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text HealthText;
    public static int HP;
    public int HealthMax;

    private Image Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        Healthbar = GetComponent<Image>();
        HP = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = (float)HP / (float)HealthMax;
        HealthText.text = HP.ToString() + "/" + HealthMax.ToString();
    }
}
