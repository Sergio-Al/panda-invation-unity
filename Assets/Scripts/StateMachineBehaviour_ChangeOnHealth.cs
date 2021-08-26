using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StateMachineBehaviour_ChangeOnHealth : StateMachineBehaviour
{
    private PandaScript pandaScriptRefernce;
    private float capturedHealth;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        Debug.Log("first!");
        pandaScriptRefernce = FindObjectOfType<PandaScript>();
        if (pandaScriptRefernce != null)
        {
            capturedHealth = pandaScriptRefernce.health;
        }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        if (pandaScriptRefernce == null)
        {
            return;
        }
        if (capturedHealth != pandaScriptRefernce.health)
        {
            if (pandaScriptRefernce.health <= 0)
            {
                animator.SetTrigger("DieTrigger");
                return;
            }
            capturedHealth = pandaScriptRefernce.health;
            animator.SetTrigger("HitTrigger");
        }

    }

}
