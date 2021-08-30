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
    /// Defines handler for <see cref="TodoItemCreatedEvent"/>.
    /// </summary>
    public class TodoItemCreatedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
    {
        private readonly ILogger<TodoItemCreatedEventHandler> _logger;

        /// <summary>
        /// Defines handler for <see cref="TodoItemCreatedEvent"/>.
        /// </summary>
        public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Handles domain event that occurred after todoItem cretion.
        /// </summary>
        /// <param name="notification">Domain event for created TodoItem.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}