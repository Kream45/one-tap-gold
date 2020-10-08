using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float forceMultiplier;
    bool canLaunch = true;
    GameController gameController;
    public Text textForce;


    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && canLaunch)
            force += forceMultiplier * Time.deltaTime * 200;

        if (Input.GetMouseButtonUp(0) && canLaunch)
        {
            canLaunch = false;
            GetComponent<Rigidbody2D>().
                AddForce(Vector2.one * force);
        }
        textForce.text = "Force: " + Mathf.Round(force);
    }

    public void PrepareToLaunch()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        canLaunch = true;
        transform.position = new Vector3(-9, -2.25f, 0);
        force = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (canLaunch == true) return;

        var layerName = LayerMask.LayerToName(collision.collider.gameObject.layer);

        if (layerName == "Hole")
        {
            gameController.ballHit(true);
            return;
        }
        else
            gameController.ballHit(false);
    }
}


