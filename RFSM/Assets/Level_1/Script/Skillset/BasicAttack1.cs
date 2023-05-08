using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;
using TMPro;

public class BasicAttack1 : MonoBehaviour
{
    public GameObject MainCamera; //main camera
    public GameObject GunCamera; //fps camera
    public GameObject MainAim; //main camera on non-charge attack
    public GameObject ChargeAim; //camera during charged attack
    public GameObject PlayerModel; //player animator
    public GameObject AttackTrigger; //left click pang damage sa kalaban
    public GameObject ChargeAttackTrigger; //right click pang damage sa kalaban
    public GameObject Hammer; // Skill 1
    public GameObject KnucklesRight; // Skill 2
    public GameObject KnucklesLeft; // Skill 2
    public GameObject gun; //Skill 3
    public GameObject staff; //Skill 4
    public int comboCount; //3 hit combo count
    public static bool basicAttack; //if basic attack walang papatong na animation
    public static bool chargeAttack; //if charge attach, walang papatong na animation
    public static bool chargeAttackTime; //while charging sa charge attack, walang papatong na animation
    public int skillType;
    // 1 = Hammer 2 = Knuckles 3 = Gunner 4 = Mage


    [Header("VFX")]
    public GameObject HammerhitEffect; //vfx ng hammer
    public GameObject HammerChargeEffect; //vfx ng charged hammer
    public GameObject HammerhitFinEffect; //vfx pag tumama na ung hammer

    public Transform KnucklePosition; //position ng gloves
    public GameObject KnuckleHitEffect; //vfx ng knuckles
    public GameObject KnuckleChargeEffect; //vfx ng charge attack ng knuckles
    public GameObject KnuckleChargeHitEffect; //vfx pag tumama sa kalaban ung knuckles
    public Transform PlayerPosition; //san current position ng player

    public GameObject MuzzleEffect; //vfx sa gun
    public Transform MuzzlePosition; //position ng paglalabasan ng bullet
    public Transform MuzzleAimPosition; //position ng paglalabasan ng bullet (if naka fps)

    [Header("Shooting")]
    public static bool hasGun; //if merong gun
    public GameObject objectToShoot; //bullet
    public Transform playerShoot; //position ng player
    public Transform attackPointShoot; //muzzle location
    public float shootForce; //gano kabilis yung bullet
    public float shootUpwardForce; //if grenade (dapat meron value to)
    public int totalShoots; //total bullet per round
    public float shootCooldown; //cooldown ng bala
    public bool readyToShoot; //if goods na mag shoot

    [Header("Shoot on Aim")]
    public Transform bulletspawnpoint; //Where the bullet will spawn when aiming
    public Transform aimedbulletspawnpoint; //Where the bullet will spawn when aiming
    public GameObject bulletprefab; //the bullet that the aim will use
    public float bulletspeed = 10f; //speed of the bullet shot

    [Header("Reloading")]
    public int bulletleft = 30; //how many bullet left before reload
    public KeyCode reload = KeyCode.R; // reload
    public static bool isReloading; // to overwrite animations
    public TextMeshProUGUI ammosize; //the text where all the bullets is shown

    [Header("Mage")]
    public GameObject MagicToShoot; //magic bullet
    public Transform MageAttackPoint; //position where the mage can attach
    public int mpleft = 300; //the mp left
    public TextMeshProUGUI magicmp; //the text where all mp is shown
    public GameObject MageMPAdder; //the item to pick up for mage
    public GameObject MageMaceVFX; //vfx for mage mace
    public Transform MageMacePosition; //position of mace
    public GameObject ChargedMagicToShoot; //charged bullet (magic)
    public int MageShootForce;
    
    // public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        isReloading = false;
        hasGun = false;
        MainAim.SetActive(true);
        GunCamera.SetActive(false);
        AttackTrigger.SetActive(false);
        ChargeAttackTrigger.SetActive(false);
        basicAttack = false;
        chargeAttackTime = false;
        Hammer.SetActive(false);
        KnucklesLeft.SetActive(false);
        KnucklesRight.SetActive(false);
        gun.SetActive(false);
        ammosize.enabled = false;
        staff.SetActive(false);
        magicmp.enabled = false;
    }

    void Update()
    {
//SKILL 1
        if (skillType == 1)
        {
            Hammer.SetActive(true);
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("GPMainAttack")){
                basicAttack = true;
                comboCount++;

                if(comboCount == 1){
                    Debug.Log("Pressed 1");
                    PlayerModel.GetComponent<Animator>().Play("hammerHit1");
                    StartCoroutine(AttackRange());
                }
                if(comboCount == 2){
                    Debug.Log("Pressed 2");
                    PlayerModel.GetComponent<Animator>().Play("hammerHit2");
                    StartCoroutine(AttackRange());
                }
                if(comboCount == 3){
                    Debug.Log("Pressed 3");
                    PlayerModel.GetComponent<Animator>().Play("hammerHit3");
                    StartCoroutine(AttackRange());
                    comboCount = 0;
                }
            }

            if (Input.GetKey(KeyCode.Mouse1) || Input.GetButton("GPChargedAttack"))
            {
                basicAttack = true;
                PlayerModel.GetComponent<Animator>().Play("HammerChargeAttack1");
                StartCoroutine(AttackCharge());

                IEnumerator AttackCharge(){
                    MainAim.SetActive(false);
                    ChargeAim.SetActive(true);
                    HammerChargeVFX();
                    yield return new WaitForSeconds(1f);
                    chargeAttackTime = true;
                    if(Input.GetKeyUp(KeyCode.Mouse1) || Input.GetButtonUp("GPChargedAttack"))
                    {
                        StartCoroutine(ChargeAttackTimer());
                        PlayerModel.GetComponent<Animator>().Play("HammerChargeAttack2");
                        MainAim.SetActive(true);
                        ChargeAim.SetActive(false);
                        yield return new WaitForSeconds(.70f);
                        CinemachineShake.isShaking = true;
                        yield return new WaitForSeconds(1.80f);
                        PlayerModel.GetComponent<Animator>().Play("idleAnim");
                        basicAttack = false;
                        chargeAttackTime = false;
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse1) && chargeAttackTime == false || Input.GetButtonUp("GPChargedAttack") && chargeAttackTime == false)
            {
                // PlayerModel.GetComponent<Animator>().Play("HammerChargeAttack2");
                PlayerModel.GetComponent<Animator>().Play("idleAnim");
                MainAim.SetActive(true);
                ChargeAim.SetActive(false);
                basicAttack = false;
            }

            IEnumerator AttackRange(){
                yield return new WaitForSeconds(0.5f);
                AttackTrigger.SetActive(true);
                HammerhitVFX();
                yield return new WaitForSeconds(0.25f);
                AttackTrigger.SetActive(false);
                basicAttack = false;
            }

            IEnumerator ChargeAttackTimer(){
                yield return new WaitForSeconds(.75f);
                ChargeAttackTrigger.SetActive(true);
                CinemachineShake.isShaking = false;
                HammerChargeHit();
                yield return new WaitForSeconds(1f);
                ChargeAttackTrigger.SetActive(false);
            }

            //VFX for Hammer
            void HammerhitVFX(){
                GameObject newBurstEffect = Instantiate(HammerhitEffect, PlayerPosition.position, PlayerPosition.rotation);
                // newBurstEffect.Play();
                Destroy(newBurstEffect.gameObject, 1.5f);
            }

            void HammerChargeVFX(){
                GameObject newChargeEffect = Instantiate(HammerhitEffect, PlayerPosition.position, PlayerPosition.rotation);
                // newBurstEffect.Play();
                Destroy(newChargeEffect.gameObject, 1f);
            }
            
            void HammerChargeHit(){
                GameObject newChargeBurstEffect = Instantiate(HammerhitFinEffect, PlayerPosition.position, PlayerPosition.rotation);
                // newBurstEffect.Play();
                Destroy(newChargeBurstEffect.gameObject, 3f);
            }
        }


//SKILL 2
        if (skillType == 2)
        {
            KnucklesLeft.SetActive(true);
            KnucklesRight.SetActive(true);
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("GPMainAttack")){
                basicAttack = true;
                comboCount++;

                if(comboCount == 1){
                    Debug.Log("Pressed 1");
                    PlayerModel.GetComponent<Animator>().Play("knuckleHit1");
                    StartCoroutine(AttackRange());
                }
                if(comboCount == 2){
                    Debug.Log("Pressed 2");
                    PlayerModel.GetComponent<Animator>().Play("knuckleHit2");
                    StartCoroutine(AttackRange());
                }
                if(comboCount == 3){
                    Debug.Log("Pressed 3");
                    PlayerModel.GetComponent<Animator>().Play("knuckleHit3");
                    StartCoroutine(AttackRange());
                    comboCount = 0;
                }
            }

            if (Input.GetKey(KeyCode.Mouse1) || Input.GetButton("GPChargedAttack"))
            {
                basicAttack = true;
                PlayerModel.GetComponent<Animator>().Play("knuckleChargeAttack1");
                StartCoroutine(AttackCharge());

                IEnumerator AttackCharge(){
                    MainAim.SetActive(false);
                    ChargeAim.SetActive(true);
                    KnuckleChargeVFX();
                    yield return new WaitForSeconds(1f);
                    chargeAttackTime = true;
                    if(Input.GetKeyUp(KeyCode.Mouse1) || Input.GetButtonUp("GPChargedAttack"))
                    {
                        CinemachineShake.isShaking = true;
                        StartCoroutine(ChargeAttackTimer());
                        PlayerModel.GetComponent<Animator>().Play("knuckleChargeAttack2");
                        MainAim.SetActive(true);
                        ChargeAim.SetActive(false);
                        yield return new WaitForSeconds(1f);
                        PlayerModel.GetComponent<Animator>().Play("idleAnim");
                        basicAttack = false;
                        chargeAttackTime = false;
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse1) && chargeAttackTime == false || Input.GetButtonUp("GPChargedAttack") && chargeAttackTime == false)
            {
                // PlayerModel.GetComponent<Animator>().Play("HammerChargeAttack2");
                PlayerModel.GetComponent<Animator>().Play("idleAnim");
                MainAim.SetActive(true);
                ChargeAim.SetActive(false);
                basicAttack = false;
            }

            IEnumerator AttackRange(){
                yield return new WaitForSeconds(0.5f);
                KnucklehitVFX();
                AttackTrigger.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                AttackTrigger.SetActive(false);
                basicAttack = false;
            }

            IEnumerator ChargeAttackTimer(){
                yield return new WaitForSeconds(.25f);
                KnuckleChargeHitVFX();
                CinemachineShake.isShaking = false;
                ChargeAttackTrigger.SetActive(true);
                yield return new WaitForSeconds(.5f);
                ChargeAttackTrigger.SetActive(false);
            }

             //VFX for Knuckles
            void KnucklehitVFX(){
                GameObject newBurstEffect = Instantiate(KnuckleHitEffect, PlayerPosition.position, PlayerPosition.rotation);
                // newBurstEffect.Play();
                Destroy(newBurstEffect.gameObject, 1.5f);
            }

            void KnuckleChargeVFX(){
                GameObject newChargeEffect = Instantiate(KnuckleChargeEffect, KnucklePosition.position, KnucklePosition.rotation);
                // newBurstEffect.Play();
                Destroy(newChargeEffect.gameObject, 1f);
            }

            void KnuckleChargeHitVFX(){
                GameObject newChargeHitEffect = Instantiate(KnuckleChargeHitEffect, KnucklePosition.position, KnucklePosition.rotation);
                // newBurstEffect.Play();
                Destroy(newChargeHitEffect.gameObject, 1f);
            }
        }


//SKILL 3
        if (skillType == 3)
        {
            ammosize.enabled = true;
            hasGun = true;
            gun.SetActive(true);
            if(bulletleft > 0){
                if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("GPMainAttack")){
                    bulletleft = bulletleft - 1;
                    ammosize.text = "AMMO: "+ bulletleft.ToString() + "/30";
                    if(Movement.isAiming == false){
                        Shoot();
                        MuzzleVFX();
                    } 
                    else if(Movement.isAiming == true){
                        ShootOnAim();
                    }
                }
            }

            if (Input.GetKey(KeyCode.Mouse1) || Input.GetButton("GPChargedAttack"))
            {
                // PlayerModel.GetComponent<Animator>().Play("AimToShoot");
                Movement.isAiming = true;
                if(isReloading == false){
                    gun.SetActive(true);
                    MainCamera.SetActive(false);
                    GunCamera.SetActive(true);
                }
                else if (isReloading == true){
                    gun.SetActive(true);
                    MainCamera.SetActive(true);
                    GunCamera.SetActive(false);
                }
            }

            if(Input.GetKeyUp(KeyCode.Mouse1) || Input.GetButtonUp("GPChargedAttack"))
            {
                gun.SetActive(true);
                Movement.isAiming = false;
                MainCamera.SetActive(true);
                GunCamera.SetActive(false);
                basicAttack = false;
            }

            if(Input.GetKeyDown(reload)){
                if(bulletleft == 30){
                    //no animation
                } 
                else if (bulletleft < 30){
                    Debug.Log("Reloading!!");
                    isReloading = true;
                    StartCoroutine(reloadingAnimTime());
                    PlayerModel.GetComponent<Animator>().Play("reloadAnim");
                }

                IEnumerator reloadingAnimTime(){
                    yield return new WaitForSeconds(2f);
                    bulletleft = 30;
                    ammosize.text = "AMMO: "+ bulletleft.ToString() + "/30";
                    isReloading = false;
                }
                
            }

            void ResetShoot()
            {
                readyToShoot = true;
            }


            void Shoot()
            {
                readyToShoot = false;
                // instantiate object to throw
                GameObject Gunprojectile = Instantiate(objectToShoot, attackPointShoot.position, playerShoot.rotation);
                // get rigidbody component
                Rigidbody GunprojectileRb = Gunprojectile.GetComponent<Rigidbody>();
                // calculate direction
                Vector3 GunforceDirection = playerShoot.transform.forward;
                RaycastHit hitshot;
                if(Physics.Raycast(playerShoot.position, playerShoot.forward, out hitshot, 500f))
                {
                    GunforceDirection = (hitshot.point - attackPointShoot.position).normalized;
                    
                }
                // add force
                Vector3 forceToAdd = GunforceDirection * shootForce + transform.up * shootUpwardForce;
                GunprojectileRb.AddForce(forceToAdd, ForceMode.Impulse);
                totalShoots--;
                Destroy(Gunprojectile, 1.5f);
                // implement throwCooldown
                Invoke(nameof(ResetShoot), shootCooldown);
            }
            void ShootOnAim(){
                var bullet = Instantiate(bulletprefab, aimedbulletspawnpoint.position, aimedbulletspawnpoint.rotation);
                MuzzleAimVFX();
                bullet.GetComponent<Rigidbody>().velocity = aimedbulletspawnpoint.forward * bulletspeed;
                Destroy(bullet, 1.5f);
            }

            //VFX for shooting
            void MuzzleVFX(){
                GameObject newBurstEffect = Instantiate(MuzzleEffect, MuzzlePosition.position, MuzzlePosition.rotation);
                // newBurstEffect.Play();
                Destroy(newBurstEffect.gameObject, 1.5f);
            }

            void MuzzleAimVFX(){
                GameObject newBurstEffect = Instantiate(MuzzleEffect, MuzzleAimPosition.position, MuzzleAimPosition.rotation);
                // newBurstEffect.Play();
                Destroy(newBurstEffect.gameObject, 1.5f);
            }
        }

//SKILL 4
        if (skillType == 4)
        {
            magicmp.enabled = true;
            staff.SetActive(true);
            if(mpleft > 0){
                if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("GPMainAttack")){
                    mpleft = mpleft - 5;
                    magicmp.text = "MP: "+ mpleft.ToString();
                    basicAttack = true;
                    comboCount++;

                    if(comboCount == 1){
                        Debug.Log("Pressed 1");
                        PlayerModel.GetComponent<Animator>().Play("mageHit1");
                        StartCoroutine(MageAnimation());
                    }
                    if(comboCount == 2){
                        Debug.Log("Pressed 2");
                        PlayerModel.GetComponent<Animator>().Play("mageHit2");
                        StartCoroutine(MageAnimation());
                    }
                    if(comboCount == 3){
                        Debug.Log("Pressed 3");
                        PlayerModel.GetComponent<Animator>().Play("mageHit3");
                        StartCoroutine(MageAnimation());
                        comboCount = 0;
                    }
                }
            }
            

            if (Input.GetKey(KeyCode.Mouse1) || Input.GetButton("GPChargedAttack"))
            {
                basicAttack = true;
                PlayerModel.GetComponent<Animator>().Play("mageChargeAttack1");
                StartCoroutine(AttackCharge());

                IEnumerator AttackCharge(){
                    MainAim.SetActive(false);
                    ChargeAim.SetActive(true);
                    MageChargeVFX();
                    yield return new WaitForSeconds(1f);
                    chargeAttackTime = true;
                    if(Input.GetKeyUp(KeyCode.Mouse1) || Input.GetButtonUp("GPChargedAttack"))
                    {
                        StartCoroutine(ChargeAttackTimer());
                        PlayerModel.GetComponent<Animator>().Play("mageChargeAttack2");
                        MainAim.SetActive(true);
                        ChargeAim.SetActive(false);
                        yield return new WaitForSeconds(.70f);
                        CinemachineShake.isShaking = true;
                        yield return new WaitForSeconds(.20f);
                        PlayerModel.GetComponent<Animator>().Play("idleAnim");
                        basicAttack = false;
                        chargeAttackTime = false;
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse1) && chargeAttackTime == false || Input.GetButtonUp("GPChargedAttack") && chargeAttackTime == false)
            {
                // PlayerModel.GetComponent<Animator>().Play("HammerChargeAttack2");
                PlayerModel.GetComponent<Animator>().Play("idleAnim");
                MainAim.SetActive(true);
                ChargeAim.SetActive(false);
                basicAttack = false;
            }

            IEnumerator ChargeAttackTimer(){
                yield return new WaitForSeconds(.75f);
                // ChargeAttackTrigger.SetActive(true);
                CinemachineShake.isShaking = false;
                MageChargeHit();
                ChargedShoot();
                yield return new WaitForSeconds(1f);
                // ChargeAttackTrigger.SetActive(false);
            }

            void MageChargeVFX(){
                // GameObject newChargeEffect = Instantiate(HammerhitEffect, PlayerPosition.position, PlayerPosition.rotation);
                // // newBurstEffect.Play();
                // Destroy(newChargeEffect.gameObject, 1f);
            }
            
            void MageChargeHit(){
                mpleft = mpleft - 25;
                magicmp.text = "MP: "+ mpleft.ToString();
                GameObject newChargeBurstEffect = Instantiate(HammerhitFinEffect, PlayerPosition.position, PlayerPosition.rotation);
                // newBurstEffect.Play();
                Destroy(newChargeBurstEffect.gameObject, 3f);
            }

            void ResetShoot()
            {
                readyToShoot = true;
            }

            IEnumerator MageAnimation(){
                yield return new WaitForSeconds(.50f);
                GameObject newChargeHitEffect = Instantiate(MageMaceVFX, MageMacePosition.position, MageMacePosition.rotation);
                Destroy(newChargeHitEffect.gameObject, 1f);
                Shoot();
                yield return new WaitForSeconds(.25f);
                basicAttack = false;
            }

            void Shoot()
            {
                readyToShoot = false;
                // instantiate object to throw
                GameObject MageProjectile = Instantiate(MagicToShoot, MageAttackPoint.position, playerShoot.rotation);
                // get rigidbody component
                Rigidbody MageProjectileRb = MageProjectile.GetComponent<Rigidbody>();
                // calculate direction
                Vector3 MageForceDirection = playerShoot.transform.forward;
                RaycastHit hitshot;
                if(Physics.Raycast(playerShoot.position, playerShoot.forward, out hitshot, 500f))
                {
                    MageForceDirection = (hitshot.point - MageAttackPoint.position).normalized;
                    
                }
                // add force
                Vector3 forceToAdd = MageForceDirection * shootForce + transform.up * shootUpwardForce;
                MageProjectileRb.AddForce(forceToAdd, ForceMode.Impulse);
                // totalShoots--;
                Destroy(MageProjectile, 4f);
                // implement throwCooldown
                Invoke(nameof(ResetShoot), shootCooldown); 
            }

            void ChargedShoot()
            {
                readyToShoot = false;
                // instantiate object to throw
                GameObject MageProjectile = Instantiate(ChargedMagicToShoot, MageAttackPoint.position, playerShoot.rotation);
                // get rigidbody component
                Rigidbody MageProjectileRb = MageProjectile.GetComponent<Rigidbody>();
                // calculate direction
                Vector3 MageForceDirection = playerShoot.transform.forward;
                RaycastHit hitshot;
                if(Physics.Raycast(playerShoot.position, playerShoot.forward, out hitshot, 500f))
                {
                    MageForceDirection = (hitshot.point - MageAttackPoint.position).normalized;
                    
                }
                // add force
                Vector3 forceToAdd = MageForceDirection * shootForce + transform.up * shootUpwardForce;
                MageProjectileRb.AddForce(forceToAdd, ForceMode.Impulse);
                // totalShoots--;
                Destroy(MageProjectile, 1.5f);
                // implement throwCooldown
                Invoke(nameof(ResetShoot), shootCooldown); 
            }
           
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "MagePotion(Clone)"){
            mpleft = mpleft + 25;
            Destroy(EnemyHit.MageMagic);
            magicmp.text = "MP: "+ mpleft.ToString();
        }
    }
  
}


