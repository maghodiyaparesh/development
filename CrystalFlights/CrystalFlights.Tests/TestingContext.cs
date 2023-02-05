﻿using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace CrystalFlights.Tests
{
    public abstract class TestingContext<T> where T : class
    {
        private Fixture fixture;
        private Dictionary<Type, Mock> injectedMocks;
        private Dictionary<Type, object> injectedConcreteClasses;

        public virtual void Setup()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            injectedMocks = new Dictionary<Type, Mock>();
            injectedConcreteClasses = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Generates a mock for a class and injects it into the final fixture
        /// </summary>
        /// <typeparam name="TMockType"></typeparam>
        /// <returns></returns>
        public Mock<TMockType> GetMockFor<TMockType>() where TMockType : class
        {
            var existingMock = injectedMocks.FirstOrDefault(x => x.Key == typeof(TMockType));
            if (existingMock.Key == null)
            {
                var newMock = new Mock<TMockType>();
                existingMock = new KeyValuePair<Type, Mock>(typeof(TMockType), newMock);
                injectedMocks.Add(existingMock.Key, existingMock.Value);
                fixture.Inject(newMock.Object);
            }
            return existingMock.Value as Mock<TMockType>;
        }

        /// <summary>
        /// Injects a concrete class to be used when generating the fixture. 
        /// </summary>
        /// <typeparam name="ClassType"></typeparam>
        /// <returns></returns>
        public void InjectClassFor<ClassType>(ClassType injectedClass) where ClassType : class
        {
            var existingClass = injectedConcreteClasses.FirstOrDefault(x => x.Key == typeof(ClassType));
            if (existingClass.Key != null)
            {
                throw new Exception($"{injectedClass.GetType().Name} has been injected more than once");
            }
            injectedConcreteClasses.Add(typeof(ClassType), injectedClass);
            fixture.Inject(injectedClass);
        }

        public T ClassUnderTest => fixture.Create<T>();
    }
}
