﻿using UnityEngine;

using Vector3 = PhysicsEngine.MathModule.Vector3;

namespace PhysicsEngine.CollisionModule
{
    [AddComponentMenu("PhysicsEngine/CollisionModule/BoxCollider")]
    public class BoxCollider : Collider
    {
        private Vector3 _size;
        private Vector3 min;
        private Vector3 max;

        /* Unity Properties */
        public UnityEngine.Vector3 size = UnityEngine.Vector3.one;

        protected override void Start()
        {
            base.Start();

            _size = transform.localScale.ToPhysics() / 2 * size.x;
            colliders.Add(this);
            type = 1;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            min = _center - _size;
            max = _center + _size;
        }

        public override Vector3 GetSize() => _size;

        public Vector3 GetMin() => min;

        public Vector3 GetMax() => max;
    }
}