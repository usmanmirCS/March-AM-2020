﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimShoot : MonoBehaviour
{
    public GameObject m_prefabFireball;
    public float m_shootForce;
    public ShotCounter m_ssScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject fireball;
            fireball = Instantiate(m_prefabFireball, transform.position, transform.rotation);
            fireball.GetComponent<Rigidbody>().AddForce(transform.forward * m_shootForce);
            Destroy(fireball, 5);
            m_ssScript.m_count++;
        }
    }
}
