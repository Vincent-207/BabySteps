using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    RectTransform jumpBar;
    [SerializeField]
    float barHeight, maxWidth;
    [SerializeField]
    float jumpPower, jumpChargeTime, JumpCooldownTime, minJumpCharge;

    [SerializeField]
    Rigidbody playerMainBody;
    float jumpChargeAmount, lastJumpTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && validJump())
        {
            jumpChargeAmount += Time.deltaTime / jumpChargeTime;
            jumpChargeAmount = Mathf.Clamp(jumpChargeAmount, 0, 1);
            Debug.Log("Jump Charge: " + jumpChargeAmount);
            jumpBar.sizeDelta = new Vector2(maxWidth * jumpChargeAmount, barHeight);
        }
        else if(Input.GetKeyUp(KeyCode.Space) )
        {
            Debug.Log("checking jump!");
            if(jumpChargeAmount >= minJumpCharge)
            {
                Debug.Log("Jumping!");  
                playerMainBody.AddForce((playerMainBody.transform.up * jumpPower) * jumpChargeAmount, ForceMode.Impulse);   
                lastJumpTime = Time.time;
            }
            
            jumpChargeAmount = 0;

        }
    }

    bool validJump()
    {
        if( Time.time >= lastJumpTime + JumpCooldownTime)
        {
            return true;
        }

        return false;
    }
}
