using Unity.AppUI.Core;
using UnityEngine;

public class ParentLoop : MonoBehaviour
{
    Transform[] childTransforms;
    private Loop.State TestState;
    bool activeNow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        childTransforms = GetComponentsInChildren<Transform>(true);
        switch (gameObject.name)
        {
            case "Loop1":
                TestState = Loop.State.One;
                break;
            case "Loop2":
                TestState = Loop.State.Two;
                break;
            case "Loop3":
                TestState = Loop.State.Three;
                break;
            case "Loop4":
                TestState = Loop.State.Four;
                break;
            case "Loop5":
                TestState = Loop.State.Five;
                break;
        }
    }
    void Apply(Loop.State s)
    {
        activeNow = (s == TestState);
        for (int i = 1; i < childTransforms.Length; i++)
            if (childTransforms[i]) childTransforms[i].gameObject.SetActive(activeNow);
    }
    void OnEnable()
    {
        LoopScript.OnLoopChanged += Apply;      // subscribe ONCE
        Apply(LoopScript.CurrentState);         // apply immediately to current state
    }

    void OnDisable()
    {
        LoopScript.OnLoopChanged -= Apply;      // always unsubscribe
    }
}

