using System;
using System.Collections.Generic;
using System.Linq;

namespace EmergingBooking.Infrastructure.Cqrs.Commands
{
    internal static class InternalErrorMessages
    {
        public static readonly string ErrorObjectIsNotProvidedForFailure =
            "You attempted to create a failure result, which must have an error, but a null error object was passed to the constructor.";

        public static readonly string ErrorObjectIsProvidedForSuccess =
            "You attempted to create a success result, which cannot have an error, but a non-null error object was passed to the constructor.";
    }

    public class CommandResult
    {
        private static readonly CommandResult OkResult = new CommandResult(true, Enumerable.Empty<string>());

        public CommandResult(bool isSuccess, IEnumerable<string> errorMessages)
        {
            bool doNotExistsErrorMessage = errorMessages.Count() == 0;
            bool doExistsErrorMessage = !doNotExistsErrorMessage;

            if (isSuccess)
            {
                if (doExistsErrorMessage)
                    throw new ArgumentException(
                        InternalErrorMessages.ErrorObjectIsProvidedForSuccess,
                        nameof(errorMessages));
            }
            else
            {
                if (doNotExistsErrorMessage)
                    throw new ArgumentNullException(
                        nameof(errorMessages),
                        InternalErrorMessages.ErrorObjectIsNotProvidedForFailure);
            }

            Success = isSuccess;
            ErrorMessages = errorMessages;
        }

        public IEnumerable<string> ErrorMessages { get; }
        public bool Success { get; }
        public bool Failure => !Success;

        public static CommandResult Ok()
        {
            return OkResult;
        }

        public static CommandResult Fail(string errorMessage)
        {
            return new CommandResult(false, new List<string> { errorMessage });
        }

        public static CommandResult Fail(IEnumerable<string> errorMessages)
        {
            return new CommandResult(false, errorMessages);
        }
    }
}