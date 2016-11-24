using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SwapAnimation : MonoBehaviour {
    public void swapAnimation(SkeletonAnimation sa, string animationName, bool loop, float timeScale) {
        sa.state.SetAnimation(0, animationName, loop);
        sa.state.TimeScale = timeScale;
    }
}
