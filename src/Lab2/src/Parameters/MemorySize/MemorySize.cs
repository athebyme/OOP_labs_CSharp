using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;

public class MemorySize
{
    public MemorySize(int memSize)
    {
        if (memSize <= 0 || memSize % 2 != 0)
        {
            throw new ParamOutOfRangeException("Memory size must be a power of two.");
        }

        MemSize = memSize;
    }

    public int MemSize { get; private set; }
}