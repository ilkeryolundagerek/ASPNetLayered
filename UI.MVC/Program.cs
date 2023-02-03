using NuGet.Protocol.Plugins;
using Services;
using UI.MVC.ViewHelpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//IServiceCollection uzantısı eklendi.
builder.Services.AddBaseServices();
builder.Services.AddScoped<IPersonHelper, PersonHelper>();
var app = builder.Build();
app.AddExceptionCenter();
//app.AddRequestedInformationCheck();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //Https adreslerini zorlar. http gelen tüm talepleri sunucu taraflı https olarak zorlar bu sayede client side ataackalrının kısmen önüne geçer.
    app.UseHsts();

    //Security Headers kullanarak güvenliği arttırmak:
    //X-Frame-Options: Uygulamamızın bir pencere içerisinde çağırılmasını yönetir.
    app.Use(async (context, next) =>
        {
            //DENY: Uygulamamız her hangi bir frame/iframe içerisinde çağırılamaz.
            //SAMEORIGIN: Kendi domainimizden başka herhangi bir domainin frame/iframe içerisinde çağırmasını engeller.
            //ALLOW-FROM <URL>: Belirlenen adres üzerinden frame/ifareme yapılmasına izin verir. 
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            await next();
        });

    //X-XSS-Protection: Injection(xss/cross-site-scripting) saldırıları için eklenir. 
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("X-Xss-Protection", "1; model=block");
        await next();
    });

    //X-Content-Type-Options: MIME Type Sniffing kullanarak dosya bitlerini okuyarak tipine karar verir. Uazantısı .png olan fakat tipi text/html olan bir dosya bu mod açık kaldığı zaman upload edilebilir  fakat sniffing nedeniyle html olarak tetiklenebilir, bu olursa içerisinde zararlı bir kod varsa tetiklenir.
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
        await next();
    });

    //Content-Security-Policy: js, css, font vb dosyalar için fazladan güvenlik sağlar.
    app.Use(async (context, next) =>
    {
        string policy = "default-src 'self'; " +
        "img-src 'self' <External-Url>; " +
        "font-src 'self'; " +
        "style-src 'self' https://cdn.jsdelivr.net;" +
        "script-src 'self' https://cdnjs.cloudflare.com;";


        context.Response.Headers.Add("Content-Security-Policy", policy);
        await next();
    });

    //Referrer-Policy: Bulundurduğumuz dış bağlantıya tıklandığı zaman, nereden geldiği bilgisi üzerine eklenir. Bu yapı eklenen bilgiyi yöner.
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("Referrer-Policy", "no-referrer");
        await next();
    });
    //Feature-Policy: Client side olarak kullanılabilen özelliklerin (görüntü, ses, konum vb) yönetilmesini sağlar.
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("Feature-Policy", "camera 'none'; geolocation: 'none'; microphone: 'none'");
        await next();
    });


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
