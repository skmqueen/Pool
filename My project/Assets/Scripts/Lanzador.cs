using UnityEngine;
using UnityEngine.InputSystem;

public class Lanzador : MonoBehaviour
{
    private Tablet controles;
    private GameObject tiro;
    private float alcance = 100f;
    public float fuerzaDisparo = 100f;
    public GameObject pelota;
    public float tiempoTranscurrido; 
    public float tiempoPelota = 10f;
    private void Awake()
    {
        controles = new Tablet();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.ShootingAction.Disparar.performed += JugadorDispara;
    }

    private void OnDisable()
    {
        controles.Disable();
        controles.ShootingAction.Disparar.performed += JugadorDispara;
    }

    void JugadorDispara(InputAction.CallbackContext context)
    {
        
        Vector2 positionClick = controles.ShootingAction.Posicion.ReadValue<Vector2>();
        Debug.Log("pinga" + positionClick);
        Vector3 puntoOrigen = Camera.main.ScreenToWorldPoint(positionClick);
        Vector3 puntoDestino = Camera.main.ScreenToWorldPoint(new Vector3(positionClick.x, positionClick.y, alcance));

        Vector3 direccion = (puntoDestino - puntoOrigen).normalized;

        GameObject pelotaDisparo = EsferasPool.instance.PopObject();

        pelotaDisparo.transform.rotation = Quaternion.LookRotation(direccion);
        pelotaDisparo.transform.position = puntoOrigen;
        pelotaDisparo.GetComponent<Rigidbody>().AddForce(direccion * fuerzaDisparo, ForceMode.Impulse);



    }
 
}
