using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    // Variable para controlar la velocidad de la bola.
    // Es publica porque queremos que se controle desde el juego (afuera del codigo) pero haga cambios en el codigo.
    // Hacerla publica hace que podamos cambiar su valor directamente desde unity como lo hacemos con un componente. Los componentes tambien son scripts.
    public float speed;

    public Text countText;

    public Text winText;

    public Vector3 lastVelocity = Vector3.zero;

    //Variable para controlar el componente de objetos rigidos.
    private Rigidbody rb;

    //Variable para contar cuantos pick ups hemos borrado.
    private int count;

    private int winCount;

    /// <summary>
    /// Update es utilizado antes de renderizar cualquier frame.
    /// Es una funcion usada en el juego.
    /// Aqui utilizaremos los movimientos del jugador
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Al empezar el primer frame necesitamos CONSTRUIR nuestro componente Rigidbody.
    /// Start por ahora lo veo como el constructor en java o dart.
    /// </summary>
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        winCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
    }

    /// <summary>
    /// Fixed Update es usao para mejorar calculos fisicos.
    /// Por ejemplo, para hacer algo con el componente Rigidbody, lo haremos aqui.
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        /// <summary>
        /// Usaremos una version simple de Rigidbody.addForce dando los valores por default.
        /// AddForce usa un vector para moverse, el vual debemos definir.
        /// x es moveHorizontal para movernos en x.
        /// y es 0 porque no necesitamos saltar o agacharnos en lo absoluto.
        /// z es moveVertical para movernos en y.
        /// </summary>

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        lastVelocity = rb.velocity;
    }

    /// <summary>
    /// Funciona para detectar otros gameObjects cuando interactuan con mi jugador.
    /// </summary>
    /// <param name="other"> Pick Up que quiero leer.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= winCount)
        {
            winText.text = "Ganaste!";
        }
    }
}
