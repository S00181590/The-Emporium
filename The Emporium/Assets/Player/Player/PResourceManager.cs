using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PResourceManager : MonoBehaviour
{
    public List<GameObject> NearResources = new List<GameObject>();

    public Inventory Inventory;

    public GameObject nearest, customerset;

    private GameObject interactText, magicIcons;

    private CinemachineBrain brain;

    // Start is called before the first frame update
    void Start()
    {
        nearest = null;

        Inventory = gameObject.GetComponent<Inventory>();

        interactText = GameObject.FindGameObjectWithTag("InteractText");

        interactText.SetActive(false);

        magicIcons = GameObject.FindGameObjectWithTag("SpellList");

        brain = Camera.main.GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if(brain.ActiveVirtualCamera.Name != "Main_ThirdPersonCamera")
        {
            magicIcons.SetActive(false);
        }
        else
        {
            magicIcons.SetActive(true);
        }

        if(NearResources != null)
        {
            if(nearest != null)
            {
                nearest = approximate(NearResources);
            }
            
        }
        else
        {
            nearest = null;
        }

        if(nearest != null)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(nearest.GetComponent<Resource>().enabled == true)
                {
                    bool waspickedup = BackupInventory.instance.AddItem(nearest.GetComponent<Resource>().Info);

                    if (waspickedup)
                    {
                        NearResources.Remove(nearest);
                        Destroy(nearest);

                        NearResources = new List<GameObject>();

                    }
                }

            }
        }
    }

    public GameObject approximate(List<GameObject> near)
    {
        float distance = 1000;

        GameObject nearest = null;

        if (near != null)
        {

            foreach (GameObject g in near)
            {

                if (Vector3.Distance(gameObject.transform.position, g.transform.position) < distance)
                {
                    nearest = g;

                    distance = Vector3.Distance(gameObject.transform.position, g.transform.position);
                }

            }
        }

        if(nearest != null)
        {
            nearest.GetComponent<Resource>().selectable = true;
        }
        

        foreach(GameObject g in near)
        {
            if(g != nearest)
            {
                nearest.GetComponent<Resource>().selectable = false;
            }
        }

        return nearest;
    }

    private void OnTriggerEnter(Collider other)
    {

        //switch more efficient than multiple else ifs
        switch(other.gameObject.tag)
        {
            case "Resource":
                NearResources.Add(other.gameObject);
                nearest = approximate(NearResources);
                interactText.SetActive(true);
                break;
            case "CraftTable":
                other.GetComponent<CraftingTable>().inrange = true;
                interactText.SetActive(true);
                break;
            case "Shelf":
                interactText.SetActive(true);
                other.gameObject.GetComponent<ShelfHolder>().opened = true;
                break;
            case "Door":
                other.gameObject.GetComponent<Animator>().SetBool("IsNear", true);
                break;
            case "Till":
                interactText.SetActive(true);
                if (customerset.GetComponent<CustomerSpawn>().CustomerCount > 0)
                {
                    other.GetComponent<TillControl>().SwitchCam();
                    other.GetComponent<TillControl>().player = gameObject;
                    other.GetComponent<TillControl>().open = true;
                    gameObject.GetComponent<PlayerMovement>().cutscene = true;
                }
                break;
            case "StatShop":
                interactText.SetActive(true);
                other.GetComponent<HealThePlayer>().playerinrange = true;
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        //switch more efficient than multiple else ifs
        switch (other.gameObject.tag)
        {
            case "Resource":
                NearResources.Remove(other.gameObject);
                other.gameObject.GetComponent<Resource>().selectable = false;
                interactText.SetActive(false);
                break;
            case "CraftTable":
                other.GetComponent<CraftingTable>().inrange = false;
                interactText.SetActive(false);
                break;
            case "Shelf":
                other.gameObject.GetComponent<ShelfHolder>().opened = false;
                interactText.SetActive(false);
                break;
            case "Door":
                other.gameObject.GetComponent<Animator>().SetBool("IsNear", false);
                break;
            case "Till":
                interactText.SetActive(false);
                break;
            case "StatShop":
                interactText.SetActive(false);
                other.GetComponent<HealThePlayer>().playerinrange = false;
                break;
        }
    }
}
