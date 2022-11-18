using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{

    Collider[] colliders;
    [SerializeField] private float attraction_force_constant;
    [SerializeField] private float repel_force_constant;
    [SerializeField] private float time_scale;
    [SerializeField] private float radius;



    // Update is called once per frame
    void FixedUpdate()
    {
        Time.timeScale = time_scale;
        colliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach(Collider c in colliders)
        {
            if (c.gameObject != gameObject)
            {
                Rigidbody rb1 = gameObject.GetComponent<Rigidbody>();
                Rigidbody rb2 = c.gameObject.GetComponent<Rigidbody>();

                float m1 = rb1.mass;
                float m2 = rb2.mass;

                Vector3 vector = rb1.position - rb2.position;
                Vector3 norm_direction = Vector3.Normalize(vector);
                float mag = Vector3.Magnitude(vector);


                //Attraction Force
                Vector3 force_attraction = attraction_force_constant*m1*m2*norm_direction / (mag * mag);
                Vector3 force_repel = repel_force_constant * m1 * m2 * norm_direction / (mag * mag * mag);


                Vector3 force = force_attraction + force_repel;
                rb1.AddForce(force, ForceMode.VelocityChange);
            }
        }
        
    }
    
}
