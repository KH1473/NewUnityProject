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
//        this.rigidbody.isKinematic = false; // ��L�l�}�e�B�b�N�ɂ���ꍇ...
//        this.rigidbody.useGravity = false; // �d�͂���p�����Ȃ�����
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
//        // ��L�l�}�e�B�b�N�ɕς����̂ŁAMovePosition�ɂ��ʒu����̌��ʂ������I��rigidbody.velocity��
//        // ���f����Ȃ��Ȃ邽�߁A�X�V���ꂽvelocity��rigidbody.velocity�ɍđ�����Ă��
//        // SmoothDamp�̕Ԃ�l�͔j�����Arigidbody.velocity���������ɂ���Ă݈̂ړ������邱�Ƃł��܂����킹��
//        this.rigidbody.velocity = velocity;

//        // ��ɓ��e�����R�[�h��translation��velocity�ɒu��������ƁA�������]�p��
//        // 1�b������̌ʓx�@�ɂ���]��...�܂�p���x�̑傫���ƂȂ�
//        // ��]�����O��Ɠ��l�̕��@�ŋ��߁A���ꂪ�p���x�x�N�g���̌����ƂȂ�
//        // ���Ƃ͋��߂��p���x�x�N�g��(����axis�A�傫��angularSpeed)��
//        // rigidbody.angularVelocity�ɑ������΂����͂�

//        var speed = velocity.magnitude; // ����
//        var scaleXYZ = transform.lossyScale; // ���[���h��Ԃł̃X�P�[������l
//        var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z); // �e���̂����ő�̃X�P�[��
//        var angularSpeed = speed / (this.sphereCollider.radius * scale); // �p���x�̑傫��
//        var axis = Vector3.Cross(Vector3.up, velocity).normalized; // �p���x�̌���
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
        //// �Ƃ肠�����A�}�E�X�|�C���^�̈ʒu�����̈ړ��ڕW�ɂ���
        //var plane = new Plane(Vector3.up, this.rigidbody.position);
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //float rayDistance;
        //plane.Raycast(ray, out rayDistance);
        //if (rayDistance > 0.0f)
        //{
        //    this.destination = ray.GetPoint(rayDistance);
        //}

        var translation = this.rigidbody.velocity * Time.deltaTime; // �ʒu�̕ω���
        var distance = translation.magnitude; // �ړ���������
        var scaleXYZ = transform.lossyScale; // ���[���h��Ԃł̃X�P�[������l
        var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z); // �e���̂����ő�̃X�P�[��
        //var angle = distance / (this.sphereCollider.radius * scale); // ������]����ׂ���
        var angle = distance / (this.capsuleCollider.radius * scale); // ������]����ׂ���
        var axis = Vector3.Cross(Vector3.up, translation).normalized; // ������]����ׂ���
        var deltaRotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, axis); // ���݂̉�]�ɉ�����ׂ���]

        // ���݂̉�]���炳���deltaRotation������]������
        this.rigidbody.MoveRotation(deltaRotation * this.rigidbody.rotation);
    }

    //private void FixedUpdate()
    //{
    //    var velocity = this.rigidbody.velocity;
    //    this.rigidbody.MovePosition(Vector3.SmoothDamp(this.rigidbody.position, this.destination, ref velocity, 1.0f, 1.0f, Time.fixedDeltaTime));
    //}
}