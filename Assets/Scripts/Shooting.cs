using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] float bulletCooldown;
    private bool canFire;

    // Get Mouse Postion in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    //private void Awake()
    //{
    //    FirePoint = transform.Find("FirePoint");
    //}
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Grab the mouse position
        Vector3 mousePosition = GetMouseWorldPosition();

        // Calculate the angle to look at the mouse for both the player and the gun
        Vector3 playerDirection = (mousePosition - transform.position).normalized;
        float playerAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Vector3 mouseDirection = (mousePosition - FirePoint.position).normalized;
        float mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        /* Set the angle of the fire point to aim at the mouse cursor only if it does not
         * deviate too far from the PC's angle.  Otherwise, if the difference in angle 
         * is too great, simply set the angle of the fire point to equal the PC's. */
        if (Mathf.Abs(playerAngle - mouseAngle) <= 10f) {
            FirePoint.eulerAngles = new Vector3(0, 0, mouseAngle);
        } else {
            FirePoint.eulerAngles = new Vector3(0, 0, playerAngle);
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Shoot();
            canFire = false;
            StartCoroutine(fireCooldown());
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator fireCooldown()
    {
        yield return new WaitForSeconds(bulletCooldown);
        canFire = true;
    }
}
