using MauiToolkit.Core.Builders;

namespace MauiToolkit.Core.Extensions;
public static class FilepathBuilderExtensions
{
    public static FilepathBuilder AddBasicDirectory(this FilepathBuilder builder, string basicDirectory)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.SetBasicDirectory(basicDirectory);
        return builder;
    }

    public static FilepathBuilder AddArgument(this FilepathBuilder builder, string argument)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddNodeName(argument);
        return builder;
    }
}
