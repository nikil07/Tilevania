using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScoll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0,scrollSpeed * Time.deltaTime));
    }
}
