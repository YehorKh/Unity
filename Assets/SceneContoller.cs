using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContoller : MonoBehaviour
{
    [SerializeField]GameObject target;
    int score = 0;
    int hp;
    private GameObject[] targets = new GameObject[7];
    void Start()
    {

    }
    public void EnemyKilled()
    {
        Debug.Log("Hello: " + score);
        score += 100;
    }
    private void OnGUI()
    {
        int n = 128;
        float xxx = 5.0F;
        float yyy = 5.0F;
        GUI.Label(new Rect(xxx, yyy, n, n), score.ToString());
        


    }
    void Update()
    {
        for(int i = 0; i < targets.Length; ++i)
        {
            if (!targets[i])
            {
                targets[i] = Instantiate(target);
                targets[i].transform.position = new Vector3(Random.Range(-50, 50), 1.0F, Random.Range(-50, 50));
                targets[i].transform.Rotate(0, Random.Range(0, 360f), 0);
            }
        }
    }
}
