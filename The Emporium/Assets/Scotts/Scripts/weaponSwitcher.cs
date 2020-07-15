using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSwitcher : MonoBehaviour
{
    public GameObject Bow;
    public GameObject sword;
    public GameObject shield;
    public GameObject FireSpell;
    public GameObject IceSpell;
    public GameObject GroundSpell;
    public int EquippedWeapon =1;
    MagicAttack magicAttack;
    FireBallTake2 fireBallTake2;
    [SerializeField] Image BowImage;
    [SerializeField] Image SwordImage;
    [SerializeField] Image ShieldImage;
    [SerializeField] Image FireImage;
    [SerializeField] Image IceImage;
   [SerializeField] Image GroundImage;
    [SerializeField] Text BowText;
    [SerializeField] Text SwordText;
    [SerializeField] Text ShieldText;
    [SerializeField] Text FireText;
    [SerializeField] Text IceText;
    [SerializeField] Text GroundText;
    void Start()
    {
        magicAttack = GetComponent<MagicAttack>();
        fireBallTake2 = FindObjectOfType<FireBallTake2>();
        ChangeWeapon(1);
        BowImage.enabled = true;
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(EquippedWeapon != 1)
            {
                ChangeWeapon(1);
                EquippedWeapon = 1;
                BowImage.enabled = true;
                SwordImage.enabled = false;
                ShieldImage.enabled = false;
                FireImage.enabled = false;
                IceImage.enabled = false;
                GroundImage.enabled = false;

                BowText.enabled = true;
                SwordText.enabled = false;
                ShieldText.enabled = false;
                FireText.enabled = false;
                IceText.enabled = false;
                GroundText.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (EquippedWeapon != 2)
            {
                ChangeWeapon(2);
                EquippedWeapon = 2;
                BowImage.enabled = false;
                SwordImage.enabled = true;
                ShieldImage.enabled = false;
                FireImage.enabled = false;
                IceImage.enabled = false;
                GroundImage.enabled = false;

                BowText.enabled = false;
                SwordText.enabled = true;
                ShieldText.enabled = false;
                FireText.enabled = false;
                IceText.enabled = false;
                GroundText.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (EquippedWeapon != 3)
            {
                ChangeWeapon(3);
                EquippedWeapon = 3;
                BowImage.enabled = true;
                SwordImage.enabled = false;
                ShieldImage.enabled = true;
                FireImage.enabled = false;
                IceImage.enabled = false;
                GroundImage.enabled = false;

                BowText.enabled = false;
                SwordText.enabled = false;
                ShieldText.enabled = true;
                FireText.enabled = false;
                IceText.enabled = false;
                GroundText.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (EquippedWeapon != 4)
            {
                
                ChangeWeapon(4);
                EquippedWeapon = 4;
                BowImage.enabled = false;
                SwordImage.enabled = false;
                ShieldImage.enabled = false;
                FireImage.enabled = true;
                IceImage.enabled = false;
                GroundImage.enabled = false;

                BowText.enabled = false;
                SwordText.enabled = false;
                ShieldText.enabled = false;
                FireText.enabled = true;
                IceText.enabled = false;
                GroundText.enabled = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (EquippedWeapon != 5)
            {
                GameObject GroundAttack = Instantiate(magicAttack.spell2, transform);
                ChangeWeapon(5);
                EquippedWeapon = 5;
                BowImage.enabled = false;
                SwordImage.enabled = false;
                ShieldImage.enabled = false;
                FireImage.enabled = false;
                IceImage.enabled = true;
                GroundImage.enabled = false;

                BowText.enabled = false;
                SwordText.enabled = false;
                ShieldText.enabled = false;
                FireText.enabled = false;
                IceText.enabled = true;
                GroundText.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (EquippedWeapon != 6)
            {
                GameObject GroundAttack = Instantiate(magicAttack.spell3, transform);
                ChangeWeapon(6);
                EquippedWeapon = 6;
                BowImage.enabled = false;
                SwordImage.enabled = false;
                ShieldImage.enabled = false;
                FireImage.enabled = false;
                IceImage.enabled = false;
                GroundImage.enabled = true;

                BowText.enabled = false;
                SwordText.enabled = false;
                ShieldText.enabled = false;
                FireText.enabled = false;
                IceText.enabled = false;
                GroundText.enabled = true;
            }
        }

        

        }
    void ChangeWeapon(int WeaponType)
    {
        if (WeaponType == 1)
        {
            Bow.SetActive(true);
            sword.SetActive(false);
            shield.SetActive(false);
            FireSpell.SetActive(false);
            IceSpell.SetActive(false);
            GroundSpell.SetActive(false);
        }
        if (WeaponType == 2)
        {
            Bow.SetActive(false);
            sword.SetActive(true);
            shield.SetActive(false);
            FireSpell.SetActive(false);
            IceSpell.SetActive(false);
            GroundSpell.SetActive(false);
        }
        if (WeaponType == 3)
        {
            Bow.SetActive(false);
            sword.SetActive(false);
            shield.SetActive(true);
            FireSpell.SetActive(false);
            IceSpell.SetActive(false);
            GroundSpell.SetActive(false);
        }
        if (WeaponType == 4)
        {
            Bow.SetActive(false);
            sword.SetActive(false);
            shield.SetActive(false);
            FireSpell.SetActive(true);
            IceSpell.SetActive(false);
            GroundSpell.SetActive(false);
        }
        if (WeaponType == 5)
        {
            Bow.SetActive(false);
            sword.SetActive(false);
            shield.SetActive(false);
            FireSpell.SetActive(false);
            IceSpell.SetActive(true);
            GroundSpell.SetActive(false);

        }
        if (WeaponType == 6)
        {
            Bow.SetActive(false);
            sword.SetActive(false);
            shield.SetActive(false);
            FireSpell.SetActive(false);
            IceSpell.SetActive(false);
            GroundSpell.SetActive(true);
        }
        
    }
}
