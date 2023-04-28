using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WristUI : MonoBehaviour
{

    public InputActionAsset inputActions;

    public Canvas _wristCanvas;
    public InputAction _menu;
    // Start is called before the first frame update
    void Start()
    {
        _wristCanvas = GetComponent<Canvas>();
        _menu = inputActions.FindActionMap("XRI LeftHand Interaction").FindAction("Menu");
        _menu.Enable();
        _menu.performed += ToggleMenu;
        
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        _menu.performed += ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        _wristCanvas.enabled = !_wristCanvas.enabled;
    }
}
