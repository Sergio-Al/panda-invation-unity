using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBehaviour_DestroyOnExit : StateMachineBehaviour
{
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        Debug.Log(animator.speed);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
