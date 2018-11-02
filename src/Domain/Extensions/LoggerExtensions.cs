using System;
using Akkatecture.Commands;
using Chessie.ErrorHandling;
using Chessie.ErrorHandling.CSharp;
using JetBrains.Annotations;
using Serilog;

namespace Correct.Storage.Domain.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogHandlingCommand([NotNull] this ILogger logger, [NotNull] ICommand command)
        {
            logger.Information("Handling command {@Command}", command);
        }

        public static void LogHandlingCommandResult<TResult>([NotNull] this ILogger logger, [NotNull] ICommand command,
            [NotNull] Result<TResult, string> commandResult)
        {
            if (commandResult == null) throw new ArgumentNullException(nameof(commandResult));
            if (commandResult.IsOk)
                logger.Information("Success handling command {@Command}", command);
            else
                logger.Error("Failed handling command {@Command}. Errors: @{CommandErrors}", command,
                    commandResult.FailedWith());
        }
    }
}