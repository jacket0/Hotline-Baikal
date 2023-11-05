using UnityEngine;

public class PlayerRandomAttack : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("attackId", Random.Range(0, 2));
    }
}
