using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WheelCont : NetworkBehaviour
{
    public WheelCollider[] WCs;
    float acc, torque, thrustTorque, turn;
    public float maxTurn;
    public GameObject[] wheels;
    Quaternion quat;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
       
        torque = 400;
        maxTurn = 35;
        
    }

    // Update is called once per frame
    void Update()
    {
        acc = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
        Drive(acc, turn);
        
       
    }

    void Drive(float Acc, float Turn)
    {
        //Acc = Mathf.Clamp(Acc, -1, 1);
        Turn = turn * maxTurn;
        thrustTorque = Acc * torque;
        for(int i = 0; i < 4; i++)
        {
            WCs[i].motorTorque = thrustTorque;
            if(i <2 )
             WCs[i].steerAngle = Turn;

            WCs[i].GetWorldPose(out pos, out quat);
           

            wheels[i].transform.position = pos;
            wheels[i].transform.rotation = quat;
        }
      
       

    }
}
