using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : NavMeshMover
{
    public List<GameObject> products, shelves;

    public List<Item> wants;

    public GameObject lookto, portal, till, shopState;

    public bool purchased;

    public int desireAmount, budget, upperSpend;
    
    // Start is called before the first frame update
    public override void Start()
    {
        shopState = GameObject.Find("ShopStateSave");

        portal = GameObject.FindGameObjectWithTag("Portal");

        purchased = false;

        till = GameObject.FindGameObjectWithTag("TillSpot");

        budget = Random.Range(1,100);

        shelves.AddRange(GameObject.FindGameObjectsWithTag("ShelfSpot"));

        foreach(GameObject g in shelves)
        {
            if(g.GetComponentInParent<ShelfHolder>().holding != null)
            {
                products.Add(g);
            }
        }

        agent = GetComponent<NavMeshAgent>();

        agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

        float howmany = budget / 10;

        desireAmount = Random.Range(1, (int)howmany);

        lookto = products[0];

    }

    // Update is called once per frame
    void Update()
    {

        float distance = 20;

        if(purchased != true)
        {
            if(desireAmount >= 1)
            {
                if(products.Count != 0)
                {
                    foreach (GameObject g in products)
                    {

                        if (g.GetComponentInParent<ShelfHolder>().holding == null)
                        {
                            products.Remove(g);
                        }
                        else
                        {
                            if (Vector3.Distance(transform.position, g.transform.position) < distance)
                            {
                                if (g.GetComponentInParent<ShelfHolder>().holding.Value < budget)
                                {
                                    if(shopState.GetComponent<ProductChoices>().shelvesTaken.Contains(g) == false)
                                    {
                                        lookto = g;

                                        distance = Vector3.Distance(gameObject.transform.position, g.transform.position);
                                    }

                                }

                            }
                        }
                    }

                    if(gameObject.transform.position != lookto.transform.position)
                    {
                        agent.SetDestination(lookto.transform.position);
                    }
                }
                else
                {
                    if(wants.Count != 0)
                    {
                        if (gameObject.transform.position != till.transform.position)
                        {
                            agent.SetDestination(till.transform.position);
                        }
                    }
                    else
                    {
                        agent.SetDestination(portal.transform.position);
                    }
                }


                //MoveTo(lookto);
            }
            else
            {
                if (gameObject.transform.position != till.transform.position)
                {
                    agent.SetDestination(till.transform.position);
                }
                //agent.SetDestination(till.transform.position);
                //MoveTo(till);
            }
        }
        else
        {
            agent.SetDestination(portal.transform.position);
            //MoveTo(portal);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShelfSpot")
        {
            if (products.Contains(other.gameObject))
            {
                if (wants.Count == 0)
                {
                    wants.Add(other.GetComponentInParent<ShelfHolder>().holding);

                    upperSpend += budget;

                    shopState.GetComponent<ProductChoices>().shelvesTaken.Add(other.gameObject.transform.parent.gameObject);

                    shopState.GetComponent<ProductChoices>().productsTaken.Add(other.GetComponentInParent<ShelfHolder>().holding);

                    products.Remove(other.gameObject);

                    desireAmount--;
                }
                else
                {
                    List<Item> toAdd = new List<Item>();

                    foreach (Item s in wants)
                    {
                        if (!shopState.GetComponent<ProductChoices>().shelvesTaken.Contains(other.gameObject.transform.parent.gameObject))
                        {
                            toAdd.Add(other.GetComponentInParent<ShelfHolder>().holding);

                            upperSpend += budget;

                            shopState.GetComponent<ProductChoices>().shelvesTaken.Add(other.gameObject.transform.parent.gameObject);

                            shopState.GetComponent<ProductChoices>().productsTaken.Add(other.GetComponentInParent<ShelfHolder>().holding);

                            products.Remove(other.gameObject);

                            desireAmount--;
                        }
                        
                    }

                    if(toAdd.Count > 0)
                    {
                        wants.AddRange(toAdd);
                    }


                }
            }
        }
        else if(other.gameObject.tag == "TillSpot")
        {
            other.GetComponentInParent<TillControl>().purchases.AddRange(wants);
            other.GetComponentInParent<TillControl>().customer = gameObject;
            other.GetComponentInParent<TillControl>().debate = upperSpend;


        }
        else if (other.gameObject.tag == "Portal")
        {
            Destroy(gameObject);
        }
    }
}
