using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool running = false;

    bool cutscene = false;

    GameObject character;

    float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        if (!cutscene)
        {
            Moving();
            
        }
    }

    private void Turning(Vector3 turn)
    {
        character.transform.rotation = Quaternion.LookRotation(turn);
    }

    private void Moving()
    {
        if (running)
        {

        }
        else
        {
            float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            Vector3 MovDirection = new Vector3(x, 0, z);

            transform.Translate(MovDirection);

            Turning(MovDirection);
        }
    }
}
