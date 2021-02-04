using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runningSpeed = 3;
    [SerializeField] float jumpingSpeed = 5;
    private bool running = false;
    private bool climbing = false;
    private float xScaleFactor; // for the facing direction of the player, 1 is right, -1 is left

    // Start is called before the first frame update
    void Start()
    {
        xScaleFactor = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxisInput = Input.GetAxis("Horizontal");
        if (horizontalAxisInput * xScaleFactor < 0) {
            ChangeFacingDirection();
        }
        if (horizontalAxisInput == 0) {
            Stop();
        } else {
            MoveHorizontally();
        }
    }

    public bool IsRunning() {
        return running;
    }

    public void SetRunning(bool running) {
        this.running = running;
    }

    public bool IsClimbing() {
        return climbing;
    }

    
    public void SetClimbing(bool climbing) {
        this.climbing  = climbing;
    }
        
    public void ChangeFacingDirection() {
        xScaleFactor = -xScaleFactor;
        transform.localScale = new Vector3(xScaleFactor, transform.localScale.y, transform.localScale.z);
    }

    public void Stop() {
        GetComponent<Animator>().SetBool("Running", false);
    }

    public void MoveHorizontally() {
        GetComponent<Animator>().SetBool("Running", true);
        float newX = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * runningSpeed;
        transform.position = new Vector2(newX, transform.position.y);
    }
}
