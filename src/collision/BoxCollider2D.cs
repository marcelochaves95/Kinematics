using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Kinematics.CollisionModule
{
    public class BoxCollider2D : MonoBehaviour
    {
        Rect rect1 = new Rect(5, 5, 50, 50);
        Rect rect2 = new Rect(20, 10, 10, 10);

        private void Update()
        {

            if (rect1.x < rect2.x + rect2.width &&
                rect1.x + rect1.width > rect2.x &&
                rect1.y < rect2.y + rect2.height &&
                rect1.y + rect1.height > rect2.y) {
                Debug.Log("collision detected!");
            }

// filling in the values =>

            if (5 < 30 &&
                55 > 20 &&
                5 < 20 &&
                55 > 10) {
                Debug.Log("collision detected! 2");
            }
        }
    }
}