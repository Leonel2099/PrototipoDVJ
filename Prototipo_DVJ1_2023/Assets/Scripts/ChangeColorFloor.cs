using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorFloor : MonoBehaviour
{
    [SerializeField] private int columns, rows;
    public Color cesped, defaultM;
    public BoxCollider colide;
    public BoxCollider colide2;
    void Start()
    {
        gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", defaultM);
        CheckPosFloor();
    }

    void Update()
    {
        
       
    }
    void CheckPosFloor()
    {
        for (int x = -2; x < columns; x += 2)
        {
            for (int y = 0; y < rows; y += 2)
            {
                switch (gameObject.name)
                {
                    case "piso 0 6":
                    case "piso 0 8":
                    case "piso 2 0":
                    case "piso 2 2":
                    case "piso 2 6":
                    case "piso 4 2":
                    case "piso 4 4":
                    case "piso 4 6":
                        colide.size=new Vector3(6f, 2, 6f);
                        gameObject.GetComponent<BoxCollider>().isTrigger = false;
                        break;
                    default:
                        colide.size = new Vector3(0, 0, 0);
                        colide2.size = new Vector3(0, 0, 0);
                        gameObject.GetComponent<BoxCollider>().isTrigger = true;
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Max" || collision.gameObject.name == "Rocky")
        {
            gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", cesped);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Max" || collision.gameObject.name == "Rocky")
        {
            StartCoroutine(DelayChangeColor());
        }
    }
    IEnumerator DelayChangeColor()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", defaultM);
    }
}
