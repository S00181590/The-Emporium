using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public GameObject[] Monster;
    public Vector3 spawnvalues;
    public float spawnwaittime;
    public float respawndelaytimemax;
    public  float respawnwaittimeleast;
    public int startwait;
    public bool stopspawning;
    int randomenemey;
    public int maxenemeys;
    public int enemeysspawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawnerrespawntimer());
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnwaittime = Random.Range(respawnwaittimeleast, respawndelaytimemax);
        if(maxenemeys >=enemeysspawned)
        {
            stopspawning = true;
        }
        else 
        {
            stopspawning = false;
        }

        if(GameObject.Find("MC_Male") != null)
        {
            if (stopspawning == true)
            {
                randomenemey = Random.Range(0, 3);

                Vector3 spawnpoistions = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), 5, Random.Range(-spawnvalues.z, spawnvalues.z));
                Instantiate(Monster[randomenemey], spawnpoistions + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

                enemeysspawned++;
            }
        }
        else if(GameObject.Find("MC_FemaleFullRig") != null)
        {
            if(stopspawning == true)
            {
                randomenemey = Random.Range(0, 3);

                Vector3 spawnpoistions = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), 5, Random.Range(-spawnvalues.z, spawnvalues.z));
                Instantiate(Monster[randomenemey], spawnpoistions + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

                enemeysspawned++;
            }
        }

    }

  
    IEnumerator spawnerrespawntimer()
    {
        yield return new WaitForSeconds(startwait);
   
        while(!stopspawning)
        {
            randomenemey = Random.Range(0,3);

            Vector3 spawnpoistions = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), 5, Random.Range(-spawnvalues.z, spawnvalues.z));
            Instantiate(Monster[randomenemey], spawnpoistions + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnwaittime);


        }
        
    }
}
