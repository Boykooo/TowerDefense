using UnityEngine;
using System.Collections;

public class MapCameraController : MonoBehaviour
{

    public float speed = 500;
    private Camera curCamera;
    private float angleRotate;

    void Start()
    {

    }

    void Update()
    {
        curCamera = GetComponent<Camera>();
        angleRotate = curCamera.transform.rotation.eulerAngles.x; // запоминаем угол поворта
        curCamera.transform.Rotate(-angleRotate, 0, 0); // поворочиваем в ортогональное состояние

        KeyMove();
        //MouseMove();

        curCamera.transform.Rotate(angleRotate, 0, 0); // поворочиваем на прежний угол
    }

    private void KeyMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= gameObject.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= gameObject.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += gameObject.transform.right * speed * Time.deltaTime;
        }
    }

    private void MouseMove()
    {
        if (Input.mousePosition.x < 5)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.y < 5)
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if ((Screen.width - 5) < Input.mousePosition.x)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if ((Screen.height - 5) < Input.mousePosition.y)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }

    }
}
