using MauiToolkit.Core.Builders;

namespace MauiToolkit.Core.Extensions;
public static class FilepathBuilderExtensions
{
    public static FilepathBuilder AddArgument(this FilepathBuilder builder, string argument)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddNodeName(argument);
        return builder;
    }
}
