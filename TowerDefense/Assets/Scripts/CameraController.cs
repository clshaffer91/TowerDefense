using UnityEngine;

namespace TowerDefense.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Movement Properties")]
        private bool cameraMovementEnabled = true;
        private float panSpeed = 30f;
        private float panBorderThickness = 10f;

        [Header("Camera Zoom Properties")]
        private float scrollSpeed = 5f;
        private int scrollAmplifier = 1000; //cause scrolls are small

        [Header("Camera Rotation Properties")]
        private float rotateSpeed = 10f;

        [Header("Camera Movement Limiting Properties")]
        private static float gameboardOffset = 40f;
        private float minX = 0f - gameboardOffset;
        private float maxX = 68f + gameboardOffset;
        private float minY = 10f;
        private float maxY = 80f;
        private float minZ = 0f - gameboardOffset;
        private float maxZ = 68f + gameboardOffset;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            MoveCameraPlayerInput();
            RotateCameraPlayerInput();
            ZoomCameraPlayerInput();
        }

        private void MoveCameraPlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                cameraMovementEnabled = !cameraMovementEnabled;
            if (!cameraMovementEnabled)
                return;
            if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) && transform.position.z < maxZ)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            else if ((Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) && transform.position.z > minZ)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            else if ((Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) && transform.position.x > minX)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
            else if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) && transform.position.x < maxX)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
        }

        private void RotateCameraPlayerInput()  //TODO: resolve the fake 90 degree behavior & resolve the mouse input rotation
        {
            if (Input.GetKey("q"))
            {
                transform.Rotate(new Vector3(0, -90, 0) * rotateSpeed * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey("e"))
            {
                transform.Rotate(new Vector3(0, 90, 0) * rotateSpeed * Time.deltaTime, Space.World);
            }
        }

        private void ZoomCameraPlayerInput()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            Vector3 position = transform.position;
            position.y -= scroll * scrollAmplifier * scrollSpeed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, minY, maxY);

            transform.position = position;
        }
    }
}