using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeGesture : MonoBehaviour
{
    public RectTransform objetivo;
    public RectTransform PosicionContenedor;

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    bool derecha=false;
    bool izquierda=false;

    void Start() {

    }


    void Update()
    {
        if (izquierda)
        {
            Vector3 targetPosition = objetivo.transform.position;
            PosicionContenedor.transform.position = Vector3.SmoothDamp(PosicionContenedor.transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if (derecha) {
            Vector3 targetPosition = new Vector3(0, 0, 0);
            PosicionContenedor.localPosition = Vector3.SmoothDamp(PosicionContenedor.localPosition, targetPosition, ref velocity, smoothTime);

        }
            
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe
                        {
                            Debug.Log("UP");
                        }

                        //Jump ();

                        else if (swipeValue < 0)//down swipe
                        {
                            Debug.Log("DOWN");
                        }

                            //Shrink ();

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)//right swipe
                        {
                            MoveRight();
                        }

                        //MoveRight ();

                        else if (swipeValue < 0 && PosicionContenedor.transform!=objetivo.transform)//left swipe
                        {
                           MoveLeft();
                        }
                            //MoveLeft ();

                    }
                    break;
            }
        }
    }


    public void MoveLeft() {
     
            Debug.Log("L");
            izquierda = true;
            derecha = false;
    }

    public void MoveRight()
    {

            Debug.Log("R");
            izquierda = false;
            derecha = true;
    }

   public void ReturnToStart() {
      SceneManager.LoadScene("StrartScene");
    }
}