using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ///Reiniciar la escena con os valores predefinidos.
        SceneManager.LoadScene(0);
    }
}
