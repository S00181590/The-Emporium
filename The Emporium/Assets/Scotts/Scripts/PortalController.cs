//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class PortalController : MonoBehaviour
//{
//    [SerializeField]
//    private Button button;
//    private Portal[] portal;
//    private PlayerStats player;
//    private GameObject panel;
//    void Start()
//    {
//        player = FindObjectOfType<PlayerStats>();
//        panel = transform.Find("PortalPanel").gameObject;
//    }

//    public void ActivateTeleportPortal(Portal[] portals)
//    {

//        panel.SetActive(true);
//        for (int i = 0; i < portals.Length; i++)
//        {
//            Button portalbutton = Instantiate(button, panel.transform);
//            portalbutton.GetComponentInChildren<Text>().text = portals[i].name;
//            int x = i;
//            portalbutton.onClick.AddListener(delegate { onportalbuttonclick(x, portals[x]); });
//        }
//    }

//    void onportalbuttonclick(int portalindex, Portal portal)
//    {
//        player.transform.position = portal.TeleportLocation;
//        foreach (Button button in GetComponentsInChildren<Button>())
//        {
//            Destroy(button.gameObject);
//        }
//        panel.SetActive(false);
//    }
//}