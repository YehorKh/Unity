using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContoller : MonoBehaviour
{
    [SerializeField]GameObject target;

    private GameObject[] targets = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        for(int i = 0; i < targets.Length; ++i)
        {
            if (!targets[i])
            {
                targets[i] = Instantiate(target);
                targets[i].transform.position = new Vector3(Random.Range(-50, 50), 2.34F, Random.Range(-50, 50));
                targets[i].transform.Rotate(0, Random.Range(0, 360f), 0);
            }
        }
        /*if(currentTarget == null)
        {
            currentTarget = Instantiate(target);
            currentTarget.transform.position = new Vector3(Random.Range(-50, 50), 2.34F, Random.Range(-50, 50));
            currentTarget.transform.Rotate(0, Random.Range(0, 360f), 0);

        }*/
    }
}
