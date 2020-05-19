using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    bool running = false;

    bool cutscene = false;

    private CharacterController controller;

    GameObject character;

    private Vector3 desireDirection;

    Camera cam;

    float speed, x,z;

    [SerializeField] float rotationSpeed = 0.3f;
    [SerializeField] float allowRotation = 0.1f;
    [SerializeField] float movementspeed = 4;
    [SerializeField] float Gravity;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");

        controller = GetComponent<CharacterController>();

        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (!cutscene)
        {
            InputSorter();
            
        }
    }

    private void InputSorter()
    {
        speed = new Vector2(x, z).sqrMagnitude;

        if(speed > allowRotation)
        {
            Rotating();
        }
        else
        {
            desireDirection = Vector3.zero;
        }
    }

    private void Rotating()
    {
        if (running)
        {
            
        }
        else
        {
           
            var forward = cam.transform.forward;
            var right = cam.transform.right;

            forward.y = 0;
            forward.Normalize();
            right.y = 0;
            right.Normalize();

            desireDirection = forward * z + right * x;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desireDirection), rotationSpeed);

            Moving();
        }

        void Moving()
        {
            Gravity -= 9.8f * Time.deltaTime;

            Vector3 MovDirection = desireDirection * (movementspeed * Time.deltaTime);
            MovDirection = new Vector3(MovDirection.x, Gravity, MovDirection.z);
            controller.Move(MovDirection);

            if(controller.isGrounded == true)
            {
                Gravity = 0f;
            }
        }
    }
}
