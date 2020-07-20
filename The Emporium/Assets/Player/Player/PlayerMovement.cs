using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    bool running = false;
    FireBallTake2 fireBallTake;
    public bool cutscene;

    private CharacterController controller;

    GameObject character;

    public Animator femModel, maleModel;

    private Vector3 desireDirection;

    Camera cam;

    float speed, x,z;

    [SerializeField] public float rotationSpeed = 0.3f;
    [SerializeField] public float allowRotation = 0.1f;
    [SerializeField] public float movementspeed = 4;
    [SerializeField] public float Gravity;


    float dogdeSpeed = 60;
    float movespeed = 5;
    float walkspeed = 5;
    float Runningspeed = 10;
    bool isRunning;
    PlayerStats PlayerStats;
    float jumpheight = 5;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        cutscene = false;
        fireBallTake = GetComponent<FireBallTake2>();
        character = GameObject.Find("Character");
        PlayerStats = GetComponent<PlayerStats>();
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

        if(x > 0 || z > 0)
        {
            if(femModel.gameObject.activeSelf)
            {
                femModel.SetBool("IsWalking", true);
            }
            else
            {
                maleModel.SetBool("IsWalking", true);
            }
            
        }
        else
        {
            if (femModel.gameObject.activeSelf)
            {
                femModel.SetBool("IsWalking", false);
            }
            else
            {
                maleModel.SetBool("IsWalking", false);
            }
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

            

            if (controller.isGrounded == true)
            {
                Gravity = 0f;
                if (Input.GetKey(KeyCode.LeftShift) && z == 1) //can only run forward 
                {


                    sprint();
                    //movementspeed = Runningspeed;

                    if (femModel.gameObject.activeSelf)
                    {
                        femModel.SetBool("IsRunning", isRunning);
                        femModel.SetBool("IsWalking", !isRunning);
                    }
                    else
                    {
                        maleModel.SetBool("IsRunning", isRunning);
                        maleModel.SetBool("IsWalking", !isRunning);
                    }
                    //isRunning = true;
                }
                else
                {
                    movementspeed = movespeed;
                    isRunning = false;

                    if (femModel.gameObject.activeSelf)
                    {
                        femModel.SetBool("IsRunning", isRunning);
                        femModel.SetBool("IsWalking", !isRunning);
                    }
                    else
                    {
                        maleModel.SetBool("IsRunning", isRunning);
                        maleModel.SetBool("IsWalking", !isRunning);
                    }
                }
                if (PlayerStats.PlayersStamina < PlayerStats.MaxStamina && isRunning == false)
                {

                    {
                        PlayerStats.PlayersStamina += 8 * Time.deltaTime;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space) && isRunning == false)
                {

                    MovDirection.y += jumpheight;
                    PlayerStats.PlayersStamina -= 5;
                    PlayerStats.CheckStamina();
                }

                MovDirection *= movementspeed;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                MovDirection = desireDirection * (dogdeSpeed * Time.deltaTime);
                MovDirection = new Vector3(MovDirection.x, Gravity, MovDirection.z);
                controller.Move(MovDirection);

            }
        }

        void sprint()
        {
            movementspeed = Runningspeed;
            isRunning = true;
            PlayerStats.PlayersStamina -= 10 * Time.deltaTime;
            PlayerStats.CheckStamina();
        }
    }
}
