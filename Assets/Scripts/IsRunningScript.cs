using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the 'W' key is pressed to start running
        bool isRunning = Input.GetKey(KeyCode.W); // Returns true if the W key is held down

        // Set the 'isRunning' parameter in the Animator to match the state of the key press
        animator.SetBool("isRunning", isRunning);
    }
}
