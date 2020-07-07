using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyIndicator : MonoBehaviour
{
    PlayerStats stats;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Character").GetComponent<PlayerStats>();

        text.text = "Money: "+stats.money.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Money: "+stats.money.ToString();
    }
}
