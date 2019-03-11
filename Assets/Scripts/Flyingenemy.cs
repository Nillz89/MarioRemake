using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyingenemy : Enemy {

    public float horizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;

    private Vector3 tempPosition;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        tempPosition = transform.position;
	}
	
	// Update is called once per frame
	public override void Move ()
    {

        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x, tempPosition.y, transform.position.z);

        base.Move();
	}
}
