using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movJugador : MonoBehaviour
{
    [SerializeField]
    private string estadoPlayer = "mi estado";
    public float velHDaniaGomez = 5.0f;
    public float velVDaniaGomez = 6.0f;

    public int vidaJugadorDania = 3;

    public float movHDaniaGomez;
    public float movVDaniaGomez;
    [SerializeField]
    public bool disparoTriple = false;

    public GameObject disparoL;
    public GameObject disparoT;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimientoPersonajeDaniaGomez();

        disparoPersonaje();
    }


    void movimientoPersonajeDaniaGomez()
    {
        movHDaniaGomez = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velHDaniaGomez * movHDaniaGomez); //Movimiento de traslación 

        movVDaniaGomez = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * velVDaniaGomez * movVDaniaGomez);

        //Restringir movimiento en escenario Horizontal
        if (transform.position.x >= 7.7f)
        {
            Debug.Log(transform.position.x);
            transform.position = new Vector3(7.7f, transform.position.y, -0.50f);
        }

        else if (transform.position.x <= -7.7f)
        {
            transform.position = new Vector3(-7.7f, transform.position.y, 0.50f);
        }

        //Restringir movimiento en escenario vertical
        if (transform.position.y >= 2f)
        {
            transform.position = new Vector3(transform.position.x, 2f, -0.50f);
        }

        else if (transform.position.y <= -1f)
        {
            transform.position = new Vector3(transform.position.x, -1f, -0.50f);
        }

    } 

    void disparoPersonaje()
    {
        //Disparo de una bala con la tecla espacio
        if (Input.GetKey(KeyCode.Space) && disparoTriple==false)
        {
            Instantiate(disparoL, transform.position + new Vector3(0, -0.05f, 0), Quaternion.identity);

        }
        //Disparo de tres balas con la tetra E
        else if (Input.GetKey(KeyCode.E))
        {
            Instantiate(disparoT, transform.position + new Vector3(1.264314f, 0.9243747f, 28.52615f), Quaternion.identity);

        }

        //Disparo triple con la letra T
        else if(disparoTriple == true && Input.GetKey(KeyCode.Space))
        {
            //Centro
            Instantiate(disparoL, transform.position + new Vector3(0.01f, 0.1f, 28.52615f), Quaternion.identity);
            //Izquierda
            Instantiate(disparoL, transform.position + new Vector3(-0.2f, 0.4003747f, 28.52615f), Quaternion.identity);
            //Derecha
            Instantiate(disparoL, transform.position + new Vector3(0.2f, 0.4003747f, 28.52615f), Quaternion.identity);

        } 
            
        }

    public void disparoTOn()
    {
        disparoTriple = true;
        StartCoroutine(disparoTUP());
    }

    IEnumerator disparoTUP()
    {
        yield return new WaitForSeconds(5.0f);
        disparoTriple = false;
    }

    //Aumento de velocidad en el movimiento vertical de la nave
    public void velocidadAumentada()
    {
        velVDaniaGomez = 10.0f;
        StartCoroutine(velAumentoDesactivado());
    }

    IEnumerator velAumentoDesactivado()
    {
        yield return new WaitForSeconds(10.0f);
        velVDaniaGomez = 4.0f;
    }


}