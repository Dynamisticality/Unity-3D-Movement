using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Camera Camera;
    public float WalkSpeed;
    public float JumpPower;

    private Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>(); 
        WalkSpeed /= 10;
    }

    KeyCode[] KeyTable = new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};

    void LateUpdate()
    {
        //Camera
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //Movement
        float speed = Mathf.Abs(RB.velocity.x) + Mathf.Abs(RB.velocity.z);

        for (int i = 0; i < KeyTable.Length; i++) {
            if (Input.GetKey(KeyTable[i]) && speed < (WalkSpeed)) {
                switch (KeyTable[i]) {
                    case KeyCode.W:
                        RB.velocity += new Vector3(0, 0, WalkSpeed);
                        break;
                    case KeyCode.A:
                        RB.velocity += new Vector3(-WalkSpeed, 0, 0);
                        break;
                    case KeyCode.S:
                        RB.velocity += new Vector3(0, 0, -WalkSpeed);
                        break;
                    case KeyCode.D:
                        RB.velocity += new Vector3(WalkSpeed, 0, 0);
                        break;

                    default: break;
                }
            }
        }
    }
}
