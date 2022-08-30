using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Character : MonoBehaviour
{
    Rigidbody rb;

    PhotonView pw;

    public float Speed=10f;
    
    void Start()
    {   
     
        rb=GetComponent<Rigidbody>();
        pw=GetComponent<PhotonView>();


        if(pw.IsMine==true){
            GetComponent<Renderer>().material.color=Color.white;
            
            
        }

    }

    public void CheckPlayers(){
        if(PhotonNetwork.PlayerList.Length==2){
            
            CancelInvoke("CheckPlayers");
        }
    }

    // Update is called once per frame
    void Update()
    {   
          
        if(PhotonNetwork.IsMasterClient){
                        
                InvokeRepeating("CheckPlayers",0,0.5f);
            }
      
      if(pw.IsMine==true){
        Movement();
      }


    }

    void Movement(){
        Vector3 newVector=new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity=newVector*Time.deltaTime*Speed;
        transform.position+=moveVelocity;
    }
}

