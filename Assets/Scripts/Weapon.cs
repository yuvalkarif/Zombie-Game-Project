using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour { // The class controls the properties of the weapon 
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
        PauseGame p;

        private Animator anim; // animation 





   

    // Use this for initialization
    void Start () { // initialized the properties 
        firePoint = this.transform;
        if (firePoint == null)
        { Debug.LogError("No Fire Point"); }
        p = new PauseGame();

    }
	void Awake() // sets the properties to a certain amount and changes the UI 
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
	void FixedUpdate () {// Fires or reloads the weapon if the game isnt paused 
		if (p.Paused == false) {
			
		
			if (isReloading) { //returns if the weapon is reloading 
				return;
			}

			if (Input.GetKeyDown (KeyCode.R) && currentAmmo != maxCurrentAmmo) { // reloads the weapon
				StartCoroutine (Reload ());
				return;
			}
			if (currentAmmo > 0) { // fires the weapon
			
		
				if (fireRate == 0) {
					if (Input.GetKeyDown (KeyCode.Mouse0)) {
						Shoot ();
                        //anim.SetTrigger("Attacking");
                        
                        
                    }
				} else {
					if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeToFire) {//fires
                
						timeToFire = Time.time + 1 / fireRate;
						Shoot ();
                        anim.SetTrigger("Attacking");

                    }
                    
                }
               
            }
		}
		
	}
	IEnumerator Reload()//Reloads the weapon 
	{
        if (currentMagAmmo > 0)//checks if there is ammo
        {
                isReloading = true;
                Debug.Log("Reloading");
                if (currentMagAmmo >= maxCurrentAmmo)
                { // sets the ammo to the max amount and changes the current ammo 
					currentMagAmmo = currentMagAmmo  + currentAmmo- maxCurrentAmmo ;
					currentAmmo = maxCurrentAmmo;
					
				} 
				else if (currentAmmo + currentMagAmmo > maxCurrentAmmo) { // sets the ammo to the max amount and changes the current ammo 
					currentMagAmmo = currentMagAmmo + currentAmmo - maxCurrentAmmo;
					currentAmmo = maxCurrentAmmo;
				}
                else
                { // sets the ammo to the max amount and changes the current ammo 
					currentAmmo = currentAmmo + currentMagAmmo;
					currentMagAmmo = 0;
				}
				
                yield return new WaitForSeconds(reloadTime);
                isReloading = false;
                SetAmmoLeftText(); // changes the UI 
                SetAmmoText();// Changes the UI 
        }
	}

    void Shoot() // shoots the weapon 
    {
		if (p.Paused == false) {

            


            currentAmmo--;
		SetAmmoText ();
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y); // creates a vector the mouse position 
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition,100,whatToHit);
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        
			if (hit.collider != null) { // checks if it hits an enemy and if it does it calls the Damage enemy function
				Enemy enemy = hit.collider.GetComponent<Enemy> ();
				if (enemy != null) {
					enemy.DamageEnemy (Damage);
				}
			}
        }

    }

    void Effect() // the effect that happens when you fire 
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform clone =Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        
        Destroy(clone.gameObject,0.02f);
    }
	void SetAmmoText() // ammo UI
	{
		AmmoText.text = currentAmmo.ToString();
	}
    void SetAmmoLeftText() // Ammo left UI
    {
        AmmoLeftText.text = "/" + currentMagAmmo.ToString();
    }
    public void MaxAmmo() // max Ammo UI 
    {
        currentAmmo = maxCurrentAmmo;
        currentMagAmmo = maxMagAmmo;
        SetAmmoText();
        SetAmmoLeftText();
        
    }
}
