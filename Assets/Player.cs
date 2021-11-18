using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerUI playerUI;
    CustomAnimator customAnimator;
    Vector2 axis;
    public float walkSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        customAnimator = GetComponent<CustomAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.I)) {
            if (!playerUI.gameObject.activeInHierarchy) {
                playerUI.gameObject.SetActive(true);
                playerUI.ShowPlayerUI(customAnimator.ThisChar.GetStandFrontSprites());
            } else {
                playerUI.gameObject.SetActive(false);
            }
        }

        if (axis.x != 0) {
            customAnimator.pose = Pose.walk;
            if (axis.x > 0)
                customAnimator.direction = Direction.right;
            else if (axis.x < 0)
                customAnimator.direction = Direction.left;
        } else if (axis.y != 0) {
            customAnimator.pose = Pose.walk;
            if (axis.y > 0)
                customAnimator.direction = Direction.back;
            else if (axis.y < 0)
                customAnimator.direction = Direction.front;
        } else {
            customAnimator.pose = Pose.idle;
        }
        //Vector3 pos = transform.position;
        transform.Translate(axis * walkSpeed * Time.deltaTime);
    }
}
