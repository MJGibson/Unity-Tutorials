using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;

	private int count;




	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCounText ();
		winText.text = "";
	}

	// physics go in here
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
	

	void OnTriggerEnter(Collider other)
	{
		//Destroy(other.gameObject);

		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			++count;
			setCounText();
		}




	}

	void setCounText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You WIN!!!!";
		}

	}// end of setCounText


}
