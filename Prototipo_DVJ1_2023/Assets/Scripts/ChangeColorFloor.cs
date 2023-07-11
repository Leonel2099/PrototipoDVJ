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
        for (int x = 0; x < columns; x += 6)
        {
            for (int y = 0; y < rows; y += 6)
            {
                switch (gameObject.name)
                {
                    case "piso 18 48":
                    case "piso 24 0":
                    case "piso 24 6":
                    case "piso 24 12":
                    case "piso 30 12":
                    case "piso 36 12":
                    case "piso 36 18":
                    case "piso 36 24":
                    case "piso 30 24":
                    case "piso 30 30":
                    case "piso 30 36":
                    case "piso 30 48":
                    case "piso 30 42":
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
