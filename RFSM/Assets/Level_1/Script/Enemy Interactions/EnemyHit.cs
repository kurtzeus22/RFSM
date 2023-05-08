using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public GameObject Enemy; //enemy prefab
    public GameObject EnemyFullBody; //enemy animator
    public GameObject AttackTrigger; //attack trigger for hammer and knuckles
    public float health = 0f; //total health (3 is the basic)
    bool isInAnim; //is currently not in idle state (enemy)
    bool tumama; //hit by hammer
    bool chargetumama; //charged hit
    bool guntumama; //hit by bullet
    bool magictumama; //hit by magic
    bool chargedmagictumama; // hit by charged magic
    Collider enemcollider; //ehemy collider
    [Header("Bullet Effects")]
    public GameObject BulletHitEffect; //bullet vfx
    public Transform BulletHitPosition; //bullet position where is hit

    [Header("Magic Effects")]
    public bool hitByMagic;
    public GameObject MagicPotion; //the object to spawn
    public static GameObject MageMagic; //GameObject to instantiate the blue orb

    // Start is called before the first frame update
    void Start()
    {
        enemcollider = GetComponent<Collider>();
        enemcollider.enabled = enemcollider.enabled;
        isInAnim = false;
        Enemy.GetComponent<Animator>().Play("idleAnim");
    }
    void Update(){
        if(Enemy != null){
            if(health >= 3f){
                Enemy.GetComponent<Animator>().Play("deathAnim");
                if(hitByMagic == true){
                    Debug.Log("Magic Dapat may lalabas dito");
                    MageMagic = Instantiate(MagicPotion, transform.position, transform.rotation);
                    Rigidbody MageMagicRb = MageMagic.GetComponent<Rigidbody>();
                    hitByMagic = false;
                }
                isInAnim = true;
                StartCoroutine(dead());
            }

            if(tumama == true){
                Enemy.GetComponent<Animator>().Play("enemyHit");
                isInAnim = true;
                Debug.Log("Tumama sa kalaban");
                health++;
                tumama = false;
                StartCoroutine(backtoIdle());
            }

            if(chargetumama == true){
                Enemy.GetComponent<Animator>().Play("enemyHit");
                isInAnim = true;
                Debug.Log("Charge tumama sa kalaban");
                health = health + 3;
                chargetumama = false;
                StartCoroutine(backtoIdle());
            }
            if(guntumama == true){
                Enemy.GetComponent<Animator>().Play("enemyHit");
                isInAnim = true;
                BulletHitVFX();
                Debug.Log("Gun tumama sa kalaban");
                health = health + 0.5f;
                guntumama = false;
                StartCoroutine(backtoIdle());
            }
            if(magictumama == true){
                hitByMagic = true;
                Enemy.GetComponent<Animator>().Play("enemyHit");
                isInAnim = true;
                BulletHitVFX();
                Debug.Log("Mage tumama sa kalaban");
                health = health + 1f;
                magictumama = false;
                StartCoroutine(backtoIdle());
            }
            if(chargedmagictumama == true){
                hitByMagic = true;
                Enemy.GetComponent<Animator>().Play("enemyHit");
                isInAnim = true;
                BulletHitVFX();
                Debug.Log("Mage tumama sa kalaban");
                health = health + 3f;
                chargedmagictumama = false;
                StartCoroutine(backtoIdle());
            }

            IEnumerator backtoIdle(){
                if(health < 3){
                    yield return new WaitForSeconds(0.75f);
                    Enemy.GetComponent<Animator>().Play("idleAnim");
                    isInAnim = false;
                }
            } 
            IEnumerator dead(){
                yield return new WaitForSeconds(3f);
                Destroy(EnemyFullBody);
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isInAnim != true){
            enemcollider.enabled = enemcollider.enabled;
            if(collision.gameObject.name == "AttackTrigger")
            {
                tumama = true;
            }
            if(collision.gameObject.name == "ChargeAttackTrigger")
            {
                chargetumama = true;
            }
            if(collision.gameObject.name == "Bullet(Clone)")
            {
                guntumama = true;
            }
            if(collision.gameObject.name == "MageBullet(Clone)")
            {
                magictumama = true;
            }
            if(collision.gameObject.name == "ChargedMagicBullet(Clone)")
            {
                chargedmagictumama = true;
            }
        }
        else if(isInAnim == true){
                // enemcollider.enabled = !enemcollider.enabled;
        }
    }

    void BulletHitVFX(){
        GameObject newBurstEffect = Instantiate(BulletHitEffect, BulletHitPosition.position, BulletHitPosition.rotation);
        // newBurstEffect.Play();
        Destroy(newBurstEffect.gameObject, 1.5f);
    }
}
