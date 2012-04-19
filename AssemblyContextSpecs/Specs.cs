using System;
using System.Collections.Generic;

using Machine.Specifications;

namespace AssemblyContextSpecs
{
  public static class DomainEvents
  {
    static readonly object @lock = new object();

    static Action<IDomainEvent> raiseEvent;

    public static void Raise<TEvent>(TEvent @event) where TEvent : class, IDomainEvent
    {
      raiseEvent(@event);
    }

    public static void RegisterEventPublisher(Action<IDomainEvent> eventPublisher)
    {
      lock (@lock)
      {
        raiseEvent = eventPublisher;
      }
    }
  }

  public interface IDomainEvent
  {
  }

  class FooEvent : IDomainEvent
  {
  }

  public class DomainEventsContext : IAssemblyContext
  {
    internal static IList<IDomainEvent> Events;

    public void OnAssemblyStart()
    {
      Events = new List<IDomainEvent>();

      DomainEvents.RegisterEventPublisher(x => Events.Add(x));
    }

    public void OnAssemblyComplete()
    {
    }
  }

  public class When_a_domain_event_is_raised_1
  {
    Because of = () => DomainEvents.Raise(new FooEvent());

    It should_capture_the_event =
      () => DomainEventsContext.Events.ShouldContain(x => x.GetType() == typeof(FooEvent));

    It should_have_at_least_one_event =
      () =>
      {
        Console.WriteLine("\r\n# of captured events: " + DomainEventsContext.Events.Count);
        DomainEventsContext.Events.Count.ShouldBeGreaterThan(0);
      };
  }

  public class When_a_domain_event_is_raised_2
  {
    Because of = () => DomainEvents.Raise(new FooEvent());

    It should_capture_the_event =
      () => DomainEventsContext.Events.ShouldContain(x => x.GetType() == typeof(FooEvent));

    It should_have_at_least_one_event =
      () =>
      {
        Console.WriteLine("\r\n# of captured events: " + DomainEventsContext.Events.Count);
        DomainEventsContext.Events.Count.ShouldBeGreaterThan(0);
      };
  }

  public class When_a_domain_event_is_raised_3
  {
    Because of = () => DomainEvents.Raise(new FooEvent());

    It should_capture_the_event =
      () => DomainEventsContext.Events.ShouldContain(x => x.GetType() == typeof(FooEvent));

    It should_have_at_least_one_event =
      () =>
      {
        Console.WriteLine("\r\n# of captured events: " + DomainEventsContext.Events.Count);
        DomainEventsContext.Events.Count.ShouldBeGreaterThan(0);
      };
  }

  public class When_a_domain_event_is_raised_4
  {
    Because of = () => DomainEvents.Raise(new FooEvent());

    It should_capture_the_event =
      () => DomainEventsContext.Events.ShouldContain(x => x.GetType() == typeof(FooEvent));

    It should_have_at_least_one_event =
      () =>
      {
        Console.WriteLine("\r\n# of captured events: " + DomainEventsContext.Events.Count);
        DomainEventsContext.Events.Count.ShouldBeGreaterThan(0);
      };
  }
}
