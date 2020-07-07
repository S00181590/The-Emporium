using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float PlayersHealth;
    public float MaxHealth;
    public float PlayersMana;
    public float  MaxMana;
    public float PlayersStamina;
    public float MaxStamina;
    public Slider ManaSlider;
    public Slider healthslider;
    public Slider StaminaSlider;
    //  public float  Playersstamina;
    // public float healthslidervalue;
    GameObject objecht;
    private bool collided;
    bool isdead;
    GameObject Gameover;

    public decimal money = 0;
    public float movementSpeed = 5;

    public float CurrenTime;
    public  float StartingTime;
    //spells
    public GameObject MagicSpellsPrefab;
    public Transform SpawnSpellLocation;

    LockOnController lockOnController;
    [SerializeField] Text AutosaveText;

    public ParticleSystem playerDeathFx;
    //public void OnTriggerEnter(Collider other)
    //{
    //    collided = true;
    //}
    //public void OnTriggerExit(Collider other)
    //{
    //    collided = false;
    //}

    void setStats()
    {
        healthslider.value = GetCurrentStamina();
        healthslider.value = GetCurrentMana();
        healthslider.value = GetCurrentHealth();
    }
    private void Start()
    {
        lockOnController = GetComponent<LockOnController>();
        CurrenTime = StartingTime;
        PlayersStamina = MaxStamina;
        PlayersMana = MaxMana;
        PlayersHealth = MaxHealth;

        //healthslider.value = GetCurrentStamina();
       // healthslider.value = GetCurrentMana();
       // healthslider.value = GetCurrentHealth();
    }
  
    private void Update()
    {
        StaminaSlider.value = GetCurrentStamina();    
        ManaSlider.value = GetCurrentMana();
        healthslider.value = GetCurrentHealth();
     
        if (PlayersHealth <= 0)
        {
            
            Time.timeScale = 1f;
            FindObjectOfType<GameOver>().gameoverScreen.SetActive(true);
            
            if (isdead == true)
            {
                Instantiate(playerDeathFx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (PlayersHealth >= MaxHealth)
        {
            PlayersHealth = MaxHealth;
            FindObjectOfType<GameOver>().gameoverScreen.SetActive(false);
        }

        if(PlayersMana >= MaxMana)
        {
            PlayersMana = MaxMana;
        }

        CurrenTime += 1 * Time.deltaTime;
        if (CurrenTime >= 800)
        {
            SaveMangerSystem.SavePlayerData(this);
            //AutosaveText.gameObject.SetActive(true);
          
            Debug.Log("autoSaved");
            CurrenTime = 0;

        }
        //else
        //{
        //    AutosaveText.gameObject.SetActive(false);
        //}
    }

    public virtual void CheckStamina()
    {
        if (PlayersStamina >= MaxStamina)
        {
            PlayersStamina = MaxStamina;
        }
        if (PlayersStamina <= 0)
        {
            PlayersStamina = 0;
        }
    }

    public virtual void CheckMana()
    {
        if (PlayersMana >= MaxMana)
        {
            PlayersMana = MaxMana;
        }
        if (PlayersMana <= 0)
        {
            PlayersMana = 0;
        }
    }
    float GetCurrentStamina()
    {
        return PlayersStamina / MaxStamina;
    }
    float GetCurrentMana()
    {
        return PlayersMana /MaxMana;
    }

    float GetCurrentHealth()
    {
        return PlayersHealth / MaxHealth;
    }

    public void SavePlayer()
    {
        SaveMangerSystem.SavePlayerData(this);

    }
   public void AutoSave()
    {
        //ElaspedTime += Time.deltaTime;
        //if(ElaspedTime >= timerspeed)
        //{
        //    Debug.Log("autosave");
        //    ElaspedTime = 0f;
        //    SaveMangerSystem.SavePlayerData(this);
        //}
    }
   
    public void LoadPlayer()
    {
        PlayerData data = SaveMangerSystem.LoadingPlayer();
        PlayersMana = data.PlayersMana;
        MaxMana = data.MaxMana;
        PlayersHealth = data.PlayersHealth;
        MaxHealth = data.MaxHealth;
        PlayersStamina = data.PlayersStamina;
        MaxStamina = data.MaxStamina;
        money = data.money;
        movementSpeed = data.movementSpeed;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

   

   
   

    


    void SelechtTarget()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            GameObject.FindGameObjectsWithTag("Enemy");
        }
    }
    //void MaigSpellAttack()
    //{
        
    //    if (PlayersMana >0 )
    //    {

    //        PlayersMana -= 10;
    //        CheckMana();
    //        //Vector3 SpawnSpellLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            
    //        //GameObject clones;
    //        //clones = Instantiate(MagicSpellsPrefab, SpawnSpellLocation, Quaternion.identity);
    //        //clones.transform.GetComponent<fireSpell>().Target.isLocjedOn;//NEED TO ADD LOCK ON LATER 
    //    }
    //}

}

