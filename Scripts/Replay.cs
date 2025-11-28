using JetBrains.Annotations;
using System.Threading;
using System.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Replay : MonoBehaviour
{
    Fila pos = new Fila(1000);

    bool ativar = false;
    int cont = 0;   

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10 * Time.deltaTime, transform.position.z);
            pos.entrar(transform.position.x, transform.position.y);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10 * Time.deltaTime, transform.position.z);
            pos.entrar(transform.position.x, transform.position.y);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
            pos.entrar(transform.position.x, transform.position.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 10 * Time.deltaTime, transform.position.y, transform.position.z);
            pos.entrar(transform.position.x, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ativar = true;
            cont = 0;           
        }

        if(ativar == true)
        {
             Debug.Log("Ativo");                        
             transform.position = new Vector3(pos.vetor[cont], pos.vetory[cont], 0);
             cont++;               
             Debug.Log(cont);

             if (cont >= pos.GetTamanhovetor())
             {
                ativar = false;
             }            
        }
    }
}

public class Fila
{
    public float[] vetor;
    public float[] vetory;

    int tamanhovetor = 0;

    public Fila(int size)
    {
        vetor = new float[size];
        vetory = new float[size];
    }

    public void entrar(float posicao, float posicaoy)
    {
        if (tamanhovetor < vetor.Length)
        {
            vetor[tamanhovetor] = posicao;
            vetory[tamanhovetor] = posicaoy;
            tamanhovetor++;
        }
        else
        {
            Debug.Log("vetor cheio");
            for (int i = 1; i < tamanhovetor; i++)
            {
                vetor[i - 1] = vetor[i];
                vetory[i - 1] = vetory[i];
            }
            tamanhovetor--;
        }
    }

     public int GetTamanhovetor()
    {
        return tamanhovetor;
    }
        
        





}