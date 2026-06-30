using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Você colidiu com o inimigo seu viadinho!");
            // Adicione aqui a lógica de dano ou destruição
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
