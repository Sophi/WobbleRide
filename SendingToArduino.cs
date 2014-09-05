using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
// this code is written in C#, Unity. It opens a port to send data through the serial port to an Arduino

public class SendingToArduino : MonoBehaviour {
	public MovementWithAccelerometer getMoveZ;
	public float passMoveZ;
	public static SerialPort sp = new SerialPort("COM3", 9600);
	public string message2;
	float timePassed = 0.0f;
	public string moveZString;

		void Start () {  // init
		// use GetComponent to access accelerometer data in MovementWithAccelerometer script
		getMoveZ = GetComponent<MovementWithAccelerometer> (); 
		OpenConnection(); // open serial port
	}
	
	// Update is called once per frame
	void Update () {
		passMoveZ = getMoveZ.ReportMoveZ ();
		moveZString = passMoveZ.ToString(); // convert to string to send it (necessary?) check this later)
		//Debug.Log (moveZString);
		sp.Write (moveZString); 			// send data as string
		//sp.Write(passMoveZ.ToString());   // send data as string
			}

	public void OpenConnection() 
    {
		if (sp != null) 
       {
         if (sp.IsOpen) 
         {
          sp.Close();
          print("Closing port, because it was already open!");
         }
         else 
         {
          sp.Open();  					 // opens the connection
          sp.ReadTimeout = 16;  		 // sets the timeout value before reporting error
	      print("Port Opened! Hooray!"); // message = "Port Opened!"
		
         }
       }
       else 
       {
         if (sp.IsOpen)
         {
          print("Port is already open");
         }
         else 
         {
          print("Port == null");
         }
       }
    }

    void OnApplicationQuit() 
    {
       sp.Close();
    }
}
 