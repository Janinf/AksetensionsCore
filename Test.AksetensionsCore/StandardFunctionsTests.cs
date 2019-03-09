using System;
using AksetensionsCore;
using NUnit.Framework;
using Shouldly;

namespace Test.AksetensionsCore
{
    [TestFixture]
    public class StandardFunctionsTests
    {
        private object _variable;

        [Test]
        public void MapTest()
        {
            _variable = new object();
            _variable.Map(v => v.ToString()).ShouldBeOfType<string>().ShouldBe("System.Object");
        }

        [Test]
        public void MapTest_SourceNull()
        {
            _variable = null;
            Should.Throw<ArgumentNullException>(() => _variable.Map(v => v.ToString()))
                .ParamName.ShouldBe("source");
        }

        [Test]
        public void MapTest_BlockNull()
        {
            _variable = new object();
            Should.Throw<ArgumentNullException>(() => _variable.Map<object, string>(null))
                .ParamName.ShouldBe("block");
        }

        [Test]
        public void WithTest()
        {
            _variable = new object();
            _variable.With(Consume).ShouldBe(_variable);
        }

        [Test]
        public void WithTest_SourceNull()
        {
            _variable = null;
            Should.Throw<ArgumentNullException>(() => _variable.With(Consume))
                .ParamName.ShouldBe("source");
        }

        [Test]
        public void WithTest_BlockNull()
        {
            _variable = new object();
            Should.Throw<ArgumentNullException>(() => _variable.With(null))
                .ParamName.ShouldBe("block");
        }

        [Test]
        public void AlsoTest()
        {
            _variable = new object();
            _variable.Also(Consume).ShouldBe(_variable);
        }

        [Test]
        public void AlsoTest_SourceNull()
        {
            _variable = null;
            Should.Throw<ArgumentNullException>(() => _variable.Also(Consume))
                .ParamName.ShouldBe("source");
        }

        [Test]
        public void AlsoTest_BlockNull()
        {
            _variable = new object();
            Should.Throw<ArgumentNullException>(() => _variable.Also(null))
                .ParamName.ShouldBe("block");
        }

        private void Consume(object source)
        {
        }

        private void Consume()
        {
        }
    }
}