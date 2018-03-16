using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
    [Range(0, 100)]
    public float fireRate = 0;
    public int Damage = 10;
    public LayerMask whatToHit;

    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;


    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

    float timeToFire = 0;
    Transform firePoint;

    
        public int maxCurrentAmmo = 30;
        public int currentAmmo;
        public int maxMagAmmo = 90;
        public int currentMagAmmo;

        public bool isReloading = false;
        public float reloadTime = 1f;

        public Text AmmoText;
        public Text AmmoLeftText;

        private Animator anim;





    PauseGame p = new PauseGame();

    // Use this for initialization
    void Awake () {
        firePoint = this.transform;
        if (firePoint == null)
        { Debug.LogError("No Fire Point"); }
		
	}
	void Start()
	{
        currentAmmo = maxCurrentAmmo;
        currentMagAmmo = maxMagAmmo;
       
		SetAmmoText ();
        SetAmmoLeftText();

        anim = transform.parent.parent.GetComponent<Animator>();

    }
	void onEnable()
	{
		isReloading = false;

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (p.Paused == false) {
			
		
			if (isReloading) {
				return;
			}

			if (Input.GetKeyDown (KeyCode.R) && currentAmmo != maxCurrentAmmo) {
				StartCoroutine (Reload ());
				return;
			}
			if (currentAmmo > 0) {
			
		
				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Shoot ();
                        //anim.SetTrigger("Attacking");
                        
                        
                    }
				} else {
					if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeToFire) {
                
						timeToFire = Time.time + 1 / fireRate;
						Shoot ();
                        anim.SetTrigger("Attacking");

                    }
                    
                }
               
            }
		}
		
	}
	IEnumerator Reload()
	{
        if (currentMagAmmo > 0)
        {
                isReloading = true;
                Debug.Log("Reloading");
				if (currentMagAmmo >= maxCurrentAmmo) {
					currentMagAmmo = currentMagAmmo  + currentAmmo- maxCurrentAmmo ;
					currentAmmo = maxCurrentAmmo;
					
				} 
				else if (currentAmmo + currentMagAmmo > maxCurrentAmmo) {
					currentMagAmmo = currentMagAmmo + currentAmmo - maxCurrentAmmo;
					currentAmmo = maxCurrentAmmo;
				} 
				else {
					currentAmmo = currentAmmo + currentMagAmmo;
					currentMagAmmo = 0;
				}
				
                yield return new WaitForSeconds(reloadTime);
                isReloading = false;
                SetAmmoLeftText();
                SetAmmoText();
        }
	}

    void Shoot()
    {
		if (p.Paused == false) {

            


            currentAmmo--;
		SetAmmoText ();
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition,100,whatToHit);
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        
			if (hit.collider != null) {
				Enemy enemy = hit.collider.GetComponent<Enemy> ();
				if (enemy != null) {
					enemy.DamageEnemy (Damage);
				}
			}
        }

    }

    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform clone =Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        
        Destroy(clone.gameObject,0.02f);
    }
	void SetAmmoText()
	{
		AmmoText.text = currentAmmo.ToString();
	}
    void SetAmmoLeftText()
    {
        AmmoLeftText.text = "/" + currentMagAmmo.ToString();
    }
    public void MaxAmmo()
    {
        currentAmmo = maxCurrentAmmo;
        currentMagAmmo = maxMagAmmo;
        SetAmmoText();
        SetAmmoLeftText();
        
    }
}
