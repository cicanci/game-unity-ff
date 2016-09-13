using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Playground
{
    public enum UIType
    {
        UICanvas, UIObject, None
    }

    public class TestInventory : MonoBehaviour
    {
        [Range(0, 100)]
        public float movementSpeed = 0;
        public UIType type = UIType.None;
        public bool inverted = false;

        void Update()
        {
            Vector3 position = Vector3.zero;

            if (Input.GetAxis("Mouse X") < 0)
            {
                //print("Mouse moved left");
                position = ((inverted) ? Vector3.right : Vector3.left) * Time.deltaTime * movementSpeed;
            }

            if (Input.GetAxis("Mouse X") > 0)
            {
                //print("Mouse moved right");
                position = ((inverted) ? Vector3.left : Vector3.right) * Time.deltaTime * movementSpeed;
            }

            if (Input.GetAxis("Mouse Y") < 0)
            {
                //print("Mouse moved down");
                position = ((inverted) ? Vector3.up : Vector3.down) * Time.deltaTime * movementSpeed;
            }

            if (Input.GetAxis("Mouse Y") > 0)
            {
                //print("Mouse moved up");
                position = ((inverted) ? Vector3.down : Vector3.up) * Time.deltaTime * movementSpeed;
            }

            switch (type)
            {
                case UIType.UICanvas:
                    gameObject.GetComponent<RectTransform>().localPosition += position;
                    break;
                case UIType.UIObject:
                    gameObject.transform.localPosition += position;
                    break;
                case UIType.None:
                    Debug.LogWarning("No UIType set for " + gameObject.name);
                    break;
                default:
                    break;
            }
        }
    }
}