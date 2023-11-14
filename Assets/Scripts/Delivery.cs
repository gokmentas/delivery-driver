using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool hasPackage;
    [SerializeField] float destroyDelay = 1.0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Sh*t!!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);
            
        }else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
} // class
