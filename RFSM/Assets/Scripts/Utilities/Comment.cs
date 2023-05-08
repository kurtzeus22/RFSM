using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comment : MonoBehaviour
{
    [Header("You can removed this anytime")]
    [Space]
    
    [TextArea(3, 10)]
    public string comment = "You can write your comment here";
}
