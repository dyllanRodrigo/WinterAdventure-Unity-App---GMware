using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSwipe : MonoBehaviour{
    public RectTransform objetivoDerecha;
    public RectTransform objetivoIzquierda;
    public RectTransform Origen;
    public RectTransform PosicionContenedor;

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    bool derecha = false;
    bool izquierda = false;
    bool regresarAMenu = false;

    void Update()
    {
        if (izquierda)
        {
            Vector3 targetPosition = objetivoDerecha.transform.position;
            PosicionContenedor.transform.position = Vector3.SmoothDamp(PosicionContenedor.transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if (derecha)
        {
            Vector3 targetPosition = objetivoIzquierda.transform.position;
            PosicionContenedor.transform.position = Vector3.SmoothDamp(PosicionContenedor.transform.position, targetPosition, ref velocity, smoothTime);

        }
        else if (regresarAMenu) {
            Vector3 targetPosition = Origen.transform.position;
            PosicionContenedor.transform.position = Vector3.SmoothDamp(PosicionContenedor.transform.position, targetPosition, ref velocity, smoothTime);
        }

    }


    public void MoveLeft()
    {

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

    public void ToOrigin()
    {
        regresarAMenu = true;
        derecha = false;
        izquierda = false;
    }
}
