using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private float animationTimer;
    private float timeBetweenAnimations;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timeBetweenAnimations = Random.Range(4, 9);
    }

    private void Update()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer >= timeBetweenAnimations)
        {
            animationTimer = 0;
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        animator.SetBool("WatchClock", true);
    }

    private void DeactivateAnimation()
    {
        animator.SetBool("WatchClock", false);
    }
}
