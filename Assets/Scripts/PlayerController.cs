using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float velocidade;
	private int	count; 
	public TMP_Text countText;
	public TMP_Text winText;
	
	void Start () {
	rb = GetComponent<Rigidbody>();
	count = 0;
	SetCountText();
	winText.text = "";	
	}

	void SetCountText () {
		countText.text = "Esqueletos Explodidos : " + count.ToString();
		if (count >= 16) winText.text = "VOCÊ EXPLODIU TODOS OS ESQUELETOS!!";
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Esqueleto") 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	void Update () {
		float movimentoHorizontal = Input.GetAxis("Horizontal");
		float movimentoVertical = Input.GetAxis("Vertical");
		Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
		rb.AddForce(movimento * velocidade);

	}
}