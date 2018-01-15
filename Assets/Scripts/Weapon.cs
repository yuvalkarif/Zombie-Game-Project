using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	
public class Weapon : MonoBehaviour {
    [Range(0,100)]
    public float fireRate =0;
    public int Damage = 10;
    public LayerMask whatToHit;

    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;

   
    public int currentMags = -1;
    public Text AmmoLeftText;

	public int maxAmmo = 30;
	public int currentAmmo =-1;
	public float reloadTime = 1f;
	private bool isReloading = false;
	public Text AmmoText;
    public int ammoLeft = 90;

    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

    float timeToFire = 0;
    Transform firePoint;


	// Use this for initialization
	void Awake () {
        firePoint = this.transform;
        if (firePoint == null)
        { Debug.LogError("No Fire Point"); }
		
	}
	void Start()
	{
		if (currentAmmo == -1) {
			currentAmmo = maxAmmo;
		}
       
		SetAmmoText ();
        SetAmmoLeftText();
       
	}
	void onEnable()
	{
		isReloading = false;

	}
	// Update is called once per frame
	void Update () {
       
		if (isReloading) {
			return;
		}

		if (Input.GetKeyDown(KeyCode.R) && ammoLeft > 0) {
			StartCoroutine(Reload ());
			return;
		}
		if (currentAmmo > 0) {
			
		
			if (fireRate == 0) {
				if (Input.GetKeyDown (KeyCode.Mouse0)) {
					Shoot ();
				}
			} else {
				if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeToFire) {
                
					timeToFire = Time.time + 1 / fireRate;
					Shoot ();
				}
			}
		}
		
	}
	IEnumerator Reload()
	{
        if (ammoLeft > 0)
        {     
            
          
                ammoLeft = ammoLeft - maxAmmo + currentAmmo;
                SetAmmoLeftText();

                isReloading = true;
                Debug.Log("Reloading");

                yield return new WaitForSeconds(reloadTime);
                if (ammoLeft % maxAmmo == 0 || ammoLeft > maxAmmo)
                {
                    currentAmmo = maxAmmo;
                }
                else
                {
                    currentAmmo =  ammoLeft%maxAmmo;
                }
                isReloading = false;
            
        }
	}

    void Shoot()
    {
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
        
        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.DamageEnemy(Damage);
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
		AmmoText.text = "Ammo  =  " + currentAmmo.ToString();
	}
    void SetAmmoLeftText()
    {
        AmmoLeftText.text = "Ammo Left  =  " + ammoLeft.ToString();
    }
}
