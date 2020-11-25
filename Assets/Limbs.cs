using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limbs : MonoBehaviour
{

    public GameObject limbPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        Limbs childLimb = transform.GetChild(0).GetComponentInChildren<Limbs>();
        if (childLimb)
            childLimb.Hit();

        transform.localScale = Vector3.zero;

        GameObject spawnLimb = Instantiate(limbPrefab, transform.parent);
        spawnLimb.transform.parent = null;
        Destroy(spawnLimb, 10);
        Destroy(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
            Hit();
    }
}
