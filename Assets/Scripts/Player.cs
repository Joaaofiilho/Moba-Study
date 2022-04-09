using UnityEngine;

public class Player : Movable
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    override protected void Update()
    {
        base.Update();
        animator.SetBool("isRunning", destination != null);
    }
}
