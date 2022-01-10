using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private float initialSpeed;
    private bool _isRunning;

    private Rigidbody2D rig;
    private Vector2 _direction;

    public Vector2 direction
    { 
        get { return _direction; } set { _direction = value; } 
    }

    public bool isRunning
    {
        get { return _isRunning; } set { _isRunning = value; }
    }


    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        onInput();
        onRun();
    }

    private void FixedUpdate()
    {
        onMovie();
    }

    #region Moviment
      
    void onInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void onMovie()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void onRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        } 
    }

    #endregion


}
