using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string trait;

    public int id;

    public string desc;

    public bool selectable;

    public List<MeshRenderer> render;

    public GameObject player;

    public Item Info;

    public List<GameObject> tochange;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Character");
        trait = gameObject.name;

        selectable = false;

        if(gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer rend) == true)
        {
            render.Add(rend);
        }
        
        if(gameObject.transform.childCount > 0)
        {
            MeshRenderer[] Mes = gameObject.GetComponentsInChildren<MeshRenderer>();
            
            foreach(MeshRenderer M in Mes)
            {
                render.Add(M);
            }
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       if(selectable)
        {
            foreach(MeshRenderer M in render)
            {
                if(M.material.shader != Shader.Find("Shader Graphs/OutLine"))
                {
                    M.material.shader = Shader.Find("Shader Graphs/OutLine");
                }
                
            }
            
        }
        else
        {
            
            foreach(MeshRenderer M in render)
            {
                if(M.material.shader != Shader.Find("Universal Render Pipeline/Lit"))
                {
                    M.material.shader = Shader.Find("Universal Render Pipeline/Lit");
                }
               
            }
           
        }
       
    }

    //public Item MakeItem(int id)
    //{
    //    Item item = new Item(id, trait, desc, null);

    //    return item;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Character")
    //    {
    //        other.gameObject.GetComponent<PResourceManager>().NearResources.Add(gameObject);

    //        selectable = true;
    //    }
    //}

    //private void OnTriggerExit(Collider collision)
    //{
    //    if(collision.gameObject.tag == "Character")
    //    {
    //        collision.gameObject.GetComponent<PResourceManager>().NearResources.Remove(gameObject);

    //        selectable = false;
    //    }
    //}

}
