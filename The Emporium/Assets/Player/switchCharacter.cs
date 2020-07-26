using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchCharacter : MonoBehaviour
{
    public static int character = 2;

    public Characterselction selection;

    public List<GameObject> characters;

    public bool InPlayer = true;

    private void Awake()
    {
        if(gameObject.scene.name == "CharacterSelectionScene")
        {
            InPlayer = false;
        }
        else
        {
            InPlayer = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(InPlayer)
        {
            if(character == 1)
            {
                foreach(GameObject g in characters)
                {
                    if(g.name == "MC_FemaleFullRig")
                    {
                        g.SetActive(true);
                    }
                    else
                    {
                        g.SetActive(false);
                    }
                }
            }
            else
            {
                foreach(GameObject g in characters)
                {
                    if(g.name == "MC_Male")
                    {
                        g.SetActive(true);
                    }
                    else
                    {
                        g.SetActive(false);
                    }
                }
            }
        }
        else
        {
            selection = gameObject.GetComponent<Characterselction>();

            character = selection.CharacterNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InPlayer)
        {

        }
        else
        {
            character = selection.CharacterNumber;


        }
    }

    public void ConfirmSelection()
    {
        if (InPlayer)
        {

        }
        else
        {
            character = selection.CharacterNumber; // 1 is female, male is 2

            SceneManager.LoadScene("PlayerScene");
        }
    }
}
