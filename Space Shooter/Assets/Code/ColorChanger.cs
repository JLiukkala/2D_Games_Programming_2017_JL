using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Color[] AvailableColors;
    public SpriteRenderer Sprite;

    private int currentIndex = 0; 

    private void Awake()
    {
        if (Sprite == null)
        {
            Sprite = GetComponent<SpriteRenderer>();
        }
        
        // Called when the GameObject is activated for the first time. 
        Debug.Log("Awake");

        if (AvailableColors.Length == 0)
        {
            Debug.LogError("No colors available!");
        }
    }

    /// <summary>
    /// Type slash three times to get this!
    /// </summary>
    
    private void OnEnable()
    {
        // Called every time the GameObject is enabled.
        Debug.Log("OnEnable");
    }

    #region Start, Update, FixedUpdate

    void Start ()
    {
        // Called when the GameObject is enabled for the first time.
        Debug.Log("Start");
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Sprite.color = AvailableColors[currentIndex];
            currentIndex++;
            if(currentIndex >= AvailableColors.Length)
            {
                currentIndex = 0;
            }
        }
        // Update is called once per frame.
        Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        // Called every physics frame (50 times / second by default).
        Debug.Log("FixedUpdate");
    }

    #endregion 

    private void OnDisable()
    {
        // Called every time this component is disabled.
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        // Called just before the object is destroyed.
        Debug.Log("OnDestroy");
    }
}
