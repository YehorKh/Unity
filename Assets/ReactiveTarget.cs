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
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.SphereCast(ray, 0.75F, out hit))
            {
                if(hit.distance < obstractRange)
                {
                    transform.Rotate(0, Random.Range(-110, 110), 0);
                }
            }
        }
    } 

    public void Shoot()
    {

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
