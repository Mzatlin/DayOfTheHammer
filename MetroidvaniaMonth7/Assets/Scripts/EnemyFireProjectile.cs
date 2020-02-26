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
    Rigidbody2D rigidbody;
    float timeBeforeFire = 0;

    public float FireRate => _fireRate;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = projectile.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFire())
        {
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
       var clone = Instantiate(projectile, transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = (CalculateDirection() * projectileSpeed);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Throw");

    }


}
