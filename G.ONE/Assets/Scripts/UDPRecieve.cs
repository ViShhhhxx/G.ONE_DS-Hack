using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;

public class UDPRecieve : MonoBehaviour
{
    Thread recievePositionThread, recieveJumpThread;
    UdpClient positionClient, jumpClient;
    public int positionPort, jumpPort;
    public bool startRecieve = true;
    public bool printToConsole = true;
    public string positionData;
    public string jumpData;

    // Start is called before the first frame update
    void Start()
    {
        recievePositionThread = new Thread(new ThreadStart(RecievePositionData));
        recievePositionThread.IsBackground = true;
        recievePositionThread.Start();

        recieveJumpThread = new Thread(new ThreadStart(RecieveJumpData));
        recieveJumpThread.IsBackground = true;
        recieveJumpThread.Start();

        startRecieve = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void RecievePositionData()
    {
        Debug.Log("started udp recieve");
        positionClient = new UdpClient(positionPort);
        while (startRecieve)
        {
            if (GameManager.Instance.StartRecieving)
            {
                try
                {
                    IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] dataByte = positionClient.Receive(ref anyIP);
                    positionData = Encoding.UTF8.GetString(dataByte);

                    GameManager.Instance.movement = positionData;

                    if (printToConsole)
                    {
                        Debug.Log("Recieved data from " + anyIP + ": " + positionData);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                }
            }
            if (GameManager.Instance.stopRecieving)
            {
                break;
            }
        }
    }

    private void RecieveJumpData()
    {
        Debug.Log("started udp recieve");
        jumpClient = new UdpClient(jumpPort);
        while (startRecieve)
        {
            if (GameManager.Instance.StartRecieving)
            {
                try
                {
                    IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] dataByte = jumpClient.Receive(ref anyIP);
                    jumpData = Encoding.UTF8.GetString(dataByte);

                    GameManager.Instance.jumpData = jumpData;

                    if (printToConsole)
                    {
                        Debug.Log("Recieved data from " + anyIP + ": " + jumpData);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                }
            }
            if (GameManager.Instance.stopRecieving)
            {
                break;
            }
        }
    }

    void OnDisable(){
        recievePositionThread.Abort();
        recieveJumpThread.Abort();
    }

}
