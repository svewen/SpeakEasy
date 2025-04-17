using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public MonoBehaviour movementScript;
    public MonoBehaviour mouseScript;
    private bool isFrozen = false;

    public void Freeze()
    {
        isFrozen = true;
        movementScript.enabled = false;
        mouseScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnfreezePlayer()
    {
        isFrozen = false;
        movementScript.enabled = true;
        mouseScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
