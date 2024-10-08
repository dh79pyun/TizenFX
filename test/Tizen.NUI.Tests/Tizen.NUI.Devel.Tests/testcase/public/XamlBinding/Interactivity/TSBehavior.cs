﻿using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Interactivity/Behavior")]
    internal class PublicBehaviorTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        internal class MyBehavior : Behavior
        {
            public MyBehavior(Type associatedType) : base(associatedType) { }

            public void TestAttachTo(BindableObject bindable)
            {
                (this as IAttachedObject).AttachTo(bindable);
            }

            public void TestDetachFrom(BindableObject bindable)
            {
                (this as IAttachedObject).DetachFrom(bindable);
            }
        }

        internal class MyBehavior<T> : Behavior<T> where T : BindableObject
        {
            public MyBehavior(){}

            

            public void AttachedTo(BindableObject bindable)
            {
                base.OnAttachedTo(bindable);
            }

            public void DetachingFrom(BindableObject bindable)
            {
                base.OnDetachingFrom(bindable);
            }

            public Type GetAssociatedType()
            {
                return AssociatedType;
            }
        }

        [Test]
        [Category("P2")]
        [Description("Behavior Behavior ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.Behavior  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void BehaviorConstructor()
        {
            tlog.Debug(tag, $"BehaviorConstructor START");
            Assert.Throws<ArgumentNullException>(() => new MyBehavior(null));
            
            tlog.Debug(tag, $"BehaviorConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("Behavior AttachTo ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.AttachTo  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AttachTo()
        {
            tlog.Debug(tag, $"AttachTo START");
            var mb = new MyBehavior(typeof(int));
            Assert.Throws<ArgumentNullException>(() => mb.TestAttachTo(null));
            var v = new View();
            Assert.Throws<InvalidOperationException>(() => mb.TestAttachTo(v));
            tlog.Debug(tag, $"AttachTo END"); 
        }

        [Test]
        [Category("P1")]
        [Description("Behavior AttachTo ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.AttachTo  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AttachTo2()
        {
            tlog.Debug(tag, $"AttachTo2 START");
            var mb = new MyBehavior(typeof(View));
            var v = new View();
            mb.TestAttachTo(v);
            mb.TestDetachFrom(v);
            tlog.Debug(tag, $"AttachTo2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Behavior Behavior ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior<T>.Behavior  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void BehaviorConstructor2()
        {
            tlog.Debug(tag, $"BehaviorConstructor2 START");
            MyBehavior<View> mb = new MyBehavior<View>();
            Assert.IsNotNull(mb, "Should not be null");
            tlog.Debug(tag, $"BehaviorConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Behavior AssociatedType")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior.AssociatedType  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void AssociatedTypeTest()
        {
            tlog.Debug(tag, $"AssociatedTypeTest START");
            MyBehavior<View> mb = new MyBehavior<View>();
            Assert.IsNotNull(mb, "Should not be null");
            var ret = mb.GetAssociatedType();
            Assert.IsNotNull(ret, "Should not be null");
            tlog.Debug(tag, $"AssociatedTypeTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Behavior OnAttachedTo ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior<T>.OnAttachedTo  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnAttachedToTest()
        {
            tlog.Debug(tag, $"AssociatedTypeTest START");
            try
            {
                MyBehavior<View> mb = new MyBehavior<View>();
                Assert.IsNotNull(mb, "Should not be null");
                mb.AttachedTo(new View());
            }
            catch(Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"AssociatedTypeTest END");
        }

        [Test]
        [Category("P2")]
        [Description("Behavior OnAttachedTo ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior<T>.OnAttachedTo  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnAttachedToTest2()
        {
            tlog.Debug(tag, $"AssociatedTypeTest2 START");

            try
            {
                MyBehavior<View> mb = new MyBehavior<View>();
                Assert.IsNotNull(mb, "Should not be null");
                mb.AttachedTo(null);
            }
            catch(Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"AssociatedTypeTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Behavior OnDetachingFrom ")]
        [Property("SPEC", "Tizen.NUI.Binding.Behavior<T>.OnDetachingFrom  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnDetachingFromTest()
        {
            tlog.Debug(tag, $"OnDetachingFromTest START");
            try
            {
                MyBehavior<View> mb = new MyBehavior<View>();
                Assert.IsNotNull(mb, "Should not be null");
                mb.DetachingFrom(new View());
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"OnDetachingFromTest END");
        }
    }
}