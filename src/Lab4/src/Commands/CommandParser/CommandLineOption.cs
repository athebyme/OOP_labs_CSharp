namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;

public record CommandLineOption
{
    public string? Name { get; set; }

    public string? Value { get; set; }

    public OptionType OptionType { get; set; }
}