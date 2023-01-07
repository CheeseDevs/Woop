using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private bool _isRedRequired;
    [SerializeField] private bool _isGreenRequired;
    [SerializeField] private bool _isPurpleRequired;
    [SerializeField] private bool _isBlueRequired;


    public Transform doorModel;
    public GameObject colObject;

    public float openSpeed;

    private bool shouldOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldOpen && doorModel.position.z < 1f){
          doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime); 
          if(doorModel.position.z >= 1f){
              colObject.SetActive(false);
          }
        }
        else if(!shouldOpen && doorModel.position.z > 0f){
          doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime); 
          if(doorModel.position.z <= 0f){
              colObject.SetActive(true);
          }
        }



    }
    public void OnTriggerEnter2D(Collider2D other)
    {   Debug.Log("Triggered");    
        if (other.tag == "Player")
        {
            CheckKey();
         
        }

     
     }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
         
        }
     }

    private void CheckKey()
    {
        PlayerInventory hasKey = PlayerMovement.instance.GetComponent<PlayerInventory>();
        if (_isRedRequired)
        {
            if (hasKey.HasRedKey)
            {
                shouldOpen = true;
            }
        }
        else if (_isGreenRequired)
        {
            if (hasKey.HasGreenKey)
            {
                shouldOpen = true;
            }
        }
        else if (_isPurpleRequired)
        {
            if (hasKey.HasPurpleKey)
            {
                shouldOpen = true;
            }
        }
        else if (_isBlueRequired)
        {
            if (hasKey.HasBlueKey)
            {
                shouldOpen = true;
            }
        }
        else
        {
            shouldOpen = true;
        }
    }
}



