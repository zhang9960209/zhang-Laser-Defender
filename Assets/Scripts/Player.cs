using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float padL;
    [SerializeField] float padR;
    [SerializeField] float padU;
    [SerializeField] float padD;
    Vector2 initInput;
    Vector2 minBound;
    Vector2 maxBound;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        GenerateBoundary();
    }

    void Update()
    {
        Mov();
    }

    void GenerateBoundary()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Mov()
    {
        Vector2 delta = initInput * movSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + padL, maxBound.x - padR);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + padD, maxBound.y - padU);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        initInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
