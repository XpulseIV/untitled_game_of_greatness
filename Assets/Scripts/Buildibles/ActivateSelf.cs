using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSelf : MonoBehaviour
{
    public string objectTag = "Traps";  // The tag to look for
    public float activationRange = 2f;  // The range at which the trap can be activated
    public bool isActivated = false;  // The activation state of the trap
    public GameObject[] linkedTraps;  // Other traps linked to this one

    private void Update()
    {
        // Check if the trap is activated
        if (isActivated)
        {
            // Set the tag to "ActivatedTrap"
            gameObject.tag = "ActivatedTrap";

            // Activate linked traps
            foreach (GameObject trap in linkedTraps)
            {
                trap.GetComponent<ActivateSelf>().isActivated = true;
            }
        }
        else
        {
            // Set the tag to "Trap"
            gameObject.tag = "Traps";

            // Deactivate linked traps
            foreach (GameObject trap in linkedTraps)
            {
                trap.GetComponent<ActivateSelf>().isActivated = false;
            }
        }
    }
}
