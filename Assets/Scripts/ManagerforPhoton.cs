using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerforPhoton : MonoBehaviourPunCallbacks //Fonksiyonların kullanımı için
{


    private bool _created  =false;


    private void Start() {
    }
    private void Update() {
     
        
         if(Input.GetKeyDown(KeyCode.Escape)){
           Debug.Log("Cıkıs yaptınız");
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            if(PhotonNetwork.IsMasterClient){
            Debug.Log("Rye bastın");
           
            LoadGameScene();
            }
         }


        
    }
    public void Connect()
    {
        
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connection successful to Server");
       PhotonNetwork.JoinLobby();
        
        
        
    }

    public override void OnJoinedLobby()
    {
        
        
        
        Debug.Log("Connecting Lobby!");
        
        
        
        ConnectRoom();
        
    }
    
    public  void ConnectRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
       
       
       PhotonNetwork.JoinOrCreateRoom("New_Room",
        new RoomOptions
        {
            MaxPlayers=2,
            IsOpen=true,
            IsVisible=true
        },TypedLobby.Default);

    }
        
        
    public override void OnJoinedRoom(){  //odayı lobi oyunu da baska fonksiyonda hallet
       
        Debug.Log("Odaya girildi");
      
        
        CreatedCharacter();
    }
  

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
            PhotonNetwork.AutomaticallySyncScene=true;
       
    }
    
    public void CreatedCharacter(){
        GameObject Character=PhotonNetwork.Instantiate("Capsule",new Vector3(0,1,0),Quaternion.identity,0);
    }

   
   
    public void LoadGameScene(){
       
        

        Debug.Log("Start Game");
            PhotonNetwork.LoadLevel("GameScene");
            Invoke("CreatedCharacter",1);

            
        }
          
      
    



    public void Quit(){
        Application.Quit();
        
        
    }


}
       




