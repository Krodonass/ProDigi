using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysBindings : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode walkForwardKey;
    public KeyCode walkBackwardKey;
    public KeyCode walkRightKey;
    public KeyCode walkLeftKey;
    public KeyCode jumpKey;
    public KeyCode sprintKey;
    public KeyCode crouchKey;

    [Header("Interaction")]
    public KeyCode grabKey;
}
