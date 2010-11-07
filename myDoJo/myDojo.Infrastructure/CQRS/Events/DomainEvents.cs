using System;
using System.Collections.Generic;
using StructureMap;


namespace myDojo.Infrastructure.CQRS
{
    public static class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> actions;

        public static IContainer Container { get {return ServiceLocation.CurrentContainer;}}

        //Registers a callback for the given domain event
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container != null)
                foreach (var handler in Container.GetAllInstances<Handles<T>>())
                    handler.Handle(args);

            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>) action)(args);
        }
    }
}