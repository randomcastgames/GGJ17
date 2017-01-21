using UnityEngine;
using System.Collections;

/// <summary>
/// Destrói um objeto X segundos após ele ser ativado na cena
/// </summary>
public class DestroyAfter : MonoBehaviour {

	/// <summary>
	/// Tempo que iremos esperar até que o objeto seja destruido
	/// </summary>
	public float time;

	/// <summary>
	/// Função chamada quando o objeto é ativo na cena
	/// </summary>
	void OnEnable () {
		StartCoroutine("DestroyObject");
	}


	/// <summary>
	/// Corrotina para destruir o objeto após X segundos
	/// </summary>
	/// <returns>The object.</returns>
	IEnumerator DestroyObject()
	{
		yield return new WaitForSeconds(time);
        print("Destroying");
		Destroy(gameObject);
	}

}
