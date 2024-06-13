using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_avatars : MonoBehaviour
{
    // Array of avatars
    public GameObject[] avatars;

    // Variable to store the feedback value
    [Range(0.0f, 1.0f)]
    private Game_manager_script GMS;
    public int index;
    public bool isMale;

    // Use this for initialization
    void Start()
    {
        // Enable the initial avatar based on the feedback value
        GMS = FindObjectOfType<Game_manager_script>();
        isMale = globalVariables.isMale;
        UpdateAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the avatar based on the feedback value
        UpdateAvatar();
    }

    // Update the active avatar based on the feedback value
    void UpdateAvatar()
    {
        // Calculate the index based on the feedback value
        index = Mathf.Min(Mathf.FloorToInt(GMS.neurofeedback * avatars.Length / 2), avatars.Length / 2 - 1);

        // Activate the selected avatar and deactivate others
        SetAvatarStates(index);
    }

    // Set the active state of avatars
    void SetAvatarStates(int activeIndex)
    {
        if (!isMale) 
        {
            activeIndex += avatars.Length / 2;
        }
        for (int i = 0; i < avatars.Length; i++)
        {
            bool isActive = (i == activeIndex);
            avatars[i].SetActive(isActive);
        }
    }
}
