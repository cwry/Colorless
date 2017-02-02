using UnityEngine;
using System.Collections;
using Spine.Unity;

public class FlipSkeleton : MonoBehaviour {
    public void flipX(SkeletonAnimation sa, bool flip){
        sa.skeleton.flipX = flip;
    }

    public void flipY(SkeletonAnimation sa, bool flip){
        sa.skeleton.flipY = flip;
    }
}
