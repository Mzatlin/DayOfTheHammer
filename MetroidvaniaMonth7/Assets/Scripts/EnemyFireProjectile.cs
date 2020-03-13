using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFireProjectile : MonoBehaviour,IShootProjectile
{
    [SerializeField]
    float projectileSpeed= 10f;
    [SerializeField]
    float _fireRate = .4f;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Vector2 direction;
    [SerializeField]
    Vector3 offset = Vector3.zero;
    Rigidbody2D rigidbody;
    float timeBeforeFire = 0;
    [SerializeField]
    Animator animate;


    public float FireRate => _fireRate;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
        rigidbody = projectile.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFire())
        {
            animate.SetBool("CanFire", true);
            FireWeapon();
        }
    }

    public Vector2 CalculateDirection()
    {
        return direction;
    }

    public bool CanFire()
    {
        if (Time.time >= timeBeforeFire)
        {
            timeBeforeFire = Time.time + _fireRate;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FireWeapon()
    {
       var clone = Instantiate(projectile, transform.position+offset, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = (CalculateDirection() * projectileSpeed);
        StartCoroutine(AnimateDelay());
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/TurretFire", GetComponent<Transform> ().position);

    }

    IEnumerator AnimateDelay()
    {
        yield return new WaitForSeconds(0.1f);
        animate.SetBool("CanFire", false);
    }


}
