using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;

    private bool isDigging = false;
    private Vector2Int dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputMove();
        InputDig();
    }

    void InputMove()
    {

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            dir.y = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            dir.y = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir.x = 0;
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.x = 0;
            dir.y = -1;
        }

        player.SetDir(dir);

        if (isDigging)
        {
            player.Highlight(false);
        }
        else
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            player.transform.position = player.transform.position + movement * Time.deltaTime * player.movementSpeed;
            if (movement.magnitude > 1.0f)
                movement.Normalize();
        }
    }

    void InputDig()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.Highlight(isDigging);
            isDigging = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.Dig();
            isDigging = false;
        }
    }
}
