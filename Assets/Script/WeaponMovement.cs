using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [SerializeField] public Vector2 mousePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    private float FireTimer;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, 
        mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(0,0, angle);

        if (Input.GetMouseButtonDown(0) && FireTimer <= 0f){
            Shoot();
            FireTimer = fireRate;
        }else{
            FireTimer -= Time.deltaTime;
        }
    }

    private void Shoot(){
        Instantiate(bulletPrefabs, firingPoint.position, firingPoint.rotation);
    }
}
