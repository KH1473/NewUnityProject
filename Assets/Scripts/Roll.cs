using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
//public class Roll : MonoBehaviour
//{
//    private Vector3 destination;
//    private new Rigidbody rigidbody;
//    private SphereCollider sphereCollider;

//    private void Start()
//    {
//        this.rigidbody = this.GetComponent<Rigidbody>();
//        this.sphereCollider = this.GetComponent<SphereCollider>();
//        this.rigidbody.isKinematic = false; // 非キネマティックにする場合...
//        this.rigidbody.useGravity = false; // 重力を作用させなくする
//    }

//    private void Update()
//    {
//        //var plane = new Plane(Vector3.up, this.rigidbody.position);
//        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        //float rayDistance;
//        //plane.Raycast(ray, out rayDistance);
//        //if (rayDistance > 0.0f)
//        //{
//        //    this.destination = ray.GetPoint(rayDistance);
//        //}
//    }

//    private void FixedUpdate()
//    {
//        var velocity = this.rigidbody.velocity;
//        Vector3.SmoothDamp(this.rigidbody.position, this.destination, ref velocity, 1.0f, 10.0f, Time.fixedDeltaTime);
//        // 非キネマティックに変えたので、MovePositionによる位置操作の結果が自動的にrigidbody.velocityに
//        // 反映されなくなるため、更新されたvelocityをrigidbody.velocityに再代入してやる
//        // SmoothDampの返り値は破棄し、rigidbody.velocity書き換えによってのみ移動させることでつじつまを合わせる
//        this.rigidbody.velocity = velocity;

//        // 先に投稿したコードのtranslationをvelocityに置き換えると、得られる回転角は
//        // 1秒あたりの弧度法による回転量...つまり角速度の大きさとなる
//        // 回転軸も前回と同様の方法で求め、これが角速度ベクトルの向きとなる
//        // あとは求めた角速度ベクトル(向きaxis、大きさangularSpeed)を
//        // rigidbody.angularVelocityに代入すればいいはず

//        var speed = velocity.magnitude; // 速さ
//        var scaleXYZ = transform.lossyScale; // ワールド空間でのスケール推定値
//        var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z); // 各軸のうち最大のスケール
//        var angularSpeed = speed / (this.sphereCollider.radius * scale); // 角速度の大きさ
//        var axis = Vector3.Cross(Vector3.up, velocity).normalized; // 角速度の向き
//        this.rigidbody.angularVelocity = angularSpeed * axis;
//    }
//}

//[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Roll : MonoBehaviour
{
    //private Vector3 destination;
    private new Rigidbody rigidbody;
    //private SphereCollider sphereCollider;
    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        //this.sphereCollider = this.GetComponent<SphereCollider>();
        this.capsuleCollider = this.GetComponent<CapsuleCollider>();
        //this.rigidbody.isKinematic = true;
    }

    private void Update()
    {
        //// とりあえず、マウスポインタの位置を球の移動目標にする
        //var plane = new Plane(Vector3.up, this.rigidbody.position);
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //float rayDistance;
        //plane.Raycast(ray, out rayDistance);
        //if (rayDistance > 0.0f)
        //{
        //    this.destination = ray.GetPoint(rayDistance);
        //}

        var translation = this.rigidbody.velocity * Time.deltaTime; // 位置の変化量
        var distance = translation.magnitude; // 移動した距離
        var scaleXYZ = transform.lossyScale; // ワールド空間でのスケール推定値
        var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z); // 各軸のうち最大のスケール
        //var angle = distance / (this.sphereCollider.radius * scale); // 球が回転するべき量
        var angle = distance / (this.capsuleCollider.radius * scale); // 球が回転するべき量
        var axis = Vector3.Cross(Vector3.up, translation).normalized; // 球が回転するべき軸
        var deltaRotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, axis); // 現在の回転に加えるべき回転

        // 現在の回転からさらにdeltaRotationだけ回転させる
        this.rigidbody.MoveRotation(deltaRotation * this.rigidbody.rotation);
    }

    //private void FixedUpdate()
    //{
    //    var velocity = this.rigidbody.velocity;
    //    this.rigidbody.MovePosition(Vector3.SmoothDamp(this.rigidbody.position, this.destination, ref velocity, 1.0f, 1.0f, Time.fixedDeltaTime));
    //}
}