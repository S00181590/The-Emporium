using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    Vector3 pin, plant;

    public GameObject Resource;

    public process current;

    private BoxCollider area;

    Random R;

    public int amount;

    public enum process { spawning, spawned};

    // Start is called before the first frame update
    void Start()
    {
        amount = 0;

        area = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
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
                plantResource();
            }
        }
    }

    private void plantResource()
    {
        Vector3 precise = new Vector3(plant.x, plant.y + Resource.transform.localScale.y / 2, plant.z);

        Instantiate(Resource, precise, Quaternion.Euler(0f, Random.Range(0, 360), 0));

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
            Debug.Log(hit);

            if (hit.collider.gameObject.tag == "Terrain")
            {
                plant = hit.point;
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
        return (int)Random.Range(1f, 10f);
    }
}
