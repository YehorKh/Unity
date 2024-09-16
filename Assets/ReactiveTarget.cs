using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public Vector3 size;
    private MeshRenderer renderer;
    // Start is called before the first frame update
    private int hp;
    private bool dead;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        dead = false;
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReactToHit()
    {
        hp--;
        if (hp == 0 && dead == false)
        {
            dead = true;
            StartCoroutine(Die());
        }
        Debug.Log("Target Hit + " + hp);
        
    }
    private IEnumerator Die()
    {
      
        this.transform.position = transform.position + new Vector3(0, -size.y/2, 0);

        this.transform.Rotate(-90,0,0);
        yield return new WaitForSeconds(2.0F);
    }
}
