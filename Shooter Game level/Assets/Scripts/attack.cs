using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

    public GameObject muzzleFlash;
    public float coolDown =0.02f;

	// Use this for initialization
	void Start () {
        muzzleFlash.SetActive(false);
	}
	
	// Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (Input.GetMouseButton(0) && coolDown <=0)
        {
            coolDown = 0.02f;
            Ray ray = new Ray(GetComponentInChildren<Camera>().transform.position, GetComponentInChildren<Camera>().transform.forward);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 100.0f))
            {
                Debug.Log(hitinfo.point);
            }
            if (hitinfo.collider)
            {
                GameObject GO = hitinfo.collider.gameObject;
                if (GO.GetComponent<Health>()) 
                {
                    GO.GetComponent<Health>().ReceiveDamage(50f);
                    if (GO.GetComponent<Health>().health <= 0)
                    {
                        Instantiate(GO.GetComponent<Health>().responseExplosion, hitinfo.point, Quaternion.identity);
                    }
                }
            }
            StartCoroutine("Flash");
        }
    }

    IEnumerator Flash() 
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        muzzleFlash.SetActive(false);
    }

}
