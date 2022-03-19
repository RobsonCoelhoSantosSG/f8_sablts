using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] CanvasGroup canvas;
    [SerializeField] bool StartHidden;
    bool isVisible;

    private void Start() {
        if (StartHidden) {
            HideWindow();
        }
    }

    public void ToggleWindow() {
        if (isVisible) {
            HideWindow();
            return;
        }
        ShowWindow();
    }

    public void ShowWindow() {
        canvas.alpha = 1;
        isVisible = true;
    }

    public void HideWindow() {
        canvas.alpha = 0;
        isVisible = false;
    }
}
