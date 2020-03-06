using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    //Es publico porque es la referencia del jugador que quiero seguir con la camara
    public GameObject player;

    //Con esto voy a saber la posicion de mi camara segun el jugador player.
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    // Es mejor usar LateUpdate porque garantiza que movera la posicion de la camara despues del jugador. Es lo recomendado.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
