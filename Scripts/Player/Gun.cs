using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Damage = 5f;
    public float Range = 150f;
    public Camera Cam;
    public Animator Animator;
    public GameObject Fire;
    public AudioSource AudioSource;
    public GameObject CrossHair;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
            AudioSource.enabled = true;
        }
        if(Input.GetMouseButton(0)==false)
        {
            Animator.SetInteger("Anim", 0);
            AudioSource.enabled = false;
        }
        if (Input.GetMouseButton(1))
        {
            Animator.SetInteger("Anim", 3);
            CrossHair.SetActive(false);
        }
        if (Input.GetMouseButton(1) && Input.GetMouseButton(0))
        {
            Animator.SetInteger("Anim", 3);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Animator.SetInteger("Anim", 0);
            CrossHair.SetActive(true);
        }
    }
    
    void Shoot()
    {
        Animator.SetInteger("Anim", 1);

        RaycastHit hit;

        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward , out hit , Range))
        {
            print(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            Instantiate(Fire, hit.point, Quaternion.LookRotation(hit.normal));
           
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
}
