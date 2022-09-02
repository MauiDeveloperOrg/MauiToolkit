namespace MauiToolkit.Mappers;

public class WindowHandlerMapper
{
    public WindowHandlerMapper()
    {
        WindowHandler.Mapper.AppendToMapping(nameof(WindowHandlerMapper), (handler, view) =>
        {
            if (view is not Window)
                return;





        });
    }
}
