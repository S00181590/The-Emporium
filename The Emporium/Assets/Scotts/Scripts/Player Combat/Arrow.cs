using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody arrowBody;
    private float ArrowLifeTime = 5;
    private float Timer;
    private bool HasHitTarget = false;
    // Start is called before the first frame update
   private  void Start()
    {
        arrowBody = GetComponent<Rigidbody>();//het the body on start 
        transform.rotation = Quaternion.LookRotation(arrowBody.velocity);
    }

    // Update is called once per frame
   private  void Update()
    {

        Timer += Time.deltaTime;//seting up arrow despaen timer 
        if(Timer >= ArrowLifeTime)
        {
            Destroy(gameObject);//destory arrow after timer 
        }
        if (!HasHitTarget)
        {
            transform.rotation = Quaternion.LookRotation(arrowBody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Arrow")//check if arrow hit somethingand stops arrows form pileing  up 
        {
            HasHitTarget = true;
            ÀrrowStickOnhit();
        }

        if (collision.collider.tag != "Enemy")
        {
            
            HasHitTarget = true;
            ÀrrowStickOnhit();
        }
    }
    private void ÀrrowStickOnhit()//frezzes the xyand z on the rigbody so can stick to walls and items 
    {
        arrowBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
