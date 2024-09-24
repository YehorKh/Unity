using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private float speed = 3.0F;
   [SerializeField] private float obstractRange = 5.0F;
    public Vector3 size;
    private MeshRenderer renderer;
     GameObject gm;
    private SceneContoller _actionTarget;

    private int hp;
    private bool dead;

    private float bulletTime = 1.0f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    void Start()
    {
        //_actionTarget = gm.GetComponent<SceneContoller>();
        gm = GameObject.Find("/Controller");
        _actionTarget = gm.GetComponent<SceneContoller>();
        renderer = GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        dead = false;
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            RaycastHit hit;
            float distance = 1.0f; 
            float heightOffset = 3.0f; 

            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z) + transform.forward * distance, transform.forward);
            if (Physics.SphereCast(ray, 0.75F, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Player player = hitObject.GetComponent<Player>();
                bulletTime -= Time.deltaTime;
                if (player && bulletTime <= 0)
                {
                    StartCoroutine(ShootBullet(ray));
                    bulletTime = 1.0f;
                }
                else
                {       
                    if (hit.distance < obstractRange)
                    {
                        transform.Rotate(0, Random.Range(-110, 110), 0);
                    }
                }
                
                
            }
        }
    }

    private IEnumerator ShootBullet(Ray ray)
    {
        GameObject bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = ray.direction * bulletSpeed;
        }

        yield return new WaitForSeconds(0.6F);
        Destroy(bullet);
    }
    public void ReactToHit()
    {
        hp--;
        if (hp == 0 && dead == false)
        {
            dead = true;
            _actionTarget.EnemyKilled();
            StartCoroutine(Die());
            DestroyObject();
        }
        
    }
    private void DestroyObject()
    {
        Destroy(gameObject, 3);
        

    }
    private IEnumerator Die()
    {
      
        this.transform.position = transform.position + new Vector3(0, -size.y/2, 0);

        yield return new WaitForSeconds(2.0F);
    }
}
