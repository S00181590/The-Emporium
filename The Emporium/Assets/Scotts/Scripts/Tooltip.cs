using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltip;
    // Start is called before the first frame update
    void Start()
    {
        tooltip = GetComponentInChildren<Text>();
        tooltip.gameObject.SetActive(false);
    }
    public void GenerattoolTip(Item item)
    {
        string statsText = "";
        if (item.stats.Count > 0)
        {
            foreach (var stat in item.stats)
            {
                statsText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>",
            item.title, item.descrption, statsText);
       // tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
