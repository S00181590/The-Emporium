using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PResourceManager : MonoBehaviour
{
    public List<GameObject> NearResources = new List<GameObject>();

    public Inventory Inventory;

    public GameObject nearest;

    // Start is called before the first frame update
    void Start()
    {
        nearest = null;

        Inventory = gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
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

        foreach(GameObject g in near)
        {

            if (Vector3.Distance(gameObject.transform.position, g.transform.position) < distance)
            {
                nearest = g;

                distance = Vector3.Distance(gameObject.transform.position, g.transform.position);
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

        //if (other.gameObject.tag == "Resource")
        //{
        //    NearResources.Add(other.gameObject);

        //    nearest = approximate(NearResources);
        //}
        //else if(other.gameObject.tag == "CraftTable")
        //{
        //    other.GetComponent<CraftingTable>().inrange = true;
        //}

        //switch more efficient than multiple else ifs
        switch(other.gameObject.tag)
        {
            case "Resource":
                NearResources.Add(other.gameObject);
                nearest = approximate(NearResources);
                break;
            case "CraftTable":
                other.GetComponent<CraftingTable>().inrange = true;
                break;
            case "Shelf":
                other.gameObject.GetComponent<ShelfHolder>().opened = true;
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Resource")
        {
            NearResources.Remove(other.gameObject);

            other.gameObject.GetComponent<Resource>().selectable = false;
        }
        else if (other.gameObject.tag == "CraftTable")
        {
            other.GetComponent<CraftingTable>().inrange = false;
        }
    }
}
