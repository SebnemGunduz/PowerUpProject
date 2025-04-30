using UnityEngine;

public class PlaneSelect : MonoBehaviour
{
    private Animator animator;
    private bool hasStarted = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Oyunun ba�lad���n� varsay�yoruz (buraya �zel bir kontrol gerekiyorsa eklenebilir)
        if (!hasStarted) hasStarted = true;

        if (hasStarted && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Select");
        }
    }
}
