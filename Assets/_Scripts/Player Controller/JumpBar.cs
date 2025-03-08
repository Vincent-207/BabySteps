using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBar : MonoBehaviour
{
    [SerializeField]
    RectTransform jumpBar;
    [SerializeField]
    float barHeight, maxWidth;
    [SerializeField]
    PlayerJump playerJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float jumpCharge = playerJump.getJumpCharge();
        jumpBar.sizeDelta = new Vector2(maxWidth * jumpCharge, barHeight);
    }
}
