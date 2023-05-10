using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int health = 5; //kung ilan buhay ng player
    public int numOfHearts; //heart icons

    public Image[] hearts; //picture nung heart (tas kung ilan sila na nakaarray)
    public Sprite fullHeart; //fullheart kapag puno pa heart icon
    public Sprite emptyHeart; //ung image na wala nang pula ung heart icon
    public GameObject Player; //player
    public GameObject playerBodyBoy; //animator ng player
    public GameObject playerBodyGirl; //animator ng player
    GameObject playerBody;

    public bool isInAnim; //if naka death animation, or hit animation di magooverlap sa ibang animation
    public static bool playerHit; //kapag naka true to, invincible yung player
    public static bool isHit; //kapag tumama, di naooverlap ung animation
    public Image damageReminder; //ung red sa side kapag 1 health left
    public Image damageReminderG1; //ung red sa side kapag more than 1 health pa
    public static bool isFrom1Health; //bool kung galing ba sa 1 health left
    Collider playerCollider; //player collider

    void Start() 
    {
        if(Movement.PlayerSkin == 1){
            playerBody = playerBodyBoy;
        }
        else if(Movement.PlayerSkin == 2){
            playerBody = playerBodyGirl;
        }
        playerCollider = GetComponent<Collider>();
        playerCollider.enabled = playerCollider.enabled;
        damageReminder.enabled = false;
        damageReminderG1.enabled = false;
        isFrom1Health = false;
    }

    void Update() 
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }


        if (playerBody != null)
        {
            if (health == 0)
            {
                playerBody.GetComponent<Animator>().Play("deathAnim");
                isInAnim = true;
                isHit = true;
                StartCoroutine(dead());
            }

            if (health == 1){
                damageReminder.enabled = true;
                damageReminder.GetComponent<Animator>().Play("1health");
            }
            if(isFrom1Health == true){
                damageReminder.enabled = false;
                damageReminderG1.enabled = false;
                isFrom1Health = false;
            }

            if(playerHit == true){
                playerBody.GetComponent<Animator>().Play("enemyHit");
                damageReminderG1.enabled = true;
                isInAnim = true;
                isHit = true;
                Debug.Log("Tumama sa kalaban");
                health = health - 1;
                playerHit = false;
                StartCoroutine(backtoIdle());
            }

            IEnumerator backtoIdle(){
                if(health > 0){
                    if(health != 1){
                        StartCoroutine(FadeImage(true));
                    }
                    else if(health == 1){
                         StartCoroutine(FadeImage(false));
                    }
                    yield return new WaitForSeconds(0.75f);
                    playerBody.GetComponent<Animator>().Play("idleAnim");
                    isInAnim = false;
                    isHit = false;
                }
            }

            IEnumerator dead(){
                isFrom1Health = true;
                StartCoroutine(FadeImage(true));
                yield return new WaitForSeconds(3f);
                isHit = false;
                // Destroy(EnemyFullBody);
            } 
        }
    }

    IEnumerator FadeImage(bool fadeAway){
         // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                damageReminderG1.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                damageReminderG1.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if(isInAnim != true){
            playerCollider.enabled = playerCollider.enabled;
            if(collision.gameObject.tag == "Enemy")
            {
                playerHit = true;
            }
       }
       else if(isInAnim == true){
            // enemcollider.enabled = !enemcollider.enabled;
       }
    }
}

        