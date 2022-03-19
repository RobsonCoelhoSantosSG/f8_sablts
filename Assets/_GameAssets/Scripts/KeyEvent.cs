using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : CustomBehaviour
{
    [SerializeField] KeyCode Key;

    public UnityEvent OnKeyPress;
    public UnityEvent OnKeyRelease;

    public override void OnUpdate() {
        if(Input.GetKeyDown(Key)) {
            OnKeyPress.Invoke();
        }

        if (Input.GetKeyUp(Key)) {
            OnKeyRelease.Invoke();
        }
    }
}
