using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Animator playerAnimator;
    float input_x = 0;
    float input_y = 0;
    public float speed = 2.5f;
    bool is_walking = false;

    void Start() {
        is_walking = false;
    }

    // Update is called once per frame
    void Update() {
        input_x = Input.GetAxisRaw("Horizontal");
	input_y = Input.GetAxisRaw("Vertical");
	is_walking = (input_x != 0 || input_y != 0);

	if (is_walking) {
		var move = new Vector3(input_x, input_y, 0).normalized;
		transform.position += move * speed * Time.deltaTime;
		playerAnimator.SetFloat("input_x", input_x);
		playerAnimator.SetFloat("input_y", input_y);
	}
	playerAnimator.SetBool("is_walking", is_walking);
    }
}
