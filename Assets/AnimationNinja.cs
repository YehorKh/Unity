using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNinja : MonoBehaviour
{
    [SerializeField] private Animator animator;
    bool isDead = false;
    int hp = 3;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Die()
    {
        hp--;
        if(hp == 0 )
        {
            isDead = true;

        }
    }
    void Update()
    {
        if (Random.Range(0, 10) != 1)
        {
            animator.SetBool("IsWalking", true);

        }
        else
        {
            animator.SetBool("IsWalking", false);

        }
        if(isDead)
        {
            animator.SetBool("IsDead", true);
        }
    }
}
