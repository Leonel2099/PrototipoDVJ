using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matriz : MonoBehaviour
{
    [SerializeField] private int columns, rows;
    [SerializeField] private GameObject floor;
    void Start()
    {
        GenerateFloor();
        
    }

    void GenerateFloor()
    {
        for (int x =-2; x < columns; x+=2)
        {
            for(int y=0; y < rows; y+=2)
            {
                var spawnPiso = Instantiate(floor, new Vector3(x,0, y), Quaternion.identity);
                spawnPiso.name = $"piso {x} {y}";
            }
        }
    }
    
}
