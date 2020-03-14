using System;
using BaltaStore.Domain.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este CPF j� est� em uso");
            }

            if (_repository.CheckEmail(command.Email))
            {
                AddNotification("Email", "Este Email j� est� em uso");
            }

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", Notifications); ;
            }

            _repository.Save(customer);

            _emailService.Send(email.Address, "hello@balto.io", "Bem Vindo", "Seja bem vindo ao BaltaStore");

            return new CommandResult(true, "Bem vindo ao BaltaStore", new
            {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}