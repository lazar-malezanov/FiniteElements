﻿using Bytes2you.Validation;
using Materials.Commands.Contracts;
using Ninject;
using System;

namespace Materials.Core.Factories
{
    internal class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();

            this.kernel = kernel;
        }

        public ICommand CreateCommand(string commandName)
        {
            try
            {
                return this.kernel.Get<ICommand>(commandName.ToLower());
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}
