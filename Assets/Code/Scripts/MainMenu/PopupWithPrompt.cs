using System;
using System.Collections.Specialized;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public abstract class PopupWithPrompt : MonoBehaviour
{
    [SerializeField] private GameObject popupUI;
    [SerializeField] private GameObject toDisableUI;
    [SerializeField] private float transparencyAlpha = 0.1f;
    private bool active;
    private bool toggle;
    private bool yesKey;
    private bool noKey;

    public abstract void YesAction();
    public abstract void NoAction();

    // Setters
    public void setToggle(bool toggle) {
        this.toggle = toggle;
    }

    public void setYes(bool yesKey) {
        this.yesKey = yesKey;
    }

    public void setNo(bool noKey) {
        this.noKey = noKey;
    }

    // to put inside Update
    public void ToggleUI() {
        // Debug.Log("Active: " + active);

        if (!active && toggle) {
            Debug.Log("Popup now appears");
            active = true;
            toggle = false;
        }

        popupUI.SetActive(active);

        if (toDisableUI.TryGetComponent<CanvasGroup>(out var canvasGroup))
        {
            canvasGroup.alpha = active ? transparencyAlpha : 1f;
            canvasGroup.interactable = !active;
        }
        else
        {
            Debug.LogWarning("UI to disable lacks CanvasGroup!");
        }

        if (active) {
            if (yesKey) {
                YesAction();
                yesKey = false; // Reset after use
                active = false;   // Close after confirmation
            }

            if (noKey) {
                Debug.Log("Popup operation cancelled!");
                NoAction();
                noKey = false;
                active = false;
            }
        }
    }

    // Canvas changer
    public void GoToCanvas(GameObject aCanvas) {
        gameObject.SetActive(false);
        aCanvas.SetActive(true);
    }
}
