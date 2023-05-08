using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Breakable : MonoBehaviour {
    [SerializeField] private GameObject _replacement_skill1;
    [SerializeField] private GameObject _replacement_unstun;
    [SerializeField] private GameObject _replacement_skill2;
    [SerializeField] private GameObject _replacement_skill3;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    [SerializeField] private bool _broken;
    [SerializeField] private bool _stunned;
    [SerializeField] private bool _slowed;
 
    void OnCollisionEnter(Collision collision) {
        if(_broken) return;
        // if(_stunned) return;

        //Collision with Skill 1 (Stunned)
        if (collision.gameObject.name == "Knockback(Clone)") {
            _stunned = true;
            
            var replacement = Instantiate(_replacement_skill1, transform.position, transform.rotation);
 
            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs) {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier,collision.contacts[0].point,2);
            }

            Destroy(gameObject);
        }

        //Collision with Skill 2 (Death)
        if (collision.gameObject.name == "Explosion(Clone)") {
            _broken = true;
            var replacement = Instantiate(_replacement_skill2, transform.position, transform.rotation);
 
            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs) {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier,collision.contacts[0].point,2);
                
            }
 
            Destroy(gameObject);
            StartCoroutine(afterDeath());
            IEnumerator afterDeath(){
                Debug.Log("dedz na");
                yield return new WaitForSeconds(1f);
                // _replacement_skill2.SetActive(false);
                Destroy(_replacement_skill2);
            }
              
        }


        //Collisin with Skill 3 (Slowed)
        if (collision.gameObject.name == "Checker" && !_slowed) {
            _slowed = true;
            var replacement = Instantiate(_replacement_skill3, transform.position, transform.rotation);
            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs){
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier,collision.contacts[0].point,2);
            }

            Destroy(gameObject);
        }
    }
}