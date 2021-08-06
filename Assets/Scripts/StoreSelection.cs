using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSelection : StateMachineBehaviour {
    private bool init = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger("index", -1);

        if (init) {
            StoreEvents.instructionEvent.AddListener((Dictionary<string, string> data) => {
                animator.SetInteger("index", int.Parse(data["ID"]));
            });

            StoreEvents.endEvent.AddListener(() => {
                animator.SetBool("end", true);
            });

            init = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       if (animator.GetBool("end")) {
           StoreEvents.bargainEvent.RemoveAllListeners();
           StoreEvents.loadEvent.RemoveAllListeners();
           StoreEvents.instructionEvent.RemoveAllListeners();
           StoreEvents.prologueEvent.RemoveAllListeners();
       }
    }
}
