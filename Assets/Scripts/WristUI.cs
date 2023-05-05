using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WristUI : MonoBehaviour
{

    public InputActionAsset inputActions;

    public Canvas _wristCanvas;
    public Canvas _wristCanvas2;
    public InputAction _menu;
    // Start is called before the first frame update
    void Start()
    {
        _wristCanvas2.enabled = false;
    }

    public void uiPress(){
        _wristCanvas.enabled = !_wristCanvas.enabled;
        _wristCanvas2.enabled = !_wristCanvas2.enabled;
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        _menu.performed += ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        _wristCanvas.enabled = !_wristCanvas.enabled;
        _wristCanvas2.enabled = !_wristCanvas2.enabled;
    }
}
