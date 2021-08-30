using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.TodoItems.EventHandlers
{
    /// <summary>
    /// Defines handler for <see cref="TodoItemCompletedEvent"/>.
    /// </summary>
    public class TodoItemCompletedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCompletedEvent>>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;

        /// <summary>
        /// Defines handler for <see cref="TodoItemCompletedEvent"/>.
        /// </summary>
        /// <param name="logger">Logging service.</param>
        public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Handles domain event that occurred after todoItem completes.
        /// </summary>
        /// <param name="notification">Domain event for completed TodoItem.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task Handle(DomainEventNotification<TodoItemCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}