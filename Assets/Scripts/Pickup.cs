using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject hand;

    private bool pickedUp;
    
    // Update is called once per frame
    void Update()
    {
        if(pickedUp == true)
        {
            this.transform.position = hand.transform.position; // sets the position of the object to your hand position
            this.transform.rotation = hand.transform.rotation; 
        }
    }

    private void OnMouseDown()
    {
        if(Vector3.Distance(this.transform.position, GameObject.Find("Body").transform.position) <= 2f)
        {
            pickedUp = true;
            GetComponent<Rigidbody>().useGravity = false;
            //this.transform.position = hand.transform.position; // sets the position of the object to your hand position
            this.transform.parent = GameObject.Find("Body").transform;
            this.transform.parent = GameObject.Find("hand").transform;
        }        
    }

    private void OnMouseUp()
    {
        pickedUp = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("cauldron"))
        {
            Destroy(this.gameObject);
        }
    }
}
