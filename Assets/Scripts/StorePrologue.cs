using UnityEngine;

public class StorePrologue : StateMachineBehaviour {
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (animator.GetBool("enableDialogue")) {
            StoreEvents.prologueEvent.Invoke();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        StoreEvents.loadEvent.Invoke();
    }
}
