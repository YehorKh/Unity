using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject gm;
    private Player _actionTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm = GameObject.Find("/Player/Capsule");
            _actionTarget = gm.GetComponent<Player>();
            _actionTarget.ReactToHit();
            Destroy(this);
        }
    }
}
