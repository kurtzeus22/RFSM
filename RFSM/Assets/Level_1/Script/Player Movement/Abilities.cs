using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown1 = false;
    public KeyCode ability1;

    //Ability 1 Input Variables
    // Vector3 position;
    // public Canvas ability1Canvas;
    // public Image skillshot;
    // public Transform player;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;

    //Ability 2 Input Variables
    // public Image targetCircle;
    // public Image indicatorRangeCirlce;
    // public Canvas ability2Canvas;
    // private Vector3 posUp;
    // public float maxAbility2Distance;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode ability3;

    [Header("Ability 4")]
    public Image abilityImage4;
    public float cooldown4 = 5;
    bool isCooldown4 = false;
    public KeyCode ability4;

    // Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;

        // skillshot.GetComponent<Image>().enabled = false;
        // targetCircle.GetComponent<Image>().enabled = false;
        // indicatorRangeCirlce.GetComponent<Image>().enabled = false;

        // _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();

        // RaycastHit hit;
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // //Ability 1 Inputs
        // if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        // {
        //     position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        // }

        // //Ability 2 Inputs
        // if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        // {
        //     if(hit.collider.gameObject != this.gameObject)
        //     {
        //         posUp = new Vector3(hit.point.x, 10f, hit.point.z);
        //         position = hit.point;
        //     }
        // }

        // //Ability 1 Canvas Inputs
        // Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        // ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);

        // //Ability 2 Canvas Inputs
        // var hitPosDir = (hit.point - transform.position).normalized;
        // float distance = Vector3.Distance(hit.point, transform.position);
        // distance = Mathf.Min(distance, maxAbility2Distance);

        // var newHitPos = transform.position + hitPosDir * distance;
        // ability2Canvas.transform.position = (newHitPos);
    }

    void Ability1()
    {
        
       if(Input.GetKey(ability1) && isCooldown1 == false || Input.GetButton("GPSkill1") && isCooldown1 == false)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }

    void Ability2()
    {
       if(Input.GetKeyUp(ability2) && isCooldown2 == false || Input.GetButton("GPSkill2") && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if(isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if(abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if(Input.GetKey(ability3) && isCooldown3 == false|| Input.GetButton("GPSkill3") && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if(isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if(abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Ability4()
    {
        if(Input.GetKey(ability4) && isCooldown4 == false|| Input.GetButton("GPSkill4") && isCooldown4 == false)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
        }

        if(isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if(abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}
