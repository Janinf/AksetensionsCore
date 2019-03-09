using AksetensionsCore;
using NUnit.Framework;
using Shouldly;

namespace Test.AksetensionsCore
{
    [TestFixture]
    public class ParameterPredicatesTests
    {
        private object _parameter;
        private string _stringParameter;

        [Test]
        public void IsNullTest_IsNull()
        {
            SetParameterAsNull();
            _parameter.IsNull().ShouldBeTrue();
        }

        [Test]
        public void IsNullTest_IsNotNull()
        {
            SetParameterAsNotNull();
            _parameter.IsNull().ShouldBeFalse();
        }

        [Test]
        public void IsNotNullTest_IsNotNull()
        {
            SetParameterAsNotNull();
            _parameter.IsNotNull().ShouldBeTrue();
        }

        [Test]
        public void IsNotNullTest_IsNull()
        {
            SetParameterAsNull();
            _parameter.IsNotNull().ShouldBeFalse();
        }

        [Test]
        public void IsNullOrEmptyTest_IsNullOrEmpty()
        {
            SetStringParameterAsNull();
            _stringParameter.IsNullOrEmpty().ShouldBeTrue();
            SetStringParameterAsEmpty();
            _stringParameter.IsNullOrEmpty().ShouldBeTrue();
        }

        [Test]
        public void IsNullOrEmptyTest_IsNotNullOrEmpty()
        {
            _stringParameter = "s";
            _stringParameter.IsNullOrEmpty().ShouldBeFalse();
        }

        [Test]
        public void IsNullOrEmptyTest_IsNullOrWhitespace()
        {
            SetStringParameterAsNull();
            _stringParameter.IsNullOrWhiteSpace().ShouldBeTrue();
            SetStringParameterAsEmpty();
            _stringParameter.IsNullOrWhiteSpace().ShouldBeTrue();
            SetStringParameterAsWhitespace();
            _stringParameter.IsNullOrWhiteSpace().ShouldBeTrue();
        }

        [Test]
        public void IsNullOrEmptyTest_IsNotNullOrWhitespace()
        {
            _stringParameter = "s";
            _stringParameter.IsNullOrWhiteSpace().ShouldBeFalse();
        }

        private void SetParameterAsNull() => _parameter = null;

        private void SetParameterAsNotNull() => _parameter = new object();

        private void SetStringParameterAsNull() => _stringParameter = null;

        private void SetStringParameterAsEmpty() => _stringParameter = string.Empty;

        private void SetStringParameterAsWhitespace() => _stringParameter = "     ";
    }
}