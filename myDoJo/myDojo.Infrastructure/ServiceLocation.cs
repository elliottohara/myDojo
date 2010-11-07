using System;
using StructureMap;

namespace myDojo.Infrastructure
{
    public static class ServiceLocation
    {
        private static IContainer _currentContainer;
        public static IContainer CurrentContainer
        {
            set { _currentContainer = value; }
            get
            {
                CurrentContainerMustBeSet();
                return _currentContainer;
            }
        }
        private static void CurrentContainerMustBeSet()
        {
            if(_currentContainer == null)
                throw  new ContainerNotSetException();
        }
        public class ContainerNotSetException : Exception
        {
            public override string Message
            {
                get { return "ServiceLocation.CurrentContainer is not set. "; }
            }
        }
    }
}