using UnityEngine;
using System.Collections;

namespace Playground
{
    public enum UIType
    {
        UICanvas,
        UIObject,
        None
    }

    public class TestInventory : MonoBehaviour
    {
        private float minMovementSpeed = 0.1f;

        public int horizontalSpeed = 0;
        public int verticalSpeed = 0;
        public UIType type = UIType.None;

        void Start()
        {
            Debug.LogWarning("Playground::TestInventory script is in use by " + gameObject.name);
        }

        void Update()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            if (Input.GetAxis ("Mouse X") < -minMovementSpeed) {
                if (type == UIType.UICanvas) {
                    if (gameObject.GetComponent<RectTransform> ().localPosition.x < 250) {
                        gameObject.GetComponent<RectTransform> ().Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
                    }
                } else if (type == UIType.UIObject) {
                    if (gameObject.transform.localPosition.x < 9) {
                        gameObject.transform.Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
                    }
                }
            }

            if (Input.GetAxis ("Mouse X") > minMovementSpeed) {
                if (type == UIType.UICanvas) {
                    if (gameObject.GetComponent<RectTransform> ().localPosition.x > -250) {
                        gameObject.GetComponent<RectTransform> ().Translate (Vector3.left * horizontalSpeed * Time.deltaTime);
                    }
                } else if (type == UIType.UIObject) {
                    if (gameObject.transform.localPosition.x > -9) {
                        gameObject.transform.Translate (Vector3.left * horizontalSpeed * Time.deltaTime);
                    }
                }
            }

            if (Input.GetAxis ("Mouse Y") < -minMovementSpeed) {
                if (type == UIType.UICanvas) {
                    if (gameObject.GetComponent<RectTransform> ().localPosition.y < 80) {
                        gameObject.GetComponent<RectTransform> ().Translate (Vector3.up * horizontalSpeed * Time.deltaTime);
                    }
                } else if (type == UIType.UIObject) {
                    if (gameObject.transform.localPosition.y < 3) {
                        gameObject.transform.Translate (Vector3.up * horizontalSpeed * Time.deltaTime);
                    }
                }
            }

            if (Input.GetAxis ("Mouse Y") > minMovementSpeed) {
                if (type == UIType.UICanvas) {
                    if (gameObject.GetComponent<RectTransform> ().localPosition.y > -80) {
                        gameObject.GetComponent<RectTransform> ().Translate (Vector3.down * horizontalSpeed * Time.deltaTime);
                    }
                } else if (type == UIType.UIObject) {
                    if (gameObject.transform.localPosition.y > -3) {
                        gameObject.transform.Translate (Vector3.down * horizontalSpeed * Time.deltaTime);
                    }
                }
            }
        }

        //void Update()
        //{
        //    if (Input.GetAxis("Mouse X") < 0)
        //    {
        //        StartCoroutine(moveObject(Vector3.left, Time.deltaTime * horizontalSpeed));
        //    }

        //    if (Input.GetAxis("Mouse X") > 0)
        //    {
        //        StartCoroutine(moveObject(Vector3.right, Time.deltaTime * horizontalSpeed));
        //    }

        //    if (Input.GetAxis("Mouse Y") < 0)
        //    {
        //        StartCoroutine(moveObject(((inverted) ? Vector3.up : Vector3.down), Time.deltaTime * verticalSpeed));
        //    }

        //    if (Input.GetAxis("Mouse Y") > 0)
        //    {
        //        StartCoroutine(moveObject(((inverted) ? Vector3.down : Vector3.up), Time.deltaTime * verticalSpeed));
        //    }
        //}

        //IEnumerator moveObject(Vector3 direction, float speed)
        //{
        //    Vector3 destination = Vector3.zero;

        //    switch (type)
        //    {
        //    case UIType.UICanvas:
        //        gameObject.GetComponent<RectTransform>().Translate(direction * speed);
        //        break;
        //    case UIType.UIObject:
        //        gameObject.transform.Translate(direction * speed);
        //        break;
        //    case UIType.None:
        //        Debug.LogWarning("No UIType set for " + gameObject.name);
        //        break;
        //    default:
        //        break;
        //    }

        //    yield return null;
        //}
    }
}