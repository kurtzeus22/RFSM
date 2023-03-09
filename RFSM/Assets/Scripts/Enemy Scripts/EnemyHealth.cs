using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    // for text floating
    public GameObject FloatingTextPrefab;
    public GameObject ShowWinText;


    public Slider healthBar; // for the health bar
    [SerializeField]
    private float HP = 100;
    public Animator animator;


    void LateUpdate()
    {
        healthBar.value = HP; // set tha value for the health bar 
    }

    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;

        // show text floating
        if (FloatingTextPrefab && HP > 0)
        {
            ShowFloatingText(damageAmount); 
        }

        if (HP <= 0)
        {
            //play death animation animator.SetTrigger("Die");
            print("Enemy Dieeeee!!!");
            HP = 0; 
            ShowWinText.SetActive(true);
            Time.timeScale = 0f;

        }
        else{
            //play hit animator.SetTrigger("Damage");
            print("Enemy was Hitttt!!!");
        }
    }

    void ShowFloatingText(float damage)
    {
        var _display = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        _display.GetComponent<TextMesh>().text = damage.ToString();
    }
}
