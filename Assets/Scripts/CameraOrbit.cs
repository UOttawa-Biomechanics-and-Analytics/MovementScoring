using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{

    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation = new Vector3(50f, 20f, 0f);
    protected float _CameraDistance = 6f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    private Vector3 lastPosition;
    public float PanSensitivity = 0.5f;

    void Start()
    {
        this.transform.position = new Vector3(0f, 0f, -6f);
        this.transform.parent.rotation = Quaternion.Euler(27f, 62f, 0f);
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }

    public void ResetCamera()
    {
        this.transform.position = new Vector3(0f, 0f, -6f);
        this.transform.parent.rotation = Quaternion.Euler(27f, 62f, 0f);
        _LocalRotation = new Vector3(50f, 20f, 0f);
        _CameraDistance = 6f;
        lastPosition = new Vector3(0f, 0f, 0f);
        this._XForm_Camera.localPosition = new Vector3(0f, 0f, -6f);
    }




    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetMouseButton(0))
            {
                //Rotation of the Camera based on Mouse Coordinates
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                    _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                    //Clamp the y Rotation to horizon and not flipping over at the top
                    if (_LocalRotation.y < 0f)
                        _LocalRotation.y = 0f;
                    else if (_LocalRotation.y > 90f)
                        _LocalRotation.y = 90f;
                }
            }
            //Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

                ScrollAmount *= (this._CameraDistance * 0.3f);

                this._CameraDistance += ScrollAmount * -1f;

                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
            }

            //Panning of the Camera based on the Mouse Coordinates while the Mouse middle-button is held down
            if (Input.GetMouseButtonDown(2))
            {
                lastPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(2))
            {
                Vector3 delta = Input.mousePosition - lastPosition;
                Vector3 deltaxy = new Vector3(delta.x, 0f, delta.y);
                transform.position = Vector3.Lerp(transform.position, transform.position + deltaxy, PanSensitivity * Time.deltaTime);
                lastPosition = Input.mousePosition;
            }

        }

        //Camera reset
        if (Input.GetKey(KeyCode.R))
        {
            ResetCamera();
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(this._XForm_Camera.localPosition.x, this._XForm_Camera.localPosition.y, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }
    }
}