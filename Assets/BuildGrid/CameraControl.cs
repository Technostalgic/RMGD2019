using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD
{
    public class CameraControl : MonoBehaviour
    {
        /*
         * Camera control script for zooming and panning.
         * Matthew Evans, 09/27/2019
         */


        // Update is called once per frame
        void Update()
        {
            doCameraPan();
            doCameraZoom();
        }

        [SerializeField]
        float panSpeed = 0.001f;
        [SerializeField]
        int cameraButtonForPan = 1;
        [SerializeField]
        int cameraMaxX = 100;
        [SerializeField]
        int cameraMaxY = 100;
        Vector3 lastPosition;
        private void doCameraPan()
        {
            if (Input.GetMouseButtonDown(cameraButtonForPan))
                lastPosition = Input.mousePosition;
            if (Input.GetMouseButton(cameraButtonForPan))
            {
                float panSpeedModifier = -panSpeed * Camera.main.orthographicSize;
                Vector3 delta = Input.mousePosition - lastPosition;
                Camera.main.transform.Translate(delta.x * panSpeedModifier, delta.y * panSpeedModifier, 0);
                //is there any easy way to clamp the value of the camera position without doing this?
                Vector3 cameraPosition = Camera.main.transform.position;
                cameraPosition.x = Mathf.Clamp(cameraPosition.x, -cameraMaxX, cameraMaxX);
                cameraPosition.y = Mathf.Clamp(cameraPosition.y, -cameraMaxY, cameraMaxY);
                Camera.main.transform.position = cameraPosition;

                lastPosition = Input.mousePosition;
            }
        }
        [SerializeField]
        int zoomMin = 4;
        [SerializeField]
        int zoomMax = 100;
        [SerializeField]
        int zoomScale = 1;
        private void doCameraZoom()
        {
            //Do camera zooming
            float size = Camera.main.orthographicSize += Input.mouseScrollDelta.y;
            Camera.main.orthographicSize = Mathf.Clamp(size, zoomMin, zoomMax);
        }
    }

}
