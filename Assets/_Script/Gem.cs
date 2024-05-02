using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float m_limit;
    private void Update()
    {
        if (transform.position.y <= -m_limit)
        {
            Destroy(this.gameObject);
        }
    }
}
