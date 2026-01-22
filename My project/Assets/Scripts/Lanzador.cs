using UnityEngine;
using UnityEngine.InputSystem;

public class Lanzador : MonoBehaviour
{
    private Tablet controles;

    public float fuerzaDisparo = 100f;
    public float distanciaRay = 100f;

    private void Awake()
    {
        controles = new Tablet();
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.ShootingAction.Disparar.performed += JugadorDispara;
    }

    private void OnDisable()
    {
        controles.ShootingAction.Disparar.performed -= JugadorDispara;
        controles.Disable();
    }

    private void JugadorDispara(InputAction.CallbackContext context)
    {
        // Leer posición del toque/click
        Vector2 posPantalla = controles.ShootingAction.Posicion.ReadValue<Vector2>();
        Debug.Log("Click en pantalla: " + posPantalla);

        // Crear un rayo desde la cámara hacia ese punto
        Ray ray = Camera.main.ScreenPointToRay(posPantalla);

        Vector3 origen = ray.origin;
        Vector3 direccion = ray.direction;

        // Sacar esfera del pool
        GameObject esfera = EsferasPool.instance.PopObject();

        // Posicionar y orientar
        esfera.transform.position = origen;
        esfera.transform.rotation = Quaternion.LookRotation(direccion);

        // Disparar
        Rigidbody rb = esfera.GetComponent<Rigidbody>();
        rb.AddForce(direccion * fuerzaDisparo, ForceMode.Impulse);
    }
}

