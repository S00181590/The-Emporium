using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    Vector3 pin, plant;

    public List<GameObject> Resource;

    public process current;

    private GameObject player;

    private BoxCollider area;

    Random R;

    public int amount;

    public enum process { spawning, spawned};

    // Start is called before the first frame update
    void Start()
    {
        amount = 0;

        area = gameObject.GetComponent<BoxCollider>();

        if(GameObject.Find("MC_FemaleFullRig") == null)
        {
            player = GameObject.Find("MC_Male");
        }
        else
        {
            player = GameObject.Find("MC_FemaleFullRig");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position,gameObject.transform.position) <= 40)
        {
            if (current == process.spawning)
            {
                if (amount == 0)
                {
                    amount = Bounty();
                }
                else
                {
                    findpin();
                    findPlant();

                    if(plant != Vector3.zero)
                    {
                        plantResource();
                    }

                }
            }
        }

    }

    private void plantResource()
    {
        int match = (int)Random.Range(0, Resource.Count);

        GameObject ToSpawn = Resource[match];

        Vector3 precise = new Vector3(plant.x, plant.y + ToSpawn.transform.localScale.y / 2, plant.z);

        Instantiate(ToSpawn, precise, Quaternion.Euler(0f, Random.Range(0, 360), 0));

        amount--;

        if(amount == 0)
        {
            current = process.spawned;
        }
    }

    private void findPlant()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = new Ray(pin, Vector3.down);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.DrawLine(ray.origin, hit.point,Color.white, 10f);

            if (hit.collider.gameObject.tag == "Terrain")
            {
                plant = hit.point;
            }
            else
            {
                plant = Vector3.zero;
            }

        }
    }

    private void findpin()
    {
        int x = (int)Random.Range(area.bounds.min.x, area.bounds.max.x);

        int z = (int)Random.Range(area.bounds.min.z, area.bounds.max.z);

        pin = new Vector3(x, gameObject.transform.position.y, z);
    }

    public int Bounty()
    {
        return Random.Range(5, 15);
    }
}
