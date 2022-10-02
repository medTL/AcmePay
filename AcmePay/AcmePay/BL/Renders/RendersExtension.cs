namespace AcmePay.BL.Renders;

public static class RendersExtension
{
    public static IServiceCollection AddRenders(this IServiceCollection services)
    {
        return services
            .AddTransient<IPaymentRender, PaymentRender>();
    }
}