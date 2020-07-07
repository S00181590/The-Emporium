using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public int CustomerCount, shopRep;
    public GameObject Customer, till, spawnpoint;
    public bool Selling;

    Renderer portalActive;

    // Start is called before the first frame update
    void Start()
    {
        shopRep = GameObject.FindGameObjectsWithTag("Shelf").Length/2;

        CustomerCount = Random.Range(1, 1 + shopRep);

        Selling = false;

        till = GameObject.FindGameObjectWithTag("Till");

        portalActive = gameObject.GetComponent<Renderer>();

        portalActive.material.shader = Shader.Find("Universal Render Pipeline/Lit");

    }

    // Update is called once per frame
    void Update()
    {
        if(Selling)
        {
            if(CustomerCount > 0)
            {
                //SpawnAfterDelay(3f);
                GameObject g = Instantiate(Customer, spawnpoint.transform.position += new Vector3(0,2,0), new Quaternion(0,0,0,0));

                //g.transform.localPosition = Vector3.zero;
                CustomerCount--;
            }
            else
            {
                if(GameObject.FindGameObjectsWithTag("Customer") == null)
                {
                    Selling = false;
                }
            }

            if(portalActive.material.shader != Shader.Find("Shader Graphs/PortalSwirl"))
            {
                portalActive.material.shader = Shader.Find("Shader Graphs/PortalSwirl");
            }

            
        }
        else
        {
            if (portalActive.material.shader != Shader.Find("Universal Render Pipeline/Lit"))
            {
                portalActive.material.shader = Shader.Find("Universal Render Pipeline/Lit");
            }

            if(CustomerCount > 0)
            {
                Selling = till.GetComponent<TillControl>().open;
            }
        }

        
    }

    private bool isCoroutineExecuting;

    IEnumerator SpawnAfterDelay(float time)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Instantiate(Customer, gameObject.transform);
        CustomerCount--;

        isCoroutineExecuting = false;
    }

    private void Spawn()
    {
        Instantiate(Customer);
    }
}
