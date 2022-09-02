namespace MauiToolkit.Mappers;

public static class WindowHandlerMapper
{
    public static bool AttachMapper()
    {
        WindowHandler.Mapper.AppendToMapping(nameof(WindowHandlerMapper), (handler, view) =>
        {
            if (view is not Window)
                return;





        });

        WindowHandler.Mapper.ModifyMapping(nameof(WindowHandlerMapper), (handler, view, action) =>
        {
            if (view is not Window)
                return;



            action?.Invoke(handler,view);

        });

        WindowHandler.Mapper.PrependToMapping(nameof(WindowHandlerMapper), (handler, view) =>
        {
            if (view is not Window)
                return;





        });

        return true;
    }
}
