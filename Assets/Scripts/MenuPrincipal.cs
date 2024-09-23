using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
	[SerializeField] private string nomeDoLevelDeJogo;
	[SerializeField] private GameObject painelMenuInicial;
	[SerializeField] private GameObject painelOpcoes;

	public void Jogar()
	{
		SceneManager.LoadScene("Joguinho");
	}

	public void AbrirComoJogar()
	{
		painelMenuInicial.SetActive(false);
		painelOpcoes.SetActive(true);
	}

	public void FecharComoJogar()
	{
		painelMenuInicial.SetActive(true);
		painelOpcoes.SetActive(false);

	}

	public void SairJogo()
	{
		Debug.Log("Fechou Viu");
		Application.Quit();
	}

}
