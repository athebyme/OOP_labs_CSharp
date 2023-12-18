using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;

public static class CommandArgumentsParser
{
    public static IList<CommandLineOption?> ParseOptions(string[] arguments)
    {
        if (arguments == null)
            throw new NullMethodParameterException(nameof(arguments));

        var results = new List<CommandLineOption?>();
        CommandLineOption? lastOption = null;

        foreach (string? argument in arguments)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                continue;
            }

            if (argument.StartsWith("--", StringComparison.Ordinal))
            {
                if (lastOption != null)
                {
                    results.Add(lastOption);
                }

                lastOption = new CommandLineOption
                {
                    OptionType = OptionType.LongName,
                    Name = argument[2..],
                };
            }
            else if (argument.StartsWith("-", StringComparison.Ordinal))
            {
                if (lastOption != null)
                {
                    results.Add(lastOption);
                }

                lastOption = new CommandLineOption
                {
                    OptionType = OptionType.ShortName,
                    Name = argument[1..],
                };
            }
            else if (lastOption == null)
            {
                results.Add(new CommandLineOption
                {
                    OptionType = OptionType.Symbol,
                    Name = argument,
                });
            }
            else
            {
                lastOption.Value = argument;
                results.Add(lastOption);
                lastOption = null;
            }
        }

        if (lastOption != null)
        {
            results.Add(lastOption);
        }

        return results;
    }
}