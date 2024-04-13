using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float moveZ;
    private float moveX;
    public float speed;

    public Animator animController;

    public bool aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0, moveZ);
        Vector3 rotationDir = new Vector3(0, moveX, 0);

        
        if (aim)
        {
            transform.Rotate(rotationDir,Space.World);
        }
        else
        {
            controller.Move(moveDir * (speed * Time.deltaTime));
            if (moveDir != Vector3.zero)
            {
                gameObject.transform.forward = moveDir;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animController.SetBool("IsRun", true);
            speed = 5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animController.SetBool("IsRun", false);
            speed = 3f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            aim = true;
            animController.SetBool("Aim", true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StartCoroutine(Walkink());
            animController.SetBool("Aim", false);
        }
        if(Input.GetKeyDown(KeyCode.Mouse2))animController.SetTrigger("Shoot");
        
        
        if (moveX != 0 || moveZ != 0)
        {
            animController.SetBool("IsWalk", true);
        }
        else
        {
            animController.SetBool("IsWalk", false);
        }
    }

    public IEnumerator Walkink()
    {
        yield return new WaitForSeconds(1f);
        aim = false;
    }
}
