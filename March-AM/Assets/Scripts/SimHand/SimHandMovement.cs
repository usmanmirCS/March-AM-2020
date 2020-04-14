using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMovement : MonoBehaviour
{
    public float m_moveSpeed = 3;
    public float m_turnSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        #region Translation
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * m_moveSpeed * Time.deltaTime);
        }
        #endregion

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"), Space.World);
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y"));
    }
}
